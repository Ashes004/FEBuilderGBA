﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace FEBuilderGBA
{
    public partial class MapSettingFE6Form : Form
    {
        public MapSettingFE6Form()
        {
            InitializeComponent();

            InputFormRef.markupJumpLabel(X_MAPSTYLE_CHANGE);
            MapPictureBox.HideCommandBar();
            U.ConvertComboBox(InputFormRef.MakeTerrainSet(), ref L_18_COMBO , true);
            this.InputFormRef = Init(this);
            this.InputFormRef.MakeGeneralAddressListContextMenu(true);
        }
        private void MapSettingFE6Form_Load(object sender, EventArgs e)
        {
        }

        public InputFormRef InputFormRef;
        static InputFormRef Init(MapSettingFE6Form self)
        {
            return new InputFormRef(self
                , ""
                , Program.ROM.RomInfo.map_setting_pointer()
                , Program.ROM.RomInfo.map_setting_datasize()
                , (int i, uint addr) =>
                {
                    //0 がポインタであればデータがあると考える.
                    uint a = Program.ROM.u32(addr + 0);
                    //                    return U.isPointer(a) || a == 0;
                    return U.isPointer(a);
                }
                , (int i, uint addr) =>
                {
                    return U.ToHexString(i) + MapSettingForm.GetMapNameWhereAddr(addr);
                }
                );
        }

        private void AddressList_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint obj_plist = (uint)W4.Value;
            uint palette_plist = (uint)B6.Value;
            uint config_plist = (uint)B7.Value;
            uint mappointer_plist = (uint)B8.Value;
            MapPictureBox.LoadMap(ImageUtilMap.DrawMap(obj_plist, palette_plist, config_plist, mappointer_plist));
        }
        //全データの取得
        public static void MakeAllDataLength(List<Address> list)
        {
            string name = "MapSetting";

            InputFormRef InputFormRef = Init(null);
            FEBuilderGBA.Address.AddAddress(list, InputFormRef, name, new uint[] { 0 });

            uint addr = InputFormRef.BaseAddress;
            for (int i = 0; i < InputFormRef.DataCount; i++, addr += InputFormRef.BlockSize)
            {
                FEBuilderGBA.Address.AddCString(list
                    , addr + 0);
            }
        }

        private void W4_ValueChanged(object sender, EventArgs e)
        {
            if (InputFormRef.IsUpdateLock)
            {
                return;
            }
            AddressList_SelectedIndexChanged(sender, e);
        }

        private void X_MAPSTYLE_CHANGE_Click(object sender, EventArgs e)
        {
            MapStyleEditorAppendPopupForm f = (MapStyleEditorAppendPopupForm)InputFormRef.JumpFormLow<MapStyleEditorAppendPopupForm>();
            f.Init((uint)W4.Value, (uint)B6.Value, (uint)B7.Value, (uint)B8.Value, (uint)B9.Value, (uint)B10.Value);
            DialogResult dr = f.ShowDialog();
            if (dr != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
            W4.Value = f.GetOBJPLIST();
            B6.Value = f.GetPALPLIST();
            B7.Value = f.GetCONFIGPLIST();
            B9.Value = f.GetANIME1PLIST();
            B10.Value = f.GetANIME2PLIST();

        }
        public static void MakeTextIDArray(List<UseTextID> list)
        {
            InputFormRef InputFormRef = Init(null);
            UseTextID.AppendTextID(list, FELint.Type.MAPSETTING, InputFormRef, new uint[] { 48,50,52,60 });
        }



    }
}
