using Individual_SMS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Individual_SMS
{

    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var W1 = new LoginWindow();
            W1.Show();
           
        }
    }
}

    
   

