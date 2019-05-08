using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using System.Diagnostics;
//using Application = System.Windows.Forms.Application;
//using Spire.Doc;

namespace Sandogh_TG
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        string FilePath = Application.StartupPath + @"\Report\GharardadSandogh";
        private void btnlettergen_Click(object sender, EventArgs e)
        {
            btnlettergen.Enabled = false;
            //  create offer letter
            try
            {
                //FilePath = Application.StartupPath + @"\Report\GharardadSandogh";
                //  Just to kill WINWORD.EXE if it is running
                KillProcess("winword");
                //  copy letter format to temp.doc
                File.Copy(FilePath + @"\GharardadeSandogh_Org.doc", FilePath + @"\GharardadeSandogh_Temp.doc", true);
                //File.Copy(@"D:\Kamal Projects\Sandogh\Sandogh TG N1\Sandogh_TG_N1_V1\Sandogh_TG\bin\Debug\Report\GharardadeSandogh.docx", "c:\\temp.docx", true);
                //File.Copy("D:\\GharardadeSandogh.docx", "D:\\temp.doc", true);
                //  create missing object
                object missing = Missing.Value;
                //  create Word application object
                Word.Application wordApp = new Word.Application();
                //  create Word document object
                Word.Document aDoc = null;
                //  create & define filename object with temp.doc
                object filename = FilePath + @"\GharardadeSandogh_Temp.doc";
                //  if temp.doc available
                if (File.Exists((string)filename))
                {
                    object readOnly = false;
                    object isVisible = false;
                    //  make visible Word application
                    wordApp.Visible = false;
                    //  open Word document named temp.doc
                    aDoc = wordApp.Documents.Open(ref filename, ref missing,
                                                  ref readOnly, ref missing, ref missing, ref missing,
                                                  ref missing, ref missing, ref missing, ref missing,
                                                  ref missing, ref isVisible, ref missing, ref missing,
                                                  ref missing, ref missing);
                    aDoc.Activate();
                    //  Call FindAndReplace()function for each change
                    this.FindAndReplace(wordApp, "<Date>", dtpDate.Text);
                    this.FindAndReplace(wordApp, "<Name>", txName.Text.Trim());
                    this.FindAndReplace(wordApp, "<Subject>",
                txtSubject.Text.Trim());
                    //  save temp.doc after modified
                    aDoc.Save();
                    KillProcess("winword");

                }
                else
                    MessageBox.Show("فایل  موقت GharardadeSandogh_Temp یافت نشد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("عملیات با خطا مواجه شد", "پیغام خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnlettergen.Enabled = true;
            simpleButton1_Click(null, null);
        }

        private void FindAndReplace(Word.Application wordApp,
            object findText, object replaceText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            wordApp.Selection.Find.Execute(ref findText, ref matchCase,
                ref matchWholeWord, ref matchWildCards, ref matchSoundsLike,
                ref matchAllWordForms, ref forward, ref wrap, ref format,
                ref replaceText, ref replace, ref matchKashida,
                        ref matchDiacritics,
                ref matchAlefHamza, ref matchControl);
        }

        public static void KillProcess(string name)
        {
            Process[] pr = Process.GetProcessesByName(name);

            foreach (Process prs in pr)
            {
                if (prs.ProcessName.ToLower() == name)
                {
                    prs.Kill();
                }
            }
        }

        private void XtraForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                foreach (var file in Directory.GetFiles(FilePath, "*.tmp", SearchOption.AllDirectories))
                {
                    File.Delete(file);
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //Document doc = new Document();
            //doc.LoadFromFile(FilePath + @"\GharardadeSandogh_Org.doc",FileFormat.Doc);
            try
            {
                Word.Application ap = new Word.Application();
                ap.Visible = true;
                object miss = Missing.Value;
                object path = FilePath + @"\GharardadeSandogh_Temp.doc";
                object readOnly = false;
                object isVisible = true;
                Word.Document doc = new Word.Document();
                doc = ap.Documents.Open(ref path, ref miss, ref readOnly, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref isVisible, ref miss, ref miss, ref miss, ref miss);
                doc.Activate();
                //Word.Application ap = new Word.Application();
                //Word.Document document = ap.Documents.Open(FilePath + @"\GharardadeSandogh_Temp.doc",);

            }
            catch //(Exception)
            {
                //doc.Application.Quit(ref missing, ref missing, ref missing);
                //throw;
            }
        }
    }
}