using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string start = "1";
        public int place = 0;
        public int amount = 0;
        public const char space = ' ';
        private void button1_Click(object sender, EventArgs e)
        {
        start = textBox1.Text;
        place = Int32.Parse(textBox2.Text);
        amount = Int32.Parse(textBox3.Text);
        textBox4.Text = Changer(start,place,amount);
        }
        public string Changer(string start, int place, int amount)
        {
            while (start[0].Equals(space)) start = start.Remove(0,1);
            int curWord = 1;
            bool nowWord;
            bool wasWord = true;
            bool inside = false;
            int findex = 0;
            int lindex = 0;
            int numb = 0; 
            for (int i = 0; i < start.Length; i++)
            {
                if (start[i].Equals(space)) nowWord = false;
                else nowWord = true;
                if (!wasWord && nowWord)
                { 
                    curWord++;
                    if (inside)
                    {
                        numb++;
                    }
                }
                if (curWord==place && !inside) { findex = i;inside = true; }
                if (wasWord && inside && !nowWord && numb==amount-1 ) { lindex = i-1; break; }    //НА 1 слово больше чем надо перемещает
                wasWord = nowWord;
            }
            string change = start.Substring(findex,lindex-findex+1);
            start = start.Remove(findex, lindex - findex + 1);
            change = String.Concat(change + " " + start);
            return change;
        }

    }
}
