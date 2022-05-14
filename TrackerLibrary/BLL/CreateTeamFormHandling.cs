using System.Collections.Generic;
using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BLL
{
	public class CreateTeamFormHandling
	{
		public PersonModel CreatePerson(string firstName, string lastName, string emailAddress, string phoneNumber)
		{
            PersonModel model = new PersonModel();
            model.FirstName = firstName;
            model.LastName = lastName;
            model.EmailAddress = emailAddress;
            model.CellPhoneNumber = phoneNumber;

            GlobalConfig.Connection.CreatePeople(model);
            return model;
		}
        public List<PersonModel> Select_All_Persons()
        {
            List<PersonModel> output = GlobalConfig.Connection.Get_All_Persons();
            return output;
        }
        public TeamModel CreateTeam(TeamModel team_from_UI)
		{
            TeamModel t = GlobalConfig.Connection.CreateTeam(team_from_UI);
            return t;
		}
    }
}
