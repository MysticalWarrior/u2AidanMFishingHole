/*
Aidan McClung
March 26, 2018
u2AidanMFishingHole
Generates avalbile catch combinations from a user-defined point set and max points.
*/
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

namespace u2AidanMFishingHole
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

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            //Take input, assign values to fish points
            string input = txtInput.Text;
            int troutFish = 0;
            int pikeFish = 0;
            int pickerelFish = 0;
            int troutPoints;
            int pikePoints;
            int pickerelPoints;
            int totalPoints;
            int counter = 0;

            ///begin tryparsing point values, then deleting them from original string.
            int.TryParse(input.Substring(0, input.IndexOf('\r')), out troutPoints);
            input = input.Substring(input.IndexOf('\r') + 2);

            int.TryParse(input.Substring(0, input.IndexOf('\r')), out pikePoints);
            input = input.Substring(input.IndexOf('\r') + 2);

            int.TryParse(input.Substring(0, input.IndexOf('\r')), out pickerelPoints);
            input = input.Substring(input.IndexOf('\r') + 2);

            //Find the overall points
            ///tryparse total point values
            int.TryParse(input.Substring(0, input.IndexOf('\r')), out totalPoints);

            //Loop to find until fish is not equal & less than total points
            while (troutFish * troutPoints != totalPoints & troutFish * troutPoints < totalPoints)
            {
                troutFish++;
                //MessageBox.Show("trout: " + troutFish);
                createLabel(troutFish, 0, 0);
                counter++;
            }
            while (pikeFish * pikePoints != totalPoints & pikeFish * pikePoints < totalPoints)
            {
                pikeFish++;
                //MessageBox.Show("pike: " + pikeFish);
                createLabel(0, pikeFish, 0);
                counter++;
            }
            while (pickerelFish * pickerelPoints != totalPoints & pickerelFish * pickerelPoints < totalPoints)
            {
                pickerelFish++;
                //MessageBox.Show("pickerel: " + pickerelFish);
                createLabel(0, 0, pickerelFish);
                counter++;
            }

            Label myLabel2 = new Label();
            myLabel2.Content = "Total number of options: " + counter;
            myStackPanel.Children.Add(myLabel2);
        }

        private void createLabel(int f1, int f2, int f3)
        {
            Label mylabel = new Label();
            mylabel.Content = "Trout: " + f1 + " Pike: " + f2 + " Pickerel: " + f3 + ".";
            myStackPanel.Children.Add(mylabel);
        }
    }
}
