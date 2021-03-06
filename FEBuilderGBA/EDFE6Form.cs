﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace FEBuilderGBA
{
    public partial class EDFE6Form : Form
    {
        public EDFE6Form()
        {
            InitializeComponent();

            this.N2_AddressList.OwnerDraw(ListBoxEx.DrawUnitAndText, DrawMode.OwnerDrawFixed);
            this.N2_InputFormRef = N2_Init(this);

            this.N2_InputFormRef.MakeGeneralAddressListContextMenu(true);
        }


        InputFormRef N2_InputFormRef;
        static InputFormRef N2_Init(Form self)
        {
            return new InputFormRef(self
                , "N2_"
                , Program.ROM.RomInfo.ed_3a_pointer()
                , 8
                , (int i, uint addr) =>
                {
                    if (i == 0)
                    {
                        return true;
                    }
                    return Program.ROM.u16(addr) != 0x00;
                }
                , (int i, uint addr) =>
                {
                    uint uid1 = (uint)i;
                    return U.ToHexString(uid1) + " " + UnitForm.GetUnitName(uid1);
                }
                );
        }

        private void EDFE6Form_Load(object sender, EventArgs e)
        {
        }
        //全データの取得
        public static void MakeAllDataLength(List<Address> list)
        {
            string name = "EDFE6Form";
            {
                InputFormRef InputFormRef = N2_Init(null);
                FEBuilderGBA.Address.AddAddress(list, InputFormRef, name, new uint[] { });
            }
        }
        public static void MakeTextIDArray(List<UseTextID> list)
        {
            {
                InputFormRef InputFormRef = N2_Init(null);
                UseTextID.AppendTextID(list, FELint.Type.ED, InputFormRef, new uint[] { 0 ,2 , 4, 6 });
            }
        }
    }
}
