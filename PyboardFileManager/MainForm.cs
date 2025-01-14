﻿using PyboardFileManager.Properties;
using ScintillaNET;
using ScintillaNET_FindReplaceDialog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WindowsInput;

namespace PyboardFileManager
{
    public partial class frmMain : Form
    {
        private const string NEW_FILENAME = "<new>";
        private const string LBracket = "[";
        private const string RBracket = "]";
        private const string LF = "\n";
        private const string CRLF = "\r\n";

        private PyboardRoutines _PYB = null;
        private string _SessionPath = string.Empty;
        private string _EditableExtensions = string.Empty;
        private bool _FileDirty = false;
        private string _CurrentPath = "";
        private string _CurrentFile = string.Empty;

        private string _micropython_keywords = string.Empty;
        private string _micropython_modules = string.Empty;

        private FindReplace _FindReplace = null;

        public frmMain(PyboardRoutines PYB)
        {
            _PYB = PYB;

            InitializeComponent();

            this.AllowDrop = true;
        }

        #region Event Handlers

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "Pyboard File Manager (" + _PYB.COMM_PORT + ")";

            // Get the dir where we save things
            string saveDir = ConfigurationManager.AppSettings["SaveDir"];
            if (String.IsNullOrWhiteSpace(saveDir))
                saveDir = Path.GetDirectoryName(Application.ExecutablePath);

            // Where we store our files while they are being edited
            string uniqueSessions = ConfigurationManager.AppSettings["UniqueSessions"];
            string SessionRoot = Path.Combine(saveDir, "session");
            if (uniqueSessions.Trim().ToUpper().StartsWith("Y"))
                _SessionPath = Path.Combine(SessionRoot, DateTime.Now.ToString("SyyyyMMdd-HHmm"));
            else
                _SessionPath = SessionRoot;
            if (!Directory.Exists(_SessionPath))
                Directory.CreateDirectory(_SessionPath);

            // load help links
            cboHelp.Items.Clear();
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["HelpLinkCount"]);
            if (count == 0)
                cboHelp.Visible = false;
            else
            {
                int current = 1;
                while (current <= count)
                {
                    string title = ConfigurationManager.AppSettings["HelpTitle" + current.ToString()];
                    cboHelp.Items.Add(title);
                    current += 1;
                }
            }

            // Setup tooltips
            toolTip1.SetToolTip(btnREPL, "Go to the MicroPython REPL");
            toolTip1.SetToolTip(btnDelete, "Delete the selected file or directory permanently from the device");
            toolTip1.SetToolTip(btnExport, "Export the selected file from the device to your computer");
            toolTip1.SetToolTip(btnLoad, "Import an external file to the device");
            toolTip1.SetToolTip(btnMkdir, "Make a sub-directory under the current directory");
            toolTip1.SetToolTip(btnMove, "Move (rename) the selected file");
            toolTip1.SetToolTip(btnNew, "Create a new file");
            toolTip1.SetToolTip(btnOpen, "Open the selected file for editing or directory for viewing");
            toolTip1.SetToolTip(btnRefresh, "Re-read the file list for the current directory");
            toolTip1.SetToolTip(btnRun, "Run the currently selected file");
            toolTip1.SetToolTip(btnSave, "Save the current file");
            toolTip1.SetToolTip(btnSaveAs, "Save the current file to the current directory with the specified name");
            toolTip1.SetToolTip(btnFind, "Simple search for current file");
            toolTip1.SetToolTip(btnReplaceAll, "Simple search-and-replace for current file");
            toolTip1.SetToolTip(cboHelp, "Local Help Documents and Hyperlinks");
            toolTip1.SetToolTip(btnEditUndo, "Undo last edit");
            toolTip1.SetToolTip(btnEditRedo, "Redo last edit");
            toolTip1.SetToolTip(btnEditCut, "Cut currently selected text to the clipboard");
            toolTip1.SetToolTip(btnEditCopy, "Copy currently selected text to the clipboard");
            toolTip1.SetToolTip(btnEditDelete, "Delete selected text");
            toolTip1.SetToolTip(btnEditPaste, "Paste clipboard contents");
            toolTip1.SetToolTip(btnView, "View file in separate window");

            // these are the file that can be opened and edited
            _EditableExtensions = ConfigurationManager.AppSettings["EditableExtensions"];
            if (String.IsNullOrWhiteSpace(_EditableExtensions))
                _EditableExtensions = "py,txt,html,js,css,json";

            lstDirectory.BackColor = Utils.DecodeColor("ExplorerColor");
            lstDirectory.Font = new Font(ConfigurationManager.AppSettings["DirectoryFont"], Convert.ToSingle(ConfigurationManager.AppSettings["DirectoryFontSize"]), FontStyle.Regular);

            _micropython_keywords = ConfigurationManager.AppSettings["Python.Keywords"];
            string[] mk = _micropython_keywords.Split(' ');
            Array.Sort(mk);
            string smk = string.Empty;
            foreach (string k in mk)
                smk += " " + k;
            _micropython_keywords = smk.Trim();

            string modules = _PYB.pyboardModules();
            string[] mm = modules.Split(' ');
            Array.Sort(mm);
            string smm = string.Empty;
            foreach (string m in mm)
                smm += " " + m;
            _micropython_modules = smm.Trim();

            RefreshFileList();

            ResetNew();

            RestoreWindow();

            if (ConfigurationManager.AppSettings["DarkMode"].Trim().ToUpper().StartsWith("Y"))
            {
                pnlCommands.BackColor = SystemColors.ControlDark;
                pnlPath.BackColor = SystemColors.ControlDark;
                pnlPathSummary.BackColor = SystemColors.ControlDark;
                lblCurrentFile.BackColor = SystemColors.ControlDark;
                pnlFileStatus.BackColor = SystemColors.ControlDark;
                pnlEditToolbar.BackColor = SystemColors.ControlDark;
                pnlSaveMessage.BackColor = SystemColors.ControlDark;
                lstDirectory.ForeColor = Color.White;
                lstDirectory.BackColor = Color.SlateGray;
            }
            else
            {
                pnlCommands.BackColor = SystemColors.Control;
                pnlPath.BackColor = SystemColors.Control;
                pnlPathSummary.BackColor = SystemColors.Control;
                lblCurrentFile.BackColor = SystemColors.Control;
                pnlFileStatus.BackColor = SystemColors.Control;
                pnlEditToolbar.BackColor = SystemColors.Control;
                pnlSaveMessage.BackColor = SystemColors.Control;
                lstDirectory.ForeColor = Color.Black;
                lstDirectory.BackColor = Color.Moccasin;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (OKToContinue())
                ResetNew();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (OKToContinue())
                OpenItem();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string newFile = openFileDialog1.FileName;
                string newFilename = Path.GetFileName(newFile);
                string FileToAdd = (_CurrentPath == "") ? newFilename : _CurrentPath + "/" + newFilename;
                Cursor.Current = Cursors.WaitCursor;
                _PYB.PutFile(newFile, FileToAdd);
                Cursor.Current = Cursors.Default;
                RefreshFileList();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string FileToExport = "";
            string selectedItem = lstDirectory.Text;
            if (selectedItem != "")
            {
                if (!selectedItem.StartsWith(LBracket))
                {
                    FileToExport = (_CurrentPath == "") ? selectedItem : _CurrentPath + "/" + selectedItem;
                }
                else
                    MessageBox.Show("Can only export files.", "Not Supported");
            }

            if (FileToExport != "")
            {
                saveFileDialog1.FileName = selectedItem;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    _PYB.GetFile(FileToExport, saveFileDialog1.FileName);
                    Cursor.Current = Cursors.Default;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedItem = lstDirectory.Text;
            if (selectedItem != "")
            {
                if (selectedItem.StartsWith(LBracket))
                {
                    string DirToDelete = selectedItem.Replace(LBracket, "").Replace(RBracket, "");
                    if (DirToDelete != "..")
                    {
                        string FullDirToDelete = (_CurrentPath == "") ? DirToDelete : _CurrentPath + "/" + DirToDelete;
                        if (MessageBox.Show("Are you sure you want to delete the directory '" + FullDirToDelete + "' ?", "Confirm Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                        {
                            Cursor.Current = Cursors.WaitCursor;
                            _PYB.DeleteDir(FullDirToDelete);
                            Cursor.Current = Cursors.Default;
                            RefreshFileList();
                        }
                    }
                }
                else
                {
                    string FileToDelete = (_CurrentPath == "") ? selectedItem : _CurrentPath + "/" + selectedItem;
                    if (MessageBox.Show("Are you sure you want to delete '" + FileToDelete + "'?", "Confirm Delete", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        _PYB.DeleteFile(FileToDelete);
                        Cursor.Current = Cursors.Default;
                        RefreshFileList();
                    }
                }
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            string FileToMove = "";
            string selectedItem = lstDirectory.Text;
            if (selectedItem != "")
            {
                if (!selectedItem.StartsWith(LBracket))
                {
                    FileToMove = (_CurrentPath == "") ? selectedItem : _CurrentPath + "/" + selectedItem;
                }
                else
                    MessageBox.Show("Can only move files.", "Not Supported");
            }

            if (FileToMove != "")
            {
                string filename = Microsoft.VisualBasic.Interaction.InputBox("New Path and Filename:", "Move File", FileToMove);
                if (filename != "")
                {
                    if (filename.IndexOf(".") > 0)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        _PYB.MoveFile(FileToMove, filename);
                        Cursor.Current = Cursors.Default;
                        RefreshFileList();
                    }
                    else
                        MessageBox.Show("Filename must have an extension.");
                }
            }
        }

        private void btnMkdir_Click(object sender, EventArgs e)
        {
            string newdir = Microsoft.VisualBasic.Interaction.InputBox("New directory under " + lblPath.Text + ":", "Create Directory", "");
            if (newdir != "")
            {
                if (!newdir.Contains("."))
                {
                    string newdirfull = (_CurrentPath == "") ? newdir : _CurrentPath + "/" + newdir;
                    Cursor.Current = Cursors.WaitCursor;
                    _PYB.CreateDir(newdirfull);
                    Cursor.Current = Cursors.Default;
                    RefreshFileList();
                }
                else
                    MessageBox.Show("Cannot create new directory with a period in the name.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFileList();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            string selectedItem = lstDirectory.Text;
            if (selectedItem != "")
            {
                if (!selectedItem.StartsWith(LBracket))
                {
                    if (selectedItem.EndsWith(".py"))
                        if (_CurrentPath == "/" || _CurrentPath == "")
                            OpenREPL("import " + selectedItem.Replace(".py", ""));
                        else
                            OpenREPL("from " + _CurrentPath.Substring(1) + " import " + selectedItem.Replace(".py", ""));
                    else
                        MessageBox.Show("Can only run '.py' files.", "Not Supported");
                }
                else
                    MessageBox.Show("Can only run '.py' files.", "Not Supported");
            }
        }

        private void cboHelp_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current = cboHelp.SelectedIndex;
            if (current >= 0)
            {
                string link = ConfigurationManager.AppSettings["HelpLink" + (current + 1).ToString()];
                if (!link.ToLower().StartsWith("http"))
                {
                    if (link.Contains("\\"))
                        link = "file:///" + link;
                    else
                    {
                        link = "file:///" + Path.Combine(Directory.GetCurrentDirectory(), "help") + "\\" + link;
                    }
                }
                HelpForm help = new HelpForm();
                help.Text = ConfigurationManager.AppSettings["HelpTitle" + (current + 1).ToString()];
                ((WebBrowser)help.Controls["webBrowser1"]).Url = new Uri(link);
                help.Controls["webBrowser1"].Dock = DockStyle.Fill;
                help.Show();
            }
        }

        private void btnREPL_Click(object sender, EventArgs e)
        {
            OpenREPL("");
        }

        private void btnReplaceAll_Click(object sender, EventArgs e)
        {
            _FindReplace = new FindReplace(scintilla1);
            _FindReplace.ShowReplace();
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (_CurrentFile == NEW_FILENAME)
                ButtonSave();
            else
            {
                string oldFilename = _CurrentFile;
                _CurrentFile = NEW_FILENAME;
                bool saved = DoSave(oldFilename);
                if (saved)
                {
                    lblCurrentFile.Text = _CurrentFile;
                    _FileDirty = false;
                    lblCurrentFile.ForeColor = Color.Black;
                    scintilla1.EmptyUndoBuffer();
                    RefreshFileList();
                }
                else
                    _CurrentFile = oldFilename;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ButtonSave();
        }

        private void scintilla1_TextChanged(object sender, EventArgs e)
        {
            _FileDirty = true;
            lblCurrentFile.ForeColor = Color.DarkRed;
        }

        private void lstDirectory_DoubleClick(object sender, EventArgs e)
        {
            if (OKToContinue())
                OpenItem();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !OKToContinue();
            SaveWindow();
        }

        private void tmrMessage_Tick(object sender, EventArgs e)
        {
            pnlSaveMessage.Visible = false;
            tmrMessage.Enabled = false;
        }

        private void pnlFileStatus_Resize(object sender, EventArgs e)
        {
            try
            {
                pnlEditToolbar.Left = (pnlFileStatus.Width - pnlEditToolbar.Width) / 2;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnEditCut_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(scintilla1.SelectedText);
                scintilla1.ReplaceSelection("");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnEditCopy_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(scintilla1.SelectedText);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnEditPaste_Click(object sender, EventArgs e)
        {
            try
            {
                scintilla1.ReplaceSelection(Clipboard.GetText());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnEditDelete_Click(object sender, EventArgs e)
        {
            try
            {
                scintilla1.ReplaceSelection("");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnEditUndo_Click(object sender, EventArgs e)
        {
            try
            {
                scintilla1.Undo();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnEditRedo_Click(object sender, EventArgs e)
        {
            try
            {
                scintilla1.Redo();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            _FindReplace = new FindReplace(scintilla1);
            _FindReplace.ShowFind();
        }

        private void frmMain_DragDrop(object sender, DragEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                string newFilename = Path.GetFileName(file);
                string FileToAdd = (_CurrentPath == "") ? newFilename : _CurrentPath + "/" + newFilename;
                _PYB.PutFile(file, FileToAdd);
            }
            Cursor.Current = Cursors.Default;
            RefreshFileList();
        }

        private void frmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void lblCurrentFile_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            string selectedItem = lstDirectory.Text;
            if (selectedItem != "")
            {
                if ((selectedItem != LBracket + ".." + RBracket) && (selectedItem.Substring(0, 1) != LBracket))
                {
                    string ViewFile = (_CurrentPath == "") ? selectedItem : _CurrentPath + "/" + selectedItem;
                    string LocalFile = Path.Combine(_SessionPath, selectedItem);

                    Cursor.Current = Cursors.WaitCursor;
                    _PYB.GetFile(ViewFile, LocalFile);
                    Cursor.Current = Cursors.Default;

                    if (File.Exists(LocalFile))
                    {
                        if (EditableFile(LocalFile))
                        {
                            Viewer viewer = new Viewer(LocalFile);
                            if (LocalFile.ToLower().Trim().EndsWith(".html") || LocalFile.ToLower().Trim().EndsWith(".xml"))
                            {
                                ConfigureForHTML((Scintilla)viewer.Controls["scintilla1"]);
                            }
                            else if (LocalFile.ToLower().Trim().EndsWith("py"))
                            {
                                ConfigureForPython((Scintilla)viewer.Controls["scintilla1"], _micropython_keywords, _micropython_modules);
                            }
                            else
                            {
                                ConfigureForText((Scintilla)viewer.Controls["scintilla1"]);
                            }
                            viewer.Show();
                        }
                        else
                            MessageBox.Show("Not listed as an editable file type.  See the .config file to add more extensions.");
                    }
                    else
                        MessageBox.Show("Unable to retrieve file.");

                }
            }

        }

        #endregion

        #region Helper Routines

        private void RestoreWindow()
        {
            Width = Settings.Default.WindowWidth;
            Height = Settings.Default.WindowHeight;
            Top = Settings.Default.WindowTop < 0 ? 0 : Settings.Default.WindowTop;
            Left = Settings.Default.WindowLeft < 0 ? 0 : Settings.Default.WindowLeft;
            mainSplitter.SplitterDistance = Settings.Default.SplitterWidth < 25 ? 25 : Settings.Default.SplitterWidth;
        }

        private void SaveWindow()
        {
            Settings.Default.WindowHeight = Height;
            Settings.Default.WindowWidth = Width;
            Settings.Default.WindowLeft = Left;
            Settings.Default.WindowTop = Top;
            Settings.Default.SplitterWidth = mainSplitter.SplitterDistance;
            Settings.Default.Save();
        }

        private string Decode(string codedString)
        {
            string result = codedString;

            result = result.Replace("\\n", "\n");
            result = result.Replace("\\r", "\r");
            result = result.Replace("\\t", "\t");

            return result;
        }

        private void ButtonSave()
        {
            bool doRefresh = (_CurrentFile == NEW_FILENAME);
            bool saved = DoSave();
            if (saved)
            {
                _FileDirty = false;
                scintilla1.EmptyUndoBuffer();
                lblCurrentFile.ForeColor = Color.Black;
                if (doRefresh)
                    RefreshFileList();
            }
        }

        private bool EditableFile(string Filename)
        {
            bool result = false;

            string[] extensions = _EditableExtensions.ToLower().Split(',');

            string targetExtension = Path.GetExtension(Filename).ToLower();
            if (!String.IsNullOrEmpty(targetExtension))
                targetExtension = targetExtension.Substring(1);

            foreach (string extension in extensions)
            {
                if (extension == targetExtension)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        private string GetFileOnly(string Filename)
        {
            string result = Filename;
            if (result.IndexOf("/") >= 0)
            {
                int pos = result.LastIndexOf("/");
                result = result.Substring(pos + 1);
            }
            return result;
        }

        private void OpenItem()
        {
            string selectedItem = lstDirectory.Text;
            if (selectedItem != "")
            {
                if (selectedItem == LBracket + ".." + RBracket) // Go up one directory
                {
                    int lastslash = _CurrentPath.LastIndexOf("/");
                    if (lastslash == 0)
                        _CurrentPath = "";
                    else
                        _CurrentPath = _CurrentPath.Substring(0, lastslash);
                    RefreshFileList();
                }
                else if (selectedItem.Substring(0, 1) == LBracket) // Go into the directory
                {
                    _CurrentPath = _CurrentPath + "/" + selectedItem.Replace(LBracket, "").Replace(RBracket, "");
                    RefreshFileList();
                }
                else // Otherwise open the file
                {
                    _CurrentFile = (_CurrentPath == "") ? selectedItem : _CurrentPath + "/" + selectedItem;
                    string LocalFile = Path.Combine(_SessionPath, selectedItem);

                    if (EditableFile(LocalFile))
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        _PYB.GetFile(_CurrentFile, LocalFile);
                        Cursor.Current = Cursors.Default;
                        if (File.Exists(LocalFile))
                        {
                            using (StreamReader sr = new StreamReader(LocalFile))
                            {
                                string contents = sr.ReadToEnd();
                                scintilla1.Text = contents.Replace(CRLF, LF);
                            }
                            _FileDirty = false;
                            scintilla1.EmptyUndoBuffer();
                            lblCurrentFile.Text = _CurrentFile;
                            lblCurrentFile.ForeColor = Color.Black;

                            if (LocalFile.ToLower().Trim().EndsWith(".html") || LocalFile.ToLower().Trim().EndsWith(".xml"))
                            {
                                ConfigureForHTML(scintilla1);
                            } 
                            else if (LocalFile.ToLower().Trim().EndsWith("py"))
                            {
                                ConfigureForPython(scintilla1, _micropython_keywords, _micropython_modules);
                            }
                            else
                            {
                                ConfigureForText(scintilla1);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Not listed as an editable file type.  See the .config file to add more extensions.");
                }
            }
        }

        private void RefreshFileList()
        {
            lstDirectory.Items.Clear();

            if (!(_CurrentPath == "" || _CurrentPath == "/"))
                lstDirectory.Items.Add(LBracket + ".." + RBracket);

            Cursor.Current = Cursors.WaitCursor;

            List<string> dir = null;

            try
            {
                dir = _PYB.GetDir(_CurrentPath, LBracket, RBracket);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("RefreshFileList() Exception: " + ex.Message);
            }

            Cursor.Current = Cursors.Default;

            int folderCount = 0;
            int fileCount = 0;
            foreach (string entry in dir)
            {
                lstDirectory.Items.Add(entry);
                if (entry.StartsWith(LBracket) && entry.EndsWith(RBracket))
                    folderCount++;
                else
                    fileCount++;
            }
            lblFolderCount.Text = folderCount.ToString();
            lblFileCount.Text = fileCount.ToString();
            lblPath.Text = (_CurrentPath == "") ? "/ (root)" : _CurrentPath;
        }

        private bool OKToContinue()
        {
            bool result = true;

            if (_FileDirty)
            {
                DialogResult r = MessageBox.Show("File has been edited.  Do you wish to save it first?", "Confirm", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                    result = DoSave();
                else if (r == DialogResult.Cancel)
                    result = false;
            }

            return result;
        }

        private bool DoSave(string prefill = "")
        {
            bool result = false;

            if (_CurrentFile == NEW_FILENAME)
            {
                string justfile = prefill;
                if ((prefill.IndexOf('/') >= 0) && (prefill.LastIndexOf('/') < prefill.Length - 1))
                {
                    justfile = prefill.Substring(prefill.LastIndexOf('/') + 1);
                }
                string filename = Microsoft.VisualBasic.Interaction.InputBox("New Filename:", "Save File", justfile);
                if (filename != "")
                {
                    if (filename.IndexOf(".") > 0)
                    {
                        _CurrentFile = _CurrentPath + "/" + filename;
                        result = SaveItem();
                    }
                    else
                        MessageBox.Show("Filename must have an extension.");
                }
            }
            else
            {
                result = SaveItem();                
            }

            return result;
        }

        private bool SaveItem()
        {
            bool result = false;

            try
            {
                string CurrentFilename = _CurrentFile.Substring(_CurrentFile.LastIndexOf('/') + 1);

                string SaveFile = Path.Combine(_SessionPath, CurrentFilename);
                if (File.Exists(SaveFile))
                    File.Delete(SaveFile);

                string text = scintilla1.Text;
                if (text.Contains("\n"))
                    text = text.Replace("\r", "");
                else
                    text = text.Replace("\r", "\n");
                File.WriteAllText(SaveFile, text);

                Cursor.Current = Cursors.WaitCursor;
                _PYB.PutFile(SaveFile, _CurrentFile);
                Cursor.Current = Cursors.Default;

                _FileDirty = false;

                result = true;

                pnlSaveMessage.Top = (scintilla1.Height - pnlSaveMessage.Height) / 2;
                pnlSaveMessage.Left = (scintilla1.Width - pnlSaveMessage.Width) / 2;
                pnlSaveMessage.Visible = true;
                tmrMessage.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Failed");
            }

            return result;
        }

        private void ResetNew()
        {
            scintilla1.Text = "";
            
            _CurrentFile = NEW_FILENAME;
            _FileDirty = false;
            lblCurrentFile.Text = _CurrentFile;
            lblCurrentFile.ForeColor = Color.Black;

            ConfigureForPython(scintilla1, _micropython_keywords, _micropython_modules);
        }

        private void OpenREPL(string cmd)
        {
            if (ConfigurationManager.AppSettings["REPL"] == "E")
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                p.StartInfo.FileName = ConfigurationManager.AppSettings["TerminalApp"];
                string terminalAppArgs = ConfigurationManager.AppSettings["TerminalAppArgs"];
                p.StartInfo.Arguments = terminalAppArgs.Replace("{PORT}", _PYB.COMM_PORT).Replace("{PORTNUM}", Convert.ToInt16(_PYB.COMM_PORT.Replace("COM", "")).ToString());
                p.Start();
                
                string terminalAppTitle = ConfigurationManager.AppSettings["TerminalAppTitle"];
                string title = GetCaptionOfActiveWindow();
                while (!title.Contains(terminalAppTitle))
                {
                    Application.DoEvents();
                    title = GetCaptionOfActiveWindow();
                }

                InputSimulator inputSimulator = new InputSimulator();
                KeyboardSimulator keySimulator = new KeyboardSimulator(inputSimulator);
                keySimulator.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                if (!String.IsNullOrEmpty(cmd))
                {
                    keySimulator.TextEntry(cmd);
                    keySimulator.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);
                }                  

                p.WaitForExit();
            }
            //else if (ConfigurationManager.AppSettings["REPL"] == "R")
            //{
            //    RebexForm replForm = new RebexForm(_PYB.COMM_PORT, _PYB.BAUD_RATE, cmd);
            //    if (replForm.ShowDialog() == DialogResult.Yes)
            //    {
            //        RebexForm replForm2 = new RebexForm(_PYB.COMM_PORT, _PYB.BAUD_RATE, cmd);
            //        replForm2.ShowDialog();
            //    }                
            //}
            else
            {
                scintilla1.Focus();
                TerminalForm terminal = new TerminalForm(_PYB.COMM_PORT, _PYB.BAUD_RATE, cmd, _PYB.DTR_ENABLED);
                terminal.ShowDialog();
            }
        }

        private void ConfigureForText(Scintilla scintilla)
        {
            // Reset the styles
            scintilla.StyleResetDefault();
            string EditorFont = ConfigurationManager.AppSettings["EditorFont"];
            if (!String.IsNullOrEmpty(EditorFont))
                scintilla.Styles[Style.Default].Font = EditorFont;
            else
                scintilla.Styles[Style.Default].Font = "Consolas";
            string EditorFontSize = ConfigurationManager.AppSettings["EditorFontSize"];
            if (!String.IsNullOrEmpty(EditorFontSize))
                scintilla.Styles[Style.Default].Size = Convert.ToInt32(EditorFontSize);
            else
                scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll(); // i.e. Apply to all

            // Set the lexer
            scintilla.Lexer = Lexer.Null;

            // Some properties we like
            scintilla.SetProperty("tab.timmy.whinge.level", "1");
            scintilla.SetProperty("fold", "1");

            scintilla1.Margins[0].Width = 35;
            scintilla1.Margins[0].Type = MarginType.Number;

            // Use margin 2 for fold markers
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 30;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Style the folder markers
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.Folder].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderEnd].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);
        }

        private void ConfigureForHTML(Scintilla scintilla)
        {
            // Reset the styles
            scintilla.StyleResetDefault();
            scintilla.Styles[Style.Default].Font = "Consolas";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();

            // Set the XML Lexer
            scintilla.Lexer = Lexer.Xml;

            // Show line numbers
            scintilla.Margins[0].Width = 20;

            // Enable folding
            scintilla.SetProperty("fold", "1");
            scintilla.SetProperty("fold.compact", "1");
            scintilla.SetProperty("fold.html", "1");

            // Use Margin 2 for fold markers
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 20;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Style the folder markers
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.Folder].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderEnd].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change;

            // Set the Styles
            scintilla.StyleResetDefault();
            // I like fixed font for XML
            scintilla.Styles[Style.Default].Font = "Courier";
            scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll();
            scintilla.Styles[Style.Xml.Attribute].ForeColor = Color.Red;
            scintilla.Styles[Style.Xml.Entity].ForeColor = Color.Red;
            scintilla.Styles[Style.Xml.Comment].ForeColor = Color.Green;
            scintilla.Styles[Style.Xml.Tag].ForeColor = Color.Blue;
            scintilla.Styles[Style.Xml.TagEnd].ForeColor = Color.Blue;
            scintilla.Styles[Style.Xml.DoubleString].ForeColor = Color.DeepPink;
            scintilla.Styles[Style.Xml.SingleString].ForeColor = Color.DeepPink;
        }

        private void ConfigureForPython(Scintilla scintilla, string keywords, string modules)
        {
            // Reset the styles
            scintilla.StyleResetDefault();
            string EditorFont = ConfigurationManager.AppSettings["EditorFont"];
            if (!String.IsNullOrEmpty(EditorFont))
                scintilla.Styles[Style.Default].Font = EditorFont;
            else
                scintilla.Styles[Style.Default].Font = "Consolas";
            string EditorFontSize = ConfigurationManager.AppSettings["EditorFontSize"];
            if (!String.IsNullOrEmpty(EditorFontSize))
                scintilla.Styles[Style.Default].Size = Convert.ToInt32(EditorFontSize);
            else
                scintilla.Styles[Style.Default].Size = 10;
            scintilla.StyleClearAll(); // i.e. Apply to all

            // Set the lexer
            scintilla.Lexer = Lexer.Python;

            // Known lexer properties:
            // "tab.timmy.whinge.level",
            // "lexer.python.literals.binary",
            // "lexer.python.strings.u",
            // "lexer.python.strings.b",
            // "lexer.python.strings.over.newline",
            // "lexer.python.keywords2.no.sub.identifiers",
            // "fold.quotes.python",
            // "fold.compact",
            // "fold"

            // Some properties we like
            scintilla.SetProperty("tab.timmy.whinge.level", "1");
            scintilla.SetProperty("fold", "1");

            scintilla1.Margins[0].Width = 35;
            scintilla1.Margins[0].Type = MarginType.Number;

            // Use margin 2 for fold markers
            scintilla.Margins[2].Type = MarginType.Symbol;
            scintilla.Margins[2].Mask = Marker.MaskFolders;
            scintilla.Margins[2].Sensitive = true;
            scintilla.Margins[2].Width = 30;

            // Reset folder markers
            for (int i = Marker.FolderEnd; i <= Marker.FolderOpen; i++)
            {
                scintilla.Markers[i].SetForeColor(SystemColors.ControlLightLight);
                scintilla.Markers[i].SetBackColor(SystemColors.ControlDark);
            }

            // Style the folder markers
            scintilla.Markers[Marker.Folder].Symbol = MarkerSymbol.BoxPlus;
            scintilla.Markers[Marker.Folder].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderOpen].Symbol = MarkerSymbol.BoxMinus;
            scintilla.Markers[Marker.FolderEnd].Symbol = MarkerSymbol.BoxPlusConnected;
            scintilla.Markers[Marker.FolderEnd].SetBackColor(SystemColors.ControlText);
            scintilla.Markers[Marker.FolderMidTail].Symbol = MarkerSymbol.TCorner;
            scintilla.Markers[Marker.FolderOpenMid].Symbol = MarkerSymbol.BoxMinusConnected;
            scintilla.Markers[Marker.FolderSub].Symbol = MarkerSymbol.VLine;
            scintilla.Markers[Marker.FolderTail].Symbol = MarkerSymbol.LCorner;

            // Enable automatic folding
            scintilla.AutomaticFold = (AutomaticFold.Show | AutomaticFold.Click | AutomaticFold.Change);

            // Set the styles
            scintilla.Styles[Style.Python.Default].ForeColor = Utils.DecodeColor("Python.Default.ForeColor");
            scintilla.Styles[Style.Python.CommentLine].ForeColor = Utils.DecodeColor("Python.CommentLine.ForeColor");
            scintilla.Styles[Style.Python.CommentLine].Italic = Utils.DecodeBoolean("Python.CommentLine.Italic");
            scintilla.Styles[Style.Python.Number].ForeColor = Utils.DecodeColor("Python.Number.ForeColor");
            scintilla.Styles[Style.Python.String].ForeColor = Utils.DecodeColor("Python.String.ForeColor");
            scintilla.Styles[Style.Python.Character].ForeColor = Utils.DecodeColor("Python.Character.ForeColor");
            scintilla.Styles[Style.Python.Word].ForeColor = Utils.DecodeColor("Python.Word.ForeColor");
            scintilla.Styles[Style.Python.Word].Bold = Utils.DecodeBoolean("Python.Word.Bold");
            scintilla.Styles[Style.Python.Triple].ForeColor = Utils.DecodeColor("Python.Triple.ForeColor");
            scintilla.Styles[Style.Python.TripleDouble].ForeColor = Utils.DecodeColor("Python.TripleDouble.ForeColor");
            scintilla.Styles[Style.Python.ClassName].ForeColor = Utils.DecodeColor("Python.ClassName.ForeColor");
            scintilla.Styles[Style.Python.ClassName].Bold = Utils.DecodeBoolean("Python.ClassName.Bold");
            scintilla.Styles[Style.Python.DefName].ForeColor = Utils.DecodeColor("Python.DefName.ForeColor");
            scintilla.Styles[Style.Python.DefName].Bold = Utils.DecodeBoolean("Python.DefName.Bold");
            scintilla.Styles[Style.Python.Operator].Bold = Utils.DecodeBoolean("Python.Operator.Bold");
            scintilla.Styles[Style.Python.Identifier].ForeColor = Utils.DecodeColor("Python.Identifier.ForeColor");
            scintilla.Styles[Style.Python.CommentBlock].ForeColor = Utils.DecodeColor("Python.CommentBlock.ForeColor");
            scintilla.Styles[Style.Python.CommentBlock].Italic = Utils.DecodeBoolean("Python.CommentBlock.Italic");
            scintilla.Styles[Style.Python.StringEol].ForeColor = Utils.DecodeColor("Python.StringEol.ForeColor");
            scintilla.Styles[Style.Python.StringEol].BackColor = Utils.DecodeColor("Python.StringEol.BackColor");
            scintilla.Styles[Style.Python.StringEol].Bold = Utils.DecodeBoolean("Python.StringEol.Bold");
            scintilla.Styles[Style.Python.StringEol].FillLine = Utils.DecodeBoolean("Python.StringEol.FillLine");
            scintilla.Styles[Style.Python.Word2].ForeColor = Utils.DecodeColor("Python.Word2.ForeColor");
            scintilla.Styles[Style.Python.Decorator].ForeColor = Utils.DecodeColor("Python.Decorator.ForeColor");

            // Important for Python
            scintilla.ViewWhitespace = WhitespaceMode.VisibleAlways;

            // Keyword lists:
            // 0 "Keywords",
            // 1 "Highlighted identifiers"

            scintilla.SetKeywords(0, keywords);
            scintilla.SetKeywords(1, modules);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        private string GetCaptionOfActiveWindow()
        {
            var strTitle = string.Empty;
            var handle = GetForegroundWindow();
            // Obtain the length of the text   
            var intLength = GetWindowTextLength(handle) + 1;
            var stringBuilder = new StringBuilder(intLength);
            if (GetWindowText(handle, stringBuilder, intLength) > 0)
            {
                strTitle = stringBuilder.ToString();
            }
            return strTitle;
        }

        #endregion

        private void scintilla1_Click(object sender, EventArgs e)
        {

        }
    }
}
