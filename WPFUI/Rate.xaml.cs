using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TrackerLibrary.BLL;
using TrackerLibrary.DTO;

namespace WPFUI
{
    /// <summary>
    /// Логика взаимодействия для Rate.xaml
    /// </summary>
    public partial class Rate : Window
    {

        private RateHandling _handling = new RateHandling();
        public Rate()
        {
            InitializeComponent();

            FillRatingTable();
        }

        private void FillRatingTable()
        {
            var teamsRate = _handling.GetTeamsRates().Select((el ,i) => new {place = i + 1, teamName = el.TeamName, score = el.Score});

            DataGridTextColumn column = new DataGridTextColumn();

            column.Header = "Место";
            column.Binding = new Binding("place");
            lstRate.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Очки";
            column.Binding = new Binding("score");
            lstRate.Columns.Add(column);

            column = new DataGridTextColumn();
            column.Header = "Название команды";
            column.Binding = new Binding("teamName");
            lstRate.Columns.Add(column);

            lstRate.ItemsSource = null;
            lstRate.ItemsSource = teamsRate;

           
        }
    }
}
