using System;
using System.IO;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        String filename;
        bool saved;
        public Form1()
        {
            InitializeComponent();
            filename = "Untitled";
            saved = false;
           
           
        }

        private void heloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("helo");
        }

        private void newCtrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFile.Text = string.Empty;
            this.Text = "Untitled - Notepad";
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFile.Undo();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void asdasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (asdasToolStripMenuItem.Checked)
            {
                asdasToolStripMenuItem.Checked = false;
                txtFile.WordWrap = false;
            }
            else {
                asdasToolStripMenuItem.Checked = true;
                txtFile.WordWrap = true;
            }
        }

        private void openCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = filename + "- Notepad";
        }
       
        void readFile() {
            using (FileStream f = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(f))
                {
                    txtFile.Text = sr.ReadToEnd();
                }
            }
        }

        void openFile() {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FileName = "*.txt";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                this.Text = filename + "- Notepad";
                readFile();
            }
        }

        void saveFile() {
            using (FileStream f= new FileStream(filename,FileMode.Create,FileAccess.Write)) {
                using (StreamWriter st = new StreamWriter(f)) {
                        st.Write(txtFile.Text);
                        saved = true;
                    
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (filename.Equals("Untitled"))
            {
                saveFileDialog1.DefaultExt = ".txt";
                saveFileDialog1.FileName = "*.txt";
                
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    filename = saveFileDialog1.FileName;
                    this.Text = filename + "- Notepad";
                    saveFile();
                }

            }
            else {
                this.Text = filename + "- Notepad";
                saveFile();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK) {
                filename = saveFileDialog1.FileName;
                this.Text = filename + "- Notepad";
                saveFile();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            pageSetupDialog1.ShowDialog();
        }

        private void printCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
            printDocument1.DocumentName = filename;
            printDocument1.Print();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFile.Cut();
        }

        private void copyCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFile.Copy();
        }

        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFile.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFile.Text = txtFile.Text.Remove(txtFile.SelectionStart, txtFile.SelectionLength);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void selectAllCtrlAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFile.SelectAll();
        }

        private void timeDateF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFile.Text = txtFile.Text.Insert(txtFile.SelectionStart, DateTime.Now.ToString());
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            txtFile.Font = fontDialog1.Font;
        }

        private void aboutNotepadToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void txtFile_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            
            String[] files = (String[])e.Data.GetData(DataFormats.FileDrop, false);
            filename = files[0];
            readFile();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop,false) == true) {
                e.Effect = DragDropEffects.All;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.N)
            {
                txtFile.Text = string.Empty;
                this.Text = "Untitled" + " - Notepad";
            }
            else if (e.Control && e.KeyCode == Keys.O)
            {
                openFile();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                if (filename.Equals("Untitled"))
                {
                    saveFileDialog1.DefaultExt = ".txt";
                    saveFileDialog1.FileName = "*.txt";

                    DialogResult dr = saveFileDialog1.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        filename = saveFileDialog1.FileName;
                        this.Text = filename + "- Notepad";
                        saveFile();
                    }

                }
                else
                {
                    this.Text = filename + "- Notepad";
                    saveFile();
                }

            } else if (e.Control && e.KeyCode == Keys.P) {
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
                printDocument1.DocumentName = filename;
                printDocument1.Print();

            } else if (e.Control && e.KeyCode == Keys.Z) {
                txtFile.Undo();
            } else if (e.Control && e.KeyCode == Keys.X) {
                txtFile.Cut();
            } else if (e.Control && e.KeyCode == Keys.V) {
                txtFile.Paste();
            } else if (e.Control && e.KeyCode == Keys.C) {
                txtFile.Copy();
            } else if (e.KeyCode == Keys.Delete) {
                txtFile.Text = txtFile.Text.Remove(txtFile.SelectionStart, txtFile.SelectionLength);
            } else if (e.Control && e.KeyCode == Keys.A){
                txtFile.SelectAll();
            } else if (e.KeyCode == Keys.F5) {
                txtFile.Text = txtFile.Text.Insert(txtFile.SelectionStart,DateTime.Now.ToString());
            }
            //MessageBox.Show("hi");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved && filename != "Untitled") {
                DialogResult dr =  MessageBox.Show("Do you want to save changes to "+filename,"Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    saveFile();
                }
                else if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if(dr == DialogResult.No){
                    e.Cancel = false;
                }
            }
        }
    }
}
