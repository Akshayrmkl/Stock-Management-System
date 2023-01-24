using StockManagementSystem.BLL;
using StockManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class FirstForm : Form
    {
      
        string connectionString;
        SqlConnection sqlConnection;
        private string commandString;
        private SqlCommand sqlCommand;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;

        

        public string Message = "";

        public FirstForm()
        {
            InitializeComponent();

            connectionString = @"Server=.\SQLEXPRESS; Database=SQLQuery; Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

      

        private void FirstForm_button_insertQuery_Click(object sender, EventArgs e)
        {
            commandString = "insert into FullQuery(FullQuery) select '" + richTextBox_sqlQuery.Text.ToString() +"'";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            //dataTable = new DataTable();
            //sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            //sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
        }
    }
}
