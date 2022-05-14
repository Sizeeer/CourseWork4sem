using System;
using System.Windows;
using TrackerLibrary.BUL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    public partial class CreatePrize : Window
    {
        public CreatePrize(IPrizeRequester caller)
        {
	        InitializeComponent();
	        callingForm = caller;
        }
        
        IPrizeRequester callingForm;

        private void btnCreatePrize_Click(object sender, EventArgs e)
        {
        	if(ValidateForm())
        	{
        		CreatePrizeModel();

        		txtPlaceName.Clear();
        		txtPlaceNumber.Clear();
        		txtPrizeAmount.Text = "0";
        		txtPrizePercentage.Text = "0";
        	}
        	else
        	{
        		MessageBox.Show("This form has invalid information. Please check it and try again ! ");
        	}
        }
        private void CreatePrizeModel()
        {
        	string placeName = txtPlaceName.Text;
        	int placeNumber = int.Parse(txtPlaceNumber.Text);
        	decimal prizeAmount = decimal.Parse(txtPrizeAmount.Text);
        	float prizePercentage = float.Parse(txtPrizePercentage.Text);

        	CreatePrizeBUL createPrizeBUL = new CreatePrizeBUL();
        	PrizeModel p = createPrizeBUL.CreatePrize(placeName, placeNumber, prizeAmount, prizePercentage);

        	callingForm.PrizeComplete(p);

        	this.Close();
        }
        private bool ValidateForm()
        {
        	bool output = true;
        	int placeNumber = 0;

        	bool placeNumberValidNumber = int.TryParse(txtPlaceNumber.Text, out placeNumber);

        	if(!placeNumberValidNumber || placeNumber < 1)
        	{
        		output = false;
        	}

        	if(txtPlaceName.Text.Length == 0)
        	{
        		output = false;
        	}

        	decimal prizeAmount = 0;
        	int prizePercentage = 0;

        	bool prizeAmountValid = decimal.TryParse(txtPrizeAmount.Text, out prizeAmount);
        	bool prizePercentageValid = int.TryParse(txtPrizePercentage.Text, out prizePercentage);

        	if(!prizeAmountValid || !prizePercentageValid)
        	{
        		output = false;
        	}
            
        	if(prizeAmount <= 0)
        	{
        		output = false;
        	}
            
        	if(prizePercentage < 0 || prizePercentage > 100)
        	{
        		output = false;
        	}
        	

        	return output;
        }
    }
}