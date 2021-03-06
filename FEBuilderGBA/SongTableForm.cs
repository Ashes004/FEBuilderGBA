﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace FEBuilderGBA
{
    public partial class SongTableForm : Form
    {
        public SongTableForm()
        {
            InitializeComponent();
            this.InputFormRef = Init(this);
            this.InputFormRef.MakeGeneralAddressListContextMenu(true);
            this.InputFormRef.UseWriteProtectionID00 = true; //ID:0x00を書き込み禁止
//            this.Icon = Properties.Resources.icon_music;
        }

        public InputFormRef InputFormRef;
        static InputFormRef Init(Form self)
        {
            return new InputFormRef(self
                , ""
                , Program.ROM.RomInfo.sound_table_pointer()
                , 8
                , (int i, uint addr) =>
                {//読込最大値検索
                    return U.isPointer(Program.ROM.u32(addr));
                }
                , (int i, uint addr) =>
                {
                    return U.ToHexString(i) + " " + GetSongNameFast((uint) i , addr);
                }
                );
        }

        private void SongTableForm_Load(object sender, EventArgs e)
        {
            //アイテムアイコン拡張を表示するかどうか
            if (IsShowSongTableExetdns(this.AddressList.Items.Count))
            {
                AddressListExpandsButton_32766.Show();
            }
            else
            {
                this.AddressList.Height += AddressListExpandsButton_32766.Height;
                AddressListExpandsButton_32766.Hide();
            }
        }

        public static string GetSongName(uint song_id)
        {
            InputFormRef InputFormRef = Init(null);

            uint addr = InputFormRef.IDToAddr(song_id);
            return GetSongNameFast(song_id, addr);
        }

        //名前の取得   アドレスを指定できるので、早く取得できる 
        public static string GetSongNameFast(uint song_id, uint addr)
        {
            string emptyTrackMessage = "";
            if (IsEmptyTrack(song_id,addr))
            {
                emptyTrackMessage = R._("[空きトラック]");
            }

            string name = SoundRoomForm.GetSongNameWhereSongID(song_id);
            if (name != "")
            {
                return name.Trim() + InputFormRef.GetCommentSA(addr) + U.SA(emptyTrackMessage);
            }
            //サウンドルームにない音楽はSEだろうから、SE Listから検索する.
            return U.at(SoundEffectList, song_id) + InputFormRef.GetCommentSA(addr) + U.SA(emptyTrackMessage);
        }

        static bool IsEmptyTrack(uint song_id , uint addr)
        {
            if (song_id == 0 || song_id >= 0x7FF)
            {//特殊指定。空きではないことにする
                return false;
            }

            uint songTrack = Program.ROM.p32(addr+0);
            if (songTrack == 0)
            {//空き
                return true;
            }
            if (!U.isSafetyOffset(songTrack))
            {//空きではないが変なデータ
                return false;
            }
            uint trackCount = Program.ROM.u8(songTrack);
            if (trackCount == 0)
            {//トラック数 ゼロ
                return true;
            }
            //空きではない.
            return false;
        }

        public static uint GetSongAddr(uint song_id)
        {
            InputFormRef InputFormRef = Init(null);
            return InputFormRef.IDToAddr(song_id);
        }

        public static List<U.AddrResult> MakeItemList()
        {
            InputFormRef InputFormRef = Init(null);
            return InputFormRef.MakeList();
        }

        private void SONGPLAY_Click(object sender, EventArgs e)
        {
            MainFormUtil.RunAsSappy((uint)AddressList.SelectedIndex);
        }


        static Dictionary<uint, string> SoundEffectList;
        public static void PreLoadResource(string fullfilename)
        {
            SoundEffectList = U.LoadDicResource(fullfilename);
        }

        public static string GetC85SoundEffect(uint command)
        {
            string need = "@C85_" + U.ToHexString(command);

            StringBuilder sb = new StringBuilder();
            foreach (var pair in SoundEffectList)
            {
                if (pair.Value.IndexOf(need) >= 0)
                {
                    sb.AppendLine(U.ToHexString(pair.Key) + "=" + pair.Value);
                }
            }
            return sb.ToString();
        }

        public static string GetErrorMessage(uint song_id,string type)
        {
            if (type == "")
            {
                return "";
            }

            if (song_id == 0 || song_id == 0xFFFF)
            {
                return "";
            }

            uint addr = GetSongAddr(song_id);
            if (addr == U.NOT_FOUND)
            {
                return "";
            }
            uint playerType = Program.ROM.u32(addr + 4);
            if (type == "MAP")
            {
                if (playerType == 0x00010001)
                {
                    return ""; //OK
                }
                return R._("警告\r\nマップで再生する音楽は、SongTableのPriority(PlayerType)で、0x00010001を指定する必要があります。\r\n現在の設定:{0}", U.To0xHexString(playerType));
            }
            else if (type == "SFX")
            {
                if (playerType >= 0x00030003)
                {
                    return ""; //OK
                }
                return R._("警告\r\n効果音で利用する音楽は、SongTableのPriority(PlayerType)で、0x00030003より大きい値を指定する必要があります。\r\n現在の設定:{0}", U.To0xHexString(playerType));
            }
            return "";
        }

        //全データの取得
        public static void MakeAllDataLength(List<Address> list)
        {
            string selfname = "SongTable";
            InputFormRef InputFormRef = Init(null);

            FEBuilderGBA.Address.AddAddress(list, InputFormRef, selfname, new uint[] { 0 });
            uint songpointer = InputFormRef.BaseAddress;
            for (int i = 0; i < InputFormRef.DataCount; i++, songpointer += InputFormRef.BlockSize)
            {
                uint songaddr = Program.ROM.p32(songpointer);
                if (!U.isSafetyOffset(songaddr))
                {
                    continue;
                }

                {//楽譜
                    string name = "Song" + U.ToHexString(i) + " ";
                    //リサイクルで回収できるので、仮にこのデータをリサイクルするとしたら、どうなるだけ求める(実際にリサイクルはしない)
                    SongUtil.RecycleOldSong(ref list, name, songpointer);
                }

                uint instpointer = songaddr + 4;
                //uint instaddr = Program.ROM.p32(instpointer);
                {//楽器
                    string name = "SongInst" + U.ToHexString(i) + " ";
                    SongInstrumentForm.RecycleOldInstrument(ref list, name, instpointer);
                }
            }
        }
        //SongHeaderアドレスから曲名への逆変換
        public static string GetSongNameWhereSongHeader(uint headerAddr)
        {
            headerAddr = U.toOffset(headerAddr);

            InputFormRef InputFormRef = Init(null);
            uint songpointer = InputFormRef.BaseAddress;
            for (uint i = 0; i < InputFormRef.DataCount; i++, songpointer += InputFormRef.BlockSize)
            {
                uint songaddr = Program.ROM.p32(songpointer);
                if (songaddr == headerAddr)
                {
                    return U.ToHexString(i) + " " +GetSongNameFast(i, songpointer);
                }
            }
            return "";
        }

        public static void ReloadList()
        {
            SongTableForm f = (SongTableForm)InputFormRef.GetForm<SongTableForm>();
            if (f == null)
            {//ウィンドウを開いていない
                return;
            }

            int selectedIndex = f.AddressList.SelectedIndex;
            f.ReloadListButton.PerformClick();
            f.AddressList.SelectedIndex = selectedIndex;
        }

        bool IsShowSongTableExetdns(int count)
        {
            if (OptionForm.show_song_table_extends() == OptionForm.show_extends_enum.Show)
            {//表示する設定の場合は表示する.
                return true;
            }

            uint addr = Program.ROM.u32(Program.ROM.RomInfo.sound_table_pointer());
            if (addr < Program.ROM.RomInfo.extends_address())
            {//拡張されていないので表示しない
                return false;
            }
            //拡張されているので表示する
            return true;
        }
    }
}
