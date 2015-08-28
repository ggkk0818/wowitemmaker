using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace WOWItemMaker
{
    public class myRichTextBox : RichTextBox
    {
        private ArrayList list_text;
        private EventHandler handler_textchange;


        //public override myRichTextBox()
        //{
            
        //    list_text = new ArrayList();
        //    handler_textchange = new EventHandler(myRichTextBox_TextChanged);
        //    this.TextChanged += handler_textchange;
        //}

        void myRichTextBox_TextChanged(object sender, EventArgs e)
        {
            list_text.Clear();
            foreach (char c in this.Text)
            {
                list_text.Add(c.ToString());
            }
        }

        public Color SelectionColor 
        {
            set 
            {
                int start = this.SelectionStart;
                string str_color = "|CFF" + Util.to16(Convert.ToInt32(value.R)) + Util.to16(Convert.ToInt32(value.G)) + Util.to16(Convert.ToInt32(value.B));
                list_text[start] = str_color + list_text[start];
            }
        }

        public string ColorText
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (object obj in list_text)
                {
                    sb.Append(obj.ToString());
                }
                return sb.ToString();
            }
        }
    }
}
