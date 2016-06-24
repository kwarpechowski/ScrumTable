using ScrumTable.Models;
using ScrumTable.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ScrumTable
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditCard : Page
    {
        private AddCardViewModel viewModel = new AddCardViewModel();
        private Card selectedCard;
        private Context db = new Context();
        public EditCard()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
            viewModel.ProjectList = db.Projects.ToList();
            Debug.WriteLine("jeden");
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            selectedCard = (Card)e.Parameter;

            viewModel.CardName = selectedCard.Name;
            viewModel.SelectedProject = selectedCard.project;
            viewModel.SelectedPoint = selectedCard.Points;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var card = db.Cards.Single(i => i.CardId == selectedCard.CardId);
            if (card.Name != viewModel.CardName)
                card.Name = viewModel.CardName;
            if(card.project.Name != viewModel.SelectedProject.Name)
                card.project = viewModel.SelectedProject;
            if (card.Points != viewModel.SelectedPoint)
                card.Points = viewModel.SelectedPoint;
            db.SaveChanges();
            Frame.Navigate(typeof(Board), selectedCard);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Board), selectedCard);
        }
    }
}
