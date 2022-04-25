using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel;
using System.Speech;
using System.Speech.Synthesis;
namespace TextEditor_Aastha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [System.ComponentModel.Browsable(false)]
        public string DocumentText { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            output.Visible = false;
            editor.Visible = false;
            timer1.Start();//to start the timer
            label1.Text = "Time:" + " " + DateTime.Now.ToLongTimeString();//to show time on editor..
            label2.Text = "Date:" + " " + DateTime.Now.ToLongDateString();//to show date on editor..
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)//to clear the document when we click on New..
        {
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)//to open an exixting .txt files..
        {
            if (richTextBox1.Visible == true)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Text Files (.txt)|*.txt";
                ofd.Title = "Open a File...";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filepath.Text = ofd.FileName;
                    System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName);
                    richTextBox1.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filepath.Text = ofd.FileName;
                    richTextBox2.Text = System.IO.File.ReadAllText(ofd.FileName);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)//to exit the application when we click on Exit..
        {
            Application.Exit();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)//to save the created document..
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.Filter = "Text Files (.txt)|*.txt";
            svf.Title = "Save a File...";
            if (svf.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(svf.FileName);
                sw.Write(richTextBox1.Text);
                sw.Close();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)//to undo the recent text
        {
            if(richTextBox1.Visible==true)
            {
                richTextBox1.Undo();
            }
            else
            {
                richTextBox2.Undo();
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)//to redo the recent text
        {
            if (richTextBox1.Visible == true)
            {
                richTextBox1.Redo();
            }
            else
            {
                richTextBox2.Redo();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)//to cut the selected text
        {
            if (richTextBox1.Visible == true)
            {
                richTextBox1.Cut();
            }
            else
            {
                richTextBox2.Cut();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)//to copy the selected text
        {
            if (richTextBox1.Visible == true)
            {
                richTextBox1.Copy();
            }
            else
            {
                richTextBox2.Copy();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)//to paste the text..
        {
            if (richTextBox1.Visible == true)
            {
                richTextBox1.Paste();
            }
            else
            {
                richTextBox2.Paste();
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)//to select all the text..
        {
            richTextBox1.SelectAll();
        }

        private void textColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog mydialog = new ColorDialog();
            if (mydialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = mydialog.Color;

            }
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog mydialog = new ColorDialog();
            if (mydialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = mydialog.Color;

            }
        }

        private void zOOMINToolStripMenuItem_Click(object sender, EventArgs e)//To Zoom in our document..
        {
            if (richTextBox1.ZoomFactor == 63)
            {
                return;
            }
            else
                richTextBox1.ZoomFactor = richTextBox1.ZoomFactor + 1;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)//To Zoom out our document..
        {
            if (richTextBox1.ZoomFactor == 1)
            {
                return;
            }
            else
                richTextBox1.ZoomFactor = richTextBox1.ZoomFactor - 1;
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)//To bold the selected text..
        {
            Font bfont = new Font(richTextBox1.Font, FontStyle.Bold);
            Font rfont = new Font(richTextBox1.Font, FontStyle.Regular);
            if (richTextBox1.SelectedText.Length == 0)
                return;
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = rfont;
            }
            else
            {
                richTextBox1.SelectionFont = bfont;
            }
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)//To Underline the selected text..
        {
            Font ufont = new Font(richTextBox1.Font, FontStyle.Underline);
            Font rfont = new Font(richTextBox1.Font, FontStyle.Regular);
            if (richTextBox1.SelectedText.Length == 0)
                return;
            if (richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = rfont;
            }
            else
            {
                richTextBox1.SelectionFont = ufont;
            }
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)//To italic the selected text..
        {
            Font ifont = new Font(richTextBox1.Font, FontStyle.Italic);
            Font I = new Font(richTextBox1.Font, FontStyle.Italic);
            Font rfont = new Font(richTextBox1.Font, FontStyle.Regular);
            if (richTextBox1.SelectedText.Length == 0)
                return;
            if (richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = rfont;
            }
            else
            {
                richTextBox1.SelectionFont = ifont;
                richTextBox1.SelectionFont = I;
            }
        }

        private void strikeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Font sfont = new Font(richTextBox1.Font, FontStyle.Strikeout);
            Font rfont = new Font(richTextBox1.Font, FontStyle.Regular);
            if (richTextBox1.SelectedText.Length == 0)
                return;
            if (richTextBox1.SelectionFont.Strikeout)
            {
                richTextBox1.SelectionFont = rfont;
            }
            else
            {
                richTextBox1.SelectionFont = sfont;
            }
        }

        private void alignLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alignRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void alignCenterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void upperCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToUpper();
        }

        private void lowerCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToLower();
        }

        private void fontsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog mydialog = new FontDialog();
            if (mydialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = mydialog.Font;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == DialogResult.OK)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //String charcount;
            this.label1.Text = "Time:" + " " + DateTime.Now.ToLongTimeString();//to make time working
            timer1.Start();
            charcount.Text = " Character Count: " + richTextBox1.TextLength.ToString();//To count no. of characters in our document which gets showed in status bar..
            zoomfactor.Text = "  ZoomFactor: " + richTextBox1.ZoomFactor.ToString() + "%";//to display the zoomfactor of our document in status bar.. 
        }
        private void charcount_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        

        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void I_Click(object sender, EventArgs e)
        {
            Font I = new Font(richTextBox1.Font, FontStyle.Italic);
            Font rfont = new Font(richTextBox1.Font, FontStyle.Regular);
            if (richTextBox1.SelectedText.Length == 0)
                return;
            if (richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = rfont;
            }
            else
            {

                richTextBox1.SelectionFont = I;
            }
        }

        private void B_Click(object sender, EventArgs e)
        {
            Font B = new Font(richTextBox1.Font, FontStyle.Bold);
            Font rfont = new Font(richTextBox1.Font, FontStyle.Regular);
            if (richTextBox1.SelectedText.Length == 0)
                return;
            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = rfont;
            }
            else
            {
                richTextBox1.SelectionFont = B;
            }
        }

        private void U_Click(object sender, EventArgs e)
        {
            Font U = new Font(richTextBox1.Font, FontStyle.Underline);
            Font rfont = new Font(richTextBox1.Font, FontStyle.Regular);
            if (richTextBox1.SelectedText.Length == 0)
                return;
            if (richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = rfont;
            }
            else
            {
                richTextBox1.SelectionFont = U;
            }
        }

        private void S_Click(object sender, EventArgs e)
        {
            Font S = new Font(richTextBox1.Font, FontStyle.Strikeout);
            Font rfont = new Font(richTextBox1.Font, FontStyle.Regular);
            if (richTextBox1.SelectedText.Length == 0)
                return;
            if (richTextBox1.SelectionFont.Strikeout)
            {
                richTextBox1.SelectionFont = rfont;
            }
            else
            {
                richTextBox1.SelectionFont = S;
            }
        }

        private void UpperC_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToUpper();
        }

        private void LowerC_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = richTextBox1.SelectedText.ToLower();
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            int fontSize = Convert.ToInt32(comboBox1.SelectedItem);
            Font font = new Font(fontFamily, fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            richTextBox1.Font = font;
        }

        SpeechSynthesizer reader = new SpeechSynthesizer();
        
        private void speakclick(object sender, EventArgs e)
        {
            panel1.BorderStyle = BorderStyle.FixedSingle;
            if(richTextBox1.Text!="")
            {
                reader.Dispose();
                reader = new SpeechSynthesizer();
                reader.SpeakAsync(richTextBox1.Text);
            }
            else
            {
                MessageBox.Show("Please Enter Some Text!!");
            }
        }

        private void pause_click(object sender, EventArgs e)
        {
            if(reader!=null)
            {
                if(reader.State==SynthesizerState.Speaking)
                {
                    reader.Pause();
                }
            }
        }

        private void stop_click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.Dispose();
            }
        }

        private void resume_click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                if (reader.State == SynthesizerState.Paused)
                {
                    reader.Resume();
                }
            }
        }
        private void speak_hover(object sender, EventArgs e)
        {
            panel1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void speak_leave(object sender, EventArgs e)
        {
            panel1.BorderStyle = BorderStyle.None;
        }

        private void pause_hover(object sender, EventArgs e)
        {
            pause.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pause_leave(object sender, EventArgs e)
        {
            pause.BorderStyle = BorderStyle.None;
        }

        private void stop_hover(object sender, EventArgs e)
        {
            panel3.BorderStyle = BorderStyle.FixedSingle;
        }

        private void stop_leave(object sender, EventArgs e)
        {
            panel3.BorderStyle = BorderStyle.None;
        }

        private void resume_hover(object sender, EventArgs e)
        {
            panel4.BorderStyle = BorderStyle.FixedSingle;
        }

        private void resume_leave(object sender, EventArgs e)
        {
            panel4.BorderStyle = BorderStyle.None;
        }

        private void bold_hover(object sender, EventArgs e)
        {
            B.ForeColor = Color.Blue;
        }

        private void bold_leave(object sender, EventArgs e)
        {
            B.ForeColor = Color.Black;
        }

        private void I_hover(object sender, EventArgs e)
        {
            I.ForeColor = Color.Blue;
        }

        private void I_leave(object sender, EventArgs e)
        {
            I.ForeColor = Color.Black;
        }

        private void U_Hover(object sender, EventArgs e)
        {
            U.ForeColor = Color.Blue;
        }

        private void U_Leave(object sender, EventArgs e)
        {

            U.ForeColor = Color.Black;
        }
        private void S_hover(object sender, EventArgs e)
        {
            S.ForeColor = Color.Blue;
        }

        private void S_Leave(object sender, EventArgs e)
        {
            S.ForeColor = Color.Black;
        }

        private void A_hover(object sender, EventArgs e)
        {
            UpperC.ForeColor = Color.Blue;
        }

        private void A_leave(object sender, EventArgs e)
        {
            UpperC.ForeColor = Color.Black;
        }

        private void a_hover(object sender, EventArgs e)
        {
            LowerC.ForeColor = Color.Blue;
        }

        private void a_leave(object sender, EventArgs e)
        {
            LowerC.ForeColor = Color.Black;
        }

        int count = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            if(count%2==0)
            {
                //light
                count = count + 1;
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
                theme.Text = "Dark";
                theme.BackColor = Color.White;
                theme.ForeColor = Color.Black;
            }
            else
            {
                //dark
                count = count + 1;
                richTextBox1.BackColor = Color.Black;
                richTextBox1.ForeColor = Color.White;
                theme.Text = "Light";
                theme.BackColor = Color.Black;
                theme.ForeColor = Color.White;
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            int start = 0;
            int end = richTextBox1.Text.LastIndexOf(textBox1.Text);
            richTextBox1.SelectAll();
            if (count % 2 == 0)
            {
                richTextBox1.SelectionBackColor = Color.Black;
            }
            else
            {
                richTextBox1.SelectionBackColor = Color.White;
            }

            //richTextBox1.Text = richTextBox1.SelectedText.Replace(textBox1.Text, replacebox.Text);
            while (start < end)
            {
                richTextBox1.Find(textBox1.Text, start, richTextBox1.TextLength, RichTextBoxFinds.MatchCase);
                if (count%2==0)
                {
                    richTextBox1.SelectionBackColor = Color.Red;

                }
                else
                {
                    richTextBox1.SelectionBackColor = Color.Green;
                }
                start = richTextBox1.Text.IndexOf(textBox1.Text, start) + 1;
            }
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        int ct = 0;
        private void Browse_Click(object sender, EventArgs e)
        {

            if (ct % 2 == 0)
            {
                filepath.Text = "";
                richTextBox1.Visible = false;
                output.Visible = true;
                editor.Visible = true;
                Browse.Text = "Text Editor";
                ct = ct + 1; ;
            }
            else
            {
                filepath.Text = "";
                richTextBox1.Visible = true;
                output.Visible = false;
                editor.Visible = false;
                Browse.Text = "HTML Editor";
                ct=ct+1;;
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (filepath.Text == "")
            {
                MessageBox.Show("Please Choose Some File!!");
            }
            else
            {
                System.IO.File.WriteAllText(filepath.Text, richTextBox2.Text);
                webBrowser1.Navigate(filepath.Text);
            }
        }

        private void replace_Click(object sender, EventArgs e)
        {
            String str = richTextBox1.Text;
            richTextBox1.Text = str.Replace(textBox1.Text, replacebox.Text);
        }

        private void filepath_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            label3.Visible = true;
        }

        private void richTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            label3.Visible = false;
        }

        private void richTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            label3.Visible = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}

