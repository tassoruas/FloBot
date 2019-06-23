using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
            Licensing lic = new Licensing();
            lic.GenerateComputerId();
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

        private void tmrCheckHP_Tick(object sender, EventArgs e)
        {
            if (Running)
            {
                int hpValue = CheckMemoryHP();
                lblHp.Text = Convert.ToString(hpValue);
                if (hpValue < 2900)
                {
                    autoIt.Send("{=}");
                    autoIt.Sleep(10000);
                    autoIt.MouseClick();
                }
            }
        }

        private int CheckMemoryHP()
        {
            uint pointerAddress = 0x0071CAF4;
            int pointerOffset = 0x2CC;
            uint offset = 0;
            int bytesReadOut = 0;

            Process process = Process.GetProcessesByName("FlorensiaEN.bin").ToList().FirstOrDefault();
            if (process != null)
            {
                ProcessMemoryReader mReader = new ProcessMemoryReader();
                mReader.ReadProcess = process;
                mReader.OpenProcess();
                offset = BitConverter.ToUInt32(mReader.ReadMemory((IntPtr)(pointerAddress + (uint)process.Modules[0].BaseAddress), 4, out bytesReadOut), 0);
                if (pointerOffset < 0)
                    offset -= (uint)(Math.Abs(pointerOffset));
                else
                    offset += (uint)pointerOffset;

                byte[] buffer = mReader.ReadMemory((IntPtr)offset, 2, out bytesReadOut);
                int intValue = BitConverter.ToInt16(buffer, 0);
                return intValue;
            }
            return 0;
        }

        private void btnTestes_Click(object sender, EventArgs e)
        {

        }
    }
}
