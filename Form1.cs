using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            try{place = Int32.Parse(textBox2.Text);}
            catch{textBox4.Text= "Ошибка! Неверно указано с какого слова начать."; return; }
            try { amount = Int32.Parse(textBox3.Text); }
            catch { textBox4.Text = "Ошибка! Неверно указано количество перемещаемых слов."; return; }
        textBox4.Text = Changer(start,place,amount);
        }

        public string Changer(string start, int place, int amount)
        {
            var words = Regex.Matches(start, @"\w+").Cast<Match>().Select(m => m.Value);
            List<string> wrds = new List<string> { };
            foreach (var w in words) wrds.Add(w);
            if (0 == wrds.Count) return "Ошибка! Введена строка без слов.";
            if (1 == wrds.Count&&amount==1&&place==1) return start;
            if (place < 1 || place > wrds.Count) return String.Format("Ошибка! Неверно указано с какого слова начать. Подходящие значения - от 1 до {0}", wrds.Count);
            if (amount < 1 || amount > wrds.Count - place + 1) return String.Format("Ошибка! Неверно указано количество перемещаемых слов.");            
            if (amount == wrds.Count||place==1) return start;
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
                if (wasWord && inside && !nowWord && numb==amount-1 ) { lindex = i-1; break; }  
                wasWord = nowWord;
            }
            if (lindex == 0) lindex = start.Length - 1;
            string change = start.Substring(findex,lindex-findex+1);
            start = start.Remove(findex, lindex - findex + 1);
            change = String.Concat(change + " " + start);
            return change;
        }

    }
}
