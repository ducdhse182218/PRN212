using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GermanyEuro2024.BLL.Services;
using GermanyEuro2024.DAL.Entities;

namespace GermanyEuro2024_SE182218
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        FootballPlayerService _footballPlayerService;
        FootballTeamService _footballTeamService;

        public FootballPlayer EdittedFootballPlayer { get; set; }
        public DetailWindow()
        {
            InitializeComponent();
            _footballPlayerService = new();
            _footballTeamService = new();
            if(EdittedFootballPlayer != null)
            {
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FootballPlayer footballPlayer = new FootballPlayer();
            footballPlayer.PlayerId = PlayerIdTextBox.Text;
            footballPlayer.PlayerName = PlayerNameTextBox.Text;
            footballPlayer.Achievements = AchievementsTextBox.Text;
            footballPlayer.Birthday = BirthdayDatePicker.SelectedDate;
            footballPlayer.OriginCountry = OriginCountryTextBox.Text;
            footballPlayer.Award = AwardTextBox.Text;
            footballPlayer.FootballTeamId = FootballTeamComboBox.SelectedValue.ToString();
            if (EdittedFootballPlayer == null)
            {
                _footballPlayerService.Save(footballPlayer);
                MessageBox.Show("Football Player added successfully!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                PlayerIdTextBox.Text = null;
            }
            else
            {
                _footballPlayerService.Update(footballPlayer);
            }
            this.Close();
        }

        private void FillComboBox()
        {
            FootballTeamComboBox.ItemsSource = _footballTeamService.GetAll();
            FootballTeamComboBox.DisplayMemberPath = "TeamTitle";
            FootballTeamComboBox.SelectedValuePath = "FootballTeamId";
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillComboBox();
            FillElement(EdittedFootballPlayer);
        }

        private void FillElement(FootballPlayer EdittedFootballPlayer)
        {
            if (EdittedFootballPlayer == null) return;
            PlayerIdTextBox.Text = EdittedFootballPlayer.PlayerId;
            PlayerNameTextBox.Text = EdittedFootballPlayer.PlayerName;
            AchievementsTextBox.Text = EdittedFootballPlayer.Achievements;
            BirthdayDatePicker.SelectedDate = EdittedFootballPlayer.Birthday;
            OriginCountryTextBox.Text = EdittedFootballPlayer.OriginCountry;
            AwardTextBox.Text = EdittedFootballPlayer.Award;
            FootballTeamComboBox.SelectedValue = EdittedFootballPlayer.FootballTeamId;
            PlayerIdTextBox.IsEnabled = false;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
