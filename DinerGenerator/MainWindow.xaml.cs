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

namespace DinerGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MakeTheMenu();
        }

        private void MakeTheMenu()
        {
            MenuItem[] menuItems = new MenuItem[5];
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i < 3)
                {
                    menuItems[i] = new MenuItem(); }
                else {
                    menuItems[i] = new MenuItem()
                    {
                        Breads = new string[] { "plain bagel", "onion bagel",
                        "pumpernickel bagel", "everything bagel"}
                    };
                    }
                }
            item1.Text = menuItems[0].GenerateMenuItem();
            item2.Text = menuItems[1].GenerateMenuItem();
            item3.Text = menuItems[2].GenerateMenuItem();
            item4.Text = menuItems[3].GenerateMenuItem();
            item5.Text = menuItems[4].GenerateMenuItem();

            price1.Text = menuItems[0].RandomPrice();
            price2.Text = menuItems[1].RandomPrice();
            price3.Text = menuItems[2].RandomPrice();
            price4.Text = menuItems[3].RandomPrice();
            price5.Text = menuItems[4].RandomPrice();

            MenuItem specialMenuItem = new MenuItem()
            {
                Proteins = new string[] {"Organic ham", "Mushroom patty", "Mortadella"},
                Breads = new string[] {"a gluten free roll", "a wrap", "pita"},
                Condiments = new string[] {"dijon mustard", "miso dressing", "au jus" }                
            };

            item6.Text = specialMenuItem.GenerateMenuItem();
            //note it calls a method from the base class
            price6.Text = specialMenuItem.RandomPrice();

            Guac.Text = $"Add guacamole for {specialMenuItem.RandomPrice()}";
        }
    }

    class MenuItem
    {
        public Random Randomiser = new Random();

        public string[] Proteins =
        {
            "Roast Beef",
            "Salami",
            "Turkey",
            "Pastrami",
            "Tofu" };

        public string[] Condiments = {"yellow mustard", "brown mustard", "honey mustard",
                                       "mayo", "relish", "french dressing"};
        public string[] Breads = { "rye", "white", "wheat", "pumpernickel", "a roll" };

        public string GenerateMenuItem()
        {
            string randomProtein = Proteins[Randomiser.Next(Proteins.Length)];
            string randomCondiment = Condiments[Randomiser.Next(Condiments.Length)];
            string randomBread = Breads[Randomiser.Next(Breads.Length)];

            return $"{randomProtein} with {randomCondiment} on {randomBread}";
        }

        public string RandomPrice()
        {
            decimal dollars = Randomiser.Next(2, 5);
            decimal cents = Randomiser.Next(1, 98);
            decimal price = dollars + (cents * 0.01m);
            return price.ToString("c");
        }

    }

}
