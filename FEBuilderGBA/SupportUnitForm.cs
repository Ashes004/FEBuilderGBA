﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace FEBuilderGBA
{
    public partial class SupportUnitForm : Form
    {
        public SupportUnitForm()
        {
            InitializeComponent();
            this.AddressList.OwnerDraw(ListBoxEx.DrawUnitAndText, DrawMode.OwnerDrawFixed);
            InputFormRef.markupJumpLabel(this.X_SUPPORTTALK_0);
            InputFormRef.markupJumpLabel(this.X_SUPPORTTALK_1);
            InputFormRef.markupJumpLabel(this.X_SUPPORTTALK_2);
            InputFormRef.markupJumpLabel(this.X_SUPPORTTALK_3);
            InputFormRef.markupJumpLabel(this.X_SUPPORTTALK_4);
            InputFormRef.markupJumpLabel(this.X_SUPPORTTALK_5);
            InputFormRef.markupJumpLabel(this.X_SUPPORTTALK_6);

            this.InputFormRef = Init(this);
            this.InputFormRef.AddressListExpandsEvent += SupportUnitForm.AddressListExpandsEvent;
            this.InputFormRef.PreWriteHandler += OnPreWrite;
            this.InputFormRef.MakeGeneralAddressListContextMenu(true);

            this.AutoCollectCheckbox.AccessibleDescription = R._("このチェックボックスを有効にしている場合、\r\n初期値、進行値を変更すると、\r\nその相手の初期値、進行値も自動的に調整します。\r\n(ただし、相手の支援データが存在している必要があります。)");
        }
        public void JumpToAddr(uint search_addr)
        {
            search_addr = U.toOffset(search_addr);

            uint addr = InputFormRef.BaseAddress;
            for (int i = 0; i < InputFormRef.DataCount; i++, addr += InputFormRef.BlockSize)
            {
                if (addr == search_addr)
                {
                    U.SelectedIndexSafety(this.AddressList, i);
                    X_WARNING_OWN_EXPANDS.Hide();
                    AddressListExpandsButton.Enabled = true;
                    return;
                }
            }

            //見つからなかった.
            InputFormRef.ReInit(search_addr, 1);
            U.SelectedIndexSafety(this.AddressList, 0);

            X_WARNING_OWN_EXPANDS.Show();
            AddressListExpandsButton.Enabled = false;
        }

        public InputFormRef InputFormRef;
        static InputFormRef Init(Form self)
        {
            return new InputFormRef(self
                , ""
                , Program.ROM.RomInfo.support_unit_pointer()
                , 24
                , (int i, uint addr) =>
                {//とりあえず 00 00 まで読む.
                    if (Program.ROM.u16(addr) != 0)
                    {//0ではないのでまだデータがある.
                        return true;
                    }
                    //飛び地になっていることがあるらしい.
                    //4ブロックほど検索してみる.
                    uint found_addr = addr;
                    for (int n = 0; n < 4; n++ , found_addr += 24)
                    {
                        uint uid = UnitForm.GetUnitIDWhereSupportAddr(found_addr);
                        if (uid != U.NOT_FOUND)
                        {//発見!
                            return true;
                        }
                    }
                    //見つからない.
                    return false;
                }
                , (int i, uint addr) =>
                {
                    uint uid = UnitForm.GetUnitIDWhereSupportAddr(addr);
                    if (uid == U.NOT_FOUND)
                    {
                        return "-EMPTY-";
                    }

                    return U.ToHexString(uid + 1) +
                        " " + UnitForm.GetUnitName(uid + 1);
                }
                );
        }
        private void SupportUnitForm_Load(object sender, EventArgs e)
        {
        }

        void OnPreWrite(object sender, EventArgs e)
        {
            if (! AutoCollectCheckbox.Checked)
            {
                return;
            }

            uint support_count = 0;
            if (this.B0.Value != 0) support_count++;
            if (this.B1.Value != 0) support_count++;
            if (this.B2.Value != 0) support_count++;
            if (this.B3.Value != 0) support_count++;
            if (this.B4.Value != 0) support_count++;
            if (this.B5.Value != 0) support_count++;
            if (this.B6.Value != 0) support_count++;
            this.B21.Value = support_count;

            uint uid = UnitForm.GetUnitIDWhereSupportAddr(U.toOffset((uint)this.Address.Value));
            if (uid == U.NOT_FOUND)
            {
                return;
            }
            uid++;

            Undo.UndoData undodata = Program.Undo.NewUndoData(this);
            AutoCollectByTargetSupport(uid, (uint)this.B0.Value, (uint)this.B7.Value, (uint)this.B14.Value, undodata);
            AutoCollectByTargetSupport(uid, (uint)this.B1.Value, (uint)this.B8.Value, (uint)this.B15.Value, undodata);
            AutoCollectByTargetSupport(uid, (uint)this.B2.Value, (uint)this.B9.Value, (uint)this.B16.Value, undodata);
            AutoCollectByTargetSupport(uid, (uint)this.B3.Value, (uint)this.B10.Value, (uint)this.B17.Value, undodata);
            AutoCollectByTargetSupport(uid, (uint)this.B4.Value, (uint)this.B11.Value, (uint)this.B18.Value, undodata);
            AutoCollectByTargetSupport(uid, (uint)this.B5.Value, (uint)this.B12.Value, (uint)this.B19.Value, undodata);
            AutoCollectByTargetSupport(uid, (uint)this.B6.Value, (uint)this.B13.Value, (uint)this.B20.Value, undodata);
        }

        void AutoCollectByTargetSupport(uint uid,uint target_uid, uint init_value, uint add_value, Undo.UndoData undodata)
        {
            if (target_uid == 0)
            {
                return;
            }
            uint addr = UnitForm.GetSupportAddrWhereUnitID(target_uid);
            if (addr == U.NOT_FOUND)
            {
                return ;
            }
            uint target_limit = addr + SUPPORT_LIMIT;
            for (; addr < target_limit; addr++)
            {
                uint target_uid2 = Program.ROM.u8(addr);
                if (uid != target_uid2)
                {
                    continue;
                }

                Program.ROM.write_u8(addr + SUPPORT_LIMIT , init_value,undodata);
                Program.ROM.write_u8(addr + SUPPORT_LIMIT + SUPPORT_LIMIT, add_value, undodata);
                return;
            }
        }

        void GotoSupportTalk(NumericUpDown src)
        {
            if (src.Value <= 0)
            {
                return;
            }

            uint addr = InputFormRef.SelectToAddr(AddressList);
            if (U.NOT_FOUND == addr)
            {
                return;
            }
            uint uid = UnitForm.GetUnitIDWhereSupportAddr(addr);
            if (uid == U.NOT_FOUND)
            {
                return;
            }
            uid = uid + 1;  //IDは1から降るので

            if (Program.ROM.RomInfo.version() == 8)
            {
                SupportTalkForm f = (SupportTalkForm)InputFormRef.JumpForm<SupportTalkForm>(U.NOT_FOUND);
                f.JumpTo(uid, (uint)src.Value);
            }
            else if (Program.ROM.RomInfo.version() == 7)
            {
                SupportTalkFE7Form f = (SupportTalkFE7Form)InputFormRef.JumpForm<SupportTalkFE7Form>(U.NOT_FOUND);
                f.JumpTo(uid, (uint)src.Value);
            }
            else if (Program.ROM.RomInfo.version() == 6)
            {
                SupportTalkFE6Form f = (SupportTalkFE6Form)InputFormRef.JumpForm<SupportTalkFE6Form>(U.NOT_FOUND);
                f.JumpTo(uid, (uint)src.Value);
            }
        }

        private void X_SUPPORTTALK_0_Click(object sender, EventArgs e)
        {
            GotoSupportTalk(B0);
        }

        private void X_SUPPORTTALK_1_Click(object sender, EventArgs e)
        {
            GotoSupportTalk(B1);
        }

        private void X_SUPPORTTALK_2_Click(object sender, EventArgs e)
        {
            GotoSupportTalk(B2);
        }

        private void X_SUPPORTTALK_3_Click(object sender, EventArgs e)
        {
            GotoSupportTalk(B3);
        }

        private void X_SUPPORTTALK_4_Click(object sender, EventArgs e)
        {
            GotoSupportTalk(B4);
        }

        private void X_SUPPORTTALK_5_Click(object sender, EventArgs e)
        {
            GotoSupportTalk(B5);
        }

        //支援はなぜかポインタ指定なのでユニットの支援ポインタを書き換えます。
        public static void AddressListExpandsEvent(object sender, EventArgs arg)
        {
            InputFormRef.ExpandsEventArgs eearg = (InputFormRef.ExpandsEventArgs)arg;
            uint oldaddr = eearg.OldBaseAddress;
            int oldcount = (int)eearg.OldDataCount;

            uint newaddr = eearg.NewBaseAddress;
            int newcount = (int)eearg.NewDataCount;

            //リストを縮めた場合も考慮したい.
            uint newaddr_limit =(uint)(newaddr + (eearg.BlockSize * newcount));

            List<U.AddrResult> unitlist = UnitForm.MakeUnitList();

            Undo.UndoData undodata = Program.Undo.NewUndoData("ChangeSupportPointer");
            int i ;
            for (i = 0; i < oldcount; i++)
            {
                uint support_addr = (uint)(oldaddr + (i * eearg.BlockSize));
                for (int n = 0; n < unitlist.Count; n++)
                {
                    uint addr44 = unitlist[n].addr + 44;

                    if (support_addr == Program.ROM.p32(addr44))
                    {//FE6,FE7,FE8共通で offset+44が支援ポインタ
                        uint change_addr = (uint)(newaddr + (i * eearg.BlockSize));
                        if (change_addr > newaddr_limit)
                        {//リストが縮小されたので無効化する.
                            change_addr = 0;
                        }

                        Program.ROM.write_p32(addr44, change_addr, undodata);
                    }
                }
            }
            //増えた分はわかるように設定します.
            byte[] cleadata = new byte[eearg.BlockSize];
            cleadata[0] = 0xf;
            cleadata[1] = 0xe;
            cleadata[2] = 0xe;
            cleadata[3] = 0xe;

            for (; i < newcount; i++)
            {
                uint support_addr = (uint)(newaddr + (i * eearg.BlockSize));

                //先頭2バイトでデータ生存判定をしているので、それは残す
                undodata.list.Add(new Undo.UndoPostion(support_addr, eearg.BlockSize));
                Program.ROM.write_range(support_addr, cleadata );
            }
            Program.Undo.Push(undodata);

            //リードしなおしてください.
            eearg.IsReload = true;   
        }

        //全データの取得
        public static void MakeAllDataLength(List<Address> list)
        {
            string name = "SupportUnit";
            InputFormRef InputFormRef = Init(null);
            FEBuilderGBA.Address.AddAddress(list, InputFormRef, name, new uint[] { });
        }

        const uint SUPPORT_LIMIT = 7;
        static void MakeCheckError_SelfCheck(List<FELint.ErrorSt> errors
            , uint support_addr , uint id
            , uint uid, uint target_uid, uint init_value, uint add_value)
        {
            //このユニットの支援相手が、自分に対して支援をもっているか確認します.
            uint addr = UnitForm.GetSupportAddrWhereUnitID(target_uid);
            if (addr != U.NOT_FOUND)
            {
                uint target_limit = addr + SUPPORT_LIMIT;
                for (; addr < target_limit; addr++)
                {
                    uint target_uid2 = Program.ROM.u8(addr);
                    if (uid != target_uid2)
                    {
                        continue;
                    }

                    uint init_value2 = Program.ROM.u8(addr + SUPPORT_LIMIT);
                    uint add_value2 = Program.ROM.u8(addr + SUPPORT_LIMIT + SUPPORT_LIMIT);
                    if (init_value != init_value2 || add_value != add_value2)
                    {
                        errors.Add(new FELint.ErrorSt(FELint.Type.SUPPORT_UNIT, support_addr
                            , R._("ユニット({0})->ユニット({1})へ支援と、その逆の、ユニット({1})->ユニット({0})へ支援の設定値が違います。\r\n初期値({2} vs {3})、進行度({4} vs {5})\r\n初期値と進行度は、同じ値にする必要があります。"
                            , UnitForm.GetUnitNameWithID(uid), UnitForm.GetUnitNameWithID(target_uid), init_value, init_value2, add_value, add_value2
                            )
                            , id));
                    }
                    return;
                }
            }

            errors.Add(new FELint.ErrorSt(FELint.Type.SUPPORT_UNIT, support_addr
                , R._("ユニット({0})->ユニット({1})への支援はありますが、逆に、ユニット({1})->ユニット({0})への支援がありません。"
                , UnitForm.GetUnitNameWithID(uid), UnitForm.GetUnitNameWithID(target_uid)
                )
                , id));
        }
        static void MakeCheckError_Check(List<FELint.ErrorSt> errors, uint support_addr , uint id)
        {
            uint uid = UnitForm.GetUnitIDWhereSupportAddr(support_addr);
            if (uid == U.NOT_FOUND)
            {
                return;
            }
            uid++;

            //実際の値を見る
            uint support_unit_count = 0;
            uint limit = support_addr + SUPPORT_LIMIT;
            for (uint addr = support_addr; addr < limit; addr++)
            {
                uint target_uid = Program.ROM.u8(addr);
                if (target_uid == 0)
                {
                    continue;
                }
                support_unit_count++;

                uint init_value = Program.ROM.u8(addr + SUPPORT_LIMIT);
                uint add_value  = Program.ROM.u8(addr + SUPPORT_LIMIT + SUPPORT_LIMIT);
                MakeCheckError_SelfCheck(errors, support_addr, id, uid, target_uid, init_value, add_value);

                if (target_uid > 0x45)
                {//敵ユニット支援
                    if (add_value > 0)
                    {//敵ユニット支援に進行度があるのはおかしいよ
                        errors.Add(new FELint.ErrorSt(FELint.Type.SUPPORT_UNIT, support_addr
                            , R._("ユニット({0})が、ユニット({1})への支援は、支援相手のユニットがUnitID:0x45を超えているので、敵ユニット同士の支援だと思われますが、「進行度」が({2})に設定されています。\r\n敵ユニットの支援ポイントが増えることはないので、0にするべきです。\r\n(UnitID:0x45を超えるデータに仲間になるユニットを配置してはいけません)"
                            , UnitForm.GetUnitNameWithID(uid), UnitForm.GetUnitNameWithID(target_uid), add_value
                            )
                            , id));
                    }
                }
            }
            //件数の比較
            uint all_count = Program.ROM.u8(support_addr + 0x15);
            if (all_count != support_unit_count)
            {
                errors.Add(new FELint.ErrorSt(FELint.Type.SUPPORT_UNIT, support_addr
                    , R._("ユニット({0})の支援人数が正しくありません。支援人数が{1}人なのに、実際のデータには、{2}人の支援があります。"
                    , UnitForm.GetUnitNameWithID(uid), all_count, support_unit_count
                    )
                    , id));
            }
        }
        public static void MakeCheckError(List<FELint.ErrorSt> errors)
        {
            InputFormRef InputFormRef = Init(null);
            uint support_addr = InputFormRef.BaseAddress;
            for (int i = 0; i < InputFormRef.DataCount; i++, support_addr += InputFormRef.BlockSize)
            {
                uint id = (uint)i;

                //支援人数が正しいかチェック
                MakeCheckError_Check(errors, support_addr, id);
            }
        } 
    }
}
