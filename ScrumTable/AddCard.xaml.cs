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
    public sealed partial class AddCard : Page
    {
        private AddCardViewModel viewModel = new AddCardViewModel();
        private Context db = new Context();
        public AddCard()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
            viewModel.ProjectList = db.Projects.ToList();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var card = new Card()
            {
                Name = viewModel.CardName,
                Points = viewModel.SelectedPoint,
                project = viewModel.SelectedProject
            };

            db.Cards.Add(card);
            db.SaveChanges();
        }
    }
}
