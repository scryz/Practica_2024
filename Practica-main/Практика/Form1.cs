using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Практика
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }



        private void Загрузить_Click(object sender, EventArgs e)
        {
            String line4 = textBox4.Text;
            Regex tb4 = new Regex(@"[0-9]{2}[.][0-9]{2}[.][0-9]{2}");
            MatchCollection match4  = tb4.Matches(line4);
            if (match4.Count == 1)
            {
                textBox4.Text = match4[0].Value;

                String line3 = textBox3.Text;
                Regex tb3 = new Regex(@"([А-Я][а-я]+)|[а-я]+");
                MatchCollection match3 = tb3.Matches(line3);
                if (match3.Count >= 1)
                {

                    textBox3.Text = match3[0].Value;

                    String lineCB1 = comboBox1.Text;
                    Regex tbCB1 = new Regex("Договор|Бюджет");
                    MatchCollection matchCB1 = tbCB1.Matches(lineCB1);
                    if (matchCB1.Count == 1)
                    {

                        comboBox1.Text = matchCB1[0].Value;


                        String line1 = textBox1.Text;
                        Regex tb1 = new Regex(@"[А-Я][а-я]+\s[А-Я][а-я]+\s[А-Я][а-я]+");
                        MatchCollection match1 = tb1.Matches(line1);
                        if (match1.Count >= 1)
                        {

                            textBox1.Text = match1[0].Value;


                            String lineCB2 = comboBox2.Text;
                            Regex tbCB2 = new Regex(@"Да|Нет");
                            MatchCollection matchCB2 = tbCB2.Matches(lineCB2);
                            if (matchCB2.Count == 1)
                            {
                                comboBox2.Text = matchCB2[0].Value;


                                String line8 = textBox8.Text;
                                Regex tb8 = new Regex(@"\d+");
                                MatchCollection match8 = tb8.Matches(line8);
                                if (match8.Count == 1)
                                {
                                    textBox8.Text = match8[0].Value;


                                    if (textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox2.Text != "" && textBox8.Text != "")
                                    {
                                        
                                        ListViewItem item = new ListViewItem(textBox5.Text);
                                        item.SubItems.Add(textBox4.Text);
                                        item.SubItems.Add(textBox3.Text);
                                        item.SubItems.Add(comboBox1.Text);
                                        item.SubItems.Add(textBox1.Text);
                                        item.SubItems.Add(dateTimePicker2.Text);
                                        item.SubItems.Add(comboBox2.Text);
                                        item.SubItems.Add(textBox8.Text);
                                        listView1.Items.Add(item);
                                    }
                                    else
                                    {
                                        listBox1.Items.Add("Вы пропустили поле!");
                                    }
                                    textBox1.Clear();
                                    textBox3.Clear();
                                    textBox4.Clear();
                                    textBox5.Clear();
                                    textBox8.Clear();
                                    comboBox1.Items.Clear();
                                    comboBox2.Items.Clear();


                                }

                                else
                                {
                                    listBox1.Items.Add("Введите корректное коллимчество баллов по ЕГЭ");
                                }
                            }
                            else
                            {
                                listBox1.Items.Add("Введите корректный пункт наличия документов");
                            }
                        }
                        else
                        {
                            listBox1.Items.Add("Введите корректное ФИО");
                        }
                    }
                    else
                    {
                        listBox1.Items.Add("Введите корректную форму обучения");
                    }
                }
                else
                {
                    listBox1.Items.Add("Введите корректное название специальности");
                }
            }
            else
            {
                listBox1.Items.Add("Введите корректный номер специальности");
            }


        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(File.ReadAllLines("Данные.txt"));

        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Text = listBox2.Text;
        }


        private void textBox8_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox8, "Введите количество баллов по ЕГЭ абитуриента");
        }

        private void comboBox2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(comboBox2, "Введите наличие оригинала документов абитуриента");
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Введите Фамилию, Имя, Отчество абитуриента");
        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(comboBox1, "Введите форму обучения (Бюджет/Договор)");
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox3, "Введите название выбранной абитуриентом спецмальности");
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox4, "Введите номер выбранной абитуриентом специальности");
        }

        private void textBox5_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox5, "Выберите из списка факультет");
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button9, "Нажмите, для загрузки списка факультетов");
        }

        private void Загрузить_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Загрузить, "Нажмите, для загрузки данных абитуриента");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text documents (.txt)|*.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter w = new StreamWriter(save.FileName);

                foreach (ListViewItem item in listView1.Items)
                {
                    string line = item.Text;

                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems.Cast<ListViewItem.ListViewSubItem>().Skip(1))
                    {
                        line += ", " + subItem.Text;
                    }

                    w.WriteLine(line);
                }

                w.Close();
            }
        }

        private void button11_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button11, "Нажмите, для сохранения данных о абитуриенте");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Текстовые документы (.txt)|*.txt";

            if (open.ShowDialog() == DialogResult.OK)
            {
                StreamReader r = new StreamReader(open.FileName);
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    string[] subItems = line.Split(',');
                    ListViewItem item = new ListViewItem(subItems[0]);
                    for (int i = 1; i < subItems.Length; i++)
                    {
                        item.SubItems.Add(subItems[i]);
                    }
                    listView1.Items.Add(item);
                }
                r.Close();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text documents (.txt)|*.txt";

            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter w = new StreamWriter(save.FileName);

                foreach (ListViewItem item in listView1.Items)
                {
                    string line = item.Text;

                    foreach (ListViewItem.ListViewSubItem subItem in item.SubItems.Cast<ListViewItem.ListViewSubItem>().Skip(1))
                    {
                        line += ", " + subItem.Text;
                    }

                    w.WriteLine(line);
                }

                w.Close();
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void listBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(listBox1, "Нажмите дважды на строку, для её удаления");
        }



        private void dateTimePicker2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(dateTimePicker2, "Выберите дату подачи заявления абитуриентом");
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.exe");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, "help.exe");
            }
        }

        private void listBox1_MouseDoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            else
                MessageBox.Show("выберите элемент");
        }
    }
}
