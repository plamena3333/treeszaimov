using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreesZaimov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conectionString = "server=192.168.1.38;" +
            "user=PC1;" +
            "password=1111;" +
            "port=3306;" +
            "database = trees_zaimov";

        MySqlConnection connect = new MySqlConnection(conectionString);
            if (connect.State == 0)
            {
                connect.Open();
            }
            MessageBox.Show("Imash vruzka s HeidiSQL");

            //formirane na query

            string insertQueryText = "INSERT INTO trees_zaimov.otdel" +
                   "(`name` , `name_bg`) " +
                   "VALUES " +
                   "(@name,@name_bg)";

            MySqlCommand query = new MySqlCommand(insertQueryText, connect);

            //svurzvane na parametri
            query.Parameters.AddWithValue("@name", txtName.Text);
            query.Parameters.AddWithValue("@name_bg", txtNameBG.Text);
            query.ExecuteNonQuery();
           
            //Run query
            int result = query.ExecuteNonQuery();
            if (result != 0)
            {
                MessageBox.Show($"Dobavi {result} records!!!");
            }

            connect.Close();


        }
    }
}
