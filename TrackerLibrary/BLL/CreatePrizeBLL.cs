using TrackerLibrary.DAL;
using TrackerLibrary.DTO;

namespace TrackerLibrary.BUL
{
    public class CreatePrizeBUL
    {
        public PrizeModel CreatePrize(string placeName, int placeNumber, decimal prizeAmount, float prizePercentage)
		{
            PrizeModel model = new PrizeModel();
            model.PlaceName = placeName;
            model.PlaceNumber = placeNumber;
            model.PrizeAmount = prizeAmount;
            model.PrizePercentage = prizePercentage;


            GlobalConfig.Connection.CreatePrize(model);
            return model;
        }

    }
}
