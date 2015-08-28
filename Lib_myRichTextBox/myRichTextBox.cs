using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace LibRichTextBox
{
    public partial class myRichTextBox : RichTextBox
    {
        public string ColorText
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                Color color_last = Color.Black;
                for (int i = 0; i < this.Text.Length; i++)
                {
                    this.SelectionStart = i;
                    this.SelectionLength = 1;
                    if (color_last != this.SelectionColor)
                    {
                        sb.Append("|CFF");
                        sb.Append(to16(this.SelectionColor));
                        color_last = this.SelectionColor;
                    }
                    sb.Append(this.Text.Substring(i, 1));
                }
                return sb.ToString();
            }

            set
            {
                this.Clear();
                string text = value;
                Regex reg = new Regex("\\|CFF[0-9A-F]{6}", RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
                if (reg.IsMatch(text))
                {
                    int index = 0;
                    ArrayList list_keys = new ArrayList();
                    ArrayList list_values = new ArrayList();
                    while (reg.IsMatch(text, index))
                    {
                        Match m = reg.Match(text, index);
                        int i = m.Index;
                        this.Text += text.Substring(index, i - index);
                        list_keys.Add(this.Text.Length);
                        list_values.Add(toColor(m.Value.Substring(4)));
                        index = i + m.Value.Length;
                        if (!reg.IsMatch(text, index))
                        {
                            this.Text += text.Substring(index, text.Length - index);
                        }
                    }
                    for (int i = 0; i < list_keys.Count; i++)
                    {
                        int start = (int)list_keys[i];
                        int length = (list_keys.Count - 1) > i ? (int)list_keys[i + 1] - start : this.Text.Length - start;
                        this.Select(start, length);
                        this.SelectionColor = (Color)list_values[i];
                    }
                }
                else
                    this.Text = value;
            }
        }

        private string to16(Color c)
        {
            return to16(c.R) + to16(c.G) + to16(c.B);
        }

        private string to16(int i)
        {
            string r = Convert.ToString(i, 16);
            if (r.Length == 1)
                r = "0" + r;
            return r.ToUpper();
        }

        private Color toColor(string str)
        {
            Color color = Color.FromArgb(to32(str.Substring(0, 2)),to32(str.Substring(2, 2)),to32(str.Substring(4, 2)));
            return color;
        }

        private int to32(string str)
        {
            return (int)Convert.ToInt16(str, 16);
        }
    }
}
