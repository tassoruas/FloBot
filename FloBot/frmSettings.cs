using AutoItX3Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FloBot
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        KeyboardHook keyboardHook = new KeyboardHook();
        AutoItX3 autoIt = new AutoItX3();
        public bool configuring = false;
        public string keyPressed;

        private void frmSettings_Load(object sender, EventArgs e)
        {
            keyboardHook.KeyPress += new KeyPressEventHandler(keyboardHook_KeyPress);
        }

        void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (configuring)
                {
                    keyPressed = e.KeyChar.ToString();
                    if (keyPressed == "1")
                    {
                        Globals.MonsterAvailablePixel_X = autoIt.MouseGetPosX();
                        Globals.MonsterAvailablePixel_Y = autoIt.MouseGetPosY();
                        Globals.MonsterAvailablePixelColor = autoIt.PixelGetColor(Globals.MonsterAvailablePixel_X, Globals.MonsterAvailablePixel_Y);
                        MessageBox.Show("Monster HP Bar Done");
                    }
                    if (keyPressed == "2")
                    {
                        Globals.HpPotionPixel_X = autoIt.MouseGetPosX();
                        Globals.HpPotionPixel_Y = autoIt.MouseGetPosY();
                        Globals.HpPotionPixelColor = autoIt.PixelGetColor(Globals.HpPotionPixel_X, Globals.HpPotionPixel_Y);
                        MessageBox.Show("HP Potion Done");
                    }
                    if (keyPressed == "3")
                    {
                        Globals.MpPotionPixel_X = autoIt.MouseGetPosX();
                        Globals.MpPotionPixel_Y = autoIt.MouseGetPosY();
                        Globals.MpPotionPixelColor = autoIt.PixelGetColor(Globals.MpPotionPixel_X, Globals.MpPotionPixel_Y);
                        MessageBox.Show("MP Potion Done");
                    }
                    if (keyPressed == "4")
                    {
                        Globals.SitHpPixel_X = autoIt.MouseGetPosX();
                        Globals.SitHpPixel_Y = autoIt.MouseGetPosY();
                        Globals.SitHpPixelColor = autoIt.PixelGetColor(Globals.SitHpPixel_X, Globals.SitHpPixel_Y);
                        MessageBox.Show("Sit HP Done");
                    }
                    if (keyPressed == "5")
                    {
                        Globals.SitMpPixel_X = autoIt.MouseGetPosX();
                        Globals.SitMpPixel_Y = autoIt.MouseGetPosY();
                        Globals.SitMpPixelColor = autoIt.PixelGetColor(Globals.SitMpPixel_X, Globals.SitMpPixel_Y);
                        MessageBox.Show("HP Full Done");
                    }
                    if (keyPressed == "6")
                    {
                        Globals.HpFullPixel_X = autoIt.MouseGetPosX();
                        Globals.HpFullPixel_Y = autoIt.MouseGetPosY();
                        Globals.HpFullPixelColor = autoIt.PixelGetColor(Globals.HpFullPixel_X, Globals.HpFullPixel_Y);
                        MessageBox.Show("MP Full Done");
                    }
                    if (keyPressed == "7")
                    {
                        Globals.MpFullPixel_X = autoIt.MouseGetPosX();
                        Globals.MpFullPixel_Y = autoIt.MouseGetPosY();
                        Globals.MpFullPixelColor = autoIt.PixelGetColor(Globals.MpFullPixel_X, Globals.MpFullPixel_Y);
                        MessageBox.Show("MP Full Done");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void chkboxSit_CheckedChanged(object sender, EventArgs e)
        {
            Globals.Sit = chkboxSit.Checked;
        }

        private void chkboxHpPotion_CheckedChanged(object sender, EventArgs e)
        {
            Globals.UseHpPotions = chkboxHpPotion.Checked;
        }

        private void chkboxMpPotion_CheckedChanged(object sender, EventArgs e)
        {
            Globals.UseMpPotions = chkboxMpPotion.Checked;
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            try
            {
                configuring = !configuring;
                if (configuring)
                {
                    keyboardHook.Start();
                    btnConfigure.Text = "Stop Config";
                }
                else
                {
                    keyboardHook.Stop();
                    btnConfigure.Text = "Configure";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
