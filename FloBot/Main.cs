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
        KeyboardHook keyboardHook = new KeyboardHook();

        public Main()
        {
            InitializeComponent();
            autoIt = new AutoItX3();
            keyboardHook.Start();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            keyboardHook.KeyPress += new KeyPressEventHandler(keyboardHook_KeyPress);
        }

        void keyboardHook_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "*")
            {
                if (Running)
                {
                    Running = false;
                    Close();
                    lblRunning.Text = "False";
                }
                else
                {
                    Running = true;
                    StartBotting();
                    MessageBox.Show("Bot Running");
                    lblRunning.Text = "True";
                }

            }
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

                autoIt.Sleep(300);
                autoIt.Send("{TAB}");
                autoIt.Sleep(300);

                while (CheckIfMonsterAvailable() == true && Running)
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
            if (pixel != Globals.SitHpPixelColor)
            {
                return true;
            }

            pixel = autoIt.PixelGetColor(Globals.SitMpPixel_X, Globals.SitMpPixel_Y);
            if (pixel != Globals.SitMpPixelColor)
            {
                return true;
            }

            return false;
        }

        public void Sit()
        {
            autoIt.Send("{=}");
            while (CheckForSit())
            {
                autoIt.Sleep(500);
            }
            autoIt.Send("{=}");
        }

        public bool CheckIfMonsterAvailable()
        {
            autoIt.WinActivate("Florensia ver2.02.00");
            var pixel = autoIt.PixelGetColor(Globals.MonsterAvailablePixel_X, Globals.MonsterAvailablePixel_Y);
            if (pixel != Globals.MonsterAvailablePixelColor)
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
            autoIt.Send("{1}");
        }

        public bool CheckHpForPotion()
        {
            autoIt.WinActivate("Florensia ver2.02.00");
            var pixel = autoIt.PixelGetColor(Globals.HpPotionPixel_X, Globals.HpPotionPixel_Y);
            if (pixel != Globals.HpPotionPixelColor)
                return true;
            else
                return false;
        }

        public bool CheckMpForPotion()
        {
            autoIt.WinActivate("Florensia ver2.02.00");
            var pixel = autoIt.PixelGetColor(Globals.MpPotionPixel_X, Globals.MpPotionPixel_Y);
            if (pixel != Globals.MpPotionPixelColor)
                return true;
            else
                return false;
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

        /// <summary>
        ///  THIS IS FOR AUTOMATIC INITIALIZATION (DEPRECATED)
        /// </summary>
        public void InitializeConfigurations()
        {
            object pixelSearch;

            #region GET HP POTION XY
            pixelSearch = autoIt.PixelSearch(0, 0, 300, 300, 13372501);
            if (autoIt.error != 1)
            {
                object[] cord = pixelSearch as object[];
                if (autoIt.PixelGetColor((int)cord[0] - 1, (int)cord[1]) == 10422594)
                {
                    Globals.HpPotionPixel_X = (int)cord[0];
                    Globals.HpPotionPixel_Y = (int)cord[1];
                }
                else
                {
                    MessageBox.Show("HP Potion initializing error!");
                }
            }
            else
            {
                MessageBox.Show("HP Potion initializing error!");
            }
            #endregion

            #region GET MP POTION XY
            pixelSearch = autoIt.PixelSearch(0, 0, 300, 300, 7403721);
            if (autoIt.error != 1)
            {
                object[] cord = pixelSearch as object[];
                if (autoIt.PixelGetColor((int)cord[0] + 4, (int)cord[1]) == 47288)
                {
                    Globals.MpPotionPixel_X = (int)cord[0] + 4;
                    Globals.MpPotionPixel_Y = (int)cord[1];
                }
                else
                {
                    MessageBox.Show("MP Potion initializing error!");
                }
            }
            else
            {
                MessageBox.Show("MP Potion initializing error!");
            }
            #endregion

            #region GET MONSTERS HEADER XY
            pixelSearch = autoIt.PixelSearch(250, 0, 1000, 250, 13372501);
            if (autoIt.error != 1)
            {
                object[] cord = pixelSearch as object[];
                if (autoIt.PixelGetColor((int)cord[0] - 1, (int)cord[1]) == 10422594)
                {
                    Globals.MonsterAvailablePixel_X = (int)cord[0];
                    Globals.MonsterAvailablePixel_Y = (int)cord[1];
                    MessageBox.Show("Monster XY: " + cord[0].ToString() + ", " + cord[1].ToString());
                }
                else
                {
                    MessageBox.Show("Monster Header initializing error!");
                }
            }
            else
            {
                MessageBox.Show("Monster Header initializing error!");
            }
            #endregion
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            InitializeConfigurations();
        }


    }
}
