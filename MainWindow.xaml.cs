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

        int counter = 0;

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
            int remainderPoints = 0;
            int remainderPoints2 = 0;

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

            int fishPoints = troutFish * troutPoints + pikeFish * pikePoints + pickerelFish * pickerelPoints;

            //Loop to find until fish is not equal & less than total points

            while (pickerelFish * pickerelPoints < totalPoints)
            {
                pickerelFish++;
                checkLine(troutFish, pikeFish, pickerelFish, troutPoints, pikePoints, pickerelPoints, totalPoints);
            }
            pickerelFish = 0;

            while (pikeFish * pikePoints < totalPoints)
            {
                pikeFish++;
                checkLine(troutFish, pikeFish, pickerelFish, troutPoints, pikePoints, pickerelPoints, totalPoints);
                remainderPoints = totalPoints - pikeFish * pikePoints;
                while (pickerelFish * pickerelPoints < totalPoints)
                {
                    pickerelFish++;
                    checkLine(troutFish, pikeFish, pickerelFish, troutPoints, pikePoints, pickerelPoints, totalPoints);
                }
                pickerelFish = 0;
            }
            pikeFish = 0;
            pickerelFish = 0;

            while (troutFish * troutPoints < totalPoints)
            {
                troutFish++;
                checkLine(troutFish, pikeFish, pickerelFish, troutPoints, pikePoints, pickerelPoints, totalPoints);
                remainderPoints = totalPoints - troutFish * troutPoints;
                while (pikeFish * pikePoints < remainderPoints)
                {
                    remainderPoints2 = remainderPoints - pikeFish * pikePoints;
                    while (pickerelFish * pickerelPoints < remainderPoints2)
                    {
                        pickerelFish++;
                        checkLine(troutFish, pikeFish, pickerelFish, troutPoints, pikePoints, pickerelPoints, totalPoints);
                    }
                    pickerelFish = 0;
                    pikeFish++;
                    checkLine(troutFish, pikeFish, pickerelFish, troutPoints, pikePoints, pickerelPoints, totalPoints);
                }
                pikeFish = 0;
            }

            //Output a label that shows counter
            Label myLabel2 = new Label();
            myLabel2.Content = "Total number of options: " + counter;
            myStackPanel.Children.Add(myLabel2);
        }

        private void checkLine(int troutFish, int pikeFish, int pickerelFish, int troutPoints, int pikePoints, int pickerelPoints, int totalPoints)
        {
            if (troutFish * troutPoints + pikeFish * pikePoints + pickerelFish * pickerelPoints > totalPoints)
            {
                Console.WriteLine("false line");
            }
            else
            {
                createLabel(troutFish, pikeFish, pickerelFish);
            }
        }

        private void createLabel(int f1, int f2, int f3)
        {
            Label mylabel = new Label();
            mylabel.Content = "Trout: " + f1 + " Pike: " + f2 + " Pickerel: " + f3 + ".";
            myStackPanel.Children.Add(mylabel);
            Console.WriteLine(mylabel.Content);
            counter++;
        }
    }
}
