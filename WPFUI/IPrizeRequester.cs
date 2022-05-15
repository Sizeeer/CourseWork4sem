using System.Collections.Generic;
using TrackerLibrary.DTO;

namespace WPFUI
{
	public interface IPrizeRequester
	{
		List<PrizeModel> selectedPrizes { get; }
		void PrizeComplete(PrizeModel p);
	}
}
