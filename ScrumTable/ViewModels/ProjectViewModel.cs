using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrumTable.ViewModels
{
    class ProjectViewModel : INotifyPropertyChanged
    {
        private List<string> _colors = new List<string>();

        public List<string> Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = value;
                SelectedColor = _colors.FirstOrDefault();
                RaisePropertyChanged("Colors");
            }
        }

        private string _selectedColor;

        public string SelectedColor
        {
            get
            {
                return _selectedColor;
            }
            set
            {
                _selectedColor = value;
                RaisePropertyChanged("SelectedColor");
            }
        }

        private string _projectName;

        public string ProjectName
        {
            get
            {
                return _projectName;
            }
            set
            {
                _projectName = value;
                RaisePropertyChanged("ProjectName");
            }
        }

        public ProjectViewModel ()
        {
            Colors.Add("Red");
            Colors.Add("Blue");
            Colors.Add("Green");
            Colors.Add("Pink");

            SelectedColor = Colors.FirstOrDefault();
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