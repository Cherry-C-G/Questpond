using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NameSpaceCountryBO;
using NameSpaceCountryEntity;
namespace Linq
{
    public partial class FormLinq : Form
    {
        public FormLinq()
        {
            InitializeComponent();
        }

        private void FormLinq_Load(object sender, EventArgs e)
        {
          
        }

        private void btnLinq_Click(object sender, EventArgs e)
        {
            CountryBO objCountryBO = new CountryBO();
            lstCountry.Items.Clear();
            foreach (CountryEntity obj in objCountryBO.getCountries())
            {
                lstCountry.Items.Add(obj.CountryCode);
            }
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            CountriesNormalBO objCountryBo = new CountriesNormalBO();
            
            lstCountry.Items.Clear();
            foreach (CountryEntity obj in objCountryBo)
            {
                lstCountry.Items.Add(obj.CountryCode);
            }
        }
    }
}
