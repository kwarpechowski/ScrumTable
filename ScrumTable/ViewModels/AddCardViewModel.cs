using ScrumTable.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ScrumTable.ViewModels
{
    class AddCardViewModel  : INotifyPropertyChanged 
    {
        public List<int> pointsList { get; } = new List<int>();
        private List<Project> _projectList { get; set; } = new List<Project>();
        private string _cardName;
        private int _selectedPoint;
        private Project _selectedProject;


        public int SelectedPoint
        {
            get
            {
                return _selectedPoint;
            }
            set
            {
                _selectedPoint = value;
                RaisePropertyChanged("SelectedPoint");
            }
        }

        public Project SelectedProject
        {
            get
            {
                return _selectedProject;
            }
            set
            {
                _selectedProject = value;
                RaisePropertyChanged("SelectedProject");
            }
        }



        public string CardName
        {
            get
            {
                return _cardName;
            }
            set
            {
                _cardName = value;
                RaisePropertyChanged("CardName");
            }
        }



        public List<Project> ProjectList
        {
            get
            {
                return _projectList;
            }
            set
            {
                _projectList = value;
                SelectedProject = _projectList.FirstOrDefault();
                RaisePropertyChanged("ProjectList");
            }
        }

        public AddCardViewModel()
        {
            pointsList.Add(1);
            pointsList.Add(2);
            pointsList.Add(3);
            pointsList.Add(5);
            pointsList.Add(8);
            pointsList.Add(13);
            pointsList.Add(21);

            SelectedPoint = pointsList.FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
