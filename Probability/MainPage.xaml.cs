using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Probability
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
            formattableTitleBar.ButtonForegroundColor = Colors.Black;
            formattableTitleBar.BackgroundColor = Colors.Transparent;
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
        }

        private Boolean contenue = false;
        private int trial = 0;
        private int p = 0;
        Random random = new Random();

        //choice selected as manual control
        private void m_c(object sender, RoutedEventArgs e)
        {
            choice.Visibility = Visibility.Collapsed;

            m_c_p.Visibility = Visibility.Visible;
            back_btn.Visibility = Visibility.Visible;
        }

        //choice selected as stop at
        private void s_a(object sender, RoutedEventArgs e)
        {
            choice.Visibility = Visibility.Collapsed;

            s_a_p.Visibility = Visibility.Visible;
            back_btn.Visibility = Visibility.Visible;
        }

        //show choice
        private void show_choice(object sender, RoutedEventArgs e)
        {
            choice.Visibility = Visibility.Visible;

            s_a_p.Visibility = Visibility.Collapsed;
            m_c_p.Visibility = Visibility.Collapsed;
            back_btn.Visibility = Visibility.Collapsed;
        }

        private async void start_p(object sender, RoutedEventArgs e)
        {
            int p_l = p;
            int trial_l = 0;
            int wait = Convert.ToInt32(sldr.Value);

            contenue = true;

            while (contenue == true)
            {
                await Task.Delay(wait);

                trial++;
                trial_l++;

                int randomNumber = new_ran_num(1, 7);

                results.Text += randomNumber.ToString() + ", ";

                if (randomNumber == 6)
                {
                    p_l += 100;
                }
                else p_l += 0;

                p = p_l;

                probability_1.Text = (p / trial).ToString();
                num_trial.Text = trial.ToString();
                num_true.Text = check_true().ToString();
                
                res_field.ChangeView(0.0f, double.MaxValue, 1.0f);
            }

            probability_1.Text = (p / trial).ToString();
            num_trial.Text = trial.ToString();
            num_true.Text = check_true().ToString();
        }
        
        
        //stop the trials
        private void stop_p(object sender, RoutedEventArgs e)
        {
            contenue = false;
        }

        //set trial number to zero (start over)
        private void clear_p(object sender, RoutedEventArgs e)
        {
            trial = 1;
            p = 0;
            results.Text = "";
            num_trial.Text = "0";
            a_start_tbx.Text = "";
            num_true.Text = "0";
            probability_1.Text = "--";
        }

        private void start_p_a(object sender, RoutedEventArgs e)
        {
            int p_l = p;
            int trial_l = 0;

            if ((a_start_tbx.Text != "") || (a_start_tbx.Text != null))
            {
                int trail_max = Convert.ToInt32(a_start_tbx.Text);

                //if (trial == 1) { trail_max++; }

                while (trial_l < trail_max)
                {
                    trial++;
                    trial_l++;

                    int randomNumber = new_ran_num(1,7);

                    results.Text += randomNumber.ToString() + ", ";

                    if (randomNumber == 6)
                    {
                        p_l += 100;
                    }
                    else p_l += 0;

                    p = p_l;

                    probability_1.Text = (p / trial).ToString();
                    num_trial.Text = trial.ToString();
                }

                probability_1.Text = (p / trial).ToString();
                num_trial.Text = trial.ToString();
                num_true.Text = check_true().ToString();
                res_field.ChangeView(0.0f, double.MaxValue, 1.0f);
            }
        }

        //check the amount of required items
        private int check_true()
        {
            int freq = 0;
            string all = results.Text;
            string[] all1 = all.Split(',');
            foreach(string res in all1)
            {
                if (res.Contains("6")) freq++;
            }

            return freq;
        }

        private int new_ran_num(int min, int max)
        {
            int randomNumber = random.Next(min, max);
            return randomNumber;
        }

        private void r6(object sender, RoutedEventArgs e)
        {
            choice1.Visibility = Visibility.Collapsed;
            choice.Visibility = Visibility.Visible;
        }

        private void t_c(object sender, RoutedEventArgs e)
        {

        }

        private void cust_options(object sender, RoutedEventArgs e)
        {

        }
    }
}
