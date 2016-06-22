using ScrumTable.Models;
using System;
using System.Collections.Generic;
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
        private Context db = new Context();
        public AddCard()
        {
            this.InitializeComponent();
            this.setPoints();
            this.projects.ItemsSource = db.Projects.ToList();
            this.projects.SelectedValue = db.Projects.FirstOrDefault();
        }

        private void setPoints()
        {
            var plist = new List<int>();
            plist.Add(1);
            plist.Add(2);
            plist.Add(3);
            plist.Add(5);
            plist.Add(8);
            plist.Add(13);
            plist.Add(21);

            points.ItemsSource = plist;
            points.SelectedItem = plist.First();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var card = new Card()
            {
                Name = textBox.Text,
                Points = Int16.Parse(points.SelectedValue.ToString()),
                project = this.projects.SelectedItem as Project
            };

            db.Cards.Add(card);
            db.SaveChanges();
        }
    }
}
