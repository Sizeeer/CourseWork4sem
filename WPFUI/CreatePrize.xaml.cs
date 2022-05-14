﻿using System;
using System.Collections.Generic;
using System.Windows;
using TrackerLibrary.BLL;
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
	        List<string> errorMessages = ValidateForm();
        	if(errorMessages.Count == 0)
        	{
        		CreatePrizeModel();

        		txtPlaceName.Clear();
        		txtPlaceNumber.Clear();
        		txtPrizeAmount.Text = "0";
        		txtPrizePercentage.Text = "0";
        	}
        	else
        	{
        		MessageBox.Show(String.Join("\n", errorMessages));
        	}
        }
        private void CreatePrizeModel()
        {
        	string placeName = txtPlaceName.Text;
        	int placeNumber = int.Parse(txtPlaceNumber.Text);
        	decimal prizeAmount = decimal.Parse(txtPrizeAmount.Text);
        	float prizePercentage = float.Parse(txtPrizePercentage.Text);

        	CreatePrizeBLL createPrizeBll = new CreatePrizeBLL();
        	PrizeModel p = createPrizeBll.CreatePrize(placeName, placeNumber, prizeAmount, prizePercentage);

        	callingForm.PrizeComplete(p);

        	this.Close();
        }
        private List<string> ValidateForm()
        {
	        List<string> erorrMessages = new List<string>();
        	bool output = true;
        	int placeNumber = 0;

        	bool placeNumberValidNumber = int.TryParse(txtPlaceNumber.Text, out placeNumber);

        	if(!placeNumberValidNumber || placeNumber < 1)
            {
	            erorrMessages.Add("Место должно быть числом и больше 0");
            }

        	if(txtPlaceName.Text.Length == 0)
        	{
	            erorrMessages.Add("Имя места не может быть пустым");
        	}

        	decimal prizeAmount = 0;
        	int prizePercentage = 0;

        	bool prizeAmountValid = decimal.TryParse(txtPrizeAmount.Text, out prizeAmount);
        	bool prizePercentageValid = int.TryParse(txtPrizePercentage.Text, out prizePercentage);

            if(!prizeAmountValid || !prizePercentageValid)
        	{
	            erorrMessages.Add("Призовые и призовые % должны быть числом");
        	}
            
        	if(prizeAmount <= 0 && prizePercentage <= 0)
        	{
	            erorrMessages.Add("Призовые должны быть больше 0. Ну ты скупердяй");
        	}
            
        	if(prizePercentage < 0 || prizePercentage > 100)
        	{
	            erorrMessages.Add("Призовые % должны быть больше 0 и меньше 100");
        	}
        	

        	return erorrMessages;
        }
    }
}