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

namespace TwoDecksWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (Resources["rightDeck"] is Deck rightDeck)           // Here's where the MainWindow constructor was modified to safely get a reference to the right deck and call its Clear()-method. 
            {
                rightDeck.Clear();                                  // This code safely gets a reference to the right deck. It's made up of two parts that you're familiar with: using a key to access an item in a Dictionary (in this case, the Window resource dictionary) and using the "is" keyword to safely cast it (in this case to a Deck reference). 
            }
        }

        private void MoveCard(bool leftToRight)                     // This method gets executed if the user double clicks or presses enter on one of the cards in the ListBox. 
        {
            if ((Resources["rightDeck"] is Deck rightDeck) && (Resources["leftDeck"] is Deck leftDeck))     // The Window.Resources tag that you added to the XAML created a resource dictionary with two entries: references to two instances of the Deck class with keys leftDeck and rightDeck.
            {
                if (leftToRight)                                                // If the user have clicked on a card in the left ListBox...
                {
                    if (leftDeckListBox.SelectedItem is Card card)              // The ListBox.SelectedItem property returns a reference to the item that's currently selected. You used data binding to set the ItemsSource to a collection of Cards, so the selected item will be a Card reference. 
                    {
                        leftDeck.Remove(card);                                  // We remove the clicked card from the left ListBox. 
                        rightDeck.Add(card);                                    // And then add it to the right ListBox instead.
                    }
                }
                else                                                            // If the user have clicked on a card in the right ListBox...
                {
                    if (rightDeckListBox.SelectedItem is Card card)
                    {
                        rightDeck.Remove(card);                                 // We remove the clicked card from the right ListBox.
                        leftDeck.Add(card);                                     // And then add it to the left ListBox instead. 
                    }
                }
            }
        }

        /// <summary>
        /// Gets called if the user clicks on a card in the left ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(true);                                                     // The ListBoxes' MouseDoubleClick event handlers just call the MoveCard()-method. The left deck ListBox calls MoveCard(true) to move the selected card from left to right. 
        }

        /// <summary>
        /// Gets called if the user clicks on a card in the right ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightDeckListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MoveCard(false);                                                    // The ListBoxes' MouseDoubleClick event handlers just call the MoveCard()-method. The right deck ListBox calls MoveCard(false) to move the selected card from right to left. 
        }

        /// <summary>
        /// Gets called if the user press Enter on a card in the left ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)                                             // The KeyDown event handlers work just like the MouseDoubleClick event handlers, except they use the KeyEventArgs argument to move the card if the user pressed the Enter key. 
            {
                MoveCard(true);
            }
        }

        /// <summary>
        /// Gets called if the user press Enter on a card in the right ListBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightDeckListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MoveCard(false);
            }
        }





        /// <summary>
        /// This method gets called when the user presses the "Shuffle"-button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shuffleLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["leftDeck"] is Deck leftDeck)                         // Each of the Button Click event handlers use the is keyword to safely get a reference to either the left or right deck. 
            {
                leftDeck.Shuffle();
            }
        }

        /// <summary>
        /// This method gets called when the user presses the "Reset"-button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetLeftDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["leftDeck"] is Deck leftDeck)
            {
                leftDeck.Reset();
            }
        }

        /// <summary>
        /// This method gets called when the user presses the "Sort"-button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sortRightDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Sort();
            }
        }

        /// <summary>
        /// This method gets called when the user presses the "Clear"-button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearRightDeck_Click(object sender, RoutedEventArgs e)
        {
            if (Resources["rightDeck"] is Deck rightDeck)
            {
                rightDeck.Clear();
            }
        }
    }
}
