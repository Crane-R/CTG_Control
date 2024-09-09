using CTG_Control.Crane.Model.Bean;
using CTG_Control.Crane.Model.Dao;
using CTG_Control.Crane.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CTG_Control.Crane.view
{
    public partial class DetailMore : Form
    {
        private CompressItem CompressItem;

        private readonly MainForm MainForm;

        public DetailMore(int id, MainForm mainForm)
        {
            InitializeComponent();

            MainForm = mainForm;

            CompressItem = DataDao.SelectById(id);
            LastBackTime.Text = CompressItem.LatelyDate.ToString();
            LastBackPast.Text = CompressItem.LastBackPast.ToString("0.0000000");
            IsAutoBack.Checked = CompressItem.IsAutoBack;
            IntervalValue.Text = CompressItem.BackInterval.ToString();
        }

        private void ChooseStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            string text = comboBox.SelectedItem.ToString();
            BackIntervalTool backIntervalTool = new BackIntervalTool();
            int hour = backIntervalTool.GetHourByStandardItemContent(text);
            IntervalValue.Text = hour.ToString();
        }

        private void SureBtn_Click(object sender, EventArgs e)
        {
            CompressItem.IsAutoBack = IsAutoBack.Checked;
            CompressItem.BackInterval = Convert.ToInt32(IntervalValue.Text);
            DataDao.UpdateOne(CompressItem);
            MainForm.Init();
            Close();
        }

        /// <summary>
        /// 循环检测输入框的值，移除非数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IntervalValue_Leave(object sender, EventArgs e)
        {
            IntervalValue.Text = System.Text.RegularExpressions.Regex.Replace(IntervalValue.Text, @"[^0-9]+", "");
        }
    }
}
