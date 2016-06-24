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

    public sealed partial class EditProject : Page
    {
        private ProjectViewModel viewModel = new ProjectViewModel();
        private Context db = new Context();
        private Project selectedProject;

        public EditProject()
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }

         protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            selectedProject = (Project)e.Parameter;

            Debug.WriteLine(selectedProject.Name);

            viewModel.SelectedColor = selectedProject.Color;
            viewModel.ProjectName = selectedProject.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var project = db.Projects.Single(i => i.ProjectId == selectedProject.ProjectId);

            if (project.Name != viewModel.ProjectName)
                project.Name = viewModel.ProjectName;

            if (project.Color != viewModel.SelectedColor)
                project.Color = viewModel.SelectedColor;

            db.SaveChanges();

            Frame.Navigate(typeof(Projects));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Projects));
        }
    }
}
