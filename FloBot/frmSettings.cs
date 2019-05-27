using Newtonsoft.Json;
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

        private void frmSettings_Load(object sender, EventArgs e)
        {
            Color clr = Color.FromArgb(255, 1, 1);
            using (StreamReader r = new StreamReader(Directory.GetCurrentDirectory() + @"\config.json"))
            {
                string json = r.ReadToEnd();
                Globals.Configurations item = JsonConvert.DeserializeObject<Globals.Configurations>(json);

                Globals.Sit = item.Sit;
                if (Globals.Sit == true)
                    chkboxSit.Checked = true;
                else
                    chkboxSit.Checked = false;

                Globals.SitHpPixel_X = item.SitHpPixel_X;
                Globals.SitHpPixel_Y = item.SitHpPixel_Y;
                Globals.SitHpPixelColor = item.SitHpPixelColor;
                Globals.SitMpPixel_X = item.SitMpPixel_X;
                Globals.SitMpPixel_Y = item.SitMpPixel_Y;
                Globals.SitMpPixelColor = item.SitMpPixelColor;
                txtSitHpPixel_X.Text = Globals.SitHpPixel_X.ToString();
                txtSitHpPixel_Y.Text = Globals.SitHpPixel_Y.ToString();
                txtSitMpPixel_X.Text = Globals.SitMpPixel_X.ToString();
                txtSitMpPixel_Y.Text = Globals.SitMpPixel_Y.ToString();


                Globals.UseHpPotions = item.UseHpPotions;
                if (Globals.UseHpPotions == true)
                    chkboxHpPotion.Checked = true;
                else
                    chkboxHpPotion.Checked = false;
                Globals.HpPotionPixel_X = item.HpPotionPixel_X;
                Globals.HpPotionPixel_Y = item.HpPotionPixel_Y;
                txtPotHpPixel_X.Text = Globals.HpPotionPixel_X.ToString();
                txtPotHpPixel_Y.Text = Globals.HpPotionPixel_Y.ToString();


                Globals.UseMpPotions = item.UseMpPotions;
                if (Globals.UseMpPotions == true)
                    chkboxMpPotion.Checked = true;
                else
                    chkboxMpPotion.Checked = false;
                Globals.MpPotionPixel_X = item.MpPotionPixel_X;
                Globals.MpPotionPixel_Y = item.MpPotionPixel_Y;
                txtPotMpPixel_X.Text = Globals.MpPotionPixel_X.ToString();
                txtPotMpPixel_Y.Text = Globals.MpPotionPixel_Y.ToString();

                Globals.MonsterAvailablePixel_X = item.MonsterAvailablePixel_X;
                Globals.MonsterAvailablePixel_Y = item.MonsterAvailablePixel_Y;
                Globals.MonsterAvailablePixelColor = item.MonsterAvailablePixelColor;
                txtMonsterPixel_X.Text = Globals.MonsterAvailablePixel_X.ToString();
                txtMonsterPixel_Y.Text = Globals.MonsterAvailablePixel_Y.ToString();

                Globals.HpFullPixel_X = item.HpFullPixel_X;
                Globals.HpFullPixel_Y = item.HpFullPixel_Y;
                Globals.HpFullPixelColor = item.HpFullPixelColor;
                txtFullHpPixel_X.Text = item.HpFullPixel_X.ToString();
                txtFullHpPixel_Y.Text = item.HpFullPixel_Y.ToString();

                Globals.MpFullPixel_X = item.MpFullPixel_X;
                Globals.MpFullPixel_Y = item.MpFullPixel_Y;
                Globals.MpFullPixelColor = item.MpFullPixelColor;
                txtFullMpPixel_X.Text = item.MpFullPixel_X.ToString();
                txtFullMpPixel_Y.Text = item.MpFullPixel_Y.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Globals.Configurations conf = new Globals.Configurations();

            Globals.Sit = chkboxSit.Checked;
            conf.Sit = chkboxSit.Checked;
            if (chkboxSit.Checked == true)
            {
                Globals.SitHpPixel_X = int.Parse(txtSitHpPixel_X.Text);
                Globals.SitHpPixel_Y = int.Parse(txtSitHpPixel_Y.Text);
                Globals.SitHpPixelColor = ColorTranslator.FromHtml(txtSitHpPixelColor.Text);
                Globals.SitMpPixel_X = int.Parse(txtSitMpPixel_X.Text);
                Globals.SitMpPixel_Y = int.Parse(txtSitMpPixel_Y.Text);
                Globals.SitMpPixelColor = ColorTranslator.FromHtml(txtSitMpPixelColor.Text);

                conf.SitHpPixel_X = int.Parse(txtSitHpPixel_X.Text);
                conf.SitHpPixel_Y = int.Parse(txtSitHpPixel_Y.Text);
                conf.SitHpPixelColor = ColorTranslator.FromHtml(txtSitHpPixelColor.Text);
                conf.SitMpPixel_X = int.Parse(txtSitMpPixel_X.Text);
                conf.SitMpPixel_Y = int.Parse(txtSitMpPixel_Y.Text);
                conf.SitMpPixelColor = ColorTranslator.FromHtml(txtSitMpPixelColor.Text);
            }

            Globals.UseHpPotions = chkboxHpPotion.Checked;
            conf.UseHpPotions = chkboxHpPotion.Checked;
            if (chkboxHpPotion.Checked == true)
            {
                Globals.HpPotionPixel_X = int.Parse(txtPotHpPixel_X.Text);
                Globals.HpPotionPixel_Y = int.Parse(txtPotHpPixel_Y.Text);
                Globals.HpPotionPixelColor = ColorTranslator.FromHtml(txtPotHpPixelColor.Text);

                conf.HpPotionPixel_X = int.Parse(txtPotHpPixel_X.Text);
                conf.HpPotionPixel_Y = int.Parse(txtPotHpPixel_Y.Text);
                conf.HpPotionPixelColor = ColorTranslator.FromHtml(txtPotHpPixelColor.Text);
            }

            Globals.UseMpPotions = chkboxMpPotion.Checked;
            conf.UseMpPotions = chkboxMpPotion.Checked;
            if (chkboxMpPotion.Checked == true)
            {
                Globals.MpPotionPixel_X = int.Parse(txtPotMpPixel_X.Text);
                Globals.MpPotionPixel_Y = int.Parse(txtPotMpPixel_Y.Text);
                Globals.MpPotionPixelColor = ColorTranslator.FromHtml(txtPotMpPixelColor.Text);

                conf.MpPotionPixel_X = int.Parse(txtPotMpPixel_X.Text);
                conf.MpPotionPixel_Y = int.Parse(txtPotMpPixel_Y.Text);
                conf.MpPotionPixelColor = ColorTranslator.FromHtml(txtPotMpPixelColor.Text);
            }

            Globals.MonsterAvailablePixel_X = int.Parse(txtMonsterPixel_X.Text);
            Globals.MonsterAvailablePixel_Y = int.Parse(txtMonsterPixel_Y.Text);
            Globals.MonsterAvailablePixelColor = ColorTranslator.FromHtml(txtMonsterPixelColor.Text);

            conf.MonsterAvailablePixel_X = int.Parse(txtMonsterPixel_X.Text);
            conf.MonsterAvailablePixel_Y = int.Parse(txtMonsterPixel_Y.Text);
            conf.MonsterAvailablePixelColor = ColorTranslator.FromHtml(txtMonsterPixelColor.Text);

            Globals.HpFullPixel_X = int.Parse(txtFullHpPixel_X.Text);
            Globals.HpFullPixel_Y = int.Parse(txtFullHpPixel_Y.Text);
            Globals.HpFullPixelColor = ColorTranslator.FromHtml(txtFullHpPixelColor.Text);

            conf.HpFullPixel_X = int.Parse(txtFullHpPixel_X.Text);
            conf.HpFullPixel_Y = int.Parse(txtFullHpPixel_Y.Text);
            conf.HpFullPixelColor = ColorTranslator.FromHtml(txtFullHpPixelColor.Text);

            Globals.MpFullPixel_X = int.Parse(txtFullMpPixel_X.Text);
            Globals.MpFullPixel_Y = int.Parse(txtFullMpPixel_Y.Text);
            Globals.MpFullPixelColor = ColorTranslator.FromHtml(txtFullMpPixelColor.Text);

            conf.MpFullPixel_X = int.Parse(txtFullMpPixel_X.Text);
            conf.MpFullPixel_Y = int.Parse(txtFullMpPixel_Y.Text);
            conf.MpFullPixelColor = ColorTranslator.FromHtml(txtFullMpPixelColor.Text);

            using (StreamWriter file = File.CreateText(Directory.GetCurrentDirectory() + @"\config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, conf);
            }

            Close();
        }

        private void chkboxSit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxSit.Checked == true)
            {
                txtSitHpPixelColor.Enabled = true;
                txtSitHpPixel_X.Enabled = true;
                txtSitHpPixel_Y.Enabled = true;
                txtSitMpPixelColor.Enabled = true;
                txtSitMpPixel_X.Enabled = true;
                txtSitMpPixel_Y.Enabled = true;
            }
            else
            {
                txtSitHpPixelColor.Enabled = false;
                txtSitHpPixel_X.Enabled = false;
                txtSitHpPixel_Y.Enabled = false;
                txtSitMpPixelColor.Enabled = false;
                txtSitMpPixel_X.Enabled = false;
                txtSitMpPixel_Y.Enabled = false;
            }
        }

        private void chkboxHpPotion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxHpPotion.Checked == true)
            {
                txtPotHpPixelColor.Enabled = true;
                txtPotHpPixel_X.Enabled = true;
                txtPotHpPixel_Y.Enabled = true;
            }
            else
            {
                txtPotHpPixelColor.Enabled = false;
                txtPotHpPixel_X.Enabled = false;
                txtPotHpPixel_Y.Enabled = false;
            }
        }

        private void chkboxMpPotion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkboxMpPotion.Checked == true)
            {
                txtPotMpPixelColor.Enabled = true;
                txtPotMpPixel_X.Enabled = true;
                txtPotMpPixel_Y.Enabled = true;
            }
            else
            {
                txtPotMpPixelColor.Enabled = false;
                txtPotMpPixel_X.Enabled = false;
                txtPotMpPixel_Y.Enabled = false;
            }
        }
    }
}
