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


        private List<UserModel> availableUsers = GlobalConfig.Connection.GetUser_All();
        private BindingList<UserModel> Users = new BindingList<UserModel>();       



        public ChallengeForm()
        {
            InitializeComponent();

            
            WireUpDropDown();
           

        }


        private void WireUpDropDown()
        {
            Users = new BindingList<UserModel>(availableUsers);
            usersListBox.DataSource = Users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                //UserModel u = new UserModel();

                //u.FirstName = firstNameText.Text;
                //u.LastName = lastNameText.Text;
                //u.Age = Convert.ToInt32(agePicker.Value);
                //p.CellphoneNumber = txt_Cellphone.Text;

                //p = GlobalConfigure.Connection.CreatePerson(p);

                //selectedTeamMembers.Add(p);

                //wireUpLists();


                //txt_FirstName.Text = "";
                //txt_LastName.Text = "";
                //txt_Email.Text = "";
                //txt_Cellphone.Text = "";

            }
            else
            {
                MessageBox.Show("This form has invalid info. Please check it and try again");
            }



        }

        public void UserComplete(UserModel model)
        {
           
            availableUsers.Add(model);
            WireUpDropDown();
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


            if(Convert.ToInt32(agePicker.Value) < 0)
            {
                output = false;
            } 
            


            return output;
        }






    }
}
