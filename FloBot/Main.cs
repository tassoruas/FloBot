using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoItX3Lib;

namespace FloBot
{
    public partial class Main : Form
    {
        private AutoItX3 autoIt;
        private bool Running = false;
        public Main()
        {
            InitializeComponent();
            autoIt = new AutoItX3();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frmSettings = new frmSettings();
            frmSettings.Show();
            frmSettings.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Running = true;
            lblRunning.Text = "True";
            StartBotting();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Running = false;
            lblRunning.Text = "False";
        }


        public void StartBotting()
        {
            while (Running)
            {
                autoIt.WinActivate("Florensia ver2.02.00");
                autoIt.Sleep(200);
                if (Globals.Sit)
                {
                    if (CheckForSit() == true)
                    {
                        Sit();
                    }
                }

                autoIt.Sleep(500);
                autoIt.Send("{TAB}");
                autoIt.Sleep(500);

                while (CheckIfMonsterAvailable() == true)
                {
                    autoIt.Send("{SPACE}");
                    autoIt.Sleep(100);
                    UseSkills();
                    autoIt.Sleep(100);
                    if (Globals.UseHpPotions)
                    {
                        if (CheckHpForPotion() == true)
                        {
                            UseHpPotion();
                        }
                    }

                    if (Globals.UseMpPotions)
                    {
                        if (CheckMpForPotion() == true)
                        {
                            UseMpPotion();
                        }
                    }
                }
                if (Globals.Looting)
                {
                    Loot();
                    autoIt.Sleep(4000);
                }

            }
        }

        public bool CheckForSit()
        {
            autoIt.WinActivate("Florensia ver2.02.00");

            var pixel = autoIt.PixelGetColor(Globals.SitHpPixel_X, Globals.SitHpPixel_Y);
            string hexValue = pixel.ToString("X");
            string globalsValue = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", Globals.SitHpPixelColor.A, Globals.SitHpPixelColor.R, Globals.SitHpPixelColor.G, Globals.SitHpPixelColor.B);
            if (globalsValue.Substring(0, 5) == "#FF00")
                hexValue = "#FF00" + hexValue;
            else
                hexValue = "#FF" + hexValue;
            if (hexValue != globalsValue)
            {
                return true;
            }

            pixel = autoIt.PixelGetColor(Globals.SitMpPixel_X, Globals.SitMpPixel_Y);
            hexValue = pixel.ToString("X");
            globalsValue = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", Globals.SitMpPixelColor.A, Globals.SitMpPixelColor.R, Globals.SitMpPixelColor.G, Globals.SitMpPixelColor.B);
            if (globalsValue.Substring(0, 5) == "#FF00")
                hexValue = "#FF00" + hexValue;
            else
                hexValue = "#FF" + hexValue;

            if (hexValue != globalsValue)
            {
                return true;
            }

            return false;
        }

        public void Sit()
        {
            autoIt.Send("{=}");
        }

        public bool CheckIfMonsterAvailable()
        {
            autoIt.WinActivate("Florensia ver2.02.00");
            var pixel = autoIt.PixelGetColor(Globals.MonsterAvailablePixel_X, Globals.MonsterAvailablePixel_Y);
            string globalsValue = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", Globals.MonsterAvailablePixelColor.A, Globals.MonsterAvailablePixelColor.R, Globals.MonsterAvailablePixelColor.G, Globals.MonsterAvailablePixelColor.B);
            string hexValue = pixel.ToString("X");
            if (globalsValue.Substring(0, 5) == "#FF00")
                hexValue = "#FF00" + hexValue;
            else
                hexValue = "#FF" + hexValue;
            if (hexValue != globalsValue)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void UseSkills()
        {

        }

        public bool CheckHpForPotion()
        {
            autoIt.WinActivate("Florensia ver2.02.00");
            var pixel = autoIt.PixelGetColor(Globals.HpPotionPixel_X, Globals.HpPotionPixel_Y);
            string globalsValue = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", Globals.HpPotionPixelColor.A, Globals.HpPotionPixelColor.R, Globals.HpPotionPixelColor.G, Globals.HpPotionPixelColor.B);
            string hexValue = pixel.ToString("X");
            if (globalsValue.Substring(0, 5) == "#FF00")
                hexValue = "#FF00" + hexValue;
            else
                hexValue = "#FF" + hexValue;
            if (hexValue != globalsValue)
                return true;
            else return false;
        }

        public bool CheckMpForPotion()
        {
            autoIt.WinActivate("Florensia ver2.02.00");
            var pixel = autoIt.PixelGetColor(Globals.MpPotionPixel_X, Globals.MpPotionPixel_Y);
            string globalsValue = string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", Globals.MpPotionPixelColor.A, Globals.MpPotionPixelColor.R, Globals.MpPotionPixelColor.G, Globals.MpPotionPixelColor.B);
            string hexValue = pixel.ToString("X");
            if (globalsValue.Substring(0, 5) == "#FF00")
                hexValue = "#FF00" + hexValue;
            else
                hexValue = "#FF" + hexValue;
            if (hexValue != globalsValue)
                return true;
            else return false;
        }

        public void UseHpPotion()
        {
            autoIt.Send("{0}");
        }

        public void UseMpPotion()
        {
            autoIt.Send("{-}");
        }

        public void Loot()
        {
            autoIt.Send("{x}");
        }
    }
}
