﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FEBuilderGBA
{
    public partial class EventUnitItemDropForm : Form
    {
        public EventUnitItemDropForm()
        {
            InitializeComponent();
        }

        private void EventUnitItemDropForm_Load(object sender, EventArgs e)
        {
            FormIcon.Image = SystemIcons.Question.ToBitmap();
            YesButton.Focus();
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
            this.Close();
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }
    }
}
