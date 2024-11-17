﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tugas_Akhir_PBO.App.Context.Admin;
using Tugas_Akhir_PBO.App.Models.Admin;

namespace Tugas_Akhir_PBO.View
{
    public partial class UserControlKatalog : UserControl
    {
        LandingPage FormParent;
        UCAddProduk addProduk;
        FlowLayoutPanel panelKatalog;
        public UserControlKatalog(LandingPage FormParent)
        {
            InitializeComponent();
            addProduk = new UCAddProduk(this);

            this.Controls.Add(addProduk);
            addProduk.Visible = false;
            this.FormParent = FormParent;

            InitializePanelKatalog();
            LoadKatalog();
        }

        private void InitializePanelKatalog()
        {
            panelKatalog = new FlowLayoutPanel
            {
                Location = new Point(445, 150),
                Size = new Size(1411, 857),
                AutoScroll = true,
                BackColor = Color.Transparent,
                Name = "panelKatalog",
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true
            };

            this.Controls.Add(panelKatalog);
        }

        public void LoadKatalog()
        {
            panelKatalog.Controls.Clear();
            KatalogContext katalogContext = new KatalogContext();
            List<Katalog> katalogList = katalogContext.GetAllKatalog();

            foreach (var katalog in katalogList)
            {
                AddKatalogCard(katalog);
            }
        }

        private void AddKatalogCard(Katalog katalog)
        {
            Panel card = new Panel
            {
                Size = new Size(195, 243),
                BackColor = Color.Transparent,
                BackgroundImage = Properties.Resources.Panel_BarangAllUse,
                Margin = new Padding(10)
            };

            Label namaLabel = new Label
            {
                Text = katalog.Nama,
                Font = new Font("Poppins", 9, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Gold,
                Location = new Point(13, 167),
                AutoSize = true
            };

            Label hargaLabel = new Label
            {
                Text = $"{katalog.Harga:C}",
                Font = new Font("Poppins", 7, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.BlueViolet,
                Location = new Point(13, 144),
                AutoSize = true
            };

            PictureBox pictureBox = new PictureBox
            {
                Size = new Size(170, 107),
                Location = new Point(13, 7),
                BackColor = Color.Transparent,
                Image = Image.FromStream(new MemoryStream(katalog.Gambar)),
                SizeMode = PictureBoxSizeMode.StretchImage
            };

            card.Controls.Add(namaLabel);
            card.Controls.Add(hargaLabel);
            card.Controls.Add(pictureBox);

            panelKatalog.Controls.Add(card);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            FormParent.ShowDashboard();
        }

        private void btnPengelolaanStok_Click(object sender, EventArgs e)
        {
            FormParent.ShowKelolaStok();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            FormParent.ShowTransaksi();
        }

        private void btnAddProduk_Click(object sender, EventArgs e)
        {
            ShowAddProduk();
        }

        public void ShowAddProduk()
        {
            addProduk.Visible = true;
            addProduk.BringToFront();
        }

        private void LogoutBox_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                FormParent.ShowLogin();
            }
        }

        private void UserControlKatalog_Load(object sender, EventArgs e)
        {

        }
    }
}
