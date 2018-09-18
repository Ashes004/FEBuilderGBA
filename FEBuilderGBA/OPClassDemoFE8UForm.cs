﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace FEBuilderGBA
{
    public partial class OPClassDemoFE8UForm : Form
    {
        public OPClassDemoFE8UForm()
        {
            InitializeComponent();

            this.AddressList.OwnerDraw(ListBoxEx.DrawClassAndText, DrawMode.OwnerDrawFixed);

            this.InputFormRef = Init(this);
            this.InputFormRef.MakeGeneralAddressListContextMenu(true);
            this.N2_InputFormRef = N2_Init(this);
        }
        public InputFormRef InputFormRef;
        static InputFormRef Init(Form self)
        {
            return new InputFormRef(self
                , ""
                , Program.ROM.RomInfo.op_class_demo_pointer()
                , 20
                , (int i, uint addr) =>
                {
                    return Program.ROM.u32(addr)<= 0xffff;
                }
                , (int i, uint addr) =>
                {
                    uint cid = Program.ROM.u8(addr+5);
                    return U.ToHexString(cid) + " " + ClassForm.GetClassName(cid);
                }
                );
        }
        InputFormRef N2_InputFormRef;
        static InputFormRef N2_Init(Form self)
        {
            return new InputFormRef(self
                , "N2_"
                , 0
                , 6
                , (int i, uint addr) =>
                {
                    return i < 1; //1つだけ
                        ;
                }
                , (int i, uint addr) =>
                {
                    return U.ToHexString(i);
                }
                );
        }

        private void OPClassDemoFE8UForm_Load(object sender, EventArgs e)
        {

        }

        private void P16_ValueChanged(object sender, EventArgs e)
        {
            N2_InputFormRef.ReInit((uint)this.P16.Value);
        }

        public static List<U.AddrResult> MakeList()
        {
            InputFormRef InputFormRef = Init(null);
            return InputFormRef.MakeList();
        }
        //全データの取得
        public static void MakeAllDataLength(List<Address> list)
        {
            {
                InputFormRef InputFormRef = Init(null);
                FEBuilderGBA.Address.AddAddress(list, InputFormRef, "OPClassDemo", new uint[] { 16});

                uint addr = InputFormRef.BaseAddress;
                for (int i = 0; i < InputFormRef.DataCount; i++, addr += InputFormRef.BlockSize)
                {
                    FEBuilderGBA.Address.AddCString(list, 0 + addr);

                    uint anime = Program.ROM.p32(addr + 16);
                    if (!U.isSafetyOffset(anime))
                    {
                        continue;
                    }

                    InputFormRef N2_InputFormRef = N2_Init(null);
                    N2_InputFormRef.ReInitPointer(addr + 16);
                    FEBuilderGBA.Address.AddAddress(list, N2_InputFormRef, "OPClassDemo_Anime", new uint[] { });
                }
            }
        }
        public static void MakeTextIDArray(List<TextID> list)
        {
            InputFormRef InputFormRef = Init(null);
            TextID.AppendTextID(list, FELint.Type.OP_CLASS_DEMO, InputFormRef, new uint[] { 0 });
        }


    }
}
