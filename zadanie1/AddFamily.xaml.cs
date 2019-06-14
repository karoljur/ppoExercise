using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zadanie1
{
    /// <summary>
    /// Interaction logic for AddFamily.xaml
    /// </summary>
    public partial class AddFamily : Page
    {
        public AddFamily()
        {
            InitializeComponent();
        }
        
        public AddFamily(object data)
        {
            this.DataContext = data;
        }
    }
}
