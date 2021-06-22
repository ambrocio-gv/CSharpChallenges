using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextFileChallenge.DataAccess;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {


        private List<UserModel> Users = GlobalConfig.Connection.GetUser_All();
        //private BindingList<UserModel> Users = new BindingList<UserModel>();       



        public ChallengeForm()
        {
            InitializeComponent();            
            WireUpDropDown();      

        }


        private void WireUpDropDown()
        {
            //Users = new BindingList<UserModel>(availableUsers);
            usersListBox.DataSource = null;
            usersListBox.DataSource = Users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                UserModel u = new UserModel();

                u.FirstName = firstNameText.Text;
                u.LastName = lastNameText.Text;
                u.Age = Convert.ToInt32(agePicker.Value);
                u.IsAlive = isAliveCheckbox.Checked;
                u = GlobalConfig.Connection.CreateUser(u);

                Users.Add(u);

                WireUpDropDown();

                firstNameText.Text = "";
                lastNameText.Text = "";
                agePicker.Value = 0;
                isAliveCheckbox.Checked = false;

            }
            else
            {
                MessageBox.Show("This form has invalid info. Please check it and try again");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;
            
            if(firstNameText.Text.Length == 0)
            {
                output = false;
            }

            if(lastNameText.Text.Length == 0)
            {
                output = false;
            }

            if(agePicker.Minimum >= agePicker.Value || agePicker.Maximum <= agePicker.Value)
            {
                output = false;
            }          

            return output;
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            GlobalConfig.Connection.SaveUser_All(Users);
        }
    }
}
