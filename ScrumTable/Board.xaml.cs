using ScrumTable.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
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
    public sealed partial class Board : Page
    {
        private Context db = new Context();
        public Board()
        {
            this.InitializeComponent();
            this.projects.ItemsSource = db.Projects.ToList();
            this.projects.SelectedItem = db.Projects.FirstOrDefault();

            ShowCards();
        }

        private void ShowCards()
        {
            var vm = projects.SelectedItem as Project;

            var cards = db.Cards.Where(i => i.project.ProjectId == vm.ProjectId);

            this.cat0.ItemsSource = cards.Where(i => i.Category == 0).ToList();
            this.cat1.ItemsSource = cards.Where(i => i.Category == 1).ToList();
            this.cat2.ItemsSource = cards.Where(i => i.Category == 2).ToList();
            this.cat3.ItemsSource = cards.Where(i => i.Category == 3).ToList();
            this.cat4.ItemsSource = cards.Where(i => i.Category == 4).ToList();
        }

        private void projects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowCards();
        }

        private void UnorganizedListView_OnDragItemsStarting(object sender, DragItemsStartingEventArgs e)
        {
            var items = string.Join(",", e.Items.Cast<Card>().Select(i => i.CardId));
            e.Data.SetText(items);
            e.Data.RequestedOperation = DataPackageOperation.Move;
        }

        private void ListView_DragOver(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                e.AcceptedOperation = DataPackageOperation.Move;
            }
        }

        private async void ListView_Drop(object sender, DragEventArgs e)
        {
            if (e.DataView.Contains(StandardDataFormats.Text))
            {
                var id = await e.DataView.GetTextAsync();
                var itemIdsToMove = id.Split(',');


                var destinationListView = sender as ListView;
                var listViewItemsSource = destinationListView?.ItemsSource as List<Card>;
                var catId = Int16.Parse(destinationListView.Name.Replace("cat", ""));

                if (listViewItemsSource != null)
                {
                    foreach (var itemId in itemIdsToMove)
                    {
                        Card card = db.Cards.First(i => i.CardId == Int16.Parse(id));
                        card.Category = catId;
                        db.SaveChanges();
                        ShowCards();
                    }
                }
            }
        }

        private void Grid_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            FrameworkElement senderElement = sender as FrameworkElement;
            FlyoutBase flyoutBase = FlyoutBase.GetAttachedFlyout(senderElement);
            flyoutBase.ShowAt(senderElement);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var datacontext = (e.OriginalSource as FrameworkElement).DataContext;
            var card = datacontext as Card;
            db.Cards.Remove(card);
            db.SaveChanges();
            ShowCards();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
