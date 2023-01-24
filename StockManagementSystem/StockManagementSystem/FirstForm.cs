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
using System.Xml;

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

        private void FirstForm_button_Parse_Click_old(object sender, EventArgs e)
        {
            commandString =  "SET SHOWPLAN_XML ON; " ;
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            commandString =  richTextBox_sqlQuery.Text.ToString();
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            dataTable = new DataTable();
            sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
        }

        private void FirstForm_button_Parse_Click_old2(object sender, EventArgs e)
        {
            commandString = "SET SHOWPLAN_XML ON; ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            commandString = richTextBox_sqlQuery.Text.ToString();
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            List<String> subscriptions = new List<String>();
            do
            {
                subscriptions.Add((string)reader["Microsoft SQL Server 2005 XML Showplan"]);
            }
            while (reader.NextResult());
            sqlConnection.Close();
        }

        private void FirstForm_button_Parse_Click(object sender, EventArgs e)
        {
            commandString = "SET STATISTICS XML ON; ";
            sqlCommand = new SqlCommand(commandString, sqlConnection);
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            commandString = richTextBox_sqlQuery.Text.ToString();
            sqlCommand = new SqlCommand(commandString, sqlConnection);

            DataSet dataset = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;
            adapter.SelectCommand.CommandType = CommandType.Text;
            adapter.Fill(dataset);
            List<string> xmlPlanListString = new List<string>();
            foreach (DataTable dt in dataset.Tables)
            {
                
                if(dt.Rows.Count > 0)
                        xmlPlanListString.Add(dt.Rows[0][0].ToString());
            }
            sqlConnection.Close();
            List<ShowPlanXML> xmlPlanList = new List<ShowPlanXML>();
            foreach (string str in xmlPlanListString)
            {
                XmlDocument doc = new XmlDocument();
                var str2 = str; 
                str2 = "<xml>" + str + "</xml>";
                doc.LoadXml(str2);

                commandString = "insert into FullQueryXmlPlan(FullQueryXmlPlan) select '" + str2  + "'";
                sqlCommand = new SqlCommand(commandString, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Parsed as xml plan and saved");
            }


        }
    }

}
