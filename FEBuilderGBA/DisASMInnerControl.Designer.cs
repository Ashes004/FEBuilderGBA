﻿namespace FEBuilderGBA
{
    partial class DisASMInnerControl
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
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.ReloadListButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReadCount = new System.Windows.Forms.NumericUpDown();
            this.ReadStartAddress = new System.Windows.Forms.NumericUpDown();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.ControlPanelCommand = new System.Windows.Forms.Panel();
            this.ParamExplain1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ParamSrc1 = new System.Windows.Forms.NumericUpDown();
            this.ParamLabel1 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ASMToFileButton = new System.Windows.Forms.Button();
            this.ToClipBordButton = new System.Windows.Forms.Button();
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.FileToASMButton = new System.Windows.Forms.Button();
            this.DumpAll = new System.Windows.Forms.Button();
            this.HexEditorButton = new System.Windows.Forms.Button();
            this.ScriptCodeName = new FEBuilderGBA.TextBoxEx();
            this.AddressList = new FEBuilderGBA.ListBoxEx();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReadCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReadStartAddress)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.ControlPanelCommand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParamSrc1)).BeginInit();
            this.FooterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeaderPanel.Controls.Add(this.ReloadListButton);
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Controls.Add(this.label2);
            this.HeaderPanel.Controls.Add(this.ReadCount);
            this.HeaderPanel.Controls.Add(this.ReadStartAddress);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(991, 21);
            this.HeaderPanel.TabIndex = 54;
            // 
            // ReloadListButton
            // 
            this.ReloadListButton.Location = new System.Drawing.Point(302, -1);
            this.ReloadListButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReloadListButton.Name = "ReloadListButton";
            this.ReloadListButton.Size = new System.Drawing.Size(75, 20);
            this.ReloadListButton.TabIndex = 25;
            this.ReloadListButton.Text = "再取得";
            this.ReloadListButton.UseVisualStyleBackColor = true;
            this.ReloadListButton.Click += new System.EventHandler(this.ReloadListButton_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(0, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 23;
            this.label1.Text = "アドレス";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(148, -1);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 22);
            this.label2.TabIndex = 24;
            this.label2.Text = "読込バイト数";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ReadCount
            // 
            this.ReadCount.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ReadCount.Location = new System.Drawing.Point(239, 1);
            this.ReadCount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReadCount.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.ReadCount.Name = "ReadCount";
            this.ReadCount.Size = new System.Drawing.Size(61, 21);
            this.ReadCount.TabIndex = 28;
            this.ReadCount.ValueChanged += new System.EventHandler(this.ReadCount_ValueChanged);
            this.ReadCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReadCount_KeyDown);
            this.ReadCount.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ReadCount_MouseDown);
            // 
            // ReadStartAddress
            // 
            this.ReadStartAddress.Hexadecimal = true;
            this.ReadStartAddress.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.ReadStartAddress.Location = new System.Drawing.Point(60, 2);
            this.ReadStartAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReadStartAddress.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.ReadStartAddress.Name = "ReadStartAddress";
            this.ReadStartAddress.Size = new System.Drawing.Size(87, 21);
            this.ReadStartAddress.TabIndex = 0;
            this.ReadStartAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ReadStartAddress_KeyDown);
            // 
            // MainPanel
            // 
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Controls.Add(this.ControlPanel);
            this.MainPanel.Controls.Add(this.AddressList);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 21);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(991, 513);
            this.MainPanel.TabIndex = 55;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // ControlPanel
            // 
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Controls.Add(this.ControlPanelCommand);
            this.ControlPanel.Controls.Add(this.CloseButton);
            this.ControlPanel.Location = new System.Drawing.Point(1, 377);
            this.ControlPanel.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(978, 45);
            this.ControlPanel.TabIndex = 3;
            this.ControlPanel.Visible = false;
            // 
            // ControlPanelCommand
            // 
            this.ControlPanelCommand.Controls.Add(this.ParamExplain1);
            this.ControlPanelCommand.Controls.Add(this.label3);
            this.ControlPanelCommand.Controls.Add(this.ScriptCodeName);
            this.ControlPanelCommand.Controls.Add(this.ParamSrc1);
            this.ControlPanelCommand.Controls.Add(this.ParamLabel1);
            this.ControlPanelCommand.Location = new System.Drawing.Point(0, 1);
            this.ControlPanelCommand.Name = "ControlPanelCommand";
            this.ControlPanelCommand.Size = new System.Drawing.Size(911, 42);
            this.ControlPanelCommand.TabIndex = 202;
            // 
            // ParamExplain1
            // 
            this.ParamExplain1.AutoSize = true;
            this.ParamExplain1.Location = new System.Drawing.Point(237, 24);
            this.ParamExplain1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ParamExplain1.Name = "ParamExplain1";
            this.ParamExplain1.Size = new System.Drawing.Size(263, 12);
            this.ParamExplain1.TabIndex = 200;
            this.ParamExplain1.Text = "リンクをクリックするか、Jで関数に移動します";
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(5, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 17);
            this.label3.TabIndex = 58;
            this.label3.Text = "Code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ParamSrc1
            // 
            this.ParamSrc1.Hexadecimal = true;
            this.ParamSrc1.Location = new System.Drawing.Point(97, 23);
            this.ParamSrc1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.ParamSrc1.Maximum = new decimal(new int[] {
            -559939585,
            902409669,
            54,
            0});
            this.ParamSrc1.Name = "ParamSrc1";
            this.ParamSrc1.ReadOnly = true;
            this.ParamSrc1.Size = new System.Drawing.Size(122, 21);
            this.ParamSrc1.TabIndex = 0;
            // 
            // ParamLabel1
            // 
            this.ParamLabel1.Location = new System.Drawing.Point(3, 25);
            this.ParamLabel1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.ParamLabel1.Name = "ParamLabel1";
            this.ParamLabel1.Size = new System.Drawing.Size(89, 12);
            this.ParamLabel1.TabIndex = 1;
            this.ParamLabel1.Text = "&Jump";
            this.ParamLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ParamLabel1.Click += new System.EventHandler(this.ParamLabel1_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(920, 5);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(55, 21);
            this.CloseButton.TabIndex = 201;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // ASMToFileButton
            // 
            this.ASMToFileButton.Location = new System.Drawing.Point(335, 3);
            this.ASMToFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ASMToFileButton.Name = "ASMToFileButton";
            this.ASMToFileButton.Size = new System.Drawing.Size(171, 20);
            this.ASMToFileButton.TabIndex = 58;
            this.ASMToFileButton.Text = "ファイルへエクスポート";
            this.ASMToFileButton.UseVisualStyleBackColor = true;
            this.ASMToFileButton.Click += new System.EventHandler(this.ToFileButton_Click);
            // 
            // ToClipBordButton
            // 
            this.ToClipBordButton.Location = new System.Drawing.Point(2, 2);
            this.ToClipBordButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ToClipBordButton.Name = "ToClipBordButton";
            this.ToClipBordButton.Size = new System.Drawing.Size(162, 20);
            this.ToClipBordButton.TabIndex = 56;
            this.ToClipBordButton.Text = "クリックボードへ(Ctrl+C)";
            this.ToClipBordButton.UseVisualStyleBackColor = true;
            this.ToClipBordButton.Click += new System.EventHandler(this.ToClipBordButton_Click);
            // 
            // FooterPanel
            // 
            this.FooterPanel.Controls.Add(this.FileToASMButton);
            this.FooterPanel.Controls.Add(this.DumpAll);
            this.FooterPanel.Controls.Add(this.HexEditorButton);
            this.FooterPanel.Controls.Add(this.ToClipBordButton);
            this.FooterPanel.Controls.Add(this.ASMToFileButton);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 534);
            this.FooterPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(991, 25);
            this.FooterPanel.TabIndex = 60;
            // 
            // FileToASMButton
            // 
            this.FileToASMButton.Location = new System.Drawing.Point(169, 2);
            this.FileToASMButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FileToASMButton.Name = "FileToASMButton";
            this.FileToASMButton.Size = new System.Drawing.Size(163, 20);
            this.FileToASMButton.TabIndex = 62;
            this.FileToASMButton.Text = "ファイルからインポート";
            this.FileToASMButton.UseVisualStyleBackColor = true;
            this.FileToASMButton.Click += new System.EventHandler(this.FileToASMButton_Click);
            // 
            // DumpAll
            // 
            this.DumpAll.Location = new System.Drawing.Point(509, 3);
            this.DumpAll.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DumpAll.Name = "DumpAll";
            this.DumpAll.Size = new System.Drawing.Size(223, 20);
            this.DumpAll.TabIndex = 61;
            this.DumpAll.Text = "全部ファイルに保存";
            this.DumpAll.UseVisualStyleBackColor = true;
            this.DumpAll.Click += new System.EventHandler(this.DumpAllButton_Click);
            // 
            // HexEditorButton
            // 
            this.HexEditorButton.Location = new System.Drawing.Point(735, 3);
            this.HexEditorButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HexEditorButton.Name = "HexEditorButton";
            this.HexEditorButton.Size = new System.Drawing.Size(162, 20);
            this.HexEditorButton.TabIndex = 59;
            this.HexEditorButton.Text = "HexEditor";
            this.HexEditorButton.UseVisualStyleBackColor = true;
            this.HexEditorButton.Click += new System.EventHandler(this.HexEditorButton_Click);
            // 
            // ScriptCodeName
            // 
            this.ScriptCodeName.ErrorMessage = "";
            this.ScriptCodeName.Location = new System.Drawing.Point(97, 3);
            this.ScriptCodeName.Margin = new System.Windows.Forms.Padding(1);
            this.ScriptCodeName.Name = "ScriptCodeName";
            this.ScriptCodeName.Placeholder = "";
            this.ScriptCodeName.ReadOnly = true;
            this.ScriptCodeName.Size = new System.Drawing.Size(800, 21);
            this.ScriptCodeName.TabIndex = 199;
            // 
            // AddressList
            // 
            this.AddressList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddressList.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.AddressList.FormattingEnabled = true;
            this.AddressList.IntegralHeight = false;
            this.AddressList.ItemHeight = 16;
            this.AddressList.Location = new System.Drawing.Point(0, 0);
            this.AddressList.Name = "AddressList";
            this.AddressList.Size = new System.Drawing.Size(989, 511);
            this.AddressList.TabIndex = 0;
            this.AddressList.SelectedIndexChanged += new System.EventHandler(this.AddressList_SelectedIndexChanged);
            this.AddressList.DoubleClick += new System.EventHandler(this.AddressList_DoubleClick);
            this.AddressList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressList_KeyDown);
            // 
            // DisASMInnerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.FooterPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "DisASMInnerControl";
            this.Size = new System.Drawing.Size(991, 559);
            this.Load += new System.EventHandler(this.DisASMForm_Load);
            this.Resize += new System.EventHandler(this.DisASMForm_Resize);
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReadCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReadStartAddress)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanelCommand.ResumeLayout(false);
            this.ControlPanelCommand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParamSrc1)).EndInit();
            this.FooterPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Button ReloadListButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ReadCount;
        private System.Windows.Forms.NumericUpDown ReadStartAddress;
        private System.Windows.Forms.Panel MainPanel;
        private ListBoxEx AddressList;
        private System.Windows.Forms.Button ASMToFileButton;
        private System.Windows.Forms.Button ToClipBordButton;
        private System.Windows.Forms.Panel FooterPanel;
        private System.Windows.Forms.Button HexEditorButton;
        private System.Windows.Forms.Button DumpAll;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Panel ControlPanelCommand;
        private System.Windows.Forms.Label label3;
        private FEBuilderGBA.TextBoxEx ScriptCodeName;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label ParamLabel1;
        private System.Windows.Forms.NumericUpDown ParamSrc1;
        private System.Windows.Forms.Label ParamExplain1;
        private System.Windows.Forms.Button FileToASMButton;
    }
}