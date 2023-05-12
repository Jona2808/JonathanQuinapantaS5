using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JonathanQuinapantaS5.ViewModels
{
    public class VMMain
    {
        private ObservableCollection<WS.Datos> listaestu;

        public ObservableCollection<WS.Datos> Listaestu
        {
            get { return listaestu; }
            set { listaestu = value; }
        }
    }
}
