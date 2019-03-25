﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FEBuilderGBA
{
    public partial class SkillAssignmentUnitSkillSystemForm : Form
    {
        public SkillAssignmentUnitSkillSystemForm()
        {
            InitializeComponent();

            uint icon = SkillConfigSkillSystemForm.FindIconPointer();
            uint text = SkillConfigSkillSystemForm.FindTextPointer();
            uint assignUnit = SkillConfigSkillSystemForm.FindAssignPersonalSkillPointer();
            uint assignLevelUpP = SkillConfigSkillSystemForm.FindAssignUnitLevelUpSkillPointer();
            
            if (icon == U.NOT_FOUND)
            {
                R.ShowStopError("スキル拡張 SkillSystem の、アイコンを取得できません。");
                return;
            }
            if (text == U.NOT_FOUND)
            {
                R.ShowStopError("スキル拡張 SkillSystem の、テキストを取得できません。");
                return;
            }
            if (assignUnit == U.NOT_FOUND)
            {
                R.ShowStopError("スキル拡張 SkillSystem の、個人スキルを取得できません。");
                return;
            }
            this.SkillNames = U.LoadDicResource(U.ConfigDataFilename("skill_extends_skillsystem_name_"));

            this.TextBaseAddress = Program.ROM.p32(text);
            this.IconBaseAddress = Program.ROM.p32(icon);
            this.AssignUnitBaseAddress = Program.ROM.p32(assignUnit);
            if (assignLevelUpP == U.NOT_FOUND)
            {//古いパッチでは、ユニットベースのレベルアップスキルが存在しない
                this.AssignLevelUpBaseAddress = U.NOT_FOUND;
                UnitLevelUpSkill.Hide();
            }
            else
            {
                this.AssignLevelUpBaseAddress = Program.ROM.p32(assignLevelUpP);
            }

            this.AddressList.OwnerDraw(ListBoxEx.DrawUnitAndText, DrawMode.OwnerDrawFixed);
            InputFormRef.markupJumpLabel(this.J_0_SKILLASSIGNMENT);
            InputFormRef = Init(this, assignUnit);
            InputFormRef.MakeGeneralAddressListContextMenu(true);

            this.N1_AddressList.OwnerDraw(DrawSkillAndText, DrawMode.OwnerDrawFixed);
            InputFormRef.markupJumpLabel(this.N1_J_1_SKILLASSIGNMENT);
            N1_InputFormRef = N1_Init(this, this.SkillNames);
            N1_InputFormRef.AddressListExpandsEvent += N1_InputFormRef_AddressListExpandsEvent;
            N1_InputFormRef.MakeGeneralAddressListContextMenu(true);
        }


        public InputFormRef InputFormRef;
        static InputFormRef Init(Form self, uint assignUnit)
        {
            uint unitDataCount = UnitForm.DataCount();

            InputFormRef ifr = new InputFormRef(self
                , ""
                , assignUnit
                , 1
                , (int i, uint addr) =>
                {//読込最大値検索
                    return i < unitDataCount;
                }
                , (int i, uint addr) =>
                {
                    return U.ToHexString(i) + " " + UnitForm.GetUnitName((uint)i);
                }
            );
            return ifr;
        }

        private void SkillAssignmentUnitSkillSystemForm_Load(object sender, EventArgs e)
        {

        }

        uint TextBaseAddress;
        uint IconBaseAddress;
        uint AssignUnitBaseAddress;
        uint AssignLevelUpBaseAddress;
        Dictionary<uint, string> SkillNames;


        private void B0_ValueChanged(object sender, EventArgs e)
        {
            SKILLICON.Image = SkillConfigSkillSystemForm.DrawIcon((uint)this.B0.Value,this.IconBaseAddress);
            SKILLTEXT.Text = SkillConfigSkillSystemForm.GetSkillText((uint)this.B0.Value, this.TextBaseAddress);
            SKILLNAME.Text = U.at(this.SkillNames,(uint)this.B0.Value);
        }

        //全データの取得
        public static void MakeAllDataLength(List<Address> list)
        {
            InputFormRef InputFormRef;
            if (InputFormRef.SearchSkillSystem() != InputFormRef.skill_system_enum.SkillSystem)
            {
                return;
            }

            {
                uint assignUnitP = SkillConfigSkillSystemForm.FindAssignPersonalSkillPointer();

                if (assignUnitP == U.NOT_FOUND)
                {
                    return;
                }


                InputFormRef = Init(null, assignUnitP);
                FEBuilderGBA.Address.AddAddress(list, InputFormRef, "SkillAssignmentUnitSkillSystem", new uint[] { });

                uint assignLevelUpP = SkillConfigSkillSystemForm.FindAssignUnitLevelUpSkillPointer();
                if (assignLevelUpP == U.NOT_FOUND)
                {
                    return;
                }

                Dictionary<uint, string> skillNames = new Dictionary<uint, string>();
                InputFormRef N1_InputFormRef = N1_Init(null, skillNames);

                uint assignLevelUpAddr = Program.ROM.p32(assignLevelUpP);
                for (uint i = 0; i < InputFormRef.DataCount; i++, assignLevelUpAddr += 4)
                {
                    if (!U.isSafetyOffset(assignLevelUpAddr))
                    {
                        break;
                    }

                    uint levelupList = Program.ROM.p32(assignLevelUpAddr);
                    if (!U.isSafetyOffset(levelupList))
                    {
                        continue;
                    }

                    N1_InputFormRef.ReInitPointer(assignLevelUpAddr);
                    FEBuilderGBA.Address.AddAddress(list, N1_InputFormRef, "SkillAssignmentUnitSkillSystem.Levelup" + i, new uint[] { });
                }
            }
        }
        //全データの取得
        public static void ExportAllData(string filename)
        {
            InputFormRef InputFormRef;
            if (InputFormRef.SearchSkillSystem() != InputFormRef.skill_system_enum.SkillSystem)
            {
                return;
            }

            List<string> lines = new List<string>();
            {
                uint assignUnitP = SkillConfigSkillSystemForm.FindAssignPersonalSkillPointer();
                if (assignUnitP == U.NOT_FOUND)
                {
                    return;
                }

                InputFormRef = Init(null, assignUnitP);
                uint p = InputFormRef.BaseAddress;
                for (int i = 0; i < InputFormRef.DataCount; i++, p += InputFormRef.BlockSize)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(U.ToHexString(Program.ROM.u8(p + 0)));
                    lines.Add(sb.ToString());
                }
            }
            File.WriteAllLines(filename, lines);
        }
        public static void ImportAllData(string filename)
        {
            InputFormRef InputFormRef;
            if (InputFormRef.SearchSkillSystem() != InputFormRef.skill_system_enum.SkillSystem)
            {
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            {
                uint assignUnitP = SkillConfigSkillSystemForm.FindAssignPersonalSkillPointer();
                if (assignUnitP == U.NOT_FOUND)
                {
                    return;
                }

                InputFormRef = Init(null, assignUnitP);
                uint p = InputFormRef.BaseAddress;
                for (int i = 0; i < InputFormRef.DataCount; i++, p += InputFormRef.BlockSize)
                {
                    if (i >= lines.Length)
                    {
                        break;
                    }
                    uint skill = U.atoh(lines[i]);
                    Program.ROM.write_u8(p + 0 , skill);
                }
            }
            File.WriteAllLines(filename, lines);
        }
        public static int MakeUnitSkillButtons(uint uid, Button[] buttons, ToolTipEx tooltip)
        {
            uint iconP = SkillConfigSkillSystemForm.FindIconPointer();
            uint textP = SkillConfigSkillSystemForm.FindTextPointer();
            uint assignUnitP = SkillConfigSkillSystemForm.FindAssignPersonalSkillPointer();

            if (iconP == U.NOT_FOUND)
            {
                return 0;
            }
            if (textP == U.NOT_FOUND)
            {
                return 0;
            }
            if (assignUnitP == U.NOT_FOUND)
            {
                return 0;
            }


            InputFormRef InputFormRef = Init(null, assignUnitP);
            List<U.AddrResult> list = InputFormRef.MakeList();
            if (uid < 0 || uid >= list.Count)
            {
                return 0;
            }

            uint classaddr = list[(int)uid].addr;
            if (!U.isSafetyOffset(classaddr))
            {
                return 0;
            }
            uint b0 = Program.ROM.u8(classaddr);
            if (b0 <= 0)
            {
                return 0;
            }

            uint icon = Program.ROM.p32(iconP);
            uint text = Program.ROM.p32(textP);

            int skillCount = 0;
            {
                Bitmap bitmap = SkillConfigSkillSystemForm.DrawIcon((uint)b0, icon);
                U.MakeTransparent(bitmap);
                buttons[0].BackgroundImage = bitmap;
                buttons[0].Tag = b0;

                string skillCaption = SkillConfigSkillSystemForm.GetSkillText((uint)b0, text);
                tooltip.SetToolTipOverraide(buttons[skillCount], skillCaption);
            }
            skillCount++;


            //レベルアップで覚えるスキル.
            Dictionary<uint, string> skillNames = new Dictionary<uint, string>();
            InputFormRef N1_InputFormRef = N1_Init(null, skillNames);

            uint assignLevelUpP = SkillConfigSkillSystemForm.FindAssignUnitLevelUpSkillPointer();
            if (assignLevelUpP == U.NOT_FOUND)
            {//昔のバージョンには、存在しなかった
                return skillCount;
            }

            SkillAssignmentClassSkillSystemForm.MakeUnitSkillButtonsList(uid, buttons, tooltip, assignLevelUpP, icon, text, skillCount);
            return skillCount;
        }


        private void AddressList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AssignLevelUpBaseAddress == U.NOT_FOUND)
            {//昔のバージョンは、ユニット単位のレベルアップスキルは存在しなかった
                return;
            }

            uint addr = AssignLevelUpBaseAddress + (((uint)AddressList.SelectedIndex) * 4);
            uint levelupList = Program.ROM.p32(addr);
            if (!U.isSafetyOffset(levelupList))
            {
                N1_InputFormRef.ClearSelect(true);
                IndependencePanel.Visible = false;
                return;
            }

            N1_InputFormRef.ReInit(levelupList);

            //他のクラスでこのデータを参照しているならば、独立ボタンを出す.
            IndependencePanel.Visible = UpdateIndependencePanel();
            //N1の書き込みボタンが反応してしまうときがあるのでやめさせる.
            InputFormRef.WriteButtonToYellow(this.N1_WriteButton, false);

        }
        //他のクラスでこのデータを参照しているか?
        bool UpdateIndependencePanel()
        {
            return SkillAssignmentClassSkillSystemForm.UpdateIndependencePanel(this.AddressList, this.AssignLevelUpBaseAddress);
        }

        public InputFormRef N1_InputFormRef;
        static InputFormRef N1_Init(Form self, Dictionary<uint, string> skillNames)
        {
            return new InputFormRef(self
                , "N1_"
                , 0
                , 2
                , (int i, uint addr) =>
                {//読込最大値検索
                    uint a = Program.ROM.u16(addr);
                    if (a == 0xFFFF || a == 0)
                    {
                        return false;
                    }
                    return true;
                }
                , (int i, uint addr) =>
                {
                    uint skillid = Program.ROM.u8(addr + 1);
                    return U.ToHexString(skillid) + " " + U.at(skillNames, skillid);
                }
            );
        }

        private void N1_B1_ValueChanged(object sender, EventArgs e)
        {
            N1_SKILLICON.Image = SkillConfigSkillSystemForm.DrawIcon((uint)this.N1_B1.Value, this.IconBaseAddress);
            N1_SKILLTEXT.Text = SkillConfigSkillSystemForm.GetSkillText((uint)this.N1_B1.Value, this.TextBaseAddress);
            N1_SKILLNAME.Text = U.at(this.SkillNames, (uint)this.N1_B1.Value);
        }

        void N1_InputFormRef_AddressListExpandsEvent(object sender, EventArgs e)
        {
            Undo.UndoData undodata = Program.Undo.NewUndoData(this, "AssignLevelUpBase");

            InputFormRef.ExpandsEventArgs eearg = (InputFormRef.ExpandsEventArgs)e;
            uint addr = eearg.NewBaseAddress;
            int count = (int)eearg.NewDataCount;

            uint termAddr = (uint)(addr + eearg.BlockSize * (count)); //余分に確保した終端データ
            uint termData = Program.ROM.u16(termAddr);
            if ((termData != 0 && count > 1))
            {//スキルリストは特殊で終端データは、0x00 0x00 でないといけない
                //終端コードを 0x00 0x00 にする.
                Program.ROM.write_u16(termAddr, 0x0000, undodata);
            }

            //拡張したアドレスを書き込む.
            uint write_addr = AssignLevelUpBaseAddress + (((uint)AddressList.SelectedIndex) * 4);
            Program.ROM.write_p32(write_addr, addr, undodata);

            Program.Undo.Push(undodata);
        }

        private void WriteButton_Click(object sender, EventArgs e)
        {
            if (AssignLevelUpBaseAddress == U.NOT_FOUND)
            {//昔のバージョンは、ユニット単位のレベルアップスキルは存在しなかった
                return;
            }

            uint addr = (uint)N1_ReadStartAddress.Value;
            uint write_addr = AssignLevelUpBaseAddress + (((uint)AddressList.SelectedIndex) * 4);
            Program.Undo.Push("AssignLevelUpBase", write_addr, 4);

            Program.ROM.write_p32(write_addr, addr);
        }

        //Skill + テキストを書くルーチン
        Size DrawSkillAndText(ListBox lb, int index, Graphics g, Rectangle listbounds, bool isWithDraw)
        {
            return SkillAssignmentClassSkillSystemForm.DrawSkillAndText(lb, index, g, listbounds, isWithDraw, this.IconBaseAddress);
        }

        private void IndependenceButton_Click(object sender, EventArgs e)
        {
            if (this.AddressList.SelectedIndex < 0)
            {
                return;
            }
            uint unitid = (uint)U.atoh(this.AddressList.Text);
            uint unitaddr = UnitForm.GetUnitAddr(unitid);
            string name = U.ToHexString(unitid) + " " + UnitForm.GetUnitNameByAddr(unitaddr);

            uint setting = this.AssignLevelUpBaseAddress + (unitid * 4);
            if (!U.isSafetyOffset(setting))
            {
                return;
            }

            uint p = Program.ROM.p32(setting);
            if (!U.isSafetyOffset(p))
            {
                return;
            }
            if (N1_InputFormRef.BaseAddress != p)
            {
                return;
            }

            Undo.UndoData undodata = Program.Undo.NewUndoData(this, this.Name + " Independence");

            uint dataSize = (N1_InputFormRef.DataCount + 1) * N1_InputFormRef.BlockSize;
            InputFormRef.WriteIndependence(p, dataSize, setting, name, undodata);
            Program.Undo.Push(undodata);

            InputFormRef.ShowWriteNotifyAnimation(this, p);

            this.ReloadListButton.PerformClick();
            this.InputFormRef.JumpTo(unitid);
        }

    }
}
