using System;
using System.Collections.Generic;
using System.Windows;
using TrackerLibrary.BLL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    public partial class CreateTeam : Window
    {
        public CreateTeam(ITeamRequester caller)
        {
	        InitializeComponent();
	        callingForm = caller;
	        LoadListData();
	        WireUpLists();
        }
        
        private List<PersonModel> _availableTeamMembers = new List<PersonModel>();
		private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
		private ITeamRequester callingForm;

		private void LoadListData()
		{
			_availableTeamMembers = new CreateTeamFormHandling().Select_All_Persons();	
		}
		private void WireUpLists()
		{
			lstTeamMembers.ItemsSource = null;
			lstTeamMembers.ItemsSource = selectedTeamMembers;
			lstTeamMembers.DisplayMemberPath = "FullName";

			cbSelectTeamMember.ItemsSource = null;
			cbSelectTeamMember.ItemsSource = _availableTeamMembers;
			cbSelectTeamMember.DisplayMemberPath = "FullName";
		}

		private void btnCreateMember_Click(object sender, EventArgs e)
		{
			List<string> errorMessages = ValidateData();
			if (errorMessages.Count == 0)
			{
				CreatePersonModel();

				txtFirstName.Text = "";
				txtLastName.Text = "";
				txtEmail.Text = "";
				txtCellPhone.Text = "";
			}
			else
			{
				MessageBox.Show(String.Join("\n", errorMessages));
			}
		}

		private void CreatePersonModel()
		{
			string firstName = txtFirstName.Text;
			string lastName = txtLastName.Text;
			string emailAddress = txtEmail.Text;
			string phoneNumber = txtCellPhone.Text;

			CreateTeamFormHandling createPersonBUL = new CreateTeamFormHandling();
			PersonModel p = createPersonBUL.CreatePerson(firstName, lastName, emailAddress, phoneNumber);

			_availableTeamMembers.Add(p);
			WireUpLists();
		}
		
		private List<string> ValidateData()
		{
			List<string> erorrMessages = new List<string>();

			if (txtFirstName.Text.Length == 0)
			{
				erorrMessages.Add("Имя не может быть пустым");
			}
			else if (txtLastName.Text.Length == 0)
			{
				erorrMessages.Add("Фамилия не может быть пустой");
			}
			else if (txtEmail.Text.Length == 0)
			{
				erorrMessages.Add("Email обязателен");
			}
			else if (!txtEmail.Text.Contains("@"))
			{
				erorrMessages.Add("Email должен содержать @");
			}
			else if(txtCellPhone.Text.Length == 0)
			{
				erorrMessages.Add("Телефон обязателен");
			}

			return erorrMessages;
		}
		private void btnAddMember_Click(object sender, EventArgs e)
		{
			PersonModel p = (PersonModel)cbSelectTeamMember.SelectedItem;

			if(p != null)
			{
				_availableTeamMembers.Remove(p);
				selectedTeamMembers.Add(p);

				WireUpLists();
			}
		}
		private void btnCreateTeam_Click(object sender, EventArgs e)
		{
			if (lstTeamMembers.Items.Count > 0)
			{
				CreateTeamFunc();
			}
			else
			{
				MessageBox.Show("В команде должен быть хотябы 1 игрок");
			}
		}

		private void CreateTeamFunc()
		{
			TeamModel t = new TeamModel();
			string teamName = txtTeamName.Text;
			t.TeamName = teamName;
			t.TeamMembers = selectedTeamMembers;

			if(t.TeamName == "")
			{
				MessageBox.Show("Название команды не может быть пустым");
			}
			else
			{
				CreateTeamFormHandling createTeamFormHandling = new CreateTeamFormHandling();
				createTeamFormHandling.CreateTeam(t);
				callingForm.TeamComplete(t);
				this.Close();
			}
		}

		private void btnRemoveSelectedMember_Click(object sender, EventArgs e)
		{
			PersonModel p = (PersonModel)lstTeamMembers.SelectedItem;
			if(p != null)
			{
				selectedTeamMembers.Remove(p);
				_availableTeamMembers.Add(p);
				WireUpLists();
			}
		}
    }
}