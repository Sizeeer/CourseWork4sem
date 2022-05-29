using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TrackerLibrary.BLL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    public partial class TournamentViewer : Window, INotifyPropertyChanged
	{

		private DateTime _startCountdown; // время запуска таймера
		private TimeSpan _startTimeSpan = TimeSpan.FromSeconds(3); // начальное время до окончания таймера
		private TimeSpan _timeToEnd; // время до окончания таймера. Меняется когда таймер запущен
		private TimeSpan _interval = TimeSpan.FromMilliseconds(15); // интервал таймера
		private DateTime _pauseTime;


		private DispatcherTimer _timer;
		public TournamentViewer(TournamentModel model, ITournamentRequester callingForm)
        {

			_timer = new DispatcherTimer();
			_timer.Interval = _interval;
			_timer.Tick += new EventHandler(async (object s, EventArgs a) =>
			{
				var now = DateTime.Now;
				var elapsed = now.Subtract(_startCountdown);
				TimeToEnd = _startTimeSpan.Subtract(elapsed);
			});

			StopTimer();


            InitializeComponent();

	        this.tournament = model;
	        this.callingForm = callingForm;

	        WireUpLists();

	        LoadFormData();

	        LoadRounds();
        }


		public TimeSpan TimeToEnd
		{
			get
			{
				return _timeToEnd;
			}

			set
			{

				_timeToEnd = value;
                if (value.TotalMilliseconds <= 0)
                {
                    StopTimer();


					txtTeamOneScore.IsEnabled = true;
					txtTeamTwoScore.IsEnabled = true;
					btnScore.IsEnabled = true;

					LoadMatchup((MatchupModel)lstMatchup.SelectedItem);
					sleepDialog.IsOpen = false;

				}

                OnPropertyChanged("StringCountdown");
			}
		}

		public string StringCountdown
		{
			get
			{
				var frmt = "mm\\:ss";

				return _timeToEnd.ToString(frmt);
			}
		}

		public bool TimerIsEnabled
		{
			get { return _timer.IsEnabled; }
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName] string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		private void StopTimer()
		{
			if (TimerIsEnabled)
				_timer.Stop();
			TimeToEnd = _startTimeSpan;
		}

		private void StartTimer(DateTime sDate)
		{
			_startCountdown = sDate;
			StopTimer();
			_timer.Start();
		}

		private void PauseTimer()
		{
			_timer.Stop();
			_pauseTime = DateTime.Now;
		}

		private void startTimer(object sender, RoutedEventArgs e)
		{
			StartTimer(DateTime.Now);
		}

		private void resetTimer(object sender, RoutedEventArgs e)
		{
			StopTimer();
		}

		private void pauseTimer(object sender, RoutedEventArgs e)
		{
			PauseTimer();
		}
		private void releaseTimer(object sender, RoutedEventArgs e)
		{
			var now = DateTime.Now;
			var elapsed = now.Subtract(_pauseTime);
			_startCountdown = _startCountdown.Add(elapsed);
			_timer.Start();
		}

		private TournamentModel tournament;
        private ITournamentRequester callingForm;
		BindingList<int> rounds = new BindingList<int>();
		BindingList<MatchupModel> selectedMatchups = new BindingList<MatchupModel>();
		private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}
		private void LoadFormData()
		{
			lbTournamentName.Text = tournament.TournamentName;
			ckbUnplayedOnly.IsChecked = tournament.IsCompleted ? false : true;
		}
		private void LoadRounds()
		{
			rounds.Clear();

			rounds.Add(1);
			int currRound = 1;

			foreach (List<MatchupModel> matchups in tournament.Rounds)
			{
				if (matchups.First().MatchupRound > currRound)
				{
					currRound = matchups.First().MatchupRound;
					rounds.Add(currRound);
				}
			}

			LoadMatchupsList(1);
		}
		private void WireUpLists()
		{
			cbRounds.ItemsSource = rounds;	
			lstMatchup.ItemsSource = selectedMatchups;
			lstMatchup.DisplayMemberPath = "DisplayName";

		}
		private void cbRounds_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadMatchupsList((int)cbRounds.SelectedItem);
		}
		private void LoadMatchupsList(int round)
		{
			
			foreach (List<MatchupModel> matchups in tournament.Rounds)
			{
				if (matchups.First().MatchupRound == round)
				{
					selectedMatchups.Clear();
					foreach (MatchupModel m in matchups)
					{
						if (m.Winner == null || !Convert.ToBoolean(ckbUnplayedOnly.IsChecked))
						{
							selectedMatchups.Add(m); 
						}
					}
				}
			}

			DisplayMatchupInfo();
		}
		private void DisplayMatchupInfo()
		{
			Visibility isVisible = selectedMatchups.Count > 0 ? Visibility.Visible : Visibility.Hidden;

			lbteamOneName.Visibility = isVisible;
			lbteamTwoName.Visibility = isVisible;
			txtTeamOneScore.Visibility = isVisible;
			txtTeamTwoScore.Visibility = isVisible;
			btnScore.Visibility = selectedMatchups.Count > 0 && !tournament.IsCompleted ? Visibility.Visible : Visibility.Hidden;
			ckbUnplayedOnly.Visibility = tournament.IsCompleted ? Visibility.Hidden : Visibility.Visible;
			sleepDialog.IsOpen = false;
		}

		private void LoadMatchup(MatchupModel m)
		{
			if(m != null)
			{
				for (int i = 0; i < m.Entries.Count; i++)
				{
					if (i == 0)
					{
						if (m.Entries[0].TeamCompeting != null)
						{
							lbteamOneName.Content = m.Entries[0].TeamCompeting.TeamName;
							txtTeamOneScore.Text = m.Entries[0].Score.ToString();

							lbteamTwoName.Content = "<не найдено>";
							txtTeamTwoScore.Text = "0";
						}
						else
						{
							lbteamOneName.Content = "Не найдено";
							txtTeamOneScore.Text = "";
						}
					}

					if (i == 1)
					{
						if (m.Entries[1].TeamCompeting != null)
						{
							lbteamTwoName.Content = m.Entries[1].TeamCompeting.TeamName;
							txtTeamTwoScore.Text = m.Entries[1].Score.ToString();
						}
						else
						{
							lbteamTwoName.Content = "Не найдено";
							txtTeamTwoScore.Text = "";
						}
					}
				}
			}
		}

		private string matchupModalTeams;

		public string MatchupModalTeams
        {
			set
            {
				matchupModalTeams = value;
				OnPropertyChanged("MatchupModalTeams");
			}

			get
            {
				return matchupModalTeams;
			}
        }

		private void lstMatchup_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (!tournament.IsCompleted)
            {
				
				MatchupModel m = lstMatchup.SelectedItem as MatchupModel;
				
				if (m != null)
				{
					List<string> result = new List<string>();
					for (int i = 0; i < m.Entries.Count; i++)
					{
						if (i == 0)
						{
							if (m.Entries[0].TeamCompeting != null)
							{
								result.Add(m.Entries[0].TeamCompeting.TeamName);
							}
							else
							{
								result.Add("Не найдено");
							}
						}

						if (i == 1)
						{
							if (m.Entries[1].TeamCompeting != null)
							{
								result.Add(m.Entries[1].TeamCompeting.TeamName);
							}
							else
							{
								result.Add("Не найдено");
							}
						}
					}

					MatchupModalTeams = String.Join(" - ", result);
				}

				sleepDialog.IsOpen = true;
				
			}
            else
            {
				LoadMatchup((MatchupModel)lstMatchup.SelectedItem);
			}

			

		}
		private void ckbUnplayedOnly_CheckedChanged(object sender, EventArgs e)
		{
			LoadMatchupsList((int)cbRounds.SelectedItem);
		}

		private List<string> ValidateData()
		{
			List<string> errorMessages = new List<string>();
			double teamOneScore;
			double teamTwoScore;
			bool scoreOneValid = double.TryParse(txtTeamOneScore.Text, out teamOneScore);
			bool scoreTwoValid = double.TryParse(txtTeamTwoScore.Text, out teamTwoScore);

			if(!scoreOneValid)
			{
				errorMessages.Add("Очки первой команды должны быть числом");
			}
			else if(!scoreTwoValid)
			{
				errorMessages.Add("Очки второй команды должны быть числом");
			}
			else if (teamOneScore < 0 || teamTwoScore < 0)
			{
				errorMessages.Add("Очки должны быть равны 0 или более");
			}

			else if(teamOneScore == 0 && teamTwoScore == 0)
			{
				errorMessages.Add("Не выбран победитель");
			}
			else if(teamOneScore == teamTwoScore)
			{
				errorMessages.Add("В текущей версии приложения не может быть ничьей");
			}

			return errorMessages;
		}
		private void btnScore_Click(object sender, EventArgs e)
		{
			List<string> errorMessages = ValidateData();
			if( errorMessages.Count == 0)
			{
				MatchupModel m = lstMatchup.SelectedItem != null ? (MatchupModel)lstMatchup.SelectedItem : (MatchupModel)lstMatchup.Items.GetItemAt(0);
				double teamOneScore;
				double teamTwoScore;
				for (int i = 0; i < m.Entries.Count; i++)
				{
					if (i == 0)
					{
						if (m.Entries[0].TeamCompeting != null)
						{
							lbteamOneName.Content = m.Entries[0].TeamCompeting.TeamName;

							bool scoreValid = double.TryParse(txtTeamOneScore.Text, out teamOneScore);

							if(scoreValid)
							{
								m.Entries[0].Score = teamOneScore;
							}
							else
							{
								MessageBox.Show("Пожалуйста, введите валидные данные для очков 1 команды");
								return;
							}
						
						}
					}

					if (i == 1)
					{
						if (m.Entries[1].TeamCompeting != null)
						{
							lbteamTwoName.Content = m.Entries[1].TeamCompeting.TeamName;

							bool scoreValid = double.TryParse(txtTeamTwoScore.Text, out teamTwoScore);

							if (scoreValid)
							{
								m.Entries[1].Score = teamTwoScore;
							}
							else
							{
								MessageBox.Show("Пожалуйста, введите валидные данные для очков 2 команды");
								return;
							}
						}
					}
				}
				
				try
				{
					TournamentLogic.UpdateTournamentResults(tournament);
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.Message);
					return;
				}

				LoadMatchupsList((int)cbRounds.SelectedItem);

				UpdateMatchupModel(m);

				txtTeamOneScore.IsEnabled = false;
				txtTeamTwoScore.IsEnabled = false;
				txtTeamOneScore.Text = "0";
				txtTeamTwoScore.Text = "0";
				lbteamOneName.Content = "Команда 1";
				lbteamTwoName.Content = "Команда 2";
				btnScore.IsEnabled = false;
				
			}
			else
			{
				MessageBox.Show(String.Join("\n", errorMessages));
			}
		}

		private void UpdateMatchupModel(MatchupModel m)
		{
			TournamentViewerFormHandling handling = new TournamentViewerFormHandling();
			handling.UpdateMatchupModel(m);
			if (cbRounds.SelectedIndex + 1 == cbRounds.Items.Count)
			{
				MessageBox.Show("Турнир окончен");
				callingForm.TournamentComplete();
				this.Close();
			}
			else
			{
				LoadMatchupsList((int)cbRounds.SelectedItem);
			}
		}

        private void sleepDialog_DialogClosing(object sender, MaterialDesignThemes.Wpf.DialogClosingEventArgs eventArgs)
        {
			lstMatchup.UnselectAll();

		}
	}
}