﻿namespace FEBuilderGBA
{
    partial class EventTemplate1Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.BLANK_Button = new System.Windows.Forms.Button();
            this.VILLAGE_TALK_Button = new System.Windows.Forms.Button();
            this.VILLAGE_ITEM_Button = new System.Windows.Forms.Button();
            this.VILLAGE_GOLD_Button = new System.Windows.Forms.Button();
            this.VILLAGE_UNIT_button = new System.Windows.Forms.Button();
            this.CALL_EndEvent_button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CALL_1_button = new System.Windows.Forms.Button();
            this.FormIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FormIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "新規にイベントを割り振りますか？";
            // 
            // BLANK_Button
            // 
            this.BLANK_Button.Location = new System.Drawing.Point(12, 102);
            this.BLANK_Button.Name = "BLANK_Button";
            this.BLANK_Button.Size = new System.Drawing.Size(759, 42);
            this.BLANK_Button.TabIndex = 0;
            this.BLANK_Button.Text = "新規にイベント領域を割り振り、空のイベントを定義します。";
            this.BLANK_Button.UseVisualStyleBackColor = true;
            this.BLANK_Button.Click += new System.EventHandler(this.BLANK_Button_Click);
            // 
            // VILLAGE_TALK_Button
            // 
            this.VILLAGE_TALK_Button.Location = new System.Drawing.Point(12, 186);
            this.VILLAGE_TALK_Button.Name = "VILLAGE_TALK_Button";
            this.VILLAGE_TALK_Button.Size = new System.Drawing.Size(759, 42);
            this.VILLAGE_TALK_Button.TabIndex = 1;
            this.VILLAGE_TALK_Button.Text = "民家での会話イベントを作成";
            this.VILLAGE_TALK_Button.UseVisualStyleBackColor = true;
            this.VILLAGE_TALK_Button.Click += new System.EventHandler(this.VILLAGE_TALK_Button_Click);
            // 
            // VILLAGE_ITEM_Button
            // 
            this.VILLAGE_ITEM_Button.Location = new System.Drawing.Point(12, 234);
            this.VILLAGE_ITEM_Button.Name = "VILLAGE_ITEM_Button";
            this.VILLAGE_ITEM_Button.Size = new System.Drawing.Size(759, 42);
            this.VILLAGE_ITEM_Button.TabIndex = 2;
            this.VILLAGE_ITEM_Button.Text = "村でのアイテム取得イベントを作成";
            this.VILLAGE_ITEM_Button.UseVisualStyleBackColor = true;
            this.VILLAGE_ITEM_Button.Click += new System.EventHandler(this.VILLAGE_ITEM_Button_Click);
            // 
            // VILLAGE_GOLD_Button
            // 
            this.VILLAGE_GOLD_Button.Location = new System.Drawing.Point(12, 282);
            this.VILLAGE_GOLD_Button.Name = "VILLAGE_GOLD_Button";
            this.VILLAGE_GOLD_Button.Size = new System.Drawing.Size(759, 42);
            this.VILLAGE_GOLD_Button.TabIndex = 3;
            this.VILLAGE_GOLD_Button.Text = "村でのゴールド取得イベントを作成";
            this.VILLAGE_GOLD_Button.UseVisualStyleBackColor = true;
            this.VILLAGE_GOLD_Button.Click += new System.EventHandler(this.VILLAGE_GOLD_Button_Click);
            // 
            // VILLAGE_UNIT_button
            // 
            this.VILLAGE_UNIT_button.Location = new System.Drawing.Point(12, 330);
            this.VILLAGE_UNIT_button.Name = "VILLAGE_UNIT_button";
            this.VILLAGE_UNIT_button.Size = new System.Drawing.Size(759, 42);
            this.VILLAGE_UNIT_button.TabIndex = 4;
            this.VILLAGE_UNIT_button.Text = "村での仲間加入イベントを作成";
            this.VILLAGE_UNIT_button.UseVisualStyleBackColor = true;
            this.VILLAGE_UNIT_button.Click += new System.EventHandler(this.VILLAGE_UNIT_button_Click);
            // 
            // CALL_EndEvent_button
            // 
            this.CALL_EndEvent_button.Location = new System.Drawing.Point(12, 423);
            this.CALL_EndEvent_button.Name = "CALL_EndEvent_button";
            this.CALL_EndEvent_button.Size = new System.Drawing.Size(759, 42);
            this.CALL_EndEvent_button.TabIndex = 5;
            this.CALL_EndEvent_button.Text = "章終了イベントを呼び出す(章クリア)";
            this.CALL_EndEvent_button.UseVisualStyleBackColor = true;
            this.CALL_EndEvent_button.Click += new System.EventHandler(this.CALL_EndEvent_button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "テンプレート";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 392);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "既存イベントを呼び出す";
            // 
            // CALL_1_button
            // 
            this.CALL_1_button.Location = new System.Drawing.Point(12, 473);
            this.CALL_1_button.Name = "CALL_1_button";
            this.CALL_1_button.Size = new System.Drawing.Size(759, 42);
            this.CALL_1_button.TabIndex = 7;
            this.CALL_1_button.Text = "何もしないイベント1を設定";
            this.CALL_1_button.UseVisualStyleBackColor = true;
            this.CALL_1_button.Click += new System.EventHandler(this.CALL_1_button_Click);
            // 
            // FormIcon
            // 
            this.FormIcon.Location = new System.Drawing.Point(16, 12);
            this.FormIcon.Name = "FormIcon";
            this.FormIcon.Size = new System.Drawing.Size(64, 64);
            this.FormIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormIcon.TabIndex = 12;
            this.FormIcon.TabStop = false;
            // 
            // EventTemplate1Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 534);
            this.Controls.Add(this.FormIcon);
            this.Controls.Add(this.CALL_1_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CALL_EndEvent_button);
            this.Controls.Add(this.VILLAGE_UNIT_button);
            this.Controls.Add(this.VILLAGE_GOLD_Button);
            this.Controls.Add(this.VILLAGE_ITEM_Button);
            this.Controls.Add(this.VILLAGE_TALK_Button);
            this.Controls.Add(this.BLANK_Button);
            this.Controls.Add(this.label1);
            this.Name = "EventTemplate1Form";
            this.Text = "新規にイベントを割り振りますか？";
            this.Load += new System.EventHandler(this.EventCondEventTemplate1Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FormIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BLANK_Button;
        private System.Windows.Forms.Button VILLAGE_TALK_Button;
        private System.Windows.Forms.Button VILLAGE_ITEM_Button;
        private System.Windows.Forms.Button VILLAGE_GOLD_Button;
        private System.Windows.Forms.Button VILLAGE_UNIT_button;
        private System.Windows.Forms.Button CALL_EndEvent_button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CALL_1_button;
        private System.Windows.Forms.PictureBox FormIcon;
    }
}