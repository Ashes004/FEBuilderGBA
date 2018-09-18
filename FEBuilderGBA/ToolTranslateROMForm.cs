﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FEBuilderGBA
{
    public partial class ToolTranslateROMForm : Form
    {
        public ToolTranslateROMForm()
        {
            InitializeComponent();
            FontROMTextBox.AllowDropFilename();
            TranslateFormROMFilename.AllowDropFilename();
            TranslateToROMFilename.AllowDropFilename();
            SimpleTranslateFromROMFilename.AllowDropFilename();
            SimpleTranslateToROMFilename.AllowDropFilename();

            useAutoTranslateCheckBox_CheckedChanged(null, null);
#if DEBUG //デバッグモードのときだけ翻訳して書出しボタンをだしてやろう.
            UseGoogleTranslateCheckBox.Enabled = true;
            UseGoogleTranslateCheckBox.Show();
            X_UseGoogleTranslateCheckBox.Hide();
#else
            UseGoogleTranslateCheckBox.Hide();
            X_UseGoogleTranslateCheckBox.Show();
#endif
            int from,to;
            TranslateTextUtil.TranslateLanguageAutoSelect(out from,out to);

            U.ForceUpdate(Translate_from, from);
            U.ForceUpdate(Translate_to, to);

            UseFontNameTextEdit.Text = UseFontNameTextEdit.Font.FontFamily.ToString();
        }
        

        private void ImportAllTextButton_Click(object sender, EventArgs e)
        {
            if (InputFormRef.IsPleaseWaitDialog(this))
            {//2重割り込み禁止
                return;
            }

            ToolTranslateROM trans = new ToolTranslateROM();
            trans.CheckTextImportPatch(true);
            trans.ImportAllText(this);
        }

        private void ExportallTextButton_Click(object sender, EventArgs e)
        {
            if (InputFormRef.IsPleaseWaitDialog(this))
            {//2重割り込み禁止
                return;
            }

            string from = "";
            string to = "";
            string fromrom = "";
            string torom = "";
            bool useGoolgeTranslate = false;

            if (useAutoTranslateCheckBox.Checked)
            {
                //翻訳言語
                from = U.InnerSplit(Translate_from.Text, "=", 0);
                to = U.InnerSplit(Translate_to.Text, "=", 0);
                if (from == to)
                {
                    return;
                }

                fromrom = TranslateFormROMFilename.Text;
                torom = TranslateToROMFilename.Text;
                if (! File.Exists(fromrom))
                {
                    return;
                }
                if (!File.Exists(torom))
                {
                    return;
                }

                useGoolgeTranslate = UseGoogleTranslateCheckBox.Checked;
            }

            ToolTranslateROM trans = new ToolTranslateROM();
            trans.ExportallText(this,useAutoTranslateCheckBox.Checked, from, to, fromrom, torom, useGoolgeTranslate);
        }


        private void FontROMSelectButton_Click(object sender, EventArgs e)
        {
            string title = R._("フォントを抽出するROMを選択してください");
            string filter = R._("GBA ROMs|*.gba|Binary files|*.bin|All files|*");

            OpenFileDialog open = new OpenFileDialog();
            open.Title = title;
            open.Filter = filter;
            Program.LastSelectedFilename.Load(this, "", open);
            DialogResult dr = open.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return ;
            }
            if (!U.CanReadFileRetry(open))
            {
                return ;
            }

            Program.LastSelectedFilename.Save(this, "", open);
            this.FontROMTextBox.Text = open.FileNames[0];
        }

        private void ImportFontButton_Click(object sender, EventArgs e)
        {
            if (InputFormRef.IsPleaseWaitDialog(this))
            {//2重割り込み禁止
                return;
            }

            ToolTranslateROMFont trans = new ToolTranslateROMFont();
            trans.ImportFont(this, this.FontROMTextBox.Text, FontAutoGenelateCheckBox.Checked, FontAutoGenelateCheckBox.Font);
        }
        private void FontROMTextBox_DoubleClick(object sender, EventArgs e)
        {
            FontROMSelectButton.PerformClick();
        }


        private void TranslateROMForm_Load(object sender, EventArgs e)
        {
        }

        private void useAutoTranslateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TranslatePanel.Enabled = useAutoTranslateCheckBox.Checked;
            TranslatePanel.Visible = useAutoTranslateCheckBox.Checked;
        }

        private void TranslateFormROMFilenameSelectButton_Click(object sender, EventArgs e)
        {
            string title = R._("定型文を抽出するROMを選択してください");
            string filter = R._("GBA ROMs|*.gba|Binary files|*.bin|All files|*");

            OpenFileDialog open = new OpenFileDialog();
            open.Title = title;
            open.Filter = filter;
            Program.LastSelectedFilename.Load(this, "", open);
            DialogResult dr = open.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }
            if (!U.CanReadFileRetry(open))
            {
                return;
            }

            Program.LastSelectedFilename.Save(this, "", open);
            this.TranslateFormROMFilename.Text = open.FileNames[0];
            this.SimpleTranslateFromROMFilename.Text = open.FileNames[0];
        }

        private void TranslateToROMFilenameSelectButton_Click(object sender, EventArgs e)
        {
            string title = R._("定型文を抽出するROMを選択してください");
            string filter = R._("GBA ROMs|*.gba|Binary files|*.bin|All files|*");

            OpenFileDialog open = new OpenFileDialog();
            open.Title = title;
            open.Filter = filter;
            Program.LastSelectedFilename.Load(this, "", open);
            DialogResult dr = open.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return;
            }
            if (!U.CanReadFileRetry(open))
            {
                return;
            }

            Program.LastSelectedFilename.Save(this, "", open);
            this.TranslateToROMFilename.Text = open.FileNames[0];
            this.SimpleTranslateToROMFilename.Text = open.FileNames[0];
        }

        private void TranslateFormROMFilename_DoubleClick(object sender, EventArgs e)
        {
            TranslateFormROMFilenameSelectButton.PerformClick();
        }

        private void TranslateToROMFilename_DoubleClick(object sender, EventArgs e)
        {
            TranslateToROMFilenameSelectButton.PerformClick();
        }

        private void Translate_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            String dir = Path.GetDirectoryName(Program.ROM.Filename);
            string from = U.InnerSplit(Translate_from.Text, "=", 0);
            TranslateFormROMFilename.Text = MainFormUtil.FindOrignalROMByLang(dir, from);
            SimpleTranslateFromROMFilename.Text = TranslateFormROMFilename.Text;
        }

        private void Translate_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            String dir = Path.GetDirectoryName(Program.ROM.Filename);
            string to = U.InnerSplit(Translate_to.Text, "=", 0);
            TranslateToROMFilename.Text = MainFormUtil.FindOrignalROMByLang(dir, to);
            SimpleTranslateToROMFilename.Text = TranslateToROMFilename.Text;
            FontROMTextBox.Text = TranslateToROMFilename.Text;
        }

        private void FontAutoGenelateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FontAutoGenelateCheckBox.Checked)
            {
                FontROMTextBox.Enabled = false;
                FontROMSelectButton.Enabled = false;
                FontAutoGenelatePanel.Show();
            }
            else
            {
                FontROMTextBox.Enabled = true;
                FontROMSelectButton.Enabled = true;
                FontAutoGenelatePanel.Hide();
            }
        }

        private void UseFontNameButton_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowColor = false;
            fd.ShowEffects = false;
            fd.Font = UseFontNameTextEdit.Font;
            DialogResult dr = fd.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            UseFontNameTextEdit.Font = fd.Font;
            UseFontNameTextEdit.Text = fd.Font.FontFamily.ToString();
        }

        private void SimpleFireButton_Click(object sender, EventArgs e)
        {
            if (InputFormRef.IsPleaseWaitDialog(this))
            {//2重割り込み禁止
                return;
            }

            //翻訳言語
            string from = U.InnerSplit(Translate_from.Text, "=", 0);
            string to = U.InnerSplit(Translate_to.Text, "=", 0);
            string fromrom = SimpleTranslateFromROMFilename.Text;
            string torom = SimpleTranslateToROMFilename.Text;
            bool useGoolgeTranslate = false;
            if (from == to)
            {
                return;
            }

            {
                string writeTextFileName = Path.GetTempFileName();

                ToolTranslateROM trans = new ToolTranslateROM();
                trans.CheckTextImportPatch(true);
                //メニューのサイズを調整する
                trans.ChangeMainMenuWidth(to);
                trans.ChangeStatusScreenSkill(to);

                trans.ExportallText(this, writeTextFileName, from, to, fromrom, torom, useGoolgeTranslate);
                trans.ImportAllText(this, writeTextFileName);

                ToolTranslateROMFont transFont = new ToolTranslateROMFont();
                transFont.ImportFont(this, torom, true, FontAutoGenelateCheckBox.Font);

                File.Delete(writeTextFileName);
            }
            R.ShowOK("完了");
            this.Close();
        }




    }
}
