using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary.BUL;
using TrackerLibrary.DTO;

namespace UIL
{
	public partial class frmCreateTeam : Form
	{
		private List<PersonModel> availableTeamMembers = new List<PersonModel>();
		private List<PersonModel> selectedTeamMembers = new List<PersonModel>();
		private ITeamRequester callingForm;
		public frmCreateTeam(ITeamRequester caller)
		{
			InitializeComponent();
			callingForm = caller;
			//CreateSampleData();
			LoadListData();
			WireUpLists();
		}

		private void LoadListData()
		{
			CreateTeamFormHandling personHandlingBUL = new CreateTeamFormHandling();
			availableTeamMembers = personHandlingBUL.Select_All_Persons();	
		}

		private void CreateSampleData()
		{
			availableTeamMembers.Add(new PersonModel { FirstName = "Tim" , LastName = "Corey" });
			availableTeamMembers.Add(new PersonModel { FirstName = "2", LastName = "2" });

			selectedTeamMembers.Add(new PersonModel { FirstName = "3", LastName = "Corey" });
			selectedTeamMembers.Add(new PersonModel { FirstName = "4", LastName = "2" });
		}

		// Wire up list of team members to list box and combo box
		private void WireUpLists()
		{
			lstTeamMembers.DataSource = null;
			lstTeamMembers.DataSource = selectedTeamMembers;
			lstTeamMembers.DisplayMember = "FullName";

			cbSelectTeamMember.DataSource = null;
			cbSelectTeamMember.DataSource = availableTeamMembers;
			cbSelectTeamMember.DisplayMember = "FullName";
		}

		private void btnCreateMember_Click(object sender, EventArgs e)
		{
			string errorMessage = ValidateData();
			if (errorMessage.Length > 0)
			{
				MessageBox.Show($"Input error : {errorMessage}");
				return;
			}

			CreatePersonModel();

			txtFirstName.Text = "";
			txtLastName.Text = "";
			txtEmail.Text = "";
			txtCellPhone.Text = "";
			
		}

		private void CreatePersonModel()
		{
			string firstName = txtFirstName.Text;
			string lastName = txtLastName.Text;
			string emailAddress = txtEmail.Text;
			string phoneNumber = txtCellPhone.Text;

			CreateTeamFormHandling createPersonBUL = new CreateTeamFormHandling();
			PersonModel p = createPersonBUL.CreatePerson(firstName, lastName, emailAddress, phoneNumber);

			// Add to the selected team members list --> Recall wireup lists
			availableTeamMembers.Add(p);
			WireUpLists();
		}

		private string ValidateData()
		{
			string output = "";

			if (txtFirstName.Text.Length == 0)
			{
				output = "You must enter the first name";
			}
			else if (txtLastName.Text.Length == 0)
			{
				output = "You must enter the last name";
			}
			else if (txtEmail.Text.Length == 0)
			{
				output = "You must enter email address";
			}
			else if (!txtEmail.Text.Contains("@"))
			{
				output = "Email address must contains @";
			}
			else if(txtCellPhone.Text.Length == 0)
			{
				output = "You must enter a cellphone number";
			}
			

			return output;
		}

		private void btnAddMember_Click(object sender, EventArgs e)
		{
			PersonModel p = (PersonModel)cbSelectTeamMember.SelectedItem;

			if(p != null)
			{
				availableTeamMembers.Remove(p);
				selectedTeamMembers.Add(p);

				WireUpLists();
			}
		}

		private void btnRemoveSelectedMember_Click(object sender, EventArgs e)
		{

		}

		private void btnCreateTeam_Click(object sender, EventArgs e)
		{
			if (lstTeamMembers.Items.Count == 0)
			{
				MessageBox.Show("You must have at least one member in a team");
			}
			else
			{
				CreateTeam();
			}
			
		}

		private void CreateTeam()
		{
			TeamModel t = new TeamModel();
			string teamName = txtTeamName.Text;
			t.TeamName = teamName;
			t.TeamMembers = selectedTeamMembers;

			if(t.TeamName != "")
			{
				CreateTeamFormHandling createTeamFormHandling = new CreateTeamFormHandling();
				createTeamFormHandling.CreateTeam(t);
				callingForm.TeamComplete(t);
				this.Close();
			}
			else
			{
				MessageBox.Show("Please create a team name ! ");
			}
			

			// TODO - If we aren't closing this form after creation, reset this form
		}

		private void btnRemoveSelectedMember_Click_1(object sender, EventArgs e)
		{
			PersonModel p = (PersonModel)lstTeamMembers.SelectedItem;
			if(p != null)
			{
				selectedTeamMembers.Remove(p);
				availableTeamMembers.Add(p);
				WireUpLists();
			}
		}
	}
}
