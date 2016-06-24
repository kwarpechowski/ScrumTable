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
        public int SelectedPoint { get; set; }
        public Project SelectedProject { get; set; }
        public string CardName { get; set; }


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
                RaisePropertyChanged("SelectedProject");
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

        public static implicit operator List<object>(AddCardViewModel v)
        {
            throw new NotImplementedException();
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
