using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

namespace WOWItemMaker
{
    class LibDBC
    {
        public static DataTable GetData(string filename)
        {
            DataTable dt = new DataTable();
            if (!File.Exists(filename))
                throw new FileNotFoundException("文件不存在。" + filename);
            //打开文件
            FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(file);
            if (br.ReadUInt32() != 0x43424457) // WDBC标志
                throw new Exception("该文件不是有效的DBC文件。");
            int rowcount, colcount, rowlen, textlen;
            rowcount = br.ReadInt32();//行数
            colcount = br.ReadInt32();//列数
            rowlen = br.ReadInt32();//行字节数
            textlen = br.ReadInt32();//文本块字节数
            for (int i = 0; i < colcount; i++)
            {
                dt.Columns.Add((i + 1).ToString(), typeof(object));
            }
            br.BaseStream.Position = br.BaseStream.Length - textlen;
            byte[] textData = br.ReadBytes(textlen);
            br.BaseStream.Position = 20;
            for (int rowindex = 0; rowindex < rowcount; rowindex++)
            {
                byte[] rowData = br.ReadBytes(rowlen);
                object[] obj_cells = new object[colcount];
                for (int colindex = 0; colindex < colcount; colindex++)
                {
                    byte[] cellData = new byte[4];
                    for (int i = 0; i < 4; i++)
                    {
                        int pos = 4 * colindex + i;
                        if (pos >= rowData.Length)
                            break;
                        cellData[i] = rowData[pos];
                    }
                    obj_cells[colindex] = bytes2int(cellData);
                }
                dt.Rows.Add(obj_cells);
            }
            file.Close();
            //处理字符字段
            Dictionary<int, string> dic_textData = new Dictionary<int, string>();
            ArrayList list_curText = new ArrayList();
            for (int i = 1; i < textData.Length; i++)
            {
                if (textData[i] != 0)
                    list_curText.Add(textData[i]);
                else
                {
                    byte[] curText = (byte[])list_curText.ToArray(typeof(byte));
                    dic_textData.Add(i - list_curText.Count, Encoding.UTF8.GetString(curText));
                    list_curText.Clear();
                }
            }
            int[] array_textcols = findTextColumns(0, dt, dic_textData);
            return dt;
        }

        public static void SaveData(string filename, DataTable dt)
        {
            //准备写入文件
            bool[] isTextCol = new bool[dt.Columns.Count];
            bool hasTextCol = false;
            Regex reg = new Regex("^(-)|()\\d+$");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    //不是整数就认为是字符
                    if (!reg.Match(dt.Rows[j][i].ToString()).Success)
                    {
                        isTextCol[i] = true;
                        hasTextCol = true;
                        break;
                    }
                }
            }
            ArrayList arr_textData = new ArrayList();//字符字节数组
            arr_textData.Add(new byte());
            if (hasTextCol)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (isTextCol[j])
                        {
                            int curPos = arr_textData.Count;
                            arr_textData.AddRange(Encoding.UTF8.GetBytes(dt.Rows[i][j].ToString()));
                            arr_textData.Add(new byte());
                            dt.Rows[i][j] = curPos;
                        }
                    }
                }
            }
            //开始写入
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(0x43424457);// WDBC标志
            bw.Write(dt.Rows.Count);//行数
            bw.Write(dt.Columns.Count);//列数
            bw.Write(4 * dt.Columns.Count);//行字节数
            bw.Write(arr_textData.Count);//文本块字节数
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    int celldata = 0;
                    try
                    {
                        celldata = int.Parse(dt.Rows[i][j].ToString());
                    }
                    catch
                    { }
                    bw.Write(celldata);
                }
            }
            bw.Write((byte[])arr_textData.ToArray(typeof(byte)));
            bw.Close();
            fs.Close();
        }

        private static byte[] int2byte(int i)
        {
            byte[] abyte0 = new byte[4];
            abyte0[0] = (byte)(0xff & i);
            abyte0[1] = (byte)((0xff00 & i) >> 8);
            abyte0[2] = (byte)((0xff0000 & i) >> 16);
            abyte0[3] = (byte)((0xff000000 & i) >> 24);
            return abyte0;
        }

        private static int bytes2int(byte[] bytes)
        {
            int ret = 0;
            ret |= (int)(bytes[0] & 0xff) << 0;
            ret |= (int)(bytes[1] & 0xff) << 8;
            ret |= (int)(bytes[2] & 0xff) << 16;
            ret |= (int)(bytes[3] & 0xff) << 24;

            return ret;
        }

        private static int[] findTextColumns(int startIndex, DataTable dt,Dictionary<int,string> dic_textData)
        {
            if (dt.Columns.Count == 0 || dic_textData.Count == 0)
                return new int[0];
            ArrayList ret = new ArrayList();
            ArrayList arr_except = new ArrayList();
            bool[] isZeroCol = new bool[dt.Columns.Count];
            for (int i = 0; i < isZeroCol.Length; i++)
            {
                isZeroCol[i] = true;
            }
            int curIndex = 1;
            for (int rowindex = 0; rowindex < dt.Columns.Count; rowindex++)
            {
                if (rowindex >= dt.Rows.Count)
                    break;
                DataRow dr = dt.Rows[rowindex];
                for (int colindex = 0; colindex < dt.Columns.Count; colindex++)
                {
                    if (dic_textData.ContainsKey(curIndex) && curIndex == int.Parse(dr[colindex].ToString()))
                    {
                        ret.Add(colindex);
                        curIndex = curIndex + 1 + Encoding.UTF8.GetBytes(dic_textData[curIndex]).Length;
                    }
                }
            }
            return (int[])ret.ToArray(typeof(int));
        }
    }
}
