﻿namespace PyboardFileManager
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlToolbar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnREPL = new System.Windows.Forms.Button();
            this.cboHelp = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnMkdir = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.mainSplitter = new System.Windows.Forms.SplitContainer();
            this.lstDirectory = new System.Windows.Forms.ListBox();
            this.pnlPathStatus = new System.Windows.Forms.Panel();
            this.lblFileCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblFolderCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlPathTop = new System.Windows.Forms.Panel();
            this.lblCurrentDirectory = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSaveMessage = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.scintilla1 = new ScintillaNET.Scintilla();
            this.pnlFileStatus = new System.Windows.Forms.Panel();
            this.pnlEditToolbar = new System.Windows.Forms.Panel();
            this.btnEditRedo = new System.Windows.Forms.Button();
            this.btnEditUndo = new System.Windows.Forms.Button();
            this.btnEditDelete = new System.Windows.Forms.Button();
            this.btnEditPaste = new System.Windows.Forms.Button();
            this.btnEditCopy = new System.Windows.Forms.Button();
            this.btnEditCut = new System.Windows.Forms.Button();
            this.btnReplaceAll = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlFileToolbar = new System.Windows.Forms.Panel();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tmrMessage = new System.Windows.Forms.Timer(this.components);
            this.pnlToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
            this.mainSplitter.Panel1.SuspendLayout();
            this.mainSplitter.Panel2.SuspendLayout();
            this.mainSplitter.SuspendLayout();
            this.pnlPathStatus.SuspendLayout();
            this.pnlPathTop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlSaveMessage.SuspendLayout();
            this.pnlFileStatus.SuspendLayout();
            this.pnlEditToolbar.SuspendLayout();
            this.pnlFileToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolbar
            // 
            this.pnlToolbar.BackColor = System.Drawing.SystemColors.Control;
            this.pnlToolbar.Controls.Add(this.panel1);
            this.pnlToolbar.Controls.Add(this.btnExport);
            this.pnlToolbar.Controls.Add(this.btnMove);
            this.pnlToolbar.Controls.Add(this.btnRun);
            this.pnlToolbar.Controls.Add(this.btnRefresh);
            this.pnlToolbar.Controls.Add(this.btnMkdir);
            this.pnlToolbar.Controls.Add(this.btnLoad);
            this.pnlToolbar.Controls.Add(this.btnNew);
            this.pnlToolbar.Controls.Add(this.btnDelete);
            this.pnlToolbar.Controls.Add(this.btnOpen);
            this.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlToolbar.Name = "pnlToolbar";
            this.pnlToolbar.Size = new System.Drawing.Size(1046, 38);
            this.pnlToolbar.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnREPL);
            this.panel1.Controls.Add(this.cboHelp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(749, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 38);
            this.panel1.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Help:";
            // 
            // btnREPL
            // 
            this.btnREPL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnREPL.ForeColor = System.Drawing.Color.Black;
            this.btnREPL.Image = ((System.Drawing.Image)(resources.GetObject("btnREPL.Image")));
            this.btnREPL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnREPL.Location = new System.Drawing.Point(219, 3);
            this.btnREPL.Name = "btnREPL";
            this.btnREPL.Size = new System.Drawing.Size(73, 31);
            this.btnREPL.TabIndex = 13;
            this.btnREPL.Text = "REPL";
            this.btnREPL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnREPL.UseVisualStyleBackColor = true;
            this.btnREPL.Click += new System.EventHandler(this.btnREPL_Click);
            // 
            // cboHelp
            // 
            this.cboHelp.FormattingEnabled = true;
            this.cboHelp.Location = new System.Drawing.Point(41, 9);
            this.cboHelp.Name = "cboHelp";
            this.cboHelp.Size = new System.Drawing.Size(164, 21);
            this.cboHelp.TabIndex = 19;
            this.cboHelp.SelectedIndexChanged += new System.EventHandler(this.cboHelp_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(184, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(67, 30);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "Export";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnMove
            // 
            this.btnMove.Image = ((System.Drawing.Image)(resources.GetObject("btnMove.Image")));
            this.btnMove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMove.Location = new System.Drawing.Point(319, 3);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(69, 30);
            this.btnMove.TabIndex = 14;
            this.btnMove.Text = "Move";
            this.btnMove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnRun
            // 
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun.Location = new System.Drawing.Point(532, 3);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(54, 30);
            this.btnRun.TabIndex = 17;
            this.btnRun.Text = "Run";
            this.btnRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(462, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 30);
            this.btnRefresh.TabIndex = 16;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnMkdir
            // 
            this.btnMkdir.Image = ((System.Drawing.Image)(resources.GetObject("btnMkdir.Image")));
            this.btnMkdir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMkdir.Location = new System.Drawing.Point(391, 3);
            this.btnMkdir.Name = "btnMkdir";
            this.btnMkdir.Size = new System.Drawing.Size(68, 30);
            this.btnMkdir.TabIndex = 15;
            this.btnMkdir.Text = "MKDIR";
            this.btnMkdir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMkdir.UseVisualStyleBackColor = true;
            this.btnMkdir.Click += new System.EventHandler(this.btnMkdir_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(122, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(59, 30);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Load";
            this.btnLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnNew
            // 
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(3, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(54, 30);
            this.btnNew.TabIndex = 9;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(254, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 30);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(61, 3);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(59, 30);
            this.btnOpen.TabIndex = 10;
            this.btnOpen.Text = "Open";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // mainSplitter
            // 
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitter.Location = new System.Drawing.Point(0, 38);
            this.mainSplitter.Name = "mainSplitter";
            // 
            // mainSplitter.Panel1
            // 
            this.mainSplitter.Panel1.Controls.Add(this.lstDirectory);
            this.mainSplitter.Panel1.Controls.Add(this.pnlPathStatus);
            this.mainSplitter.Panel1.Controls.Add(this.pnlPathTop);
            // 
            // mainSplitter.Panel2
            // 
            this.mainSplitter.Panel2.Controls.Add(this.pnlSaveMessage);
            this.mainSplitter.Panel2.Controls.Add(this.scintilla1);
            this.mainSplitter.Panel2.Controls.Add(this.pnlFileStatus);
            this.mainSplitter.Panel2.Controls.Add(this.pnlFileToolbar);
            this.mainSplitter.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.mainSplitter.Size = new System.Drawing.Size(1046, 599);
            this.mainSplitter.SplitterDistance = 278;
            this.mainSplitter.TabIndex = 1;
            // 
            // lstDirectory
            // 
            this.lstDirectory.BackColor = System.Drawing.Color.Azure;
            this.lstDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDirectory.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDirectory.FormattingEnabled = true;
            this.lstDirectory.IntegralHeight = false;
            this.lstDirectory.ItemHeight = 22;
            this.lstDirectory.Location = new System.Drawing.Point(0, 31);
            this.lstDirectory.Name = "lstDirectory";
            this.lstDirectory.Size = new System.Drawing.Size(278, 531);
            this.lstDirectory.TabIndex = 18;
            this.lstDirectory.DoubleClick += new System.EventHandler(this.lstDirectory_DoubleClick);
            // 
            // pnlPathStatus
            // 
            this.pnlPathStatus.BackColor = System.Drawing.SystemColors.Control;
            this.pnlPathStatus.Controls.Add(this.lblFileCount);
            this.pnlPathStatus.Controls.Add(this.label6);
            this.pnlPathStatus.Controls.Add(this.lblFolderCount);
            this.pnlPathStatus.Controls.Add(this.label4);
            this.pnlPathStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPathStatus.Location = new System.Drawing.Point(0, 562);
            this.pnlPathStatus.Name = "pnlPathStatus";
            this.pnlPathStatus.Size = new System.Drawing.Size(278, 37);
            this.pnlPathStatus.TabIndex = 17;
            // 
            // lblFileCount
            // 
            this.lblFileCount.AutoSize = true;
            this.lblFileCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileCount.Location = new System.Drawing.Point(132, 12);
            this.lblFileCount.Name = "lblFileCount";
            this.lblFileCount.Size = new System.Drawing.Size(28, 13);
            this.lblFileCount.TabIndex = 3;
            this.lblFileCount.Text = "999";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(101, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Files:";
            // 
            // lblFolderCount
            // 
            this.lblFolderCount.AutoSize = true;
            this.lblFolderCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderCount.Location = new System.Drawing.Point(69, 12);
            this.lblFolderCount.Name = "lblFolderCount";
            this.lblFolderCount.Size = new System.Drawing.Size(28, 13);
            this.lblFolderCount.TabIndex = 1;
            this.lblFolderCount.Text = "999";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Sub-Folders:";
            // 
            // pnlPathTop
            // 
            this.pnlPathTop.Controls.Add(this.lblCurrentDirectory);
            this.pnlPathTop.Controls.Add(this.panel3);
            this.pnlPathTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPathTop.Location = new System.Drawing.Point(0, 0);
            this.pnlPathTop.Name = "pnlPathTop";
            this.pnlPathTop.Size = new System.Drawing.Size(278, 31);
            this.pnlPathTop.TabIndex = 15;
            // 
            // lblCurrentDirectory
            // 
            this.lblCurrentDirectory.BackColor = System.Drawing.SystemColors.Control;
            this.lblCurrentDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentDirectory.Location = new System.Drawing.Point(77, 0);
            this.lblCurrentDirectory.Name = "lblCurrentDirectory";
            this.lblCurrentDirectory.Size = new System.Drawing.Size(201, 31);
            this.lblCurrentDirectory.TabIndex = 8;
            this.lblCurrentDirectory.Text = "<current path>";
            this.lblCurrentDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(77, 31);
            this.panel3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current Path:";
            // 
            // pnlSaveMessage
            // 
            this.pnlSaveMessage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSaveMessage.Controls.Add(this.label5);
            this.pnlSaveMessage.Location = new System.Drawing.Point(220, 295);
            this.pnlSaveMessage.Name = "pnlSaveMessage";
            this.pnlSaveMessage.Size = new System.Drawing.Size(295, 49);
            this.pnlSaveMessage.TabIndex = 20;
            this.pnlSaveMessage.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(255, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "File Saved And Uploaded Successfully.";
            // 
            // scintilla1
            // 
            this.scintilla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla1.EolMode = ScintillaNET.Eol.Lf;
            this.scintilla1.IndentationGuides = ScintillaNET.IndentView.Real;
            this.scintilla1.Lexer = ScintillaNET.Lexer.Python;
            this.scintilla1.Location = new System.Drawing.Point(3, 34);
            this.scintilla1.Name = "scintilla1";
            this.scintilla1.Size = new System.Drawing.Size(758, 525);
            this.scintilla1.TabIndex = 19;
            this.scintilla1.TextChanged += new System.EventHandler(this.scintilla1_TextChanged);
            // 
            // pnlFileStatus
            // 
            this.pnlFileStatus.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pnlFileStatus.Controls.Add(this.pnlEditToolbar);
            this.pnlFileStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFileStatus.Location = new System.Drawing.Point(3, 559);
            this.pnlFileStatus.Name = "pnlFileStatus";
            this.pnlFileStatus.Size = new System.Drawing.Size(758, 37);
            this.pnlFileStatus.TabIndex = 18;
            this.pnlFileStatus.Resize += new System.EventHandler(this.pnlFileStatus_Resize);
            // 
            // pnlEditToolbar
            // 
            this.pnlEditToolbar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlEditToolbar.Controls.Add(this.btnEditRedo);
            this.pnlEditToolbar.Controls.Add(this.btnEditUndo);
            this.pnlEditToolbar.Controls.Add(this.btnEditDelete);
            this.pnlEditToolbar.Controls.Add(this.btnEditPaste);
            this.pnlEditToolbar.Controls.Add(this.btnEditCopy);
            this.pnlEditToolbar.Controls.Add(this.btnEditCut);
            this.pnlEditToolbar.Controls.Add(this.btnReplaceAll);
            this.pnlEditToolbar.Controls.Add(this.btnSaveAs);
            this.pnlEditToolbar.Controls.Add(this.btnSave);
            this.pnlEditToolbar.Location = new System.Drawing.Point(217, 0);
            this.pnlEditToolbar.Name = "pnlEditToolbar";
            this.pnlEditToolbar.Size = new System.Drawing.Size(463, 37);
            this.pnlEditToolbar.TabIndex = 9;
            // 
            // btnEditRedo
            // 
            this.btnEditRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnEditRedo.Image")));
            this.btnEditRedo.Location = new System.Drawing.Point(32, 6);
            this.btnEditRedo.Name = "btnEditRedo";
            this.btnEditRedo.Size = new System.Drawing.Size(28, 27);
            this.btnEditRedo.TabIndex = 23;
            this.btnEditRedo.UseVisualStyleBackColor = false;
            this.btnEditRedo.Click += new System.EventHandler(this.btnEditRedo_Click);
            // 
            // btnEditUndo
            // 
            this.btnEditUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnEditUndo.Image")));
            this.btnEditUndo.Location = new System.Drawing.Point(3, 6);
            this.btnEditUndo.Name = "btnEditUndo";
            this.btnEditUndo.Size = new System.Drawing.Size(28, 27);
            this.btnEditUndo.TabIndex = 22;
            this.btnEditUndo.UseVisualStyleBackColor = false;
            this.btnEditUndo.Click += new System.EventHandler(this.btnEditUndo_Click);
            // 
            // btnEditDelete
            // 
            this.btnEditDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnEditDelete.Image")));
            this.btnEditDelete.Location = new System.Drawing.Point(163, 6);
            this.btnEditDelete.Name = "btnEditDelete";
            this.btnEditDelete.Size = new System.Drawing.Size(28, 27);
            this.btnEditDelete.TabIndex = 21;
            this.btnEditDelete.UseVisualStyleBackColor = false;
            this.btnEditDelete.Click += new System.EventHandler(this.btnEditDelete_Click);
            // 
            // btnEditPaste
            // 
            this.btnEditPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnEditPaste.Image")));
            this.btnEditPaste.Location = new System.Drawing.Point(128, 6);
            this.btnEditPaste.Name = "btnEditPaste";
            this.btnEditPaste.Size = new System.Drawing.Size(28, 27);
            this.btnEditPaste.TabIndex = 20;
            this.btnEditPaste.UseVisualStyleBackColor = false;
            this.btnEditPaste.Click += new System.EventHandler(this.btnEditPaste_Click);
            // 
            // btnEditCopy
            // 
            this.btnEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCopy.Image")));
            this.btnEditCopy.Location = new System.Drawing.Point(98, 6);
            this.btnEditCopy.Name = "btnEditCopy";
            this.btnEditCopy.Size = new System.Drawing.Size(28, 27);
            this.btnEditCopy.TabIndex = 19;
            this.btnEditCopy.UseVisualStyleBackColor = false;
            this.btnEditCopy.Click += new System.EventHandler(this.btnEditCopy_Click);
            // 
            // btnEditCut
            // 
            this.btnEditCut.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCut.Image")));
            this.btnEditCut.Location = new System.Drawing.Point(69, 6);
            this.btnEditCut.Name = "btnEditCut";
            this.btnEditCut.Size = new System.Drawing.Size(28, 27);
            this.btnEditCut.TabIndex = 18;
            this.btnEditCut.UseVisualStyleBackColor = false;
            this.btnEditCut.Click += new System.EventHandler(this.btnEditCut_Click);
            // 
            // btnReplaceAll
            // 
            this.btnReplaceAll.Location = new System.Drawing.Point(201, 6);
            this.btnReplaceAll.Name = "btnReplaceAll";
            this.btnReplaceAll.Size = new System.Drawing.Size(68, 27);
            this.btnReplaceAll.TabIndex = 17;
            this.btnReplaceAll.Text = "Replace";
            this.btnReplaceAll.UseVisualStyleBackColor = false;
            this.btnReplaceAll.Click += new System.EventHandler(this.btnReplaceAll_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Location = new System.Drawing.Point(280, 6);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(70, 27);
            this.btnSaveAs.TabIndex = 15;
            this.btnSaveAs.Text = "Save As...";
            this.btnSaveAs.UseVisualStyleBackColor = false;
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(351, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 27);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlFileToolbar
            // 
            this.pnlFileToolbar.Controls.Add(this.lblCurrentFile);
            this.pnlFileToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFileToolbar.Location = new System.Drawing.Point(3, 3);
            this.pnlFileToolbar.Name = "pnlFileToolbar";
            this.pnlFileToolbar.Size = new System.Drawing.Size(758, 31);
            this.pnlFileToolbar.TabIndex = 0;
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblCurrentFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentFile.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(758, 31);
            this.lblCurrentFile.TabIndex = 9;
            this.lblCurrentFile.Text = "<current file>";
            this.lblCurrentFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "py";
            this.openFileDialog1.Filter = "All Files (*.*)|*.*|Python Files (*.py)|*.*";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "Export File";
            // 
            // tmrMessage
            // 
            this.tmrMessage.Interval = 800;
            this.tmrMessage.Tick += new System.EventHandler(this.tmrMessage_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 637);
            this.Controls.Add(this.mainSplitter);
            this.Controls.Add(this.pnlToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Pyboard File Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlToolbar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.mainSplitter.Panel1.ResumeLayout(false);
            this.mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
            this.mainSplitter.ResumeLayout(false);
            this.pnlPathStatus.ResumeLayout(false);
            this.pnlPathStatus.PerformLayout();
            this.pnlPathTop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlSaveMessage.ResumeLayout(false);
            this.pnlSaveMessage.PerformLayout();
            this.pnlFileStatus.ResumeLayout(false);
            this.pnlEditToolbar.ResumeLayout(false);
            this.pnlFileToolbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlToolbar;
        private System.Windows.Forms.SplitContainer mainSplitter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnMkdir;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnREPL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboHelp;
        private System.Windows.Forms.Panel pnlFileToolbar;
        private System.Windows.Forms.Panel pnlPathTop;
        private System.Windows.Forms.Label lblCurrentDirectory;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListBox lstDirectory;
        private System.Windows.Forms.Panel pnlPathStatus;
        private ScintillaNET.Scintilla scintilla1;
        private System.Windows.Forms.Panel pnlFileStatus;
        private System.Windows.Forms.Label lblFileCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFolderCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlSaveMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer tmrMessage;
        private System.Windows.Forms.Panel pnlEditToolbar;
        private System.Windows.Forms.Button btnReplaceAll;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEditCut;
        private System.Windows.Forms.Button btnEditPaste;
        private System.Windows.Forms.Button btnEditCopy;
        private System.Windows.Forms.Button btnEditDelete;
        private System.Windows.Forms.Button btnEditRedo;
        private System.Windows.Forms.Button btnEditUndo;
    }
}