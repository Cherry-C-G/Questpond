using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using IStockView;
using Presenter;
namespace WindowsMVPStock
{
    public partial class Form1 : Form,StockView
    {
        clsPresenter objpresenter = new clsPresenter();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objpresenter.add(this);
        }

        private void btnInCreaseStock_Click(object sender, EventArgs e)
        {
            objpresenter.increaseStock();
        }

        private void btnDecreaseStock_Click(object sender, EventArgs e)
        {
            objpresenter.decreaseStock();
        }

        #region StockView Members

        public void setStockValue(int intStockValue)
        {
            txtStockValue.Text = intStockValue.ToString();
        }

        public void setColor(Color objColor)
        {
            txtStockValue.BackColor = objColor;
        }

        #endregion
    }
}