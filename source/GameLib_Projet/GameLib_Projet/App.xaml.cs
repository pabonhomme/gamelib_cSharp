using Modele;
using Managment;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Persistance;

namespace PageAccueil
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Manager Manager { get; set; } = new Manager( new StubDataManager());
    }
}
