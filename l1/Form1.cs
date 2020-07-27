using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace l1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.SelectionFont = fontDialog1.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            richTextBox1.SelectionColor = colorDialog1.Color;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Файлы RTF|*.rtf";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Файл RTF|*.rtf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName.Length > 0)
                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTotalRows.Text = "Строк: " + richTextBox1.Lines.Length.ToString();
            labelCurrentRow.Text = "Текущая строка: " + (richTextBox1.GetLineFromCharIndex(richTextBox1.SelectionStart) + 1).ToString();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = !richTextBox1.WordWrap;
            wordWrapToolStripMenuItem.Checked = !wordWrapToolStripMenuItem.Checked;
        }

        private void markersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = !richTextBox1.SelectionBullet;
            markersToolStripMenuItem.Checked = !markersToolStripMenuItem.Checked;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionIndent = (int)numericUpDown1.Value;
            richTextBox1.Update();
        }
    }
}
