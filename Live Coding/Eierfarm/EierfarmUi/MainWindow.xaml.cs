using EggfarmModel.Model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EierfarmUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDuck_Click(object sender, RoutedEventArgs e)
        {
            Duck duck = new Duck();

            cbxAnimals.Items.Add(duck);
            cbxAnimals.SelectedItem = duck;
        }

        private void btnChicken_Click(object sender, RoutedEventArgs e)
        {
            Chicken chicken = new Chicken();

            cbxAnimals.Items.Add(chicken);
            cbxAnimals.SelectedItem=chicken;
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            if(cbxAnimals.SelectedItem is Poultry animal)
            {
                animal.Eat();
            }
        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            IEggProducer? producer = cbxAnimals.SelectedItem as IEggProducer;

            if(producer != null) 
                producer.LayEgg();
        }
    }
}