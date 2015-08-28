using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using WOWItemMaker;
using Microsoft.Win32;
using System.Xml;

namespace WOWItemMaker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ConnInfo.SaveConnInfo)
            {
                bool ContinueSave = false;
                do
                {
                    try
                    {
                        SaveConnInfoXml();
                    }
                    catch (Exception err)
                    {
                        DialogResult re = MessageBox.Show("连接信息保存失败", "连接信息", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                        if (re == DialogResult.Abort)
                        {
                            e.Cancel = true;
                            ContinueSave = false;
                        }
                        else if (re == DialogResult.Retry)
                            ContinueSave = true;
                        else if (re == DialogResult.Ignore)
                            ContinueSave = false;
                    }
                } while (ContinueSave);
            }
            else
            {
                if(File.Exists("Data\\ConnInfo.cfg"))
                    File.Delete("Data\\ConnInfo.cfg");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FrmGetSql f2 = new FrmGetSql();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ConnInfo.HostName = "LocalHost";
            ConnInfo.SaveConnInfo = false;
            ConnInfo.SavePwd = false;
            bool ContinueLoad = false;
            do
            {
                try
                {
                    this.LoadConnInfoXml();
                }
                catch (Exception err)
                {
                    DialogResult re = MessageBox.Show("由于以下原因连接信息没有成功读取:" + err.Message, "连接信息", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (re == DialogResult.Retry)
                        ContinueLoad = true;
                    else if (re == DialogResult.Cancel)
                        ContinueLoad = false;
                }
            } while (ContinueLoad);
            GetList();
            SetConn sc = new SetConn();
            sc.ShowDialog();
            if (ConnInfo.Dbstruct == "3.0.X")
            {
                dmg_min3TextBox.Enabled = true;
                dmg_max3TextBox.Enabled = true;
                dmg_type3List.Enabled = true;
                dmg_min4TextBox.Enabled = true;
                dmg_max4TextBox.Enabled = true;
                dmg_type4List.Enabled = true;
                dmg_min5TextBox.Enabled = true;
                dmg_max5TextBox.Enabled = true;
                dmg_type5List.Enabled = true;
                FactionTextBox.Enabled = false;
                HolidayIDTextBox.Enabled = false;
            }
            else if (ConnInfo.Dbstruct == "3.1.X")
            {
                dmg_min3TextBox.Enabled = false;
                dmg_max3TextBox.Enabled = false;
                dmg_type3List.Enabled = false;
                dmg_min4TextBox.Enabled = false;
                dmg_max4TextBox.Enabled = false;
                dmg_type4List.Enabled = false;
                dmg_min5TextBox.Enabled = false;
                dmg_max5TextBox.Enabled = false;
                dmg_type5List.Enabled = false;
                FactionTextBox.Enabled = false;
                HolidayIDTextBox.Enabled = false;
            }
            else if (ConnInfo.Dbstruct == "3.2.X")
            {
                dmg_min3TextBox.Enabled = false;
                dmg_max3TextBox.Enabled = false;
                dmg_type3List.Enabled = false;
                dmg_min4TextBox.Enabled = false;
                dmg_max4TextBox.Enabled = false;
                dmg_type4List.Enabled = false;
                dmg_min5TextBox.Enabled = false;
                dmg_max5TextBox.Enabled = false;
                dmg_type5List.Enabled = false;
                FactionTextBox.Enabled = true;
                HolidayIDTextBox.Enabled = false;
            }
            else if (ConnInfo.Dbstruct == "3.3.X")
            {
                dmg_min3TextBox.Enabled = false;
                dmg_max3TextBox.Enabled = false;
                dmg_type3List.Enabled = false;
                dmg_min4TextBox.Enabled = false;
                dmg_max4TextBox.Enabled = false;
                dmg_type4List.Enabled = false;
                dmg_min5TextBox.Enabled = false;
                dmg_max5TextBox.Enabled = false;
                dmg_type5List.Enabled = false;
                FactionTextBox.Enabled = true;
                HolidayIDTextBox.Enabled = true;
            }
            if (ConnInfo.Stat)
            {
                ConnStat.Text = ConnInfo.UserName + "@" + ConnInfo.HostName;
                if (ConnInfo.DataBase != "")
                {
                    ConnStat.Text += " → " + ConnInfo.DataBase;
                }
                ConnStat.Text += "(" + ConnInfo.Dbstruct + ")";
            }
            else
            {
                ConnStat.Text = "未连接";
            }
        }
        public void GetList()
        {
            Regex reg = new Regex("\r\n");
            try
            {
                StreamReader classTXT = new StreamReader("Data\\class.txt");
                string[] EveryLine = reg.Split(classTXT.ReadToEnd());
                classTXT.Close();
                ItemClassList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    ItemClassList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader subclassTXT = new StreamReader("Data\\subclass0.txt");
                string[] EveryLine = reg.Split(subclassTXT.ReadToEnd());
                subclassTXT.Close();
                ItemSubClassList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    ItemSubClassList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader socketColorTXT = new StreamReader("Data\\socketColor.txt");
                string[] EveryLine = reg.Split(socketColorTXT.ReadToEnd());
                socketColorTXT.Close();
                SocketColor_1List.Items.Clear();
                SocketColor_2List.Items.Clear();
                SocketColor_3List.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    SocketColor_1List.Items.Add(Line);
                    SocketColor_2List.Items.Add(Line);
                    SocketColor_3List.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader socketBonusTXT = new StreamReader("Data\\socketBonus.txt");
                string[] EveryLine = reg.Split(socketBonusTXT.ReadToEnd());
                socketBonusTXT.Close();
                SocketBonusList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    SocketBonusList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader QualityTXT = new StreamReader("Data\\Quality.txt");
                string[] EveryLine = reg.Split(QualityTXT.ReadToEnd());
                QualityTXT.Close();
                QualityList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    QualityList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader MapTXT = new StreamReader("Data\\map.txt");
                string[] EveryLine = reg.Split(MapTXT.ReadToEnd());
                MapTXT.Close();
                MapList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    MapList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader AreaTXT = new StreamReader("Data\\area.txt");
                string[] EveryLine = reg.Split(AreaTXT.ReadToEnd());
                AreaTXT.Close();
                AreaList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    AreaList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader AllowableClassTXT = new StreamReader("Data\\AllowableClass.txt");
                string[] EveryLine = reg.Split(AllowableClassTXT.ReadToEnd());
                AllowableClassTXT.Close();
                AllowableClassList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    AllowableClassList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader spellidTXT = new StreamReader("Data\\spellid.txt");
                string[] EveryLine = reg.Split(spellidTXT.ReadToEnd());
                spellidTXT.Close();
                spellid_1List.Items.Clear();
                spellid_2List.Items.Clear();
                spellid_3List.Items.Clear();
                spellid_4List.Items.Clear();
                spellid_5List.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    spellid_1List.Items.Add(Line);
                    spellid_2List.Items.Add(Line);
                    spellid_3List.Items.Add(Line);
                    spellid_4List.Items.Add(Line);
                    spellid_5List.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader spelltriggerTXT = new StreamReader("Data\\spelltrigger.txt");
                string[] EveryLine = reg.Split(spelltriggerTXT.ReadToEnd());
                spelltriggerTXT.Close();
                spelltrigger_1List.Items.Clear();
                spelltrigger_2List.Items.Clear();
                spelltrigger_3List.Items.Clear();
                spelltrigger_4List.Items.Clear();
                spelltrigger_5List.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    spelltrigger_1List.Items.Add(Line);
                    spelltrigger_2List.Items.Add(Line);
                    spelltrigger_3List.Items.Add(Line);
                    spelltrigger_4List.Items.Add(Line);
                    spelltrigger_5List.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader bondingTXT = new StreamReader("Data\\bonding.txt");
                string[] EveryLine = reg.Split(bondingTXT.ReadToEnd());
                bondingTXT.Close();
                BondingList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    BondingList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }

            try
            {
                StreamReader sheathTXT = new StreamReader("Data\\sheath.txt");
                string[] EveryLine = reg.Split(sheathTXT.ReadToEnd());
                sheathTXT.Close();
                SheathList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    SheathList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader RandomPropertyTXT = new StreamReader("Data\\RandomProperty.txt");
                string[] EveryLine = reg.Split(RandomPropertyTXT.ReadToEnd());
                RandomPropertyTXT.Close();
                RandomPropertyList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    RandomPropertyList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader RandomSuffixTXT = new StreamReader("Data\\RandomSuffix.txt");
                string[] EveryLine = reg.Split(RandomSuffixTXT.ReadToEnd());
                RandomSuffixTXT.Close();
                RandomSuffixList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    RandomSuffixList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader InventoryTypeTXT = new StreamReader("Data\\InventoryType.txt");
                string[] EveryLine = reg.Split(InventoryTypeTXT.ReadToEnd());
                InventoryTypeTXT.Close();
                InventoryTypeList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    InventoryTypeList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader ammo_typeTXT = new StreamReader("Data\\ammo_type.txt");
                string[] EveryLine = reg.Split(ammo_typeTXT.ReadToEnd());
                ammo_typeTXT.Close();
                Ammo_TypeList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    Ammo_TypeList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader MaterialTXT = new StreamReader("Data\\Material.txt");
                string[] EveryLine = reg.Split(MaterialTXT.ReadToEnd());
                MaterialTXT.Close();
                MaterialList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    MaterialList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader FlagsTXT = new StreamReader("Data\\Flags.txt");
                string[] EveryLine = reg.Split(FlagsTXT.ReadToEnd());
                FlagsTXT.Close();
                FlagsList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    FlagsList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader AllowableRaceTXT = new StreamReader("Data\\AllowableRace.txt");
                string[] EveryLine = reg.Split(AllowableRaceTXT.ReadToEnd());
                AllowableRaceTXT.Close();
                AllowableRaceList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    AllowableRaceList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader dmg_typeTXT = new StreamReader("Data\\dmg_type.txt");
                string[] EveryLine = reg.Split(dmg_typeTXT.ReadToEnd());
                dmg_typeTXT.Close();
                dmg_type1List.Items.Clear();
                dmg_type2List.Items.Clear();
                dmg_type3List.Items.Clear();
                dmg_type4List.Items.Clear();
                dmg_type5List.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    dmg_type1List.Items.Add(Line);
                    dmg_type2List.Items.Add(Line);
                    dmg_type3List.Items.Add(Line);
                    dmg_type4List.Items.Add(Line);
                    dmg_type5List.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader stat_typeTXT = new StreamReader("Data\\stat_type.txt");
                string[] EveryLine = reg.Split(stat_typeTXT.ReadToEnd());
                stat_typeTXT.Close();
                Stat_Type1List.Items.Clear();
                Stat_Type2List.Items.Clear();
                Stat_Type3List.Items.Clear();
                Stat_Type4List.Items.Clear();
                Stat_Type5List.Items.Clear();
                Stat_Type6List.Items.Clear();
                Stat_Type7List.Items.Clear();
                Stat_Type8List.Items.Clear();
                Stat_Type9List.Items.Clear();
                Stat_Type10List.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    Stat_Type1List.Items.Add(Line);
                    Stat_Type2List.Items.Add(Line);
                    Stat_Type3List.Items.Add(Line);
                    Stat_Type4List.Items.Add(Line);
                    Stat_Type5List.Items.Add(Line);
                    Stat_Type6List.Items.Add(Line);
                    Stat_Type7List.Items.Add(Line);
                    Stat_Type8List.Items.Add(Line);
                    Stat_Type9List.Items.Add(Line);
                    Stat_Type10List.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
            try
            {
                StreamReader displayidTXT = new StreamReader("Data\\displayid.txt");
                string[] EveryLine = reg.Split(displayidTXT.ReadToEnd());
                displayidTXT.Close();
                DisplayIDList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    DisplayIDList.Items.Add(Line);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误");
            }
        }

        private void ItemClssList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string SubClassNum = GetValue("[0-9]+",ItemClassList.Text);
                Regex reg = new Regex("\r\n");
                StreamReader subclassTXT = new StreamReader("Data\\subclass" + SubClassNum + ".txt");
                string[] EveryLine = reg.Split(subclassTXT.ReadToEnd());
                subclassTXT.Close();
                ItemSubClassList.Items.Clear();
                foreach (string Line in EveryLine)
                {
                    ItemSubClassList.Items.Add(Line);
                }
                ItemSubClassList.Text = ItemSubClassList.Items[0].ToString();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"错误");
                ItemSubClassList.DropDownStyle = ComboBoxStyle.DropDown;
            }
        }

        public string GetValue(string pattern, string TextBox)
        {
            string re = null;
            try
            {
                Regex TestReg = new Regex(pattern);
                Match MatchResault = TestReg.Match(TextBox);
                re = MatchResault.Value;
            }
            catch
            {
                re = null;
            }
            return re;
        }

        public string GetAddSql()
        {
            string Entry =GetValue("[1-9]{1}[0-9]+",EntryTextBox.Text);
            string Class = GetValue("[0-9]+", ItemClassList.Text);
            string SubClass = GetValue("[0-9]+", ItemSubClassList.Text);
            string unk0 = unk0TextBox.Text;
            string Name = RTB_ItemName.ColorText.Replace("'", "''");
            string DisplayID = GetValue("[0-9]+", DisplayIDList.Text);
            string Quality = GetValue("[0-9]+", QualityList.Text);
            string Flags = GetValue("[0-9]+", FlagsList.Text);
            string Faction = GetValue("(-[0-9]+)|([0-9]+)", FactionTextBox.Text);
            string BuyCount = GetValue("[0-9]+", BuyCountTextBox.Text);
            string BuyPrice = GetValue("[0-9]+", BuyPriceTextBox.Text);
            string SellPrice = GetValue("[0-9]+", SellPriceTextBox.Text);
            string InventoryType = GetValue("[0-9]+", InventoryTypeList.Text);
            string AllowableClass = GetValue("(-[0-9]+)|([0-9]+)", AllowableClassList.Text);
            string AllowableRace = GetValue("(-[0-9]+)|([0-9]+)", AllowableRaceList.Text);
            string ItemLevel = GetValue("[0-9]+", ItemLevelTextBox.Text);
            string RequiredLevel = GetValue("[0-9]+", RequiredLevelTextBox.Text);
            string RequiredSkill = GetValue("[0-9]+", RequiredSkillTextBox.Text);
            string RequiredSkillRank = GetValue("[0-9]+", RequiredSkillRankTextBox.Text);
            string RequiredSpell = GetValue("[0-9]+", RequiredSpellTextBox.Text);
            string RequiredHonnorRank = GetValue("[0-9]+", RequiredHonnorRankTextBox.Text);
            string RequiredCityRank = GetValue("[0-9]+", RequiredCityRankTextBox.Text);
            string RequiredReputationFaction = GetValue("[0-9]+", RequiredReputationFactionTextBox.Text);
            string RequiredReputationRank = GetValue("[0-9]+", RequiredReputationRankTextBox.Text);
            string MaxCount = GetValue("[0-9]+", maxcountTextBox.Text);
            string StackAble = GetValue("[0-9]+", StackAbleTextBox.Text);
            string ContainerSlots = GetValue("[0-9]+", ContainerSlotsTextBox.Text);
            string StatsCount = GetValue("[0-9]+", StatsCountList.Text);
            string Stat_Type1 = GetValue("[0-9]+", Stat_Type1List.Text);
            string Stat_Type2 = GetValue("[0-9]+", Stat_Type2List.Text);
            string Stat_Type3 = GetValue("[0-9]+", Stat_Type3List.Text);
            string Stat_Type4 = GetValue("[0-9]+", Stat_Type4List.Text);
            string Stat_Type5 = GetValue("[0-9]+", Stat_Type5List.Text);
            string Stat_Type6 = GetValue("[0-9]+", Stat_Type6List.Text);
            string Stat_Type7 = GetValue("[0-9]+", Stat_Type7List.Text);
            string Stat_Type8 = GetValue("[0-9]+", Stat_Type8List.Text);
            string Stat_Type9 = GetValue("[0-9]+", Stat_Type9List.Text);
            string Stat_Type10 = GetValue("[0-9]+", Stat_Type10List.Text);
            string Stat_Value1 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value1TextBox.Text);
            string Stat_Value2 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value2TextBox.Text);
            string Stat_Value3 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value3TextBox.Text);
            string Stat_Value4 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value4TextBox.Text);
            string Stat_Value5 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value5TextBox.Text);
            string Stat_Value6 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value6TextBox.Text);
            string Stat_Value7 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value7TextBox.Text);
            string Stat_Value8 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value8TextBox.Text);
            string Stat_Value9 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value9TextBox.Text);
            string Stat_Value10 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value10TextBox.Text);
            string ScalingStatDistribution = ScalingStatDistributionTextBox.Text;
            string ScalingStatValue = ScalingStatValueTextBox.Text;
            string Dmg_Min1 = GetValue("[0-9]+", dmg_min1TextBox.Text);
            string Dmg_Min2 = GetValue("[0-9]+", dmg_min2TextBox.Text);
            string Dmg_Min3 = GetValue("[0-9]+", dmg_min3TextBox.Text);
            string Dmg_Min4 = GetValue("[0-9]+", dmg_min4TextBox.Text);
            string Dmg_Min5 = GetValue("[0-9]+", dmg_min5TextBox.Text);
            string Dmg_Max1 = GetValue("[0-9]+", dmg_max1TextBox.Text);
            string Dmg_Max2 = GetValue("[0-9]+", dmg_max2TextBox.Text);
            string Dmg_Max3 = GetValue("[0-9]+", dmg_max3TextBox.Text);
            string Dmg_Max4 = GetValue("[0-9]+", dmg_max4TextBox.Text);
            string Dmg_Max5 = GetValue("[0-9]+", dmg_max5TextBox.Text);
            string Dmg_Type1 = GetValue("[0-9]+", dmg_type1List.Text);
            string Dmg_Type2 = GetValue("[0-9]+", dmg_type2List.Text);
            string Dmg_Type3 = GetValue("[0-9]+", dmg_type3List.Text);
            string Dmg_Type4 = GetValue("[0-9]+", dmg_type4List.Text);
            string Dmg_Type5 = GetValue("[0-9]+", dmg_type5List.Text);
            string Armor = GetValue("(-[0-9]+)|([0-9]+)", armorTextBox.Text);
            string Holy_Res = GetValue("(-[0-9]+)|([0-9]+)", holy_resTextBox.Text);
            string Fire_Res = GetValue("(-[0-9]+)|([0-9]+)", fire_resTextBox.Text);
            string Nature_Res = GetValue("(-[0-9]+)|([0-9]+)", nature_resTextBox.Text);
            string Frost_Res = GetValue("(-[0-9]+)|([0-9]+)", frost_resTextBox.Text);
            string Shadow_Res = GetValue("(-[0-9]+)|([0-9]+)", shadow_resTextBox.Text);
            string Arcane_Res = GetValue("(-[0-9]+)|([0-9]+)", arcane_resTextBox.Text);
            string Delay = GetValue("[0-9]+", delayTextBox.Text);
            string Ammo_Type = GetValue("[0-9]+", Ammo_TypeList.Text);
            string RangedModRange = RangedModRangeTextBox.Text;
            string SpellID_1 = GetValue("[0-9]+", spellid_1List.Text);
            string SpellID_2 = GetValue("[0-9]+", spellid_2List.Text);
            string SpellID_3 = GetValue("[0-9]+", spellid_3List.Text);
            string SpellID_4 = GetValue("[0-9]+", spellid_4List.Text);
            string SpellID_5 = GetValue("[0-9]+", spellid_5List.Text);
            string SpellTrigger_1 = GetValue("[0-9]+", spelltrigger_1List.Text);
            string SpellTrigger_2 = GetValue("[0-9]+", spelltrigger_2List.Text);
            string SpellTrigger_3 = GetValue("[0-9]+", spelltrigger_3List.Text);
            string SpellTrigger_4 = GetValue("[0-9]+", spelltrigger_4List.Text);
            string SpellTrigger_5 = GetValue("[0-9]+", spelltrigger_5List.Text);
            string SpellCharges_1 = SpellCharges_1TextBox.Text;
            string SpellCharges_2 = SpellCharges_2TextBox.Text;
            string SpellCharges_3 = SpellCharges_3TextBox.Text;
            string SpellCharges_4 = SpellCharges_4TextBox.Text;
            string SpellCharges_5 = SpellCharges_5TextBox.Text;
            string SpellppmRate_1 = SpellppmRate_1TextBox.Text;
            string SpellppmRate_2 = SpellppmRate_2TextBox.Text;
            string SpellppmRate_3 = SpellppmRate_3TextBox.Text;
            string SpellppmRate_4 = SpellppmRate_4TextBox.Text;
            string SpellppmRate_5 = SpellppmRate_5TextBox.Text;
            string SpellCooldown_1 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_1TextBox.Text);
            string SpellCooldown_2 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_2TextBox.Text);
            string SpellCooldown_3 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_3TextBox.Text);
            string SpellCooldown_4 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_4TextBox.Text);
            string SpellCooldown_5 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_5TextBox.Text);
            string SpellCategory_1 = SpellCategory_1TextBox.Text;
            string SpellCategory_2 = SpellCategory_2TextBox.Text;
            string SpellCategory_3 = SpellCategory_3TextBox.Text;
            string SpellCategory_4 = SpellCategory_4TextBox.Text;
            string SpellCategory_5 = SpellCategory_5TextBox.Text;
            string SpellCategoryCooldown_1 = SpellCategoryCooldown_1TextBox.Text;
            string SpellCategoryCooldown_2 = SpellCategoryCooldown_2TextBox.Text;
            string SpellCategoryCooldown_3 = SpellCategoryCooldown_3TextBox.Text;
            string SpellCategoryCooldown_4 = SpellCategoryCooldown_4TextBox.Text;
            string SpellCategoryCooldown_5 = SpellCategoryCooldown_5TextBox.Text;
            string Bonding = GetValue("[0-9]+", BondingList.Text);
            string Description = RTB_Description.ColorText.Replace("'", "''");
            string PageText = GetValue("[0-9]+", PageTextTextBox.Text);
            string LanguageID = GetValue("[0-9]+", LanguageIDTextBox.Text);
            string PageMeterial = GetValue("[0-9]+", PageMeterialTextBox.Text);
            string StartQuest = GetValue("[0-9]+", StartQuestTextBox.Text);
            string LockID = GetValue("[0-9]+", LockIdTextBox.Text);
            string Material = GetValue("[0-9]+", MaterialList.Text);
            string Sheath = GetValue("[0-9]+", SheathList.Text);
            string RandomProperty = GetValue("[0-9]+", RandomPropertyList.Text);
            string RandomSuffix = GetValue("[0-9]+", RandomSuffixList.Text);
            string Block = GetValue("[0-9]+", blockTextBox.Text);
            string ItemSet = GetValue("[0-9]+", ItemSetTextBox.Text);
            string MaxDurability = GetValue("[0-9]+", MaxDurabilityTextBox.Text);
            string Area = GetValue("[0-9]+", AreaList.Text);
            string Map = GetValue("[0-9]+", MapList.Text);
            string BagFamily = BagFamilyTextBox.Text;
            string TotemCategory = TotemCategoryTextBox.Text;
            string SocketColor_1 = GetValue("[0-9]+", SocketColor_1List.Text);
            string SocketColor_2 = GetValue("[0-9]+", SocketColor_2List.Text);
            string SocketColor_3 = GetValue("[0-9]+", SocketColor_3List.Text);
            string SocketContent_1 = SocketContent_1TextBox.Text;
            string SocketContent_2 = SocketContent_2TextBox.Text;
            string SocketContent_3 = SocketContent_3TextBox.Text;
            string SocketBonus = GetValue("[0-9]+", SocketBonusList.Text);
            string GemProperties = GemPropertiesTextBox.Text;
            string RequiredDisenchantSkill = RequiredDisenchantSkillTextBox.Text;
            string ArmorDamageModifier = ArmorDamageModifierTextBox.Text;
            string Duration = DurationTextBox.Text;
            string ItemLimitCategory = ItemLimitCategoryTextBox.Text;
            string HolidayId = GetValue("[0-9]+", HolidayIDTextBox.Text);
            string ScriptName = ScriptNameTextBox.Text.Replace("'", "''");
            string DisenchantID = DisenchantIDTextBox.Text;
            string FoodType = FoodTypeTextBox.Text;
            string MinMoneyLoot = MinMoneyLootTextBox.Text;
            string MaxMoneyLoot = MaxMoneyLootTextBox.Text;
            string SQL = string.Empty;
            if (ConnInfo.Dbstruct == "3.0.X")
            {
                SQL = "insert into item_template (entry,class,subclass,unk0,name,displayid,Quality,Flags,BuyCount,BuyPrice,SellPrice,InventoryType,AllowableClass,AllowableRace,ItemLevel,RequiredLevel,RequiredSkill,RequiredSkillRank,requiredspell,requiredhonorrank,RequiredCityRank,RequiredReputationFaction,RequiredReputationRank,maxcount,stackable,ContainerSlots,StatsCount,stat_type1,stat_value1,stat_type2,stat_value2,stat_type3,stat_value3,stat_type4,stat_value4,stat_type5,stat_value5,stat_type6,stat_value6,stat_type7,stat_value7,stat_type8,stat_value8,stat_type9,stat_value9,stat_type10,stat_value10,ScalingStatDistribution,ScalingStatValue,dmg_min1,dmg_max1,dmg_type1,dmg_min2,dmg_max2,dmg_type2,dmg_min3,dmg_max3,dmg_type3,dmg_min4,dmg_max4,dmg_type4,dmg_min5,dmg_max5,dmg_type5,armor,holy_res,fire_res,nature_res,frost_res,shadow_res,arcane_res,delay,ammo_type,RangedModRange,spellid_1,spelltrigger_1,spellcharges_1,spellppmRate_1,spellcooldown_1,spellcategory_1,spellcategorycooldown_1,spellid_2,spelltrigger_2,spellcharges_2,spellppmRate_2,spellcooldown_2,spellcategory_2,spellcategorycooldown_2,spellid_3,spelltrigger_3,spellcharges_3,spellppmRate_3,spellcooldown_3,spellcategory_3,spellcategorycooldown_3,spellid_4,spelltrigger_4,spellcharges_4,spellppmRate_4,spellcooldown_4,spellcategory_4,spellcategorycooldown_4,spellid_5,spelltrigger_5,spellcharges_5,spellppmRate_5,spellcooldown_5,spellcategory_5,spellcategorycooldown_5,bonding,description,PageText,LanguageID,PageMaterial,startquest,lockid,Material,sheath,RandomProperty,RandomSuffix,block,itemset,MaxDurability,area,Map,BagFamily,TotemCategory,socketColor_1,socketContent_1,socketColor_2,socketContent_2,socketColor_3,socketContent_3,socketBonus,GemProperties,RequiredDisenchantSkill,ArmorDamageModifier,Duration,ItemLimitCategory,ScriptName,DisenchantID,FoodType,minMoneyLoot,maxMoneyLoot) values('" + Entry + "','" + Class + "','" + SubClass + "','" + unk0 + "','" + Name + "','" + DisplayID + "','" + Quality + "','" + Flags + "','"  + BuyCount + "','" + BuyPrice + "','" + SellPrice + "','" + InventoryType + "','" + AllowableClass + "','" + AllowableRace + "','" + ItemLevel + "','" + RequiredLevel + "','" + RequiredSkill + "','" + RequiredSkillRank + "','" + RequiredSpell + "','" + RequiredHonnorRank + "','" + RequiredCityRank + "','" + RequiredReputationFaction + "','" + RequiredReputationRank + "','" + MaxCount + "','" + StackAble + "','" + ContainerSlots + "','" + StatsCount + "','" + Stat_Type1 + "','" + Stat_Value1 + "','" + Stat_Type2 + "','" + Stat_Value2 + "','" + Stat_Type3 + "','" + Stat_Value3 + "','" + Stat_Type4 + "','" + Stat_Value4 + "','" + Stat_Type5 + "','" + Stat_Value5 + "','" + Stat_Type6 + "','" + Stat_Value6 + "','" + Stat_Type7 + "','" + Stat_Value7 + "','" + Stat_Type8 + "','" + Stat_Value8 + "','" + Stat_Type9 + "','" + Stat_Value9 + "','" + Stat_Type10 + "','" + Stat_Value10 + "','" + ScalingStatDistribution + "','" + ScalingStatValue + "','" + Dmg_Min1 + "','" + Dmg_Max1 + "','" + Dmg_Type1 + "','" + Dmg_Min2 + "','" + Dmg_Max2 + "','" + Dmg_Type2 + "','" + Dmg_Min3 + "','" + Dmg_Max3 + "','" + Dmg_Type3 + "','" + Dmg_Min4 + "','" + Dmg_Max4 + "','" + Dmg_Type4 + "','" + Dmg_Min5 + "','" + Dmg_Max5 + "','" + Dmg_Type5 + "','" + Armor + "','" + Holy_Res + "','" + Fire_Res + "','" + Nature_Res + "','" + Frost_Res + "','" + Shadow_Res + "','" + Arcane_Res + "','" + Delay + "','" + Ammo_Type + "','" + RangedModRange + "','" + SpellID_1 + "','" + SpellTrigger_1 + "','" + SpellCharges_1 + "','" + SpellppmRate_1 + "','" + SpellCooldown_1 + "','" + SpellCategory_1 + "','" + SpellCategoryCooldown_1 + "','" + SpellID_2 + "','" + SpellTrigger_2 + "','" + SpellCharges_2 + "','" + SpellppmRate_2 + "','" + SpellCooldown_2 + "','" + SpellCategory_2 + "','" + SpellCategoryCooldown_2 + "','" + SpellID_3 + "','" + SpellTrigger_3 + "','" + SpellCharges_3 + "','" + SpellppmRate_3 + "','" + SpellCooldown_3 + "','" + SpellCategory_3 + "','" + SpellCategoryCooldown_3 + "','" + SpellID_4 + "','" + SpellTrigger_4 + "','" + SpellCharges_4 + "','" + SpellppmRate_4 + "','" + SpellCooldown_4 + "','" + SpellCategory_4 + "','" + SpellCategoryCooldown_4 + "','" + SpellID_5 + "','" + SpellTrigger_5 + "','" + SpellCharges_5 + "','" + SpellppmRate_5 + "','" + SpellCooldown_5 + "','" + SpellCategory_5 + "','" + SpellCategoryCooldown_5 + "','" + Bonding + "','" + Description + "','" + PageText + "','" + LanguageID + "','" + PageMeterial + "','" + StartQuest + "','" + LockID + "','" + Material + "','" + Sheath + "','" + RandomProperty + "','" + RandomSuffix + "','" + Block + "','" + ItemSet + "','" + MaxDurability + "','" + Area + "','" + Map + "','" + BagFamily + "','" + TotemCategory + "','" + SocketColor_1 + "','" + SocketContent_1 + "','" + SocketColor_2 + "','" + SocketContent_2 + "','" + SocketColor_3 + "','" + SocketContent_3 + "','" + SocketBonus + "','" + GemProperties + "','" + RequiredDisenchantSkill + "','" + ArmorDamageModifier + "','" + Duration + "','" + ItemLimitCategory + "','" + ScriptName + "','" + DisenchantID + "','" + FoodType + "','" + MinMoneyLoot + "','" + MaxMoneyLoot + "');";
            }
            else if (ConnInfo.Dbstruct == "3.1.X")
            {
                SQL = "insert into item_template (entry,class,subclass,unk0,name,displayid,Quality,Flags,BuyCount,BuyPrice,SellPrice,InventoryType,AllowableClass,AllowableRace,ItemLevel,RequiredLevel,RequiredSkill,RequiredSkillRank,requiredspell,requiredhonorrank,RequiredCityRank,RequiredReputationFaction,RequiredReputationRank,maxcount,stackable,ContainerSlots,StatsCount,stat_type1,stat_value1,stat_type2,stat_value2,stat_type3,stat_value3,stat_type4,stat_value4,stat_type5,stat_value5,stat_type6,stat_value6,stat_type7,stat_value7,stat_type8,stat_value8,stat_type9,stat_value9,stat_type10,stat_value10,ScalingStatDistribution,ScalingStatValue,dmg_min1,dmg_max1,dmg_type1,dmg_min2,dmg_max2,dmg_type2,armor,holy_res,fire_res,nature_res,frost_res,shadow_res,arcane_res,delay,ammo_type,RangedModRange,spellid_1,spelltrigger_1,spellcharges_1,spellppmRate_1,spellcooldown_1,spellcategory_1,spellcategorycooldown_1,spellid_2,spelltrigger_2,spellcharges_2,spellppmRate_2,spellcooldown_2,spellcategory_2,spellcategorycooldown_2,spellid_3,spelltrigger_3,spellcharges_3,spellppmRate_3,spellcooldown_3,spellcategory_3,spellcategorycooldown_3,spellid_4,spelltrigger_4,spellcharges_4,spellppmRate_4,spellcooldown_4,spellcategory_4,spellcategorycooldown_4,spellid_5,spelltrigger_5,spellcharges_5,spellppmRate_5,spellcooldown_5,spellcategory_5,spellcategorycooldown_5,bonding,description,PageText,LanguageID,PageMaterial,startquest,lockid,Material,sheath,RandomProperty,RandomSuffix,block,itemset,MaxDurability,area,Map,BagFamily,TotemCategory,socketColor_1,socketContent_1,socketColor_2,socketContent_2,socketColor_3,socketContent_3,socketBonus,GemProperties,RequiredDisenchantSkill,ArmorDamageModifier,Duration,ItemLimitCategory,ScriptName,DisenchantID,FoodType,minMoneyLoot,maxMoneyLoot) values('" + Entry + "','" + Class + "','" + SubClass + "','" + unk0 + "','" + Name + "','" + DisplayID + "','" + Quality + "','" + Flags + "','" + BuyCount + "','" + BuyPrice + "','" + SellPrice + "','" + InventoryType + "','" + AllowableClass + "','" + AllowableRace + "','" + ItemLevel + "','" + RequiredLevel + "','" + RequiredSkill + "','" + RequiredSkillRank + "','" + RequiredSpell + "','" + RequiredHonnorRank + "','" + RequiredCityRank + "','" + RequiredReputationFaction + "','" + RequiredReputationRank + "','" + MaxCount + "','" + StackAble + "','" + ContainerSlots + "','" + StatsCount + "','" + Stat_Type1 + "','" + Stat_Value1 + "','" + Stat_Type2 + "','" + Stat_Value2 + "','" + Stat_Type3 + "','" + Stat_Value3 + "','" + Stat_Type4 + "','" + Stat_Value4 + "','" + Stat_Type5 + "','" + Stat_Value5 + "','" + Stat_Type6 + "','" + Stat_Value6 + "','" + Stat_Type7 + "','" + Stat_Value7 + "','" + Stat_Type8 + "','" + Stat_Value8 + "','" + Stat_Type9 + "','" + Stat_Value9 + "','" + Stat_Type10 + "','" + Stat_Value10 + "','" + ScalingStatDistribution + "','" + ScalingStatValue + "','" + Dmg_Min1 + "','" + Dmg_Max1 + "','" + Dmg_Type1 + "','" + Dmg_Min2 + "','" + Dmg_Max2 + "','" + Dmg_Type2 + "','" + Armor + "','" + Holy_Res + "','" + Fire_Res + "','" + Nature_Res + "','" + Frost_Res + "','" + Shadow_Res + "','" + Arcane_Res + "','" + Delay + "','" + Ammo_Type + "','" + RangedModRange + "','" + SpellID_1 + "','" + SpellTrigger_1 + "','" + SpellCharges_1 + "','" + SpellppmRate_1 + "','" + SpellCooldown_1 + "','" + SpellCategory_1 + "','" + SpellCategoryCooldown_1 + "','" + SpellID_2 + "','" + SpellTrigger_2 + "','" + SpellCharges_2 + "','" + SpellppmRate_2 + "','" + SpellCooldown_2 + "','" + SpellCategory_2 + "','" + SpellCategoryCooldown_2 + "','" + SpellID_3 + "','" + SpellTrigger_3 + "','" + SpellCharges_3 + "','" + SpellppmRate_3 + "','" + SpellCooldown_3 + "','" + SpellCategory_3 + "','" + SpellCategoryCooldown_3 + "','" + SpellID_4 + "','" + SpellTrigger_4 + "','" + SpellCharges_4 + "','" + SpellppmRate_4 + "','" + SpellCooldown_4 + "','" + SpellCategory_4 + "','" + SpellCategoryCooldown_4 + "','" + SpellID_5 + "','" + SpellTrigger_5 + "','" + SpellCharges_5 + "','" + SpellppmRate_5 + "','" + SpellCooldown_5 + "','" + SpellCategory_5 + "','" + SpellCategoryCooldown_5 + "','" + Bonding + "','" + Description + "','" + PageText + "','" + LanguageID + "','" + PageMeterial + "','" + StartQuest + "','" + LockID + "','" + Material + "','" + Sheath + "','" + RandomProperty + "','" + RandomSuffix + "','" + Block + "','" + ItemSet + "','" + MaxDurability + "','" + Area + "','" + Map + "','" + BagFamily + "','" + TotemCategory + "','" + SocketColor_1 + "','" + SocketContent_1 + "','" + SocketColor_2 + "','" + SocketContent_2 + "','" + SocketColor_3 + "','" + SocketContent_3 + "','" + SocketBonus + "','" + GemProperties + "','" + RequiredDisenchantSkill + "','" + ArmorDamageModifier + "','" + Duration + "','" + ItemLimitCategory + "','" + ScriptName + "','" + DisenchantID + "','" + FoodType + "','" + MinMoneyLoot + "','" + MaxMoneyLoot + "');";
            }
            else if (ConnInfo.Dbstruct == "3.2.X")
            {
                SQL = "insert into item_template (entry,class,subclass,unk0,name,displayid,Quality,Flags,Faction,BuyCount,BuyPrice,SellPrice,InventoryType,AllowableClass,AllowableRace,ItemLevel,RequiredLevel,RequiredSkill,RequiredSkillRank,requiredspell,requiredhonorrank,RequiredCityRank,RequiredReputationFaction,RequiredReputationRank,maxcount,stackable,ContainerSlots,StatsCount,stat_type1,stat_value1,stat_type2,stat_value2,stat_type3,stat_value3,stat_type4,stat_value4,stat_type5,stat_value5,stat_type6,stat_value6,stat_type7,stat_value7,stat_type8,stat_value8,stat_type9,stat_value9,stat_type10,stat_value10,ScalingStatDistribution,ScalingStatValue,dmg_min1,dmg_max1,dmg_type1,dmg_min2,dmg_max2,dmg_type2,armor,holy_res,fire_res,nature_res,frost_res,shadow_res,arcane_res,delay,ammo_type,RangedModRange,spellid_1,spelltrigger_1,spellcharges_1,spellppmRate_1,spellcooldown_1,spellcategory_1,spellcategorycooldown_1,spellid_2,spelltrigger_2,spellcharges_2,spellppmRate_2,spellcooldown_2,spellcategory_2,spellcategorycooldown_2,spellid_3,spelltrigger_3,spellcharges_3,spellppmRate_3,spellcooldown_3,spellcategory_3,spellcategorycooldown_3,spellid_4,spelltrigger_4,spellcharges_4,spellppmRate_4,spellcooldown_4,spellcategory_4,spellcategorycooldown_4,spellid_5,spelltrigger_5,spellcharges_5,spellppmRate_5,spellcooldown_5,spellcategory_5,spellcategorycooldown_5,bonding,description,PageText,LanguageID,PageMaterial,startquest,lockid,Material,sheath,RandomProperty,RandomSuffix,block,itemset,MaxDurability,area,Map,BagFamily,TotemCategory,socketColor_1,socketContent_1,socketColor_2,socketContent_2,socketColor_3,socketContent_3,socketBonus,GemProperties,RequiredDisenchantSkill,ArmorDamageModifier,Duration,ItemLimitCategory,ScriptName,DisenchantID,FoodType,minMoneyLoot,maxMoneyLoot) values('" + Entry + "','" + Class + "','" + SubClass + "','" + unk0 + "','" + Name + "','" + DisplayID + "','" + Quality + "','" + Flags + "','" + Faction + "','" + BuyCount + "','" + BuyPrice + "','" + SellPrice + "','" + InventoryType + "','" + AllowableClass + "','" + AllowableRace + "','" + ItemLevel + "','" + RequiredLevel + "','" + RequiredSkill + "','" + RequiredSkillRank + "','" + RequiredSpell + "','" + RequiredHonnorRank + "','" + RequiredCityRank + "','" + RequiredReputationFaction + "','" + RequiredReputationRank + "','" + MaxCount + "','" + StackAble + "','" + ContainerSlots + "','" + StatsCount + "','" + Stat_Type1 + "','" + Stat_Value1 + "','" + Stat_Type2 + "','" + Stat_Value2 + "','" + Stat_Type3 + "','" + Stat_Value3 + "','" + Stat_Type4 + "','" + Stat_Value4 + "','" + Stat_Type5 + "','" + Stat_Value5 + "','" + Stat_Type6 + "','" + Stat_Value6 + "','" + Stat_Type7 + "','" + Stat_Value7 + "','" + Stat_Type8 + "','" + Stat_Value8 + "','" + Stat_Type9 + "','" + Stat_Value9 + "','" + Stat_Type10 + "','" + Stat_Value10 + "','" + ScalingStatDistribution + "','" + ScalingStatValue + "','" + Dmg_Min1 + "','" + Dmg_Max1 + "','" + Dmg_Type1 + "','" + Dmg_Min2 + "','" + Dmg_Max2 + "','" + Dmg_Type2 + "','" + Armor + "','" + Holy_Res + "','" + Fire_Res + "','" + Nature_Res + "','" + Frost_Res + "','" + Shadow_Res + "','" + Arcane_Res + "','" + Delay + "','" + Ammo_Type + "','" + RangedModRange + "','" + SpellID_1 + "','" + SpellTrigger_1 + "','" + SpellCharges_1 + "','" + SpellppmRate_1 + "','" + SpellCooldown_1 + "','" + SpellCategory_1 + "','" + SpellCategoryCooldown_1 + "','" + SpellID_2 + "','" + SpellTrigger_2 + "','" + SpellCharges_2 + "','" + SpellppmRate_2 + "','" + SpellCooldown_2 + "','" + SpellCategory_2 + "','" + SpellCategoryCooldown_2 + "','" + SpellID_3 + "','" + SpellTrigger_3 + "','" + SpellCharges_3 + "','" + SpellppmRate_3 + "','" + SpellCooldown_3 + "','" + SpellCategory_3 + "','" + SpellCategoryCooldown_3 + "','" + SpellID_4 + "','" + SpellTrigger_4 + "','" + SpellCharges_4 + "','" + SpellppmRate_4 + "','" + SpellCooldown_4 + "','" + SpellCategory_4 + "','" + SpellCategoryCooldown_4 + "','" + SpellID_5 + "','" + SpellTrigger_5 + "','" + SpellCharges_5 + "','" + SpellppmRate_5 + "','" + SpellCooldown_5 + "','" + SpellCategory_5 + "','" + SpellCategoryCooldown_5 + "','" + Bonding + "','" + Description + "','" + PageText + "','" + LanguageID + "','" + PageMeterial + "','" + StartQuest + "','" + LockID + "','" + Material + "','" + Sheath + "','" + RandomProperty + "','" + RandomSuffix + "','" + Block + "','" + ItemSet + "','" + MaxDurability + "','" + Area + "','" + Map + "','" + BagFamily + "','" + TotemCategory + "','" + SocketColor_1 + "','" + SocketContent_1 + "','" + SocketColor_2 + "','" + SocketContent_2 + "','" + SocketColor_3 + "','" + SocketContent_3 + "','" + SocketBonus + "','" + GemProperties + "','" + RequiredDisenchantSkill + "','" + ArmorDamageModifier + "','" + Duration + "','" + ItemLimitCategory + "','" + ScriptName + "','" + DisenchantID + "','" + FoodType + "','" + MinMoneyLoot + "','" + MaxMoneyLoot + "');";
            }
            else if (ConnInfo.Dbstruct == "3.3.X")
            {
                SQL = "insert into item_template (entry,class,subclass,unk0,name,displayid,Quality,Flags,Faction,BuyCount,BuyPrice,SellPrice,InventoryType,AllowableClass,AllowableRace,ItemLevel,RequiredLevel,RequiredSkill,RequiredSkillRank,requiredspell,requiredhonorrank,RequiredCityRank,RequiredReputationFaction,RequiredReputationRank,maxcount,stackable,ContainerSlots,StatsCount,stat_type1,stat_value1,stat_type2,stat_value2,stat_type3,stat_value3,stat_type4,stat_value4,stat_type5,stat_value5,stat_type6,stat_value6,stat_type7,stat_value7,stat_type8,stat_value8,stat_type9,stat_value9,stat_type10,stat_value10,ScalingStatDistribution,ScalingStatValue,dmg_min1,dmg_max1,dmg_type1,dmg_min2,dmg_max2,dmg_type2,armor,holy_res,fire_res,nature_res,frost_res,shadow_res,arcane_res,delay,ammo_type,RangedModRange,spellid_1,spelltrigger_1,spellcharges_1,spellppmRate_1,spellcooldown_1,spellcategory_1,spellcategorycooldown_1,spellid_2,spelltrigger_2,spellcharges_2,spellppmRate_2,spellcooldown_2,spellcategory_2,spellcategorycooldown_2,spellid_3,spelltrigger_3,spellcharges_3,spellppmRate_3,spellcooldown_3,spellcategory_3,spellcategorycooldown_3,spellid_4,spelltrigger_4,spellcharges_4,spellppmRate_4,spellcooldown_4,spellcategory_4,spellcategorycooldown_4,spellid_5,spelltrigger_5,spellcharges_5,spellppmRate_5,spellcooldown_5,spellcategory_5,spellcategorycooldown_5,bonding,description,PageText,LanguageID,PageMaterial,startquest,lockid,Material,sheath,RandomProperty,RandomSuffix,block,itemset,MaxDurability,area,Map,BagFamily,TotemCategory,socketColor_1,socketContent_1,socketColor_2,socketContent_2,socketColor_3,socketContent_3,socketBonus,GemProperties,RequiredDisenchantSkill,ArmorDamageModifier,Duration,ItemLimitCategory,HolidayId,ScriptName,DisenchantID,FoodType,minMoneyLoot,maxMoneyLoot) values('" + Entry + "','" + Class + "','" + SubClass + "','" + unk0 + "','" + Name + "','" + DisplayID + "','" + Quality + "','" + Flags + "','" + Faction + "','" + BuyCount + "','" + BuyPrice + "','" + SellPrice + "','" + InventoryType + "','" + AllowableClass + "','" + AllowableRace + "','" + ItemLevel + "','" + RequiredLevel + "','" + RequiredSkill + "','" + RequiredSkillRank + "','" + RequiredSpell + "','" + RequiredHonnorRank + "','" + RequiredCityRank + "','" + RequiredReputationFaction + "','" + RequiredReputationRank + "','" + MaxCount + "','" + StackAble + "','" + ContainerSlots + "','" + StatsCount + "','" + Stat_Type1 + "','" + Stat_Value1 + "','" + Stat_Type2 + "','" + Stat_Value2 + "','" + Stat_Type3 + "','" + Stat_Value3 + "','" + Stat_Type4 + "','" + Stat_Value4 + "','" + Stat_Type5 + "','" + Stat_Value5 + "','" + Stat_Type6 + "','" + Stat_Value6 + "','" + Stat_Type7 + "','" + Stat_Value7 + "','" + Stat_Type8 + "','" + Stat_Value8 + "','" + Stat_Type9 + "','" + Stat_Value9 + "','" + Stat_Type10 + "','" + Stat_Value10 + "','" + ScalingStatDistribution + "','" + ScalingStatValue + "','" + Dmg_Min1 + "','" + Dmg_Max1 + "','" + Dmg_Type1 + "','" + Dmg_Min2 + "','" + Dmg_Max2 + "','" + Dmg_Type2 + "','" + Armor + "','" + Holy_Res + "','" + Fire_Res + "','" + Nature_Res + "','" + Frost_Res + "','" + Shadow_Res + "','" + Arcane_Res + "','" + Delay + "','" + Ammo_Type + "','" + RangedModRange + "','" + SpellID_1 + "','" + SpellTrigger_1 + "','" + SpellCharges_1 + "','" + SpellppmRate_1 + "','" + SpellCooldown_1 + "','" + SpellCategory_1 + "','" + SpellCategoryCooldown_1 + "','" + SpellID_2 + "','" + SpellTrigger_2 + "','" + SpellCharges_2 + "','" + SpellppmRate_2 + "','" + SpellCooldown_2 + "','" + SpellCategory_2 + "','" + SpellCategoryCooldown_2 + "','" + SpellID_3 + "','" + SpellTrigger_3 + "','" + SpellCharges_3 + "','" + SpellppmRate_3 + "','" + SpellCooldown_3 + "','" + SpellCategory_3 + "','" + SpellCategoryCooldown_3 + "','" + SpellID_4 + "','" + SpellTrigger_4 + "','" + SpellCharges_4 + "','" + SpellppmRate_4 + "','" + SpellCooldown_4 + "','" + SpellCategory_4 + "','" + SpellCategoryCooldown_4 + "','" + SpellID_5 + "','" + SpellTrigger_5 + "','" + SpellCharges_5 + "','" + SpellppmRate_5 + "','" + SpellCooldown_5 + "','" + SpellCategory_5 + "','" + SpellCategoryCooldown_5 + "','" + Bonding + "','" + Description + "','" + PageText + "','" + LanguageID + "','" + PageMeterial + "','" + StartQuest + "','" + LockID + "','" + Material + "','" + Sheath + "','" + RandomProperty + "','" + RandomSuffix + "','" + Block + "','" + ItemSet + "','" + MaxDurability + "','" + Area + "','" + Map + "','" + BagFamily + "','" + TotemCategory + "','" + SocketColor_1 + "','" + SocketContent_1 + "','" + SocketColor_2 + "','" + SocketContent_2 + "','" + SocketColor_3 + "','" + SocketContent_3 + "','" + SocketBonus + "','" + GemProperties + "','" + RequiredDisenchantSkill + "','" + ArmorDamageModifier + "','" + Duration + "','" + ItemLimitCategory + "','" + HolidayId + "','" + ScriptName + "','" + DisenchantID + "','" + FoodType + "','" + MinMoneyLoot + "','" + MaxMoneyLoot + "');";
            }
            else if (ConnInfo.Dbstruct == "真爱XV")
            {
                SQL = "insert into item_template (entry,class,subclass,unk0,name,displayid,Quality,Flags,FlagsExtra,BuyCount,BuyPrice,SellPrice,InventoryType,AllowableClass,AllowableRace,ItemLevel,RequiredLevel,RequiredSkill,RequiredSkillRank,requiredspell,requiredhonorrank,RequiredCityRank,RequiredReputationFaction,RequiredReputationRank,maxcount,stackable,ContainerSlots,StatsCount,stat_type1,stat_value1,stat_type2,stat_value2,stat_type3,stat_value3,stat_type4,stat_value4,stat_type5,stat_value5,stat_type6,stat_value6,stat_type7,stat_value7,stat_type8,stat_value8,stat_type9,stat_value9,stat_type10,stat_value10,ScalingStatDistribution,ScalingStatValue,dmg_min1,dmg_max1,dmg_type1,dmg_min2,dmg_max2,dmg_type2,armor,holy_res,fire_res,nature_res,frost_res,shadow_res,arcane_res,delay,ammo_type,RangedModRange,spellid_1,spelltrigger_1,spellcharges_1,spellppmRate_1,spellcooldown_1,spellcategory_1,spellcategorycooldown_1,spellid_2,spelltrigger_2,spellcharges_2,spellppmRate_2,spellcooldown_2,spellcategory_2,spellcategorycooldown_2,spellid_3,spelltrigger_3,spellcharges_3,spellppmRate_3,spellcooldown_3,spellcategory_3,spellcategorycooldown_3,spellid_4,spelltrigger_4,spellcharges_4,spellppmRate_4,spellcooldown_4,spellcategory_4,spellcategorycooldown_4,spellid_5,spelltrigger_5,spellcharges_5,spellppmRate_5,spellcooldown_5,spellcategory_5,spellcategorycooldown_5,bonding,description,PageText,LanguageID,PageMaterial,startquest,lockid,Material,sheath,RandomProperty,RandomSuffix,block,itemset,MaxDurability,area,Map,BagFamily,TotemCategory,socketColor_1,socketContent_1,socketColor_2,socketContent_2,socketColor_3,socketContent_3,socketBonus,GemProperties,RequiredDisenchantSkill,ArmorDamageModifier,Duration,ItemLimitCategory,HolidayId,ScriptName,DisenchantID,FoodType,minMoneyLoot,maxMoneyLoot) values('" + Entry + "','" + Class + "','" + SubClass + "','" + unk0 + "','" + Name + "','" + DisplayID + "','" + Quality + "','" + Flags + "','" + Faction + "','" + BuyCount + "','" + BuyPrice + "','" + SellPrice + "','" + InventoryType + "','" + AllowableClass + "','" + AllowableRace + "','" + ItemLevel + "','" + RequiredLevel + "','" + RequiredSkill + "','" + RequiredSkillRank + "','" + RequiredSpell + "','" + RequiredHonnorRank + "','" + RequiredCityRank + "','" + RequiredReputationFaction + "','" + RequiredReputationRank + "','" + MaxCount + "','" + StackAble + "','" + ContainerSlots + "','" + StatsCount + "','" + Stat_Type1 + "','" + Stat_Value1 + "','" + Stat_Type2 + "','" + Stat_Value2 + "','" + Stat_Type3 + "','" + Stat_Value3 + "','" + Stat_Type4 + "','" + Stat_Value4 + "','" + Stat_Type5 + "','" + Stat_Value5 + "','" + Stat_Type6 + "','" + Stat_Value6 + "','" + Stat_Type7 + "','" + Stat_Value7 + "','" + Stat_Type8 + "','" + Stat_Value8 + "','" + Stat_Type9 + "','" + Stat_Value9 + "','" + Stat_Type10 + "','" + Stat_Value10 + "','" + ScalingStatDistribution + "','" + ScalingStatValue + "','" + Dmg_Min1 + "','" + Dmg_Max1 + "','" + Dmg_Type1 + "','" + Dmg_Min2 + "','" + Dmg_Max2 + "','" + Dmg_Type2 + "','" + Armor + "','" + Holy_Res + "','" + Fire_Res + "','" + Nature_Res + "','" + Frost_Res + "','" + Shadow_Res + "','" + Arcane_Res + "','" + Delay + "','" + Ammo_Type + "','" + RangedModRange + "','" + SpellID_1 + "','" + SpellTrigger_1 + "','" + SpellCharges_1 + "','" + SpellppmRate_1 + "','" + SpellCooldown_1 + "','" + SpellCategory_1 + "','" + SpellCategoryCooldown_1 + "','" + SpellID_2 + "','" + SpellTrigger_2 + "','" + SpellCharges_2 + "','" + SpellppmRate_2 + "','" + SpellCooldown_2 + "','" + SpellCategory_2 + "','" + SpellCategoryCooldown_2 + "','" + SpellID_3 + "','" + SpellTrigger_3 + "','" + SpellCharges_3 + "','" + SpellppmRate_3 + "','" + SpellCooldown_3 + "','" + SpellCategory_3 + "','" + SpellCategoryCooldown_3 + "','" + SpellID_4 + "','" + SpellTrigger_4 + "','" + SpellCharges_4 + "','" + SpellppmRate_4 + "','" + SpellCooldown_4 + "','" + SpellCategory_4 + "','" + SpellCategoryCooldown_4 + "','" + SpellID_5 + "','" + SpellTrigger_5 + "','" + SpellCharges_5 + "','" + SpellppmRate_5 + "','" + SpellCooldown_5 + "','" + SpellCategory_5 + "','" + SpellCategoryCooldown_5 + "','" + Bonding + "','" + Description + "','" + PageText + "','" + LanguageID + "','" + PageMeterial + "','" + StartQuest + "','" + LockID + "','" + Material + "','" + Sheath + "','" + RandomProperty + "','" + RandomSuffix + "','" + Block + "','" + ItemSet + "','" + MaxDurability + "','" + Area + "','" + Map + "','" + BagFamily + "','" + TotemCategory + "','" + SocketColor_1 + "','" + SocketContent_1 + "','" + SocketColor_2 + "','" + SocketContent_2 + "','" + SocketColor_3 + "','" + SocketContent_3 + "','" + SocketBonus + "','" + GemProperties + "','" + RequiredDisenchantSkill + "','" + ArmorDamageModifier + "','" + Duration + "','" + ItemLimitCategory + "','" + HolidayId + "','" + ScriptName + "','" + DisenchantID + "','" + FoodType + "','" + MinMoneyLoot + "','" + MaxMoneyLoot + "');";
            }
            else if (ConnInfo.Dbstruct == "3.3.5")
            {
                SQL = "insert into item_template (entry,class,subclass,unk0,name,displayid,Quality,Flags,Flags2,BuyCount,BuyPrice,SellPrice,InventoryType,AllowableClass,AllowableRace,ItemLevel,RequiredLevel,RequiredSkill,RequiredSkillRank,requiredspell,requiredhonorrank,RequiredCityRank,RequiredReputationFaction,RequiredReputationRank,maxcount,stackable,ContainerSlots,StatsCount,stat_type1,stat_value1,stat_type2,stat_value2,stat_type3,stat_value3,stat_type4,stat_value4,stat_type5,stat_value5,stat_type6,stat_value6,stat_type7,stat_value7,stat_type8,stat_value8,stat_type9,stat_value9,stat_type10,stat_value10,ScalingStatDistribution,ScalingStatValue,dmg_min1,dmg_max1,dmg_type1,dmg_min2,dmg_max2,dmg_type2,armor,holy_res,fire_res,nature_res,frost_res,shadow_res,arcane_res,delay,ammo_type,RangedModRange,spellid_1,spelltrigger_1,spellcharges_1,spellppmRate_1,spellcooldown_1,spellcategory_1,spellcategorycooldown_1,spellid_2,spelltrigger_2,spellcharges_2,spellppmRate_2,spellcooldown_2,spellcategory_2,spellcategorycooldown_2,spellid_3,spelltrigger_3,spellcharges_3,spellppmRate_3,spellcooldown_3,spellcategory_3,spellcategorycooldown_3,spellid_4,spelltrigger_4,spellcharges_4,spellppmRate_4,spellcooldown_4,spellcategory_4,spellcategorycooldown_4,spellid_5,spelltrigger_5,spellcharges_5,spellppmRate_5,spellcooldown_5,spellcategory_5,spellcategorycooldown_5,bonding,description,PageText,LanguageID,PageMaterial,startquest,lockid,Material,sheath,RandomProperty,RandomSuffix,block,itemset,MaxDurability,area,Map,BagFamily,TotemCategory,socketColor_1,socketContent_1,socketColor_2,socketContent_2,socketColor_3,socketContent_3,socketBonus,GemProperties,RequiredDisenchantSkill,ArmorDamageModifier,Duration,ItemLimitCategory,HolidayId,ScriptName,DisenchantID,FoodType,minMoneyLoot,maxMoneyLoot) values('" + Entry + "','" + Class + "','" + SubClass + "','" + unk0 + "','" + Name + "','" + DisplayID + "','" + Quality + "','" + Flags + "','" + Faction + "','" + BuyCount + "','" + BuyPrice + "','" + SellPrice + "','" + InventoryType + "','" + AllowableClass + "','" + AllowableRace + "','" + ItemLevel + "','" + RequiredLevel + "','" + RequiredSkill + "','" + RequiredSkillRank + "','" + RequiredSpell + "','" + RequiredHonnorRank + "','" + RequiredCityRank + "','" + RequiredReputationFaction + "','" + RequiredReputationRank + "','" + MaxCount + "','" + StackAble + "','" + ContainerSlots + "','" + StatsCount + "','" + Stat_Type1 + "','" + Stat_Value1 + "','" + Stat_Type2 + "','" + Stat_Value2 + "','" + Stat_Type3 + "','" + Stat_Value3 + "','" + Stat_Type4 + "','" + Stat_Value4 + "','" + Stat_Type5 + "','" + Stat_Value5 + "','" + Stat_Type6 + "','" + Stat_Value6 + "','" + Stat_Type7 + "','" + Stat_Value7 + "','" + Stat_Type8 + "','" + Stat_Value8 + "','" + Stat_Type9 + "','" + Stat_Value9 + "','" + Stat_Type10 + "','" + Stat_Value10 + "','" + ScalingStatDistribution + "','" + ScalingStatValue + "','" + Dmg_Min1 + "','" + Dmg_Max1 + "','" + Dmg_Type1 + "','" + Dmg_Min2 + "','" + Dmg_Max2 + "','" + Dmg_Type2 + "','" + Armor + "','" + Holy_Res + "','" + Fire_Res + "','" + Nature_Res + "','" + Frost_Res + "','" + Shadow_Res + "','" + Arcane_Res + "','" + Delay + "','" + Ammo_Type + "','" + RangedModRange + "','" + SpellID_1 + "','" + SpellTrigger_1 + "','" + SpellCharges_1 + "','" + SpellppmRate_1 + "','" + SpellCooldown_1 + "','" + SpellCategory_1 + "','" + SpellCategoryCooldown_1 + "','" + SpellID_2 + "','" + SpellTrigger_2 + "','" + SpellCharges_2 + "','" + SpellppmRate_2 + "','" + SpellCooldown_2 + "','" + SpellCategory_2 + "','" + SpellCategoryCooldown_2 + "','" + SpellID_3 + "','" + SpellTrigger_3 + "','" + SpellCharges_3 + "','" + SpellppmRate_3 + "','" + SpellCooldown_3 + "','" + SpellCategory_3 + "','" + SpellCategoryCooldown_3 + "','" + SpellID_4 + "','" + SpellTrigger_4 + "','" + SpellCharges_4 + "','" + SpellppmRate_4 + "','" + SpellCooldown_4 + "','" + SpellCategory_4 + "','" + SpellCategoryCooldown_4 + "','" + SpellID_5 + "','" + SpellTrigger_5 + "','" + SpellCharges_5 + "','" + SpellppmRate_5 + "','" + SpellCooldown_5 + "','" + SpellCategory_5 + "','" + SpellCategoryCooldown_5 + "','" + Bonding + "','" + Description + "','" + PageText + "','" + LanguageID + "','" + PageMeterial + "','" + StartQuest + "','" + LockID + "','" + Material + "','" + Sheath + "','" + RandomProperty + "','" + RandomSuffix + "','" + Block + "','" + ItemSet + "','" + MaxDurability + "','" + Area + "','" + Map + "','" + BagFamily + "','" + TotemCategory + "','" + SocketColor_1 + "','" + SocketContent_1 + "','" + SocketColor_2 + "','" + SocketContent_2 + "','" + SocketColor_3 + "','" + SocketContent_3 + "','" + SocketBonus + "','" + GemProperties + "','" + RequiredDisenchantSkill + "','" + ArmorDamageModifier + "','" + Duration + "','" + ItemLimitCategory + "','" + HolidayId + "','" + ScriptName + "','" + DisenchantID + "','" + FoodType + "','" + MinMoneyLoot + "','" + MaxMoneyLoot + "');";
            }
            else if (ConnInfo.Dbstruct == "3.3.5(TC2)")
            {
                SQL = "insert into item_template (entry,class,subclass,SoundOverrideSubclass,name,displayid,Quality,Flags,FlagsExtra,BuyCount,BuyPrice,SellPrice,InventoryType,AllowableClass,AllowableRace,ItemLevel,RequiredLevel,RequiredSkill,RequiredSkillRank,requiredspell,requiredhonorrank,RequiredCityRank,RequiredReputationFaction,RequiredReputationRank,maxcount,stackable,ContainerSlots,StatsCount,stat_type1,stat_value1,stat_type2,stat_value2,stat_type3,stat_value3,stat_type4,stat_value4,stat_type5,stat_value5,stat_type6,stat_value6,stat_type7,stat_value7,stat_type8,stat_value8,stat_type9,stat_value9,stat_type10,stat_value10,ScalingStatDistribution,ScalingStatValue,dmg_min1,dmg_max1,dmg_type1,dmg_min2,dmg_max2,dmg_type2,armor,holy_res,fire_res,nature_res,frost_res,shadow_res,arcane_res,delay,ammo_type,RangedModRange,spellid_1,spelltrigger_1,spellcharges_1,spellppmRate_1,spellcooldown_1,spellcategory_1,spellcategorycooldown_1,spellid_2,spelltrigger_2,spellcharges_2,spellppmRate_2,spellcooldown_2,spellcategory_2,spellcategorycooldown_2,spellid_3,spelltrigger_3,spellcharges_3,spellppmRate_3,spellcooldown_3,spellcategory_3,spellcategorycooldown_3,spellid_4,spelltrigger_4,spellcharges_4,spellppmRate_4,spellcooldown_4,spellcategory_4,spellcategorycooldown_4,spellid_5,spelltrigger_5,spellcharges_5,spellppmRate_5,spellcooldown_5,spellcategory_5,spellcategorycooldown_5,bonding,description,PageText,LanguageID,PageMaterial,startquest,lockid,Material,sheath,RandomProperty,RandomSuffix,block,itemset,MaxDurability,area,Map,BagFamily,TotemCategory,socketColor_1,socketContent_1,socketColor_2,socketContent_2,socketColor_3,socketContent_3,socketBonus,GemProperties,RequiredDisenchantSkill,ArmorDamageModifier,Duration,ItemLimitCategory,HolidayId,ScriptName,DisenchantID,FoodType,minMoneyLoot,maxMoneyLoot) values('" + Entry + "','" + Class + "','" + SubClass + "','" + unk0 + "','" + Name + "','" + DisplayID + "','" + Quality + "','" + Flags + "','" + Faction + "','" + BuyCount + "','" + BuyPrice + "','" + SellPrice + "','" + InventoryType + "','" + AllowableClass + "','" + AllowableRace + "','" + ItemLevel + "','" + RequiredLevel + "','" + RequiredSkill + "','" + RequiredSkillRank + "','" + RequiredSpell + "','" + RequiredHonnorRank + "','" + RequiredCityRank + "','" + RequiredReputationFaction + "','" + RequiredReputationRank + "','" + MaxCount + "','" + StackAble + "','" + ContainerSlots + "','" + StatsCount + "','" + Stat_Type1 + "','" + Stat_Value1 + "','" + Stat_Type2 + "','" + Stat_Value2 + "','" + Stat_Type3 + "','" + Stat_Value3 + "','" + Stat_Type4 + "','" + Stat_Value4 + "','" + Stat_Type5 + "','" + Stat_Value5 + "','" + Stat_Type6 + "','" + Stat_Value6 + "','" + Stat_Type7 + "','" + Stat_Value7 + "','" + Stat_Type8 + "','" + Stat_Value8 + "','" + Stat_Type9 + "','" + Stat_Value9 + "','" + Stat_Type10 + "','" + Stat_Value10 + "','" + ScalingStatDistribution + "','" + ScalingStatValue + "','" + Dmg_Min1 + "','" + Dmg_Max1 + "','" + Dmg_Type1 + "','" + Dmg_Min2 + "','" + Dmg_Max2 + "','" + Dmg_Type2 + "','" + Armor + "','" + Holy_Res + "','" + Fire_Res + "','" + Nature_Res + "','" + Frost_Res + "','" + Shadow_Res + "','" + Arcane_Res + "','" + Delay + "','" + Ammo_Type + "','" + RangedModRange + "','" + SpellID_1 + "','" + SpellTrigger_1 + "','" + SpellCharges_1 + "','" + SpellppmRate_1 + "','" + SpellCooldown_1 + "','" + SpellCategory_1 + "','" + SpellCategoryCooldown_1 + "','" + SpellID_2 + "','" + SpellTrigger_2 + "','" + SpellCharges_2 + "','" + SpellppmRate_2 + "','" + SpellCooldown_2 + "','" + SpellCategory_2 + "','" + SpellCategoryCooldown_2 + "','" + SpellID_3 + "','" + SpellTrigger_3 + "','" + SpellCharges_3 + "','" + SpellppmRate_3 + "','" + SpellCooldown_3 + "','" + SpellCategory_3 + "','" + SpellCategoryCooldown_3 + "','" + SpellID_4 + "','" + SpellTrigger_4 + "','" + SpellCharges_4 + "','" + SpellppmRate_4 + "','" + SpellCooldown_4 + "','" + SpellCategory_4 + "','" + SpellCategoryCooldown_4 + "','" + SpellID_5 + "','" + SpellTrigger_5 + "','" + SpellCharges_5 + "','" + SpellppmRate_5 + "','" + SpellCooldown_5 + "','" + SpellCategory_5 + "','" + SpellCategoryCooldown_5 + "','" + Bonding + "','" + Description + "','" + PageText + "','" + LanguageID + "','" + PageMeterial + "','" + StartQuest + "','" + LockID + "','" + Material + "','" + Sheath + "','" + RandomProperty + "','" + RandomSuffix + "','" + Block + "','" + ItemSet + "','" + MaxDurability + "','" + Area + "','" + Map + "','" + BagFamily + "','" + TotemCategory + "','" + SocketColor_1 + "','" + SocketContent_1 + "','" + SocketColor_2 + "','" + SocketContent_2 + "','" + SocketColor_3 + "','" + SocketContent_3 + "','" + SocketBonus + "','" + GemProperties + "','" + RequiredDisenchantSkill + "','" + ArmorDamageModifier + "','" + Duration + "','" + ItemLimitCategory + "','" + HolidayId + "','" + ScriptName + "','" + DisenchantID + "','" + FoodType + "','" + MinMoneyLoot + "','" + MaxMoneyLoot + "');";
            }
            return SQL;
        }
        public string GetEditSql()
        {
            string Entry = GetValue("[1-9]{1}[0-9]+", EntryTextBox.Text);
            string Class = GetValue("[0-9]+", ItemClassList.Text);
            string SubClass = GetValue("[0-9]+", ItemSubClassList.Text);
            string unk0 = unk0TextBox.Text;
            string Name = RTB_ItemName.ColorText.Replace("'", "''");
            string DisplayID = GetValue("[0-9]+", DisplayIDList.Text);
            string Quality = GetValue("[0-9]+", QualityList.Text);
            string Flags = GetValue("[0-9]+", FlagsList.Text);
            string Faction = GetValue("(-[0-9]+)|([0-9]+)", FactionTextBox.Text);
            string BuyCount = GetValue("[0-9]+", BuyCountTextBox.Text);
            string BuyPrice = GetValue("[0-9]+", BuyPriceTextBox.Text);
            string SellPrice = GetValue("[0-9]+", SellPriceTextBox.Text);
            string InventoryType = GetValue("[0-9]+", InventoryTypeList.Text);
            string AllowableClass = GetValue("(-[0-9]+)|([0-9]+)", AllowableClassList.Text);
            string AllowableRace = GetValue("(-[0-9]+)|([0-9]+)", AllowableRaceList.Text);
            string ItemLevel = GetValue("[0-9]+", ItemLevelTextBox.Text);
            string RequiredLevel = GetValue("[0-9]+", RequiredLevelTextBox.Text);
            string RequiredSkill = GetValue("[0-9]+", RequiredSkillTextBox.Text);
            string RequiredSkillRank = GetValue("[0-9]+", RequiredSkillRankTextBox.Text);
            string RequiredSpell = GetValue("[0-9]+", RequiredSpellTextBox.Text);
            string RequiredHonnorRank = GetValue("[0-9]+", RequiredHonnorRankTextBox.Text);
            string RequiredCityRank = GetValue("[0-9]+", RequiredCityRankTextBox.Text);
            string RequiredReputationFaction = GetValue("[0-9]+", RequiredReputationFactionTextBox.Text);
            string RequiredReputationRank = GetValue("[0-9]+", RequiredReputationRankTextBox.Text);
            string MaxCount = GetValue("[0-9]+", maxcountTextBox.Text);
            string StackAble = GetValue("[0-9]+", StackAbleTextBox.Text);
            string ContainerSlots = GetValue("[0-9]+", ContainerSlotsTextBox.Text);
            string StatsCount = GetValue("[0-9]+", StatsCountList.Text);
            string Stat_Type1 = GetValue("[0-9]+", Stat_Type1List.Text);
            string Stat_Type2 = GetValue("[0-9]+", Stat_Type2List.Text);
            string Stat_Type3 = GetValue("[0-9]+", Stat_Type3List.Text);
            string Stat_Type4 = GetValue("[0-9]+", Stat_Type4List.Text);
            string Stat_Type5 = GetValue("[0-9]+", Stat_Type5List.Text);
            string Stat_Type6 = GetValue("[0-9]+", Stat_Type6List.Text);
            string Stat_Type7 = GetValue("[0-9]+", Stat_Type7List.Text);
            string Stat_Type8 = GetValue("[0-9]+", Stat_Type8List.Text);
            string Stat_Type9 = GetValue("[0-9]+", Stat_Type9List.Text);
            string Stat_Type10 = GetValue("[0-9]+", Stat_Type10List.Text);
            string Stat_Value1 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value1TextBox.Text);
            string Stat_Value2 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value2TextBox.Text);
            string Stat_Value3 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value3TextBox.Text);
            string Stat_Value4 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value4TextBox.Text);
            string Stat_Value5 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value5TextBox.Text);
            string Stat_Value6 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value6TextBox.Text);
            string Stat_Value7 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value7TextBox.Text);
            string Stat_Value8 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value8TextBox.Text);
            string Stat_Value9 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value9TextBox.Text);
            string Stat_Value10 = GetValue("(-[0-9]+)|([0-9]+)", Stat_Value10TextBox.Text);
            string ScalingStatDistribution = ScalingStatDistributionTextBox.Text;
            string ScalingStatValue = ScalingStatValueTextBox.Text;
            string Dmg_Min1 = GetValue("[0-9]+", dmg_min1TextBox.Text);
            string Dmg_Min2 = GetValue("[0-9]+", dmg_min2TextBox.Text);
            string Dmg_Min3 = GetValue("[0-9]+", dmg_min3TextBox.Text);
            string Dmg_Min4 = GetValue("[0-9]+", dmg_min4TextBox.Text);
            string Dmg_Min5 = GetValue("[0-9]+", dmg_min5TextBox.Text);
            string Dmg_Max1 = GetValue("[0-9]+", dmg_max1TextBox.Text);
            string Dmg_Max2 = GetValue("[0-9]+", dmg_max2TextBox.Text);
            string Dmg_Max3 = GetValue("[0-9]+", dmg_max3TextBox.Text);
            string Dmg_Max4 = GetValue("[0-9]+", dmg_max4TextBox.Text);
            string Dmg_Max5 = GetValue("[0-9]+", dmg_max5TextBox.Text);
            string Dmg_Type1 = GetValue("[0-9]+", dmg_type1List.Text);
            string Dmg_Type2 = GetValue("[0-9]+", dmg_type2List.Text);
            string Dmg_Type3 = GetValue("[0-9]+", dmg_type3List.Text);
            string Dmg_Type4 = GetValue("[0-9]+", dmg_type4List.Text);
            string Dmg_Type5 = GetValue("[0-9]+", dmg_type5List.Text);
            string Armor = GetValue("(-[0-9]+)|([0-9]+)", armorTextBox.Text);
            string Holy_Res = GetValue("(-[0-9]+)|([0-9]+)", holy_resTextBox.Text);
            string Fire_Res = GetValue("(-[0-9]+)|([0-9]+)", fire_resTextBox.Text);
            string Nature_Res = GetValue("(-[0-9]+)|([0-9]+)", nature_resTextBox.Text);
            string Frost_Res = GetValue("(-[0-9]+)|([0-9]+)", frost_resTextBox.Text);
            string Shadow_Res = GetValue("(-[0-9]+)|([0-9]+)", shadow_resTextBox.Text);
            string Arcane_Res = GetValue("(-[0-9]+)|([0-9]+)", arcane_resTextBox.Text);
            string Delay = GetValue("[0-9]+", delayTextBox.Text);
            string Ammo_Type = GetValue("[0-9]+", Ammo_TypeList.Text);
            string RangedModRange = RangedModRangeTextBox.Text;
            string SpellID_1 = GetValue("[0-9]+", spellid_1List.Text);
            string SpellID_2 = GetValue("[0-9]+", spellid_2List.Text);
            string SpellID_3 = GetValue("[0-9]+", spellid_3List.Text);
            string SpellID_4 = GetValue("[0-9]+", spellid_4List.Text);
            string SpellID_5 = GetValue("[0-9]+", spellid_5List.Text);
            string SpellTrigger_1 = GetValue("[0-9]+", spelltrigger_1List.Text);
            string SpellTrigger_2 = GetValue("[0-9]+", spelltrigger_2List.Text);
            string SpellTrigger_3 = GetValue("[0-9]+", spelltrigger_3List.Text);
            string SpellTrigger_4 = GetValue("[0-9]+", spelltrigger_4List.Text);
            string SpellTrigger_5 = GetValue("[0-9]+", spelltrigger_5List.Text);
            string SpellCharges_1 = SpellCharges_1TextBox.Text;
            string SpellCharges_2 = SpellCharges_2TextBox.Text;
            string SpellCharges_3 = SpellCharges_3TextBox.Text;
            string SpellCharges_4 = SpellCharges_4TextBox.Text;
            string SpellCharges_5 = SpellCharges_5TextBox.Text;
            string SpellppmRate_1 = SpellppmRate_1TextBox.Text;
            string SpellppmRate_2 = SpellppmRate_2TextBox.Text;
            string SpellppmRate_3 = SpellppmRate_3TextBox.Text;
            string SpellppmRate_4 = SpellppmRate_4TextBox.Text;
            string SpellppmRate_5 = SpellppmRate_5TextBox.Text;
            string SpellCooldown_1 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_1TextBox.Text);
            string SpellCooldown_2 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_2TextBox.Text);
            string SpellCooldown_3 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_3TextBox.Text);
            string SpellCooldown_4 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_4TextBox.Text);
            string SpellCooldown_5 = GetValue("(-[0-9]+)|([0-9]+)", spellcooldown_5TextBox.Text);
            string SpellCategory_1 = SpellCategory_1TextBox.Text;
            string SpellCategory_2 = SpellCategory_2TextBox.Text;
            string SpellCategory_3 = SpellCategory_3TextBox.Text;
            string SpellCategory_4 = SpellCategory_4TextBox.Text;
            string SpellCategory_5 = SpellCategory_5TextBox.Text;
            string SpellCategoryCooldown_1 = SpellCategoryCooldown_1TextBox.Text;
            string SpellCategoryCooldown_2 = SpellCategoryCooldown_2TextBox.Text;
            string SpellCategoryCooldown_3 = SpellCategoryCooldown_3TextBox.Text;
            string SpellCategoryCooldown_4 = SpellCategoryCooldown_4TextBox.Text;
            string SpellCategoryCooldown_5 = SpellCategoryCooldown_5TextBox.Text;
            string Bonding = GetValue("[0-9]+", BondingList.Text);
            string Description = RTB_Description.ColorText.Replace("'", "''");
            string PageText = GetValue("[0-9]+", PageTextTextBox.Text);
            string LanguageID = GetValue("[0-9]+", LanguageIDTextBox.Text);
            string PageMeterial = GetValue("[0-9]+", PageMeterialTextBox.Text);
            string StartQuest = GetValue("[0-9]+", StartQuestTextBox.Text);
            string LockID = GetValue("[0-9]+", LockIdTextBox.Text);
            string Material = GetValue("[0-9]+", MaterialList.Text);
            string Sheath = GetValue("[0-9]+", SheathList.Text);
            string RandomProperty = GetValue("[0-9]+", RandomPropertyList.Text);
            string RandomSuffix = GetValue("[0-9]+", RandomSuffixList.Text);
            string Block = GetValue("[0-9]+", blockTextBox.Text);
            string ItemSet = GetValue("[0-9]+", ItemSetTextBox.Text);
            string MaxDurability = GetValue("[0-9]+", MaxDurabilityTextBox.Text);
            string Area = GetValue("[0-9]+", AreaList.Text);
            string Map = GetValue("[0-9]+", MapList.Text);
            string BagFamily = BagFamilyTextBox.Text;
            string TotemCategory = TotemCategoryTextBox.Text;
            string SocketColor_1 = GetValue("[0-9]+", SocketColor_1List.Text);
            string SocketColor_2 = GetValue("[0-9]+", SocketColor_2List.Text);
            string SocketColor_3 = GetValue("[0-9]+", SocketColor_3List.Text);
            string SocketContent_1 = SocketContent_1TextBox.Text;
            string SocketContent_2 = SocketContent_2TextBox.Text;
            string SocketContent_3 = SocketContent_3TextBox.Text;
            string SocketBonus = GetValue("[0-9]+", SocketBonusList.Text);
            string GemProperties = GemPropertiesTextBox.Text;
            string RequiredDisenchantSkill = RequiredDisenchantSkillTextBox.Text;
            string ArmorDamageModifier = ArmorDamageModifierTextBox.Text;
            string Duration = DurationTextBox.Text;
            string ItemLimitCategory = ItemLimitCategoryTextBox.Text;
            string HolidayId = GetValue("[0-9]+", HolidayIDTextBox.Text);
            string ScriptName = ScriptNameTextBox.Text.Replace("'", "''");
            string DisenchantID = DisenchantIDTextBox.Text;
            string FoodType = FoodTypeTextBox.Text;
            string MinMoneyLoot = MinMoneyLootTextBox.Text;
            string MaxMoneyLoot = MaxMoneyLootTextBox.Text;
            string SQL = string.Empty;
            if (ConnInfo.Dbstruct == "3.0.X")
            {
                SQL = "update item_template set class='" + Class + "',subclass='" + SubClass + "',unk0='" + unk0 + "',name='" + Name + "',displayid='" + DisplayID + "',Quality='" + Quality + "',Flags='" + Flags + "',BuyCount='" + BuyCount + "',BuyPrice='" + BuyPrice + "',SellPrice='" + SellPrice + "',InventoryType='" + InventoryType + "',AllowableClass='" + AllowableClass + "',AllowableRace='" + AllowableRace + "',ItemLevel='" + ItemLevel + "',RequiredLevel='" + RequiredLevel + "',RequiredSkill='" + RequiredSkill + "',RequiredSkillRank='" + RequiredSkillRank + "',requiredspell='" + RequiredSpell + "',requiredhonorrank='" + RequiredHonnorRank + "',RequiredCityRank='" + RequiredCityRank + "',RequiredReputationFaction='" + RequiredReputationFaction + "',RequiredReputationRank='" + RequiredReputationRank + "',maxcount='" + MaxCount + "',stackable='" + StackAble + "',ContainerSlots='" + ContainerSlots + "',StatsCount='" + StatsCount + "',stat_type1='" + Stat_Type1 + "',stat_value1='" + Stat_Value1 + "',stat_type2='" + Stat_Type2 + "',stat_value2='" + Stat_Value2 + "',stat_type3='" + Stat_Type3 + "',stat_value3='" + Stat_Value3 + "',stat_type4='" + Stat_Type4 + "',stat_value4='" + Stat_Value4 + "',stat_type5='" + Stat_Type5 + "',stat_value5='" + Stat_Value5 + "',stat_type6='" + Stat_Type6 + "',stat_value6='" + Stat_Value6 + "',stat_type7='" + Stat_Type7 + "',stat_value7='" + Stat_Value7 + "',stat_type8='" + Stat_Type8 + "',stat_value8='" + Stat_Value8 + "',stat_type9='" + Stat_Type9 + "',stat_value9='" + Stat_Value9 + "',stat_type10='" + Stat_Type10 + "',stat_value10='" + Stat_Value10 + "',ScalingStatDistribution='" + ScalingStatDistribution + "',ScalingStatValue='" + ScalingStatValue + "',dmg_min1='" + Dmg_Min1 + "',dmg_max1='" + Dmg_Max1 + "',dmg_type1='" + Dmg_Type1 + "',dmg_min2='" + Dmg_Min2 + "',dmg_max2='" + Dmg_Max2 + "',dmg_type2='" + Dmg_Type2 + "',dmg_min3='" + Dmg_Min3 + "',dmg_max3='" + Dmg_Max3 + "',dmg_type3='" + Dmg_Type3 + "',dmg_min4='" + Dmg_Min4 + "',dmg_max4='" + Dmg_Max4 + "',dmg_type4='" + Dmg_Type4 + "',dmg_min5='" + Dmg_Min5 + "',dmg_max5='" + Dmg_Max5 + "',dmg_type5='" + Dmg_Type5 + "',armor='" + Armor + "',holy_res='" + Holy_Res + "',fire_res='" + Fire_Res + "',nature_res='" + Nature_Res + "',frost_res='" + Frost_Res + "',shadow_res='" + Shadow_Res + "',arcane_res='" + Arcane_Res + "',delay='" + Delay + "',ammo_type='" + Ammo_Type + "',RangedModRange='" + RangedModRange + "',spellid_1='" + SpellID_1 + "',spelltrigger_1='" + SpellTrigger_1 + "',spellcharges_1='" + SpellCharges_1 + "',spellppmRate_1='" + SpellppmRate_1 + "',spellcooldown_1='" + SpellCooldown_1 + "',spellcategory_1='" + SpellCategory_1 + "',spellcategorycooldown_1='" + SpellCategoryCooldown_1 + "',spellid_2='" + SpellID_2 + "',spelltrigger_2='" + SpellTrigger_2 + "',spellcharges_2='" + SpellCharges_2 + "',spellppmRate_2='" + SpellppmRate_2 + "',spellcooldown_2='" + SpellCooldown_2 + "',spellcategory_2='" + SpellCategory_2 + "',spellcategorycooldown_2='" + SpellCategoryCooldown_2 + "',spellid_3='" + SpellID_3 + "',spelltrigger_3='" + SpellTrigger_3 + "',spellcharges_3='" + SpellCharges_3 + "',spellppmRate_3='" + SpellppmRate_3 + "',spellcooldown_3='" + SpellCooldown_3 + "',spellcategory_3='" + SpellCategory_3 + "',spellcategorycooldown_3='" + SpellCategoryCooldown_3 + "',spellid_4='" + SpellID_4 + "',spelltrigger_4='" + SpellTrigger_4 + "',spellcharges_4='" + SpellCharges_4 + "',spellppmRate_4='" + SpellppmRate_4 + "',spellcooldown_4='" + SpellCooldown_4 + "',spellcategory_4='" + SpellCategory_4 + "',spellcategorycooldown_4='" + SpellCategoryCooldown_4 + "',spellid_5='" + SpellID_5 + "',spelltrigger_5='" + SpellTrigger_5 + "',spellcharges_5='" + SpellCharges_5 + "',spellppmRate_5='" + SpellppmRate_5 + "',spellcooldown_5='" + SpellCooldown_5 + "',spellcategory_5='" + SpellCategory_5 + "',spellcategorycooldown_5='" + SpellCategoryCooldown_5 + "',bonding='" + Bonding + "',description='" + Description + "',PageText='" + PageText + "',LanguageID='" + LanguageID + "',PageMaterial='" + PageMeterial + "',startquest='" + StartQuest + "',lockid='" + LockID + "',Material='" + Material + "',sheath='" + Sheath + "',RandomProperty='" + RandomProperty + "',RandomSuffix='" + RandomSuffix + "',block='" + Block + "',itemset='" + ItemSet + "',MaxDurability='" + MaxDurability + "',area='" + Area + "',Map='" + Map + "',BagFamily='" + BagFamily + "',TotemCategory='" + TotemCategory + "',socketColor_1='" + SocketColor_1 + "',socketContent_1='" + SocketContent_1 + "',socketColor_2='" + SocketColor_2 + "',socketContent_2='" + SocketContent_2 + "',socketColor_3='" + SocketColor_3 + "',socketContent_3='" + SocketContent_3 + "',socketBonus='" + SocketBonus + "',GemProperties='" + GemProperties + "',RequiredDisenchantSkill='" + RequiredDisenchantSkill + "',ArmorDamageModifier='" + ArmorDamageModifier + "',Duration='" + Duration + "',ItemLimitCategory='" + ItemLimitCategory + "',ScriptName='" + ScriptName + "',DisenchantID='" + DisenchantID + "',FoodType='" + FoodType + "',minMoneyLoot='" + MinMoneyLoot + "',maxMoneyLoot='" + MaxMoneyLoot + "' where entry = '" + Entry + "';";
            }
            else if (ConnInfo.Dbstruct == "3.1.X")
            {
                SQL = "update item_template set class='" + Class + "',subclass='" + SubClass + "',unk0='" + unk0 + "',name='" + Name + "',displayid='" + DisplayID + "',Quality='" + Quality + "',Flags='" + Flags + "',BuyCount='" + BuyCount + "',BuyPrice='" + BuyPrice + "',SellPrice='" + SellPrice + "',InventoryType='" + InventoryType + "',AllowableClass='" + AllowableClass + "',AllowableRace='" + AllowableRace + "',ItemLevel='" + ItemLevel + "',RequiredLevel='" + RequiredLevel + "',RequiredSkill='" + RequiredSkill + "',RequiredSkillRank='" + RequiredSkillRank + "',requiredspell='" + RequiredSpell + "',requiredhonorrank='" + RequiredHonnorRank + "',RequiredCityRank='" + RequiredCityRank + "',RequiredReputationFaction='" + RequiredReputationFaction + "',RequiredReputationRank='" + RequiredReputationRank + "',maxcount='" + MaxCount + "',stackable='" + StackAble + "',ContainerSlots='" + ContainerSlots + "',StatsCount='" + StatsCount + "',stat_type1='" + Stat_Type1 + "',stat_value1='" + Stat_Value1 + "',stat_type2='" + Stat_Type2 + "',stat_value2='" + Stat_Value2 + "',stat_type3='" + Stat_Type3 + "',stat_value3='" + Stat_Value3 + "',stat_type4='" + Stat_Type4 + "',stat_value4='" + Stat_Value4 + "',stat_type5='" + Stat_Type5 + "',stat_value5='" + Stat_Value5 + "',stat_type6='" + Stat_Type6 + "',stat_value6='" + Stat_Value6 + "',stat_type7='" + Stat_Type7 + "',stat_value7='" + Stat_Value7 + "',stat_type8='" + Stat_Type8 + "',stat_value8='" + Stat_Value8 + "',stat_type9='" + Stat_Type9 + "',stat_value9='" + Stat_Value9 + "',stat_type10='" + Stat_Type10 + "',stat_value10='" + Stat_Value10 + "',ScalingStatDistribution='" + ScalingStatDistribution + "',ScalingStatValue='" + ScalingStatValue + "',dmg_min1='" + Dmg_Min1 + "',dmg_max1='" + Dmg_Max1 + "',dmg_type1='" + Dmg_Type1 + "',dmg_min2='" + Dmg_Min2 + "',dmg_max2='" + Dmg_Max2 + "',dmg_type2='" + Dmg_Type2 + "',armor='" + Armor + "',holy_res='" + Holy_Res + "',fire_res='" + Fire_Res + "',nature_res='" + Nature_Res + "',frost_res='" + Frost_Res + "',shadow_res='" + Shadow_Res + "',arcane_res='" + Arcane_Res + "',delay='" + Delay + "',ammo_type='" + Ammo_Type + "',RangedModRange='" + RangedModRange + "',spellid_1='" + SpellID_1 + "',spelltrigger_1='" + SpellTrigger_1 + "',spellcharges_1='" + SpellCharges_1 + "',spellppmRate_1='" + SpellppmRate_1 + "',spellcooldown_1='" + SpellCooldown_1 + "',spellcategory_1='" + SpellCategory_1 + "',spellcategorycooldown_1='" + SpellCategoryCooldown_1 + "',spellid_2='" + SpellID_2 + "',spelltrigger_2='" + SpellTrigger_2 + "',spellcharges_2='" + SpellCharges_2 + "',spellppmRate_2='" + SpellppmRate_2 + "',spellcooldown_2='" + SpellCooldown_2 + "',spellcategory_2='" + SpellCategory_2 + "',spellcategorycooldown_2='" + SpellCategoryCooldown_2 + "',spellid_3='" + SpellID_3 + "',spelltrigger_3='" + SpellTrigger_3 + "',spellcharges_3='" + SpellCharges_3 + "',spellppmRate_3='" + SpellppmRate_3 + "',spellcooldown_3='" + SpellCooldown_3 + "',spellcategory_3='" + SpellCategory_3 + "',spellcategorycooldown_3='" + SpellCategoryCooldown_3 + "',spellid_4='" + SpellID_4 + "',spelltrigger_4='" + SpellTrigger_4 + "',spellcharges_4='" + SpellCharges_4 + "',spellppmRate_4='" + SpellppmRate_4 + "',spellcooldown_4='" + SpellCooldown_4 + "',spellcategory_4='" + SpellCategory_4 + "',spellcategorycooldown_4='" + SpellCategoryCooldown_4 + "',spellid_5='" + SpellID_5 + "',spelltrigger_5='" + SpellTrigger_5 + "',spellcharges_5='" + SpellCharges_5 + "',spellppmRate_5='" + SpellppmRate_5 + "',spellcooldown_5='" + SpellCooldown_5 + "',spellcategory_5='" + SpellCategory_5 + "',spellcategorycooldown_5='" + SpellCategoryCooldown_5 + "',bonding='" + Bonding + "',description='" + Description + "',PageText='" + PageText + "',LanguageID='" + LanguageID + "',PageMaterial='" + PageMeterial + "',startquest='" + StartQuest + "',lockid='" + LockID + "',Material='" + Material + "',sheath='" + Sheath + "',RandomProperty='" + RandomProperty + "',RandomSuffix='" + RandomSuffix + "',block='" + Block + "',itemset='" + ItemSet + "',MaxDurability='" + MaxDurability + "',area='" + Area + "',Map='" + Map + "',BagFamily='" + BagFamily + "',TotemCategory='" + TotemCategory + "',socketColor_1='" + SocketColor_1 + "',socketContent_1='" + SocketContent_1 + "',socketColor_2='" + SocketColor_2 + "',socketContent_2='" + SocketContent_2 + "',socketColor_3='" + SocketColor_3 + "',socketContent_3='" + SocketContent_3 + "',socketBonus='" + SocketBonus + "',GemProperties='" + GemProperties + "',RequiredDisenchantSkill='" + RequiredDisenchantSkill + "',ArmorDamageModifier='" + ArmorDamageModifier + "',Duration='" + Duration + "',ItemLimitCategory='" + ItemLimitCategory + "',ScriptName='" + ScriptName + "',DisenchantID='" + DisenchantID + "',FoodType='" + FoodType + "',minMoneyLoot='" + MinMoneyLoot + "',maxMoneyLoot='" + MaxMoneyLoot + "' where entry = '" + Entry + "';";
            }
            else if (ConnInfo.Dbstruct == "3.2.X")
            {
                SQL = "update item_template set class='" + Class + "',subclass='" + SubClass + "',unk0='" + unk0 + "',name='" + Name + "',displayid='" + DisplayID + "',Quality='" + Quality + "',Flags='" + Flags + "',Faction='" + Faction + "',BuyCount='" + BuyCount + "',BuyPrice='" + BuyPrice + "',SellPrice='" + SellPrice + "',InventoryType='" + InventoryType + "',AllowableClass='" + AllowableClass + "',AllowableRace='" + AllowableRace + "',ItemLevel='" + ItemLevel + "',RequiredLevel='" + RequiredLevel + "',RequiredSkill='" + RequiredSkill + "',RequiredSkillRank='" + RequiredSkillRank + "',requiredspell='" + RequiredSpell + "',requiredhonorrank='" + RequiredHonnorRank + "',RequiredCityRank='" + RequiredCityRank + "',RequiredReputationFaction='" + RequiredReputationFaction + "',RequiredReputationRank='" + RequiredReputationRank + "',maxcount='" + MaxCount + "',stackable='" + StackAble + "',ContainerSlots='" + ContainerSlots + "',StatsCount='" + StatsCount + "',stat_type1='" + Stat_Type1 + "',stat_value1='" + Stat_Value1 + "',stat_type2='" + Stat_Type2 + "',stat_value2='" + Stat_Value2 + "',stat_type3='" + Stat_Type3 + "',stat_value3='" + Stat_Value3 + "',stat_type4='" + Stat_Type4 + "',stat_value4='" + Stat_Value4 + "',stat_type5='" + Stat_Type5 + "',stat_value5='" + Stat_Value5 + "',stat_type6='" + Stat_Type6 + "',stat_value6='" + Stat_Value6 + "',stat_type7='" + Stat_Type7 + "',stat_value7='" + Stat_Value7 + "',stat_type8='" + Stat_Type8 + "',stat_value8='" + Stat_Value8 + "',stat_type9='" + Stat_Type9 + "',stat_value9='" + Stat_Value9 + "',stat_type10='" + Stat_Type10 + "',stat_value10='" + Stat_Value10 + "',ScalingStatDistribution='" + ScalingStatDistribution + "',ScalingStatValue='" + ScalingStatValue + "',dmg_min1='" + Dmg_Min1 + "',dmg_max1='" + Dmg_Max1 + "',dmg_type1='" + Dmg_Type1 + "',dmg_min2='" + Dmg_Min2 + "',dmg_max2='" + Dmg_Max2 + "',dmg_type2='" + Dmg_Type2 + "',armor='" + Armor + "',holy_res='" + Holy_Res + "',fire_res='" + Fire_Res + "',nature_res='" + Nature_Res + "',frost_res='" + Frost_Res + "',shadow_res='" + Shadow_Res + "',arcane_res='" + Arcane_Res + "',delay='" + Delay + "',ammo_type='" + Ammo_Type + "',RangedModRange='" + RangedModRange + "',spellid_1='" + SpellID_1 + "',spelltrigger_1='" + SpellTrigger_1 + "',spellcharges_1='" + SpellCharges_1 + "',spellppmRate_1='" + SpellppmRate_1 + "',spellcooldown_1='" + SpellCooldown_1 + "',spellcategory_1='" + SpellCategory_1 + "',spellcategorycooldown_1='" + SpellCategoryCooldown_1 + "',spellid_2='" + SpellID_2 + "',spelltrigger_2='" + SpellTrigger_2 + "',spellcharges_2='" + SpellCharges_2 + "',spellppmRate_2='" + SpellppmRate_2 + "',spellcooldown_2='" + SpellCooldown_2 + "',spellcategory_2='" + SpellCategory_2 + "',spellcategorycooldown_2='" + SpellCategoryCooldown_2 + "',spellid_3='" + SpellID_3 + "',spelltrigger_3='" + SpellTrigger_3 + "',spellcharges_3='" + SpellCharges_3 + "',spellppmRate_3='" + SpellppmRate_3 + "',spellcooldown_3='" + SpellCooldown_3 + "',spellcategory_3='" + SpellCategory_3 + "',spellcategorycooldown_3='" + SpellCategoryCooldown_3 + "',spellid_4='" + SpellID_4 + "',spelltrigger_4='" + SpellTrigger_4 + "',spellcharges_4='" + SpellCharges_4 + "',spellppmRate_4='" + SpellppmRate_4 + "',spellcooldown_4='" + SpellCooldown_4 + "',spellcategory_4='" + SpellCategory_4 + "',spellcategorycooldown_4='" + SpellCategoryCooldown_4 + "',spellid_5='" + SpellID_5 + "',spelltrigger_5='" + SpellTrigger_5 + "',spellcharges_5='" + SpellCharges_5 + "',spellppmRate_5='" + SpellppmRate_5 + "',spellcooldown_5='" + SpellCooldown_5 + "',spellcategory_5='" + SpellCategory_5 + "',spellcategorycooldown_5='" + SpellCategoryCooldown_5 + "',bonding='" + Bonding + "',description='" + Description + "',PageText='" + PageText + "',LanguageID='" + LanguageID + "',PageMaterial='" + PageMeterial + "',startquest='" + StartQuest + "',lockid='" + LockID + "',Material='" + Material + "',sheath='" + Sheath + "',RandomProperty='" + RandomProperty + "',RandomSuffix='" + RandomSuffix + "',block='" + Block + "',itemset='" + ItemSet + "',MaxDurability='" + MaxDurability + "',area='" + Area + "',Map='" + Map + "',BagFamily='" + BagFamily + "',TotemCategory='" + TotemCategory + "',socketColor_1='" + SocketColor_1 + "',socketContent_1='" + SocketContent_1 + "',socketColor_2='" + SocketColor_2 + "',socketContent_2='" + SocketContent_2 + "',socketColor_3='" + SocketColor_3 + "',socketContent_3='" + SocketContent_3 + "',socketBonus='" + SocketBonus + "',GemProperties='" + GemProperties + "',RequiredDisenchantSkill='" + RequiredDisenchantSkill + "',ArmorDamageModifier='" + ArmorDamageModifier + "',Duration='" + Duration + "',ItemLimitCategory='" + ItemLimitCategory + "',ScriptName='" + ScriptName + "',DisenchantID='" + DisenchantID + "',FoodType='" + FoodType + "',minMoneyLoot='" + MinMoneyLoot + "',maxMoneyLoot='" + MaxMoneyLoot + "' where entry = '" + Entry + "';";
            }
            else if (ConnInfo.Dbstruct == "3.3.X")
            {
                SQL = "update item_template set class='" + Class + "',subclass='" + SubClass + "',unk0='" + unk0 + "',name='" + Name + "',displayid='" + DisplayID + "',Quality='" + Quality + "',Flags='" + Flags + "',Faction='" + Faction + "',BuyCount='" + BuyCount + "',BuyPrice='" + BuyPrice + "',SellPrice='" + SellPrice + "',InventoryType='" + InventoryType + "',AllowableClass='" + AllowableClass + "',AllowableRace='" + AllowableRace + "',ItemLevel='" + ItemLevel + "',RequiredLevel='" + RequiredLevel + "',RequiredSkill='" + RequiredSkill + "',RequiredSkillRank='" + RequiredSkillRank + "',requiredspell='" + RequiredSpell + "',requiredhonorrank='" + RequiredHonnorRank + "',RequiredCityRank='" + RequiredCityRank + "',RequiredReputationFaction='" + RequiredReputationFaction + "',RequiredReputationRank='" + RequiredReputationRank + "',maxcount='" + MaxCount + "',stackable='" + StackAble + "',ContainerSlots='" + ContainerSlots + "',StatsCount='" + StatsCount + "',stat_type1='" + Stat_Type1 + "',stat_value1='" + Stat_Value1 + "',stat_type2='" + Stat_Type2 + "',stat_value2='" + Stat_Value2 + "',stat_type3='" + Stat_Type3 + "',stat_value3='" + Stat_Value3 + "',stat_type4='" + Stat_Type4 + "',stat_value4='" + Stat_Value4 + "',stat_type5='" + Stat_Type5 + "',stat_value5='" + Stat_Value5 + "',stat_type6='" + Stat_Type6 + "',stat_value6='" + Stat_Value6 + "',stat_type7='" + Stat_Type7 + "',stat_value7='" + Stat_Value7 + "',stat_type8='" + Stat_Type8 + "',stat_value8='" + Stat_Value8 + "',stat_type9='" + Stat_Type9 + "',stat_value9='" + Stat_Value9 + "',stat_type10='" + Stat_Type10 + "',stat_value10='" + Stat_Value10 + "',ScalingStatDistribution='" + ScalingStatDistribution + "',ScalingStatValue='" + ScalingStatValue + "',dmg_min1='" + Dmg_Min1 + "',dmg_max1='" + Dmg_Max1 + "',dmg_type1='" + Dmg_Type1 + "',dmg_min2='" + Dmg_Min2 + "',dmg_max2='" + Dmg_Max2 + "',dmg_type2='" + Dmg_Type2 + "',armor='" + Armor + "',holy_res='" + Holy_Res + "',fire_res='" + Fire_Res + "',nature_res='" + Nature_Res + "',frost_res='" + Frost_Res + "',shadow_res='" + Shadow_Res + "',arcane_res='" + Arcane_Res + "',delay='" + Delay + "',ammo_type='" + Ammo_Type + "',RangedModRange='" + RangedModRange + "',spellid_1='" + SpellID_1 + "',spelltrigger_1='" + SpellTrigger_1 + "',spellcharges_1='" + SpellCharges_1 + "',spellppmRate_1='" + SpellppmRate_1 + "',spellcooldown_1='" + SpellCooldown_1 + "',spellcategory_1='" + SpellCategory_1 + "',spellcategorycooldown_1='" + SpellCategoryCooldown_1 + "',spellid_2='" + SpellID_2 + "',spelltrigger_2='" + SpellTrigger_2 + "',spellcharges_2='" + SpellCharges_2 + "',spellppmRate_2='" + SpellppmRate_2 + "',spellcooldown_2='" + SpellCooldown_2 + "',spellcategory_2='" + SpellCategory_2 + "',spellcategorycooldown_2='" + SpellCategoryCooldown_2 + "',spellid_3='" + SpellID_3 + "',spelltrigger_3='" + SpellTrigger_3 + "',spellcharges_3='" + SpellCharges_3 + "',spellppmRate_3='" + SpellppmRate_3 + "',spellcooldown_3='" + SpellCooldown_3 + "',spellcategory_3='" + SpellCategory_3 + "',spellcategorycooldown_3='" + SpellCategoryCooldown_3 + "',spellid_4='" + SpellID_4 + "',spelltrigger_4='" + SpellTrigger_4 + "',spellcharges_4='" + SpellCharges_4 + "',spellppmRate_4='" + SpellppmRate_4 + "',spellcooldown_4='" + SpellCooldown_4 + "',spellcategory_4='" + SpellCategory_4 + "',spellcategorycooldown_4='" + SpellCategoryCooldown_4 + "',spellid_5='" + SpellID_5 + "',spelltrigger_5='" + SpellTrigger_5 + "',spellcharges_5='" + SpellCharges_5 + "',spellppmRate_5='" + SpellppmRate_5 + "',spellcooldown_5='" + SpellCooldown_5 + "',spellcategory_5='" + SpellCategory_5 + "',spellcategorycooldown_5='" + SpellCategoryCooldown_5 + "',bonding='" + Bonding + "',description='" + Description + "',PageText='" + PageText + "',LanguageID='" + LanguageID + "',PageMaterial='" + PageMeterial + "',startquest='" + StartQuest + "',lockid='" + LockID + "',Material='" + Material + "',sheath='" + Sheath + "',RandomProperty='" + RandomProperty + "',RandomSuffix='" + RandomSuffix + "',block='" + Block + "',itemset='" + ItemSet + "',MaxDurability='" + MaxDurability + "',area='" + Area + "',Map='" + Map + "',BagFamily='" + BagFamily + "',TotemCategory='" + TotemCategory + "',socketColor_1='" + SocketColor_1 + "',socketContent_1='" + SocketContent_1 + "',socketColor_2='" + SocketColor_2 + "',socketContent_2='" + SocketContent_2 + "',socketColor_3='" + SocketColor_3 + "',socketContent_3='" + SocketContent_3 + "',socketBonus='" + SocketBonus + "',GemProperties='" + GemProperties + "',RequiredDisenchantSkill='" + RequiredDisenchantSkill + "',ArmorDamageModifier='" + ArmorDamageModifier + "',Duration='" + Duration + "',ItemLimitCategory='" + ItemLimitCategory + "',ScriptName='" + ScriptName + "',HolidayId='" + HolidayId + "',DisenchantID='" + DisenchantID + "',FoodType='" + FoodType + "',minMoneyLoot='" + MinMoneyLoot + "',maxMoneyLoot='" + MaxMoneyLoot + "' where entry = '" + Entry + "';";
            }
            else if (ConnInfo.Dbstruct == "真爱XV")
            {
                SQL = "update item_template set class='" + Class + "',subclass='" + SubClass + "',unk0='" + unk0 + "',name='" + Name + "',displayid='" + DisplayID + "',Quality='" + Quality + "',Flags='" + Flags + "',FlagsExtra='" + Faction + "',BuyCount='" + BuyCount + "',BuyPrice='" + BuyPrice + "',SellPrice='" + SellPrice + "',InventoryType='" + InventoryType + "',AllowableClass='" + AllowableClass + "',AllowableRace='" + AllowableRace + "',ItemLevel='" + ItemLevel + "',RequiredLevel='" + RequiredLevel + "',RequiredSkill='" + RequiredSkill + "',RequiredSkillRank='" + RequiredSkillRank + "',requiredspell='" + RequiredSpell + "',requiredhonorrank='" + RequiredHonnorRank + "',RequiredCityRank='" + RequiredCityRank + "',RequiredReputationFaction='" + RequiredReputationFaction + "',RequiredReputationRank='" + RequiredReputationRank + "',maxcount='" + MaxCount + "',stackable='" + StackAble + "',ContainerSlots='" + ContainerSlots + "',StatsCount='" + StatsCount + "',stat_type1='" + Stat_Type1 + "',stat_value1='" + Stat_Value1 + "',stat_type2='" + Stat_Type2 + "',stat_value2='" + Stat_Value2 + "',stat_type3='" + Stat_Type3 + "',stat_value3='" + Stat_Value3 + "',stat_type4='" + Stat_Type4 + "',stat_value4='" + Stat_Value4 + "',stat_type5='" + Stat_Type5 + "',stat_value5='" + Stat_Value5 + "',stat_type6='" + Stat_Type6 + "',stat_value6='" + Stat_Value6 + "',stat_type7='" + Stat_Type7 + "',stat_value7='" + Stat_Value7 + "',stat_type8='" + Stat_Type8 + "',stat_value8='" + Stat_Value8 + "',stat_type9='" + Stat_Type9 + "',stat_value9='" + Stat_Value9 + "',stat_type10='" + Stat_Type10 + "',stat_value10='" + Stat_Value10 + "',ScalingStatDistribution='" + ScalingStatDistribution + "',ScalingStatValue='" + ScalingStatValue + "',dmg_min1='" + Dmg_Min1 + "',dmg_max1='" + Dmg_Max1 + "',dmg_type1='" + Dmg_Type1 + "',dmg_min2='" + Dmg_Min2 + "',dmg_max2='" + Dmg_Max2 + "',dmg_type2='" + Dmg_Type2 + "',armor='" + Armor + "',holy_res='" + Holy_Res + "',fire_res='" + Fire_Res + "',nature_res='" + Nature_Res + "',frost_res='" + Frost_Res + "',shadow_res='" + Shadow_Res + "',arcane_res='" + Arcane_Res + "',delay='" + Delay + "',ammo_type='" + Ammo_Type + "',RangedModRange='" + RangedModRange + "',spellid_1='" + SpellID_1 + "',spelltrigger_1='" + SpellTrigger_1 + "',spellcharges_1='" + SpellCharges_1 + "',spellppmRate_1='" + SpellppmRate_1 + "',spellcooldown_1='" + SpellCooldown_1 + "',spellcategory_1='" + SpellCategory_1 + "',spellcategorycooldown_1='" + SpellCategoryCooldown_1 + "',spellid_2='" + SpellID_2 + "',spelltrigger_2='" + SpellTrigger_2 + "',spellcharges_2='" + SpellCharges_2 + "',spellppmRate_2='" + SpellppmRate_2 + "',spellcooldown_2='" + SpellCooldown_2 + "',spellcategory_2='" + SpellCategory_2 + "',spellcategorycooldown_2='" + SpellCategoryCooldown_2 + "',spellid_3='" + SpellID_3 + "',spelltrigger_3='" + SpellTrigger_3 + "',spellcharges_3='" + SpellCharges_3 + "',spellppmRate_3='" + SpellppmRate_3 + "',spellcooldown_3='" + SpellCooldown_3 + "',spellcategory_3='" + SpellCategory_3 + "',spellcategorycooldown_3='" + SpellCategoryCooldown_3 + "',spellid_4='" + SpellID_4 + "',spelltrigger_4='" + SpellTrigger_4 + "',spellcharges_4='" + SpellCharges_4 + "',spellppmRate_4='" + SpellppmRate_4 + "',spellcooldown_4='" + SpellCooldown_4 + "',spellcategory_4='" + SpellCategory_4 + "',spellcategorycooldown_4='" + SpellCategoryCooldown_4 + "',spellid_5='" + SpellID_5 + "',spelltrigger_5='" + SpellTrigger_5 + "',spellcharges_5='" + SpellCharges_5 + "',spellppmRate_5='" + SpellppmRate_5 + "',spellcooldown_5='" + SpellCooldown_5 + "',spellcategory_5='" + SpellCategory_5 + "',spellcategorycooldown_5='" + SpellCategoryCooldown_5 + "',bonding='" + Bonding + "',description='" + Description + "',PageText='" + PageText + "',LanguageID='" + LanguageID + "',PageMaterial='" + PageMeterial + "',startquest='" + StartQuest + "',lockid='" + LockID + "',Material='" + Material + "',sheath='" + Sheath + "',RandomProperty='" + RandomProperty + "',RandomSuffix='" + RandomSuffix + "',block='" + Block + "',itemset='" + ItemSet + "',MaxDurability='" + MaxDurability + "',area='" + Area + "',Map='" + Map + "',BagFamily='" + BagFamily + "',TotemCategory='" + TotemCategory + "',socketColor_1='" + SocketColor_1 + "',socketContent_1='" + SocketContent_1 + "',socketColor_2='" + SocketColor_2 + "',socketContent_2='" + SocketContent_2 + "',socketColor_3='" + SocketColor_3 + "',socketContent_3='" + SocketContent_3 + "',socketBonus='" + SocketBonus + "',GemProperties='" + GemProperties + "',RequiredDisenchantSkill='" + RequiredDisenchantSkill + "',ArmorDamageModifier='" + ArmorDamageModifier + "',Duration='" + Duration + "',ItemLimitCategory='" + ItemLimitCategory + "',ScriptName='" + ScriptName + "',HolidayId='" + HolidayId + "',DisenchantID='" + DisenchantID + "',FoodType='" + FoodType + "',minMoneyLoot='" + MinMoneyLoot + "',maxMoneyLoot='" + MaxMoneyLoot + "' where entry = '" + Entry + "';";
            }
            else if (ConnInfo.Dbstruct == "3.3.5")
            {
                SQL = "update item_template set class='" + Class + "',subclass='" + SubClass + "',unk0='" + unk0 + "',name='" + Name + "',displayid='" + DisplayID + "',Quality='" + Quality + "',Flags='" + Flags + "',Flags2='" + Faction + "',BuyCount='" + BuyCount + "',BuyPrice='" + BuyPrice + "',SellPrice='" + SellPrice + "',InventoryType='" + InventoryType + "',AllowableClass='" + AllowableClass + "',AllowableRace='" + AllowableRace + "',ItemLevel='" + ItemLevel + "',RequiredLevel='" + RequiredLevel + "',RequiredSkill='" + RequiredSkill + "',RequiredSkillRank='" + RequiredSkillRank + "',requiredspell='" + RequiredSpell + "',requiredhonorrank='" + RequiredHonnorRank + "',RequiredCityRank='" + RequiredCityRank + "',RequiredReputationFaction='" + RequiredReputationFaction + "',RequiredReputationRank='" + RequiredReputationRank + "',maxcount='" + MaxCount + "',stackable='" + StackAble + "',ContainerSlots='" + ContainerSlots + "',StatsCount='" + StatsCount + "',stat_type1='" + Stat_Type1 + "',stat_value1='" + Stat_Value1 + "',stat_type2='" + Stat_Type2 + "',stat_value2='" + Stat_Value2 + "',stat_type3='" + Stat_Type3 + "',stat_value3='" + Stat_Value3 + "',stat_type4='" + Stat_Type4 + "',stat_value4='" + Stat_Value4 + "',stat_type5='" + Stat_Type5 + "',stat_value5='" + Stat_Value5 + "',stat_type6='" + Stat_Type6 + "',stat_value6='" + Stat_Value6 + "',stat_type7='" + Stat_Type7 + "',stat_value7='" + Stat_Value7 + "',stat_type8='" + Stat_Type8 + "',stat_value8='" + Stat_Value8 + "',stat_type9='" + Stat_Type9 + "',stat_value9='" + Stat_Value9 + "',stat_type10='" + Stat_Type10 + "',stat_value10='" + Stat_Value10 + "',ScalingStatDistribution='" + ScalingStatDistribution + "',ScalingStatValue='" + ScalingStatValue + "',dmg_min1='" + Dmg_Min1 + "',dmg_max1='" + Dmg_Max1 + "',dmg_type1='" + Dmg_Type1 + "',dmg_min2='" + Dmg_Min2 + "',dmg_max2='" + Dmg_Max2 + "',dmg_type2='" + Dmg_Type2 + "',armor='" + Armor + "',holy_res='" + Holy_Res + "',fire_res='" + Fire_Res + "',nature_res='" + Nature_Res + "',frost_res='" + Frost_Res + "',shadow_res='" + Shadow_Res + "',arcane_res='" + Arcane_Res + "',delay='" + Delay + "',ammo_type='" + Ammo_Type + "',RangedModRange='" + RangedModRange + "',spellid_1='" + SpellID_1 + "',spelltrigger_1='" + SpellTrigger_1 + "',spellcharges_1='" + SpellCharges_1 + "',spellppmRate_1='" + SpellppmRate_1 + "',spellcooldown_1='" + SpellCooldown_1 + "',spellcategory_1='" + SpellCategory_1 + "',spellcategorycooldown_1='" + SpellCategoryCooldown_1 + "',spellid_2='" + SpellID_2 + "',spelltrigger_2='" + SpellTrigger_2 + "',spellcharges_2='" + SpellCharges_2 + "',spellppmRate_2='" + SpellppmRate_2 + "',spellcooldown_2='" + SpellCooldown_2 + "',spellcategory_2='" + SpellCategory_2 + "',spellcategorycooldown_2='" + SpellCategoryCooldown_2 + "',spellid_3='" + SpellID_3 + "',spelltrigger_3='" + SpellTrigger_3 + "',spellcharges_3='" + SpellCharges_3 + "',spellppmRate_3='" + SpellppmRate_3 + "',spellcooldown_3='" + SpellCooldown_3 + "',spellcategory_3='" + SpellCategory_3 + "',spellcategorycooldown_3='" + SpellCategoryCooldown_3 + "',spellid_4='" + SpellID_4 + "',spelltrigger_4='" + SpellTrigger_4 + "',spellcharges_4='" + SpellCharges_4 + "',spellppmRate_4='" + SpellppmRate_4 + "',spellcooldown_4='" + SpellCooldown_4 + "',spellcategory_4='" + SpellCategory_4 + "',spellcategorycooldown_4='" + SpellCategoryCooldown_4 + "',spellid_5='" + SpellID_5 + "',spelltrigger_5='" + SpellTrigger_5 + "',spellcharges_5='" + SpellCharges_5 + "',spellppmRate_5='" + SpellppmRate_5 + "',spellcooldown_5='" + SpellCooldown_5 + "',spellcategory_5='" + SpellCategory_5 + "',spellcategorycooldown_5='" + SpellCategoryCooldown_5 + "',bonding='" + Bonding + "',description='" + Description + "',PageText='" + PageText + "',LanguageID='" + LanguageID + "',PageMaterial='" + PageMeterial + "',startquest='" + StartQuest + "',lockid='" + LockID + "',Material='" + Material + "',sheath='" + Sheath + "',RandomProperty='" + RandomProperty + "',RandomSuffix='" + RandomSuffix + "',block='" + Block + "',itemset='" + ItemSet + "',MaxDurability='" + MaxDurability + "',area='" + Area + "',Map='" + Map + "',BagFamily='" + BagFamily + "',TotemCategory='" + TotemCategory + "',socketColor_1='" + SocketColor_1 + "',socketContent_1='" + SocketContent_1 + "',socketColor_2='" + SocketColor_2 + "',socketContent_2='" + SocketContent_2 + "',socketColor_3='" + SocketColor_3 + "',socketContent_3='" + SocketContent_3 + "',socketBonus='" + SocketBonus + "',GemProperties='" + GemProperties + "',RequiredDisenchantSkill='" + RequiredDisenchantSkill + "',ArmorDamageModifier='" + ArmorDamageModifier + "',Duration='" + Duration + "',ItemLimitCategory='" + ItemLimitCategory + "',ScriptName='" + ScriptName + "',HolidayId='" + HolidayId + "',DisenchantID='" + DisenchantID + "',FoodType='" + FoodType + "',minMoneyLoot='" + MinMoneyLoot + "',maxMoneyLoot='" + MaxMoneyLoot + "' where entry = '" + Entry + "';";
            }
            else if (ConnInfo.Dbstruct == "3.3.5(TC2)")
            {
                SQL = "update item_template set class='" + Class + "',subclass='" + SubClass + "',SoundOverrideSubclass='" + unk0 + "',name='" + Name + "',displayid='" + DisplayID + "',Quality='" + Quality + "',Flags='" + Flags + "',FlagsExtra='" + Faction + "',BuyCount='" + BuyCount + "',BuyPrice='" + BuyPrice + "',SellPrice='" + SellPrice + "',InventoryType='" + InventoryType + "',AllowableClass='" + AllowableClass + "',AllowableRace='" + AllowableRace + "',ItemLevel='" + ItemLevel + "',RequiredLevel='" + RequiredLevel + "',RequiredSkill='" + RequiredSkill + "',RequiredSkillRank='" + RequiredSkillRank + "',requiredspell='" + RequiredSpell + "',requiredhonorrank='" + RequiredHonnorRank + "',RequiredCityRank='" + RequiredCityRank + "',RequiredReputationFaction='" + RequiredReputationFaction + "',RequiredReputationRank='" + RequiredReputationRank + "',maxcount='" + MaxCount + "',stackable='" + StackAble + "',ContainerSlots='" + ContainerSlots + "',StatsCount='" + StatsCount + "',stat_type1='" + Stat_Type1 + "',stat_value1='" + Stat_Value1 + "',stat_type2='" + Stat_Type2 + "',stat_value2='" + Stat_Value2 + "',stat_type3='" + Stat_Type3 + "',stat_value3='" + Stat_Value3 + "',stat_type4='" + Stat_Type4 + "',stat_value4='" + Stat_Value4 + "',stat_type5='" + Stat_Type5 + "',stat_value5='" + Stat_Value5 + "',stat_type6='" + Stat_Type6 + "',stat_value6='" + Stat_Value6 + "',stat_type7='" + Stat_Type7 + "',stat_value7='" + Stat_Value7 + "',stat_type8='" + Stat_Type8 + "',stat_value8='" + Stat_Value8 + "',stat_type9='" + Stat_Type9 + "',stat_value9='" + Stat_Value9 + "',stat_type10='" + Stat_Type10 + "',stat_value10='" + Stat_Value10 + "',ScalingStatDistribution='" + ScalingStatDistribution + "',ScalingStatValue='" + ScalingStatValue + "',dmg_min1='" + Dmg_Min1 + "',dmg_max1='" + Dmg_Max1 + "',dmg_type1='" + Dmg_Type1 + "',dmg_min2='" + Dmg_Min2 + "',dmg_max2='" + Dmg_Max2 + "',dmg_type2='" + Dmg_Type2 + "',armor='" + Armor + "',holy_res='" + Holy_Res + "',fire_res='" + Fire_Res + "',nature_res='" + Nature_Res + "',frost_res='" + Frost_Res + "',shadow_res='" + Shadow_Res + "',arcane_res='" + Arcane_Res + "',delay='" + Delay + "',ammo_type='" + Ammo_Type + "',RangedModRange='" + RangedModRange + "',spellid_1='" + SpellID_1 + "',spelltrigger_1='" + SpellTrigger_1 + "',spellcharges_1='" + SpellCharges_1 + "',spellppmRate_1='" + SpellppmRate_1 + "',spellcooldown_1='" + SpellCooldown_1 + "',spellcategory_1='" + SpellCategory_1 + "',spellcategorycooldown_1='" + SpellCategoryCooldown_1 + "',spellid_2='" + SpellID_2 + "',spelltrigger_2='" + SpellTrigger_2 + "',spellcharges_2='" + SpellCharges_2 + "',spellppmRate_2='" + SpellppmRate_2 + "',spellcooldown_2='" + SpellCooldown_2 + "',spellcategory_2='" + SpellCategory_2 + "',spellcategorycooldown_2='" + SpellCategoryCooldown_2 + "',spellid_3='" + SpellID_3 + "',spelltrigger_3='" + SpellTrigger_3 + "',spellcharges_3='" + SpellCharges_3 + "',spellppmRate_3='" + SpellppmRate_3 + "',spellcooldown_3='" + SpellCooldown_3 + "',spellcategory_3='" + SpellCategory_3 + "',spellcategorycooldown_3='" + SpellCategoryCooldown_3 + "',spellid_4='" + SpellID_4 + "',spelltrigger_4='" + SpellTrigger_4 + "',spellcharges_4='" + SpellCharges_4 + "',spellppmRate_4='" + SpellppmRate_4 + "',spellcooldown_4='" + SpellCooldown_4 + "',spellcategory_4='" + SpellCategory_4 + "',spellcategorycooldown_4='" + SpellCategoryCooldown_4 + "',spellid_5='" + SpellID_5 + "',spelltrigger_5='" + SpellTrigger_5 + "',spellcharges_5='" + SpellCharges_5 + "',spellppmRate_5='" + SpellppmRate_5 + "',spellcooldown_5='" + SpellCooldown_5 + "',spellcategory_5='" + SpellCategory_5 + "',spellcategorycooldown_5='" + SpellCategoryCooldown_5 + "',bonding='" + Bonding + "',description='" + Description + "',PageText='" + PageText + "',LanguageID='" + LanguageID + "',PageMaterial='" + PageMeterial + "',startquest='" + StartQuest + "',lockid='" + LockID + "',Material='" + Material + "',sheath='" + Sheath + "',RandomProperty='" + RandomProperty + "',RandomSuffix='" + RandomSuffix + "',block='" + Block + "',itemset='" + ItemSet + "',MaxDurability='" + MaxDurability + "',area='" + Area + "',Map='" + Map + "',BagFamily='" + BagFamily + "',TotemCategory='" + TotemCategory + "',socketColor_1='" + SocketColor_1 + "',socketContent_1='" + SocketContent_1 + "',socketColor_2='" + SocketColor_2 + "',socketContent_2='" + SocketContent_2 + "',socketColor_3='" + SocketColor_3 + "',socketContent_3='" + SocketContent_3 + "',socketBonus='" + SocketBonus + "',GemProperties='" + GemProperties + "',RequiredDisenchantSkill='" + RequiredDisenchantSkill + "',ArmorDamageModifier='" + ArmorDamageModifier + "',Duration='" + Duration + "',ItemLimitCategory='" + ItemLimitCategory + "',ScriptName='" + ScriptName + "',HolidayId='" + HolidayId + "',DisenchantID='" + DisenchantID + "',FoodType='" + FoodType + "',minMoneyLoot='" + MinMoneyLoot + "',maxMoneyLoot='" + MaxMoneyLoot + "' where entry = '" + Entry + "';";
            }
            return SQL;
        }
        public string GetDelSql(string Entry)
        {
            Entry = GetValue("[1-9]{1}[0-9]+", Entry);
            string SQL = "delete from item_template where entry = '"+Entry+"';";
            return SQL;
        }
        private void GetSqlBtn_Click(object sender, EventArgs e)
        {
            FrmGetSql f2 = new FrmGetSql();
            f2.ShowSQL(GetAddSql(),"新建"+EntryTextBox.Text + "(" + RTB_ItemName.ColorText + ")");
            f2.Show();
        }

        private void ShowSQLBtn_Click_1(object sender, EventArgs e)
        {
            FrmGetSql f2 = new FrmGetSql();
            f2.ShowSQL(GetAddSql(), EntryTextBox.Text + "(" + RTB_ItemName.ColorText + ")");
            f2.ShowDialog();
        }
        public static string  GetConnStr()
        {
            string HostName = ConnInfo.HostName;
            string UserName = ConnInfo.UserName;
            string PWD = ConnInfo.PassWord;
            string db = ConnInfo.DataBase;
            uint port = ConnInfo.Port;
            //MySQLConnectionString strConn = new MySQLConnectionString(HostName, db, UserName, PWD);
            string strConn = "Database=" + db + ";Data Source=" + HostName + ";port=" + port + ";User Id=" + UserName + ";Password=" + PWD + ";CharSet=gbk";
            return strConn;
        }
        private void InsertBtn_Click(object sender, EventArgs e)
        {
            if (ConnInfo.Stat)
            {
                StateForm sf = new StateForm();
                Thread Del = new Thread(new ParameterizedThreadStart(sf.DBCMD));
                Del.Start(GetAddSql());
                sf.ShowDialog();
            }
            else
            {
                MessageBox.Show("没有连接数据库！", "写入数据库");
            }
        }
        public string GetFileName()
        {
            return EntryTextBox.Text + "(" + RTB_ItemName.ColorText + ")";
        }

        private void AbountBtn_Click(object sender, EventArgs e)
        {
            AboutForm AboutForm = new AboutForm();
            AboutForm.ShowDialog();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void DelItem(string Entry)
        {
            DialogResult result = MessageBox.Show("确认删除Entry为【" + Entry + "】的物品吗？\r\n注意：此操作是不可逆的！物品将永久删除。", "删除物品", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                StateForm sf = new StateForm();
                Thread Del = new Thread(new ParameterizedThreadStart(sf.DBCMD));
                Del.Start(GetDelSql(Entry));
                sf.ShowDialog();
            }
        }
        private void DelItemBtn_Click(object sender, EventArgs e)
        {
            if (ConnInfo.Stat)
            {
                DelItem(EntryTextBox.Text);
            }
            else
            {
                MessageBox.Show("没有连接数据库！", "连接数据库");
            }
        }

        private void GetDelSqlBtn_Click(object sender, EventArgs e)
        {
            FrmGetSql f2 = new FrmGetSql();
            f2.ShowSQL(GetDelSql(EntryTextBox.Text), "删除" + EntryTextBox.Text + "(" + RTB_ItemName.ColorText + ")");
            f2.Show();
        }

        private void GetEditSqlBtn_Click(object sender, EventArgs e)
        {
            FrmGetSql f2 = new FrmGetSql();
            f2.ShowSQL(GetEditSql(), "编辑"+EntryTextBox.Text + "(" + RTB_ItemName.ColorText + ")");
            f2.Show();
        }

        private void SaveItemInfoBtn_Click(object sender, EventArgs e)
        {
            if (ConnInfo.Stat)
            {
                DialogResult result = MessageBox.Show("确认编辑Entry为【" + EntryTextBox.Text + "】的物品吗？\r\n注意：此操作是不可逆的！原先的物品信息将被覆盖。", "保存物品信息", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    StateForm sf = new StateForm();
                    Thread Edit = new Thread(new ParameterizedThreadStart(sf.DBCMD));
                    Edit.Start(GetEditSql());
                    sf.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("没有连接数据库！", "写入数据库");
            }
        }
            public void GetItemInfo(DataSet ds)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ItemInfo.AllowableClass = ds.Tables[0].Rows[0]["AllowableClass"].ToString();
                    ItemInfo.AllowableRace = ds.Tables[0].Rows[0]["AllowableRace"].ToString();
                    ItemInfo.Ammo_Type = ds.Tables[0].Rows[0]["Ammo_Type"].ToString();
                    ItemInfo.Arcane_Res = ds.Tables[0].Rows[0]["Arcane_Res"].ToString();
                    ItemInfo.Area = ds.Tables[0].Rows[0]["Area"].ToString();
                    ItemInfo.Armor = ds.Tables[0].Rows[0]["Armor"].ToString();
                    ItemInfo.ArmorDamageModifier = ds.Tables[0].Rows[0]["ArmorDamageModifier"].ToString();
                    ItemInfo.BagFamily = ds.Tables[0].Rows[0]["BagFamily"].ToString();
                    ItemInfo.Block = ds.Tables[0].Rows[0]["Block"].ToString();
                    ItemInfo.Bonding = ds.Tables[0].Rows[0]["Bonding"].ToString();
                    ItemInfo.BuyCount = ds.Tables[0].Rows[0]["BuyCount"].ToString();
                    ItemInfo.BuyPrice = ds.Tables[0].Rows[0]["BuyPrice"].ToString();
                    ItemInfo.Class = ds.Tables[0].Rows[0]["Class"].ToString();
                    ItemInfo.ContainerSlots = ds.Tables[0].Rows[0]["ContainerSlots"].ToString();
                    ItemInfo.Delay = ds.Tables[0].Rows[0]["Delay"].ToString();
                    ItemInfo.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                    ItemInfo.DisenchantID = ds.Tables[0].Rows[0]["DisenchantID"].ToString();
                    ItemInfo.DisplayID = ds.Tables[0].Rows[0]["DisplayID"].ToString();
                    ItemInfo.Dmg_Max1 = ds.Tables[0].Rows[0]["Dmg_Max1"].ToString();
                    ItemInfo.Dmg_Max2 = ds.Tables[0].Rows[0]["Dmg_Max2"].ToString();
                    ItemInfo.Dmg_Min1 = ds.Tables[0].Rows[0]["Dmg_Min1"].ToString();
                    ItemInfo.Dmg_Min2 = ds.Tables[0].Rows[0]["Dmg_Min2"].ToString();
                    ItemInfo.Dmg_Type1 = ds.Tables[0].Rows[0]["Dmg_Type1"].ToString();
                    ItemInfo.Dmg_Type2 = ds.Tables[0].Rows[0]["Dmg_Type2"].ToString();
                    ItemInfo.Duration = ds.Tables[0].Rows[0]["Duration"].ToString();
                    ItemInfo.Entry = ds.Tables[0].Rows[0]["Entry"].ToString();
                    ItemInfo.Fire_Res = ds.Tables[0].Rows[0]["Fire_Res"].ToString();
                    ItemInfo.Flags = ds.Tables[0].Rows[0]["Flags"].ToString();
                    ItemInfo.FoodType = ds.Tables[0].Rows[0]["FoodType"].ToString();
                    ItemInfo.Frost_Res = ds.Tables[0].Rows[0]["Frost_Res"].ToString();
                    ItemInfo.GemProperties = ds.Tables[0].Rows[0]["GemProperties"].ToString();
                    ItemInfo.Holy_Res = ds.Tables[0].Rows[0]["Holy_Res"].ToString();
                    ItemInfo.InventoryType = ds.Tables[0].Rows[0]["InventoryType"].ToString();
                    ItemInfo.ItemLevel = ds.Tables[0].Rows[0]["ItemLevel"].ToString();
                    ItemInfo.ItemLimitCategory = ds.Tables[0].Rows[0]["ItemLimitCategory"].ToString();
                    ItemInfo.ItemSet = ds.Tables[0].Rows[0]["ItemSet"].ToString();
                    ItemInfo.LanguageID = ds.Tables[0].Rows[0]["LanguageID"].ToString();
                    ItemInfo.LockID = ds.Tables[0].Rows[0]["LockID"].ToString();
                    ItemInfo.Map = ds.Tables[0].Rows[0]["Map"].ToString();
                    ItemInfo.Material = ds.Tables[0].Rows[0]["Material"].ToString();
                    ItemInfo.MaxCount = ds.Tables[0].Rows[0]["MaxCount"].ToString();
                    ItemInfo.MaxDurability = ds.Tables[0].Rows[0]["MaxDurability"].ToString();
                    ItemInfo.MaxMoneyLoot = ds.Tables[0].Rows[0]["MaxMoneyLoot"].ToString();
                    ItemInfo.MinMoneyLoot = ds.Tables[0].Rows[0]["MinMoneyLoot"].ToString();
                    ItemInfo.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    ItemInfo.Nature_Res = ds.Tables[0].Rows[0]["Nature_Res"].ToString();
                    ItemInfo.PageMeterial = ds.Tables[0].Rows[0]["PageMaterial"].ToString();
                    ItemInfo.PageText = ds.Tables[0].Rows[0]["PageText"].ToString();
                    ItemInfo.Quality = ds.Tables[0].Rows[0]["Quality"].ToString();
                    ItemInfo.RandomProperty = ds.Tables[0].Rows[0]["RandomProperty"].ToString();
                    ItemInfo.RandomSuffix = ds.Tables[0].Rows[0]["RandomSuffix"].ToString();
                    ItemInfo.RangedModRange = ds.Tables[0].Rows[0]["RangedModRange"].ToString();
                    ItemInfo.RequiredCityRank = ds.Tables[0].Rows[0]["RequiredCityRank"].ToString();
                    ItemInfo.RequiredDisenchantSkill = ds.Tables[0].Rows[0]["RequiredDisenchantSkill"].ToString();
                    ItemInfo.RequiredHonnorRank = ds.Tables[0].Rows[0]["RequiredHonorRank"].ToString();
                    ItemInfo.RequiredLevel = ds.Tables[0].Rows[0]["RequiredLevel"].ToString();
                    ItemInfo.RequiredReputationFaction = ds.Tables[0].Rows[0]["RequiredReputationFaction"].ToString();
                    ItemInfo.RequiredReputationRank = ds.Tables[0].Rows[0]["RequiredReputationRank"].ToString();
                    ItemInfo.RequiredSkill = ds.Tables[0].Rows[0]["RequiredSkill"].ToString();
                    ItemInfo.RequiredSkillRank = ds.Tables[0].Rows[0]["RequiredSkillRank"].ToString();
                    ItemInfo.RequiredSpell = ds.Tables[0].Rows[0]["RequiredSpell"].ToString();
                    ItemInfo.ScalingStatDistribution = ds.Tables[0].Rows[0]["ScalingStatDistribution"].ToString();
                    ItemInfo.ScalingStatValue = ds.Tables[0].Rows[0]["ScalingStatValue"].ToString();
                    ItemInfo.ScriptName = ds.Tables[0].Rows[0]["ScriptName"].ToString();
                    ItemInfo.SellPrice = ds.Tables[0].Rows[0]["SellPrice"].ToString();
                    ItemInfo.Shadow_Res = ds.Tables[0].Rows[0]["Shadow_Res"].ToString();
                    ItemInfo.Sheath = ds.Tables[0].Rows[0]["Sheath"].ToString();
                    ItemInfo.SocketBonus = ds.Tables[0].Rows[0]["SocketBonus"].ToString();
                    ItemInfo.SocketColor_1 = ds.Tables[0].Rows[0]["SocketColor_1"].ToString();
                    ItemInfo.SocketColor_2 = ds.Tables[0].Rows[0]["SocketColor_2"].ToString();
                    ItemInfo.SocketColor_3 = ds.Tables[0].Rows[0]["SocketColor_3"].ToString();
                    ItemInfo.SocketContent_1 = ds.Tables[0].Rows[0]["SocketContent_1"].ToString();
                    ItemInfo.SocketContent_2 = ds.Tables[0].Rows[0]["SocketContent_2"].ToString();
                    ItemInfo.SocketContent_3 = ds.Tables[0].Rows[0]["SocketContent_3"].ToString();
                    ItemInfo.SpellCategory_1 = ds.Tables[0].Rows[0]["SpellCategory_1"].ToString();
                    ItemInfo.SpellCategory_2 = ds.Tables[0].Rows[0]["SpellCategory_2"].ToString();
                    ItemInfo.SpellCategory_3 = ds.Tables[0].Rows[0]["SpellCategory_3"].ToString();
                    ItemInfo.SpellCategory_4 = ds.Tables[0].Rows[0]["SpellCategory_4"].ToString();
                    ItemInfo.SpellCategory_5 = ds.Tables[0].Rows[0]["SpellCategory_5"].ToString();
                    ItemInfo.SpellCategoryCooldown_1 = ds.Tables[0].Rows[0]["SpellCategoryCooldown_1"].ToString();
                    ItemInfo.SpellCategoryCooldown_2 = ds.Tables[0].Rows[0]["SpellCategoryCooldown_2"].ToString();
                    ItemInfo.SpellCategoryCooldown_3 = ds.Tables[0].Rows[0]["SpellCategoryCooldown_3"].ToString();
                    ItemInfo.SpellCategoryCooldown_4 = ds.Tables[0].Rows[0]["SpellCategoryCooldown_4"].ToString();
                    ItemInfo.SpellCategoryCooldown_5 = ds.Tables[0].Rows[0]["SpellCategoryCooldown_5"].ToString();
                    ItemInfo.SpellCharges_1 = ds.Tables[0].Rows[0]["SpellCharges_1"].ToString();
                    ItemInfo.SpellCharges_2 = ds.Tables[0].Rows[0]["SpellCharges_2"].ToString();
                    ItemInfo.SpellCharges_3 = ds.Tables[0].Rows[0]["SpellCharges_3"].ToString();
                    ItemInfo.SpellCharges_4 = ds.Tables[0].Rows[0]["SpellCharges_4"].ToString();
                    ItemInfo.SpellCharges_5 = ds.Tables[0].Rows[0]["SpellCharges_5"].ToString();
                    ItemInfo.SpellCooldown_1 = ds.Tables[0].Rows[0]["SpellCooldown_1"].ToString();
                    ItemInfo.SpellCooldown_2 = ds.Tables[0].Rows[0]["SpellCooldown_2"].ToString();
                    ItemInfo.SpellCooldown_3 = ds.Tables[0].Rows[0]["SpellCooldown_3"].ToString();
                    ItemInfo.SpellCooldown_4 = ds.Tables[0].Rows[0]["SpellCooldown_4"].ToString();
                    ItemInfo.SpellCooldown_5 = ds.Tables[0].Rows[0]["SpellCooldown_5"].ToString();
                    ItemInfo.SpellID_1 = ds.Tables[0].Rows[0]["SpellID_1"].ToString();
                    ItemInfo.SpellID_2 = ds.Tables[0].Rows[0]["SpellID_2"].ToString();
                    ItemInfo.SpellID_3 = ds.Tables[0].Rows[0]["SpellID_3"].ToString();
                    ItemInfo.SpellID_4 = ds.Tables[0].Rows[0]["SpellID_4"].ToString();
                    ItemInfo.SpellID_5 = ds.Tables[0].Rows[0]["SpellID_5"].ToString();
                    ItemInfo.SpellppmRate_1 = ds.Tables[0].Rows[0]["SpellppmRate_1"].ToString();
                    ItemInfo.SpellppmRate_2 = ds.Tables[0].Rows[0]["SpellppmRate_2"].ToString();
                    ItemInfo.SpellppmRate_3 = ds.Tables[0].Rows[0]["SpellppmRate_3"].ToString();
                    ItemInfo.SpellppmRate_4 = ds.Tables[0].Rows[0]["SpellppmRate_4"].ToString();
                    ItemInfo.SpellppmRate_5 = ds.Tables[0].Rows[0]["SpellppmRate_5"].ToString();
                    ItemInfo.SpellTrigger_1 = ds.Tables[0].Rows[0]["SpellTrigger_1"].ToString();
                    ItemInfo.SpellTrigger_2 = ds.Tables[0].Rows[0]["SpellTrigger_2"].ToString();
                    ItemInfo.SpellTrigger_3 = ds.Tables[0].Rows[0]["SpellTrigger_3"].ToString();
                    ItemInfo.SpellTrigger_4 = ds.Tables[0].Rows[0]["SpellTrigger_4"].ToString();
                    ItemInfo.SpellTrigger_5 = ds.Tables[0].Rows[0]["SpellTrigger_5"].ToString();
                    ItemInfo.StackAble = ds.Tables[0].Rows[0]["StackAble"].ToString();
                    ItemInfo.StartQuest = ds.Tables[0].Rows[0]["StartQuest"].ToString();
                    ItemInfo.Stat_Type1 = ds.Tables[0].Rows[0]["Stat_Type1"].ToString();
                    ItemInfo.Stat_Type2 = ds.Tables[0].Rows[0]["Stat_Type2"].ToString();
                    ItemInfo.Stat_Type3 = ds.Tables[0].Rows[0]["Stat_Type3"].ToString();
                    ItemInfo.Stat_Type4 = ds.Tables[0].Rows[0]["Stat_Type4"].ToString();
                    ItemInfo.Stat_Type5 = ds.Tables[0].Rows[0]["Stat_Type5"].ToString();
                    ItemInfo.Stat_Type6 = ds.Tables[0].Rows[0]["Stat_Type6"].ToString();
                    ItemInfo.Stat_Type7 = ds.Tables[0].Rows[0]["Stat_Type7"].ToString();
                    ItemInfo.Stat_Type8 = ds.Tables[0].Rows[0]["Stat_Type8"].ToString();
                    ItemInfo.Stat_Type9 = ds.Tables[0].Rows[0]["Stat_Type9"].ToString();
                    ItemInfo.Stat_Type10 = ds.Tables[0].Rows[0]["Stat_Type10"].ToString();
                    ItemInfo.Stat_Value1 = ds.Tables[0].Rows[0]["Stat_Value1"].ToString();
                    ItemInfo.Stat_Value2 = ds.Tables[0].Rows[0]["Stat_Value2"].ToString();
                    ItemInfo.Stat_Value3 = ds.Tables[0].Rows[0]["Stat_Value3"].ToString();
                    ItemInfo.Stat_Value4 = ds.Tables[0].Rows[0]["Stat_Value4"].ToString();
                    ItemInfo.Stat_Value5 = ds.Tables[0].Rows[0]["Stat_Value5"].ToString();
                    ItemInfo.Stat_Value6 = ds.Tables[0].Rows[0]["Stat_Value6"].ToString();
                    ItemInfo.Stat_Value7 = ds.Tables[0].Rows[0]["Stat_Value7"].ToString();
                    ItemInfo.Stat_Value8 = ds.Tables[0].Rows[0]["Stat_Value8"].ToString();
                    ItemInfo.Stat_Value9 = ds.Tables[0].Rows[0]["Stat_Value9"].ToString();
                    ItemInfo.Stat_Value10 = ds.Tables[0].Rows[0]["Stat_Value10"].ToString();
                    ItemInfo.StatsCount = ds.Tables[0].Rows[0]["StatsCount"].ToString();
                    ItemInfo.SubClass = ds.Tables[0].Rows[0]["SubClass"].ToString();
                    ItemInfo.TotemCategory = ds.Tables[0].Rows[0]["TotemCategory"].ToString();
                    if (ds.Tables[0].Columns.Contains("Unk0"))
                        ItemInfo.Unk0 = ds.Tables[0].Rows[0]["Unk0"].ToString();
                    else if (ds.Tables[0].Columns.Contains("SoundOverrideSubclass"))
                        ItemInfo.Unk0 = ds.Tables[0].Rows[0]["SoundOverrideSubclass"].ToString();
                    ItemInfo.Stat = true;
                    if (ConnInfo.Dbstruct == "3.0.X")
                    {
                        ItemInfo.Dmg_Max3 = ds.Tables[0].Rows[0]["Dmg_Max3"].ToString();
                        ItemInfo.Dmg_Max4 = ds.Tables[0].Rows[0]["Dmg_Max4"].ToString();
                        ItemInfo.Dmg_Max5 = ds.Tables[0].Rows[0]["Dmg_Max5"].ToString();
                        ItemInfo.Dmg_Min3 = ds.Tables[0].Rows[0]["Dmg_Min3"].ToString();
                        ItemInfo.Dmg_Min4 = ds.Tables[0].Rows[0]["Dmg_Min4"].ToString();
                        ItemInfo.Dmg_Min5 = ds.Tables[0].Rows[0]["Dmg_Min5"].ToString();
                        ItemInfo.Dmg_Type3 = ds.Tables[0].Rows[0]["Dmg_Type3"].ToString();
                        ItemInfo.Dmg_Type4 = ds.Tables[0].Rows[0]["Dmg_Type4"].ToString();
                        ItemInfo.Dmg_Type5 = ds.Tables[0].Rows[0]["Dmg_Type5"].ToString();
                    }
                    else if (ConnInfo.Dbstruct == "3.3.X")
                    {
                        ItemInfo.HolidayId = (ds.Tables[0].Rows[0].IsNull("HolidayId") == false) ? ds.Tables[0].Rows[0]["HolidayId"].ToString() : string.Empty;
                    }
                    else if (ConnInfo.Dbstruct == "真爱XV")
                    {
                        ItemInfo.HolidayId = (ds.Tables[0].Rows[0].IsNull("HolidayId") == false) ? ds.Tables[0].Rows[0]["HolidayId"].ToString() : string.Empty;
                    }
                }
                else
                {
                    throw new Exception("没有找到该物品！");
                }
        }

            public void GetItemInfo(string Entry)
            {
                StateForm sf = new StateForm();
                Thread EditAdp = new Thread(new ParameterizedThreadStart(sf.DBAdapter));
                EditAdp.Start("select * from item_template where entry = '" + Entry + "';");
                sf.ShowDialog();
                if (ItemInfo.Stat)
                {
                    AllowableClassList.Text = ItemInfo.AllowableClass;
                    AllowableRaceList.Text = ItemInfo.AllowableRace;
                    Ammo_TypeList.Text = ItemInfo.Ammo_Type;
                    arcane_resTextBox.Text = ItemInfo.Arcane_Res;
                    AreaList.Text = ItemInfo.Area;
                    armorTextBox.Text = ItemInfo.Armor;
                    ArmorDamageModifierTextBox.Text = ItemInfo.ArmorDamageModifier;
                    BagFamilyTextBox.Text = ItemInfo.BagFamily;
                    blockTextBox.Text = ItemInfo.Block;
                    BondingList.Text = ItemInfo.Bonding;
                    BuyCountTextBox.Text = ItemInfo.BuyCount;
                    BuyPriceTextBox.Text = ItemInfo.BuyPrice;
                    ItemClassList.Text = ItemInfo.Class;
                    ContainerSlotsTextBox.Text = ItemInfo.ContainerSlots;
                    delayTextBox.Text = ItemInfo.Delay;
                    RTB_Description.ColorText = ItemInfo.Description;
                    DisenchantIDTextBox.Text = ItemInfo.DisenchantID;
                    DisplayIDList.Text = ItemInfo.DisplayID;
                    dmg_max1TextBox.Text = ItemInfo.Dmg_Max1;
                    dmg_max2TextBox.Text = ItemInfo.Dmg_Max2;
                    dmg_min1TextBox.Text = ItemInfo.Dmg_Min1;
                    dmg_min2TextBox.Text = ItemInfo.Dmg_Min2;
                    dmg_type1List.Text = ItemInfo.Dmg_Type1;
                    dmg_type2List.Text = ItemInfo.Dmg_Type2;
                    DurationTextBox.Text = ItemInfo.Duration;
                    EntryTextBox.Text = ItemInfo.Entry;
                    fire_resTextBox.Text = ItemInfo.Fire_Res;
                    FlagsList.Text = ItemInfo.Flags;
                    FoodTypeTextBox.Text = ItemInfo.FoodType;
                    frost_resTextBox.Text = ItemInfo.Frost_Res;
                    GemPropertiesTextBox.Text = ItemInfo.GemProperties;
                    holy_resTextBox.Text = ItemInfo.Holy_Res;
                    InventoryTypeList.Text = ItemInfo.InventoryType;
                    ItemLevelTextBox.Text = ItemInfo.ItemLevel;
                    ItemLimitCategoryTextBox.Text = ItemInfo.ItemLimitCategory;
                    ItemSetTextBox.Text = ItemInfo.ItemSet;
                    LanguageIDTextBox.Text = ItemInfo.LanguageID;
                    LockIdTextBox.Text = ItemInfo.LockID;
                    MapList.Text = ItemInfo.Map;
                    MaterialList.Text = ItemInfo.Material;
                    maxcountTextBox.Text = ItemInfo.MaxCount;
                    MaxDurabilityTextBox.Text = ItemInfo.MaxDurability;
                    MaxMoneyLootTextBox.Text = ItemInfo.MaxMoneyLoot;
                    MinMoneyLootTextBox.Text = ItemInfo.MinMoneyLoot;
                    RTB_ItemName.ColorText = ItemInfo.Name;
                    nature_resTextBox.Text = ItemInfo.Nature_Res;
                    PageMeterialTextBox.Text = ItemInfo.PageMeterial;
                    PageTextTextBox.Text = ItemInfo.PageText;
                    QualityList.Text = ItemInfo.Quality;
                    RandomPropertyList.Text = ItemInfo.RandomProperty;
                    RandomSuffixList.Text = ItemInfo.RandomSuffix;
                    RangedModRangeTextBox.Text = ItemInfo.RangedModRange;
                    RequiredCityRankTextBox.Text = ItemInfo.RequiredCityRank;
                    RequiredDisenchantSkillTextBox.Text = ItemInfo.RequiredDisenchantSkill;
                    RequiredHonnorRankTextBox.Text = ItemInfo.RequiredHonnorRank;
                    RequiredLevelTextBox.Text = ItemInfo.RequiredLevel;
                    RequiredReputationFactionTextBox.Text = ItemInfo.RequiredReputationFaction;
                    RequiredReputationRankTextBox.Text = ItemInfo.RequiredReputationRank;
                    RequiredSkillTextBox.Text = ItemInfo.RequiredSkill;
                    RequiredSkillRankTextBox.Text = ItemInfo.RequiredSkillRank;
                    RequiredSpellTextBox.Text = ItemInfo.RequiredSpell;
                    ScalingStatDistributionTextBox.Text = ItemInfo.ScalingStatDistribution;
                    ScalingStatValueTextBox.Text = ItemInfo.ScalingStatValue;
                    ScriptNameTextBox.Text = ItemInfo.ScriptName;
                    SellPriceTextBox.Text = ItemInfo.SellPrice;
                    shadow_resTextBox.Text = ItemInfo.Shadow_Res;
                    SheathList.Text = ItemInfo.Sheath;
                    SocketBonusList.Text = ItemInfo.SocketBonus;
                    SocketColor_1List.Text = ItemInfo.SocketColor_1;
                    SocketColor_2List.Text = ItemInfo.SocketColor_2;
                    SocketColor_3List.Text = ItemInfo.SocketColor_3;
                    SocketContent_1TextBox.Text = ItemInfo.SocketContent_1;
                    SocketContent_2TextBox.Text = ItemInfo.SocketContent_2;
                    SocketContent_3TextBox.Text = ItemInfo.SocketContent_3;
                    SpellCategory_1TextBox.Text = ItemInfo.SpellCategory_1;
                    SpellCategory_2TextBox.Text = ItemInfo.SpellCategory_2;
                    SpellCategory_3TextBox.Text = ItemInfo.SpellCategory_3;
                    SpellCategory_4TextBox.Text = ItemInfo.SpellCategory_4;
                    SpellCategory_5TextBox.Text = ItemInfo.SpellCategory_5;
                    SpellCategoryCooldown_1TextBox.Text = ItemInfo.SpellCategoryCooldown_1;
                    SpellCategoryCooldown_2TextBox.Text = ItemInfo.SpellCategoryCooldown_2;
                    SpellCategoryCooldown_3TextBox.Text = ItemInfo.SpellCategoryCooldown_3;
                    SpellCategoryCooldown_4TextBox.Text = ItemInfo.SpellCategoryCooldown_4;
                    SpellCategoryCooldown_5TextBox.Text = ItemInfo.SpellCategoryCooldown_5;
                    SpellCharges_1TextBox.Text = ItemInfo.SpellCharges_1;
                    SpellCharges_2TextBox.Text = ItemInfo.SpellCharges_2;
                    SpellCharges_3TextBox.Text = ItemInfo.SpellCharges_3;
                    SpellCharges_4TextBox.Text = ItemInfo.SpellCharges_4;
                    SpellCharges_5TextBox.Text = ItemInfo.SpellCharges_5;
                    spellcooldown_1TextBox.Text = ItemInfo.SpellCooldown_1;
                    spellcooldown_2TextBox.Text = ItemInfo.SpellCooldown_2;
                    spellcooldown_3TextBox.Text = ItemInfo.SpellCooldown_3;
                    spellcooldown_4TextBox.Text = ItemInfo.SpellCooldown_4;
                    spellcooldown_5TextBox.Text = ItemInfo.SpellCooldown_5;
                    spellid_1List.Text = ItemInfo.SpellID_1;
                    spellid_2List.Text = ItemInfo.SpellID_2;
                    spellid_3List.Text = ItemInfo.SpellID_3;
                    spellid_4List.Text = ItemInfo.SpellID_4;
                    spellid_5List.Text = ItemInfo.SpellID_5;
                    SpellppmRate_1TextBox.Text = ItemInfo.SpellppmRate_1;
                    SpellppmRate_2TextBox.Text = ItemInfo.SpellppmRate_2;
                    SpellppmRate_3TextBox.Text = ItemInfo.SpellppmRate_3;
                    SpellppmRate_4TextBox.Text = ItemInfo.SpellppmRate_4;
                    SpellppmRate_5TextBox.Text = ItemInfo.SpellppmRate_5;
                    spelltrigger_1List.Text = ItemInfo.SpellTrigger_1;
                    spelltrigger_2List.Text = ItemInfo.SpellTrigger_2;
                    spelltrigger_3List.Text = ItemInfo.SpellTrigger_3;
                    spelltrigger_4List.Text = ItemInfo.SpellTrigger_4;
                    spelltrigger_5List.Text = ItemInfo.SpellTrigger_5;
                    StackAbleTextBox.Text = ItemInfo.StackAble;
                    StartQuestTextBox.Text = ItemInfo.StartQuest;
                    Stat_Type1List.Text = ItemInfo.Stat_Type1;
                    Stat_Type2List.Text = ItemInfo.Stat_Type2;
                    Stat_Type3List.Text = ItemInfo.Stat_Type3;
                    Stat_Type4List.Text = ItemInfo.Stat_Type4;
                    Stat_Type5List.Text = ItemInfo.Stat_Type5;
                    Stat_Type6List.Text = ItemInfo.Stat_Type6;
                    Stat_Type7List.Text = ItemInfo.Stat_Type7;
                    Stat_Type8List.Text = ItemInfo.Stat_Type8;
                    Stat_Type9List.Text = ItemInfo.Stat_Type9;
                    Stat_Type10List.Text = ItemInfo.Stat_Type10;
                    Stat_Value1TextBox.Text = ItemInfo.Stat_Value1;
                    Stat_Value2TextBox.Text = ItemInfo.Stat_Value2;
                    Stat_Value3TextBox.Text = ItemInfo.Stat_Value3;
                    Stat_Value4TextBox.Text = ItemInfo.Stat_Value4;
                    Stat_Value5TextBox.Text = ItemInfo.Stat_Value5;
                    Stat_Value6TextBox.Text = ItemInfo.Stat_Value6;
                    Stat_Value7TextBox.Text = ItemInfo.Stat_Value7;
                    Stat_Value8TextBox.Text = ItemInfo.Stat_Value8;
                    Stat_Value9TextBox.Text = ItemInfo.Stat_Value9;
                    Stat_Value10TextBox.Text = ItemInfo.Stat_Value10;
                    StatsCountList.Text = ItemInfo.StatsCount;
                    ItemSubClassList.Text = ItemInfo.SubClass;
                    TotemCategoryTextBox.Text = ItemInfo.TotemCategory;
                    unk0TextBox.Text = ItemInfo.Unk0;
                    if (ConnInfo.Dbstruct == "3.0.0-3.0.9")
                    {
                        dmg_max3TextBox.Text = ItemInfo.Dmg_Max3;
                        dmg_max4TextBox.Text = ItemInfo.Dmg_Max4;
                        dmg_max5TextBox.Text = ItemInfo.Dmg_Max5;
                        dmg_min3TextBox.Text = ItemInfo.Dmg_Min3;
                        dmg_min4TextBox.Text = ItemInfo.Dmg_Min4;
                        dmg_min5TextBox.Text = ItemInfo.Dmg_Min5;
                        dmg_type3List.Text = ItemInfo.Dmg_Type3;
                        dmg_type4List.Text = ItemInfo.Dmg_Type4;
                        dmg_type5List.Text = ItemInfo.Dmg_Type5;
                        label1.Text = "Faction(阵营)：";
                    }
                    else if (ConnInfo.Dbstruct == "3.1.X")
                    {
                        label1.Text = "Faction(阵营)：";
                    }
                    else if (ConnInfo.Dbstruct == "3.3.X")
                    {
                        HolidayIDTextBox.Text = ItemInfo.HolidayId;
                        label1.Text = "Faction(阵营)：";
                    }
                    else if (ConnInfo.Dbstruct == "真爱XV")
                    {
                        HolidayIDTextBox.Text = ItemInfo.HolidayId;
                        label1.Text = "FlagsExtra:";
                    }
                    try
                    {
                        string SubClassNum = GetValue("[0-9]+", ItemClassList.Text);
                        Regex reg = new Regex("\r\n");
                        StreamReader subclassTXT = new StreamReader("Data\\subclass" + SubClassNum + ".txt");
                        string[] EveryLine = reg.Split(subclassTXT.ReadToEnd());
                        subclassTXT.Close();
                        ItemSubClassList.Items.Clear();
                        foreach (string Line in EveryLine)
                        {
                            ItemSubClassList.Items.Add(Line);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "错误");
                        ItemSubClassList.DropDownStyle = ComboBoxStyle.DropDown;
                    }

                }
            }
        private void GetItemInfoBtn_Click(object sender, EventArgs e)
        {
            if (ConnInfo.Stat)
            {
                GetItemInfo(EntryTextBox.Text);
            }
            else
            {
                MessageBox.Show("没有连接数据库！", "连接数据库");
            }
        }

        private void ExecuteSqlBtn_Click(object sender, EventArgs e)
        {
            if (ConnInfo.Stat)
            {
                ExecuteSql ExecSql = new ExecuteSql();
                ExecSql.Show();
            }
            else
            {
                MessageBox.Show("没有连接数据库！", "连接数据库");
            }
        }

        private void ShowSetConnBtn_Click(object sender, EventArgs e)
        {
            SetConn sc = new SetConn();
            sc.ShowDialog();
            if (ConnInfo.Dbstruct == "3.0.X")
            {
                dmg_min3TextBox.Enabled = true;
                dmg_max3TextBox.Enabled = true;
                dmg_type3List.Enabled = true;
                dmg_min4TextBox.Enabled = true;
                dmg_max4TextBox.Enabled = true;
                dmg_type4List.Enabled = true;
                dmg_min5TextBox.Enabled = true;
                dmg_max5TextBox.Enabled = true;
                dmg_type5List.Enabled = true;
                FactionTextBox.Enabled = false;
                HolidayIDTextBox.Enabled = false;
                label1.Text = "Faction(阵营)：";
            }
            else if (ConnInfo.Dbstruct == "3.1.X")
            {
                dmg_min3TextBox.Enabled = false;
                dmg_max3TextBox.Enabled = false;
                dmg_type3List.Enabled = false;
                dmg_min4TextBox.Enabled = false;
                dmg_max4TextBox.Enabled = false;
                dmg_type4List.Enabled = false;
                dmg_min5TextBox.Enabled = false;
                dmg_max5TextBox.Enabled = false;
                dmg_type5List.Enabled = false;
                FactionTextBox.Enabled = false;
                HolidayIDTextBox.Enabled = false;
                label1.Text = "Faction(阵营)：";
            }
            else if (ConnInfo.Dbstruct == "3.2.X")
            {
                dmg_min3TextBox.Enabled = false;
                dmg_max3TextBox.Enabled = false;
                dmg_type3List.Enabled = false;
                dmg_min4TextBox.Enabled = false;
                dmg_max4TextBox.Enabled = false;
                dmg_type4List.Enabled = false;
                dmg_min5TextBox.Enabled = false;
                dmg_max5TextBox.Enabled = false;
                dmg_type5List.Enabled = false;
                FactionTextBox.Enabled = true;
                HolidayIDTextBox.Enabled = false;
                label1.Text = "Faction(阵营)：";
            }
            else if (ConnInfo.Dbstruct == "3.3.X")
            {
                dmg_min3TextBox.Enabled = false;
                dmg_max3TextBox.Enabled = false;
                dmg_type3List.Enabled = false;
                dmg_min4TextBox.Enabled = false;
                dmg_max4TextBox.Enabled = false;
                dmg_type4List.Enabled = false;
                dmg_min5TextBox.Enabled = false;
                dmg_max5TextBox.Enabled = false;
                dmg_type5List.Enabled = false;
                FactionTextBox.Enabled = true;
                HolidayIDTextBox.Enabled = true;
                label1.Text = "Faction(阵营)：";
            }
            else if (ConnInfo.Dbstruct == "真爱XV")
            {
                HolidayIDTextBox.Text = ItemInfo.HolidayId;
                label1.Text = "FlagsExtra:";
            }
            if (ConnInfo.Stat)
            {
                ConnStat.Text = ConnInfo.UserName + "@" + ConnInfo.HostName;
                if (ConnInfo.DataBase != "")
                {
                    ConnStat.Text += " → " + ConnInfo.DataBase;
                }
                ConnStat.Text += "(" + ConnInfo.Dbstruct + ")";
            }
            else
            {
                ConnStat.Text = "未连接";
            }
        }

        private void ShowSearchBtn_Click(object sender, EventArgs e)
        {
            if (ConnInfo.Stat)
            {
                Search SearchForm = new Search();
                SearchForm.OnEdit += new OnEditBtnClick(SearchForm_OnEdit);
                SearchForm.OnDel += new OnEditBtnClick(SearchForm_OnDel);
                SearchForm.Show();
            }
            else
            {
                MessageBox.Show("没有连接数据库！", "连接数据库");
            }
        }

        void SearchForm_OnDel(string str)
        {
            this.Activate();
            if (ConnInfo.Stat)
            {
                DelItem(str);
            }
            else
            {
                MessageBox.Show("没有连接数据库！", "连接数据库");
            }
        }

        void SearchForm_OnEdit(string str)
        {
            this.Activate();
            if (ConnInfo.Stat)
            {
                GetItemInfo(str);
            }
            else
            {
                MessageBox.Show("没有连接数据库！", "连接数据库");
            }
        }

        private void ItemSubClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Class = GetValue("[0-9]+", ItemClassList.Text);
            string SubClass = GetValue("[0-9]+", ItemSubClassList.Text);
            if (Class == "2")
            {
                if (SubClass == "2" | SubClass == "3" | SubClass == "16" | SubClass == "18"|SubClass=="19")
                {
                    RangedModRangeTextBox.Text = "100";
                }
            }
        }

        public void SaveConnInfoXml()
        {
            if (File.Exists("Data\\ConnInfo.cfg"))
                File.Delete("Data\\ConnInfo.cfg");
            XmlWriter xmlr = XmlWriter.Create("Data\\ConnInfo.cfg");
            xmlr.WriteStartElement("WOWItemMaker");
            string hostStr = ConnInfo.HostName;
            if (ConnInfo.Port != 3306)
                hostStr += ":" + ConnInfo.Port;
            xmlr.WriteElementString("HostName", hostStr);
            xmlr.WriteElementString("UserName", ConnInfo.UserName);
            if (ConnInfo.SavePwd)
                xmlr.WriteElementString("PassWord", ConnInfo.PassWord);
            else
                xmlr.WriteElementString("PassWord", string.Empty);
            xmlr.WriteElementString("DataBase", ConnInfo.DataBase);
            xmlr.WriteElementString("Dbstruct", ConnInfo.Dbstruct);
            xmlr.WriteEndElement();
            xmlr.Flush();
            xmlr.Close();
        }

        public void LoadConnInfoXml()
        {
            if (File.Exists("Data\\ConnInfo.cfg"))
            {
                XmlReader xmlr = XmlReader.Create("Data\\ConnInfo.cfg");
                xmlr.Read();
                xmlr.ReadToNextSibling("WOWItemMaker");
                xmlr.ReadToDescendant("HostName");
                ConnInfo.HostName = xmlr.ReadString();
                xmlr.ReadToNextSibling("UserName");
                ConnInfo.UserName = xmlr.ReadString();
                xmlr.ReadToNextSibling("PassWord");
                string PassWord = xmlr.ReadString();
                if (PassWord != string.Empty)
                {
                    ConnInfo.PassWord = PassWord;
                    ConnInfo.SavePwd = true;
                }
                else
                {
                    ConnInfo.PassWord = string.Empty;
                }
                xmlr.ReadToNextSibling("DataBase");
                ConnInfo.DataBase = xmlr.ReadString();
                xmlr.ReadToNextSibling("Dbstruct");
                ConnInfo.Dbstruct = xmlr.ReadString();
                xmlr.Close();
                ConnInfo.SaveConnInfo = true;
            }
        }

        private void Btn_MPQMaker_Click(object sender, EventArgs e)
        {
            if (ConnInfo.Stat)
            {
                FrmMPQMaker frm_MPQMaker = new FrmMPQMaker();
                frm_MPQMaker.Show();
            }
            else
            {
                MessageBox.Show("没有连接数据库！", "连接数据库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_NameColor_Click(object sender, EventArgs e)
        {
            DialogResult r = colorDialog1.ShowDialog();
            if (r == DialogResult.OK)
                RTB_ItemName.SelectionColor = colorDialog1.Color;
        }

        private void RTB_ItemName_Enter(object sender, EventArgs e)
        {
            Btn_NameColor.Visible = true;
        }

        private void RTB_ItemName_Leave(object sender, EventArgs e)
        {
            Btn_NameColor.Visible = false;
        }

        private void Btn_DcpColor_Click(object sender, EventArgs e)
        {
            DialogResult r = colorDialog1.ShowDialog();
            if (r == DialogResult.OK)
                RTB_Description.SelectionColor = colorDialog1.Color;
        }

        private void RTB_Description_Enter(object sender, EventArgs e)
        {
            Btn_DcpColor.Visible = true;
        }

        private void RTB_Description_Leave(object sender, EventArgs e)
        {
            Btn_DcpColor.Visible = false;
        }

    }
}
