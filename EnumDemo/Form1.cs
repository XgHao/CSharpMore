using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace EnumDemo
{
    public partial class Form1 : Form
    {
        public City city { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            city = City.HangZhou;
            string res = city.ToString();
            int r = (int)city;
        }

        /// <summary>
        /// 更改选项时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cmb_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            city = (City)(Enum.Parse(typeof(City), Cmb_City.SelectedItem.ToString(), true));
        }

        /// <summary>
        /// 城市
        /// </summary>
        public enum City
        {
            HangZhou = 1,
            BeiJing = 0,
            ShangHai = 2,
            ShenZhen = 3
        }

        /// <summary>
        /// 城市
        /// </summary>
        public enum CityMore
        {
            HangZhou,
            BeiJing,
            ShangHai,
            ShenZhen
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int id = int.Parse(btn.Name.Substring(btn.Name.Length - 1, 1    ));
            listBox1.Items.Add(new Student { ID = id, Name = btn.Name });
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var t = Cmb_City.SelectedItem.ToString();
            City city = MyEnum.GetEnumByIDorName<City>(t);
        }
    }
}
