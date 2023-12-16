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

namespace SQL_Select__insert_and_update
{
    public partial class FrmUpdateMember : Form
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;
        private string ConnectionString;
        public FrmUpdateMember()
        {
            InitializeComponent();
            ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\HP EliteBook\source\repos\SQL Select, insert and update\SQL Select, insert and update\ClubDB.mdf; Integrated Security = True";
            sqlConnect = new SqlConnection(ConnectionString);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sqlConnect.Open();
            sqlCommand = new SqlCommand("SELECT * FROM ClubMembers WHERE StudentID = @StudentId", sqlConnect);
            sqlCommand.Parameters.AddWithValue("@StudentId", cmbStudId.Text);
            sqlReader = sqlCommand.ExecuteReader();
            sqlReader.Read();

          fNameBox.Text = sqlReader["FirstName"].ToString();
            mNameBox.Text = sqlReader["MiddleName"].ToString();
     lastNameBox.Text = sqlReader["LastName"].ToString();
            ageBox.Text = sqlReader["Age"].ToString();
            cmbGender.Text = sqlReader["Gender"].ToString();
            cmbProgram.Text = sqlReader["Program"].ToString();
            sqlConnect.Close();
        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            sqlConnect.Open();
            string query1 = "SELECT StudentID FROM ClubMembers";
            sqlCommand = new SqlCommand(query1, sqlConnect);
            sqlReader = sqlCommand.ExecuteReader();

            while (sqlReader.Read())
            {
               cmbStudId.Items.Add(sqlReader["StudentId"]);
            }

            sqlConnect.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            string query = @"UPDATE ClubMembers SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, 
                            Age = @Age, Gender = @Gender, Program = @Program WHERE StudentID = @StudentId";

            sqlCommand = new SqlCommand(query, sqlConnect);
            sqlCommand.Parameters.AddWithValue("@StudentId", cmbStudId.Text);
            sqlCommand.Parameters.AddWithValue("@FirstName", fNameBox.Text);
            sqlCommand.Parameters.AddWithValue("@MiddleName", mNameBox.Text);
            sqlCommand.Parameters.AddWithValue("@LastName", lastNameBox.Text);
            sqlCommand.Parameters.AddWithValue("@Age", ageBox.Text);
            sqlCommand.Parameters.AddWithValue("@Gender", cmbGender.Text);
            sqlCommand.Parameters.AddWithValue("@Program", cmbProgram.Text);
            sqlCommand.ExecuteNonQuery();
            sqlConnect.Close();

            this.Close();
        }
    }
}

