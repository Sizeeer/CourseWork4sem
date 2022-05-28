namespace TrackerLibrary.DTO
{
    public class MatchupEntryModel
    {
        public int Id { get; set; }
        public int TeamCompetingID { get; set; }
        public TeamModel TeamCompeting { get; set; }
        public double Score { get; set; }
        public int ParentMatchupID { get; set; }
        public MatchupModel ParentMatchup { get; set; }
    }
}
