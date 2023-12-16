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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace SQL_Select__insert_and_update
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, Count;
        private string FirstName, MiddleName, LastName, Gender, Program;
        private long StudentId;

        private void updateBtn_Click(object sender, EventArgs e)
        {
         FrmUpdateMember updatemember = new FrmUpdateMember();
            updatemember.Show();
        }

        public FrmClubRegistration()
        {
            InitializeComponent();
            clubRegistrationQuery = new ClubRegistrationQuery();
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
        }
        private void RefreshListOfClubMembers()
        {
            
            clubRegistrationQuery.DisplayList();

           
            dataGridViewMembers.DataSource = clubRegistrationQuery.bindingSource;
        }
        private int RegistrationID()
        {
            return Count++;
        }
        private void registerBtn_Click(object sender, EventArgs e)
        {
          
                    ID = RegistrationID();
            
                    FirstName = firstNameBox.Text;
                    MiddleName = middleNameBox.Text;
                    LastName = lastNameBox.Text;
                    Age = Convert.ToInt32(AgeBox.Text);
                    Gender = genderBox.Text;
                    Program = programBox.Text;
                    StudentId = Convert.ToInt64(studIDBox.Text);
                    clubRegistrationQuery.RegisterStudent(ID, StudentId, FirstName, MiddleName, LastName, Age, Gender, Program);


        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }
       
            }
        }
    

