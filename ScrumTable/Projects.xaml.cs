using Microsoft.EntityFrameworkCore;
using ScrumTable.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Projects : Page
    {
        private Context db = new Context();
        public List<string> colors = new List<string>();
        public Projects()
        {
            this.InitializeComponent();
            this.SetColors();
            this.SetProjects();
        }

        private void SetColors()
        {

            colors.Add("Red");
            colors.Add("Blue");
            colors.Add("Green");

            color.ItemsSource = colors.ToList();
            color.SelectedValue = colors.FirstOrDefault();
        }

        private void SetProjects()
        {
            listView.ItemsSource = db.Projects.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Project pr = new Project() { Name = textBox.Text, Color = color.SelectedValue.ToString() };
            db.Projects.Add(pr);
            db.SaveChanges();
            SetProjects();

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var dialog = new MessageDialog("Are you sure?");
            dialog.Title = "Really?";
            dialog.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
            dialog.Commands.Add(new UICommand { Label = "Cancel", Id = 1 });
            var res = await dialog.ShowAsync();

            if ((int)res.Id == 0)
            {
                var datacontext = (e.OriginalSource as FrameworkElement).DataContext;
                var project = datacontext as Project;
                db.Cards.RemoveRange(db.Cards.Where(i => i.project.ProjectId == project.ProjectId));
                db.Projects.Remove(project);
                db.SaveChanges();
                SetProjects();

            }
        }
    }
}
