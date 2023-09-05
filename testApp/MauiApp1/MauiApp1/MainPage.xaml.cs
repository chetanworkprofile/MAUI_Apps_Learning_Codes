namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        /*string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");    // file for note exercise
        public const double MyFontSize = 28;*/

        // exercise tip calc for shared resource
        private Color colorNavy = Colors.Navy;
        private Color colorSilver = Colors.Silver;
        public MainPage()
        {
            InitializeComponent();

            // to handle file existense in note app
            /*if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }*/

            // exercise tip calc for stack layout + grid tip calc exercise
            /*billInput.TextChanged += (s, e) => CalculateTip(false, false);
            roundDown.Clicked += (s, e) => CalculateTip(false, true);
            roundUp.Clicked += (s, e) => CalculateTip(true, false);

            tipPercentSlider.ValueChanged += (s, e) =>
            {
                double pct = Math.Round(e.NewValue);
                tipPercent.Text = pct + "%";
                CalculateTip(false, false);
            };*/

            // exercise tip calc for shared resource
            billInput.TextChanged += (s, e) => CalculateTip();
        }

        //call permission exercise
        /* string translatedNumber;

         private void OnTranslate(object sender, EventArgs e)
         {
             string enteredNumber = PhoneNumberText.Text;
             translatedNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

             if (!string.IsNullOrEmpty(translatedNumber))
             {
                 CallButton.IsEnabled = true;
                 CallButton.Text = "Call " + translatedNumber;
             }
             else
             {
                 CallButton.IsEnabled = false;
                 CallButton.Text = "Call";
             }
         }

         async void OnCall(object sender, System.EventArgs e)
         {
             if (await this.DisplayAlert(
                 "Dial a Number",
                 "Would you like to call " + translatedNumber + "?",
                 "Yes",
                 "No"))
             {
                 try
                 {
                     if (PhoneDialer.Default.IsSupported)
                         PhoneDialer.Default.Open(translatedNumber);
                 }
                 catch (ArgumentNullException)
                 {
                     await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
                 }
                 catch (Exception)
                 {
                     // Other error has occurred.
                     await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
                 }
             }
         }*/

        // note exercise
        /*void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            editor.Text = string.Empty;
        }*/

        /*

        void OnHorizontalStartClicked(object sender, EventArgs e) { target.HorizontalOptions = LayoutOptions.Start; }
        void OnHorizontalCenterClicked(object sender, EventArgs e) { target.HorizontalOptions = LayoutOptions.Center; }
        void OnHorizontalEndClicked(object sender, EventArgs e) { target.HorizontalOptions = LayoutOptions.End; }
        void OnHorizontalFillClicked(object sender, EventArgs e) { target.HorizontalOptions = LayoutOptions.Fill; }

        void OnVerticalStartClicked(object sender, EventArgs e) { target.VerticalOptions = LayoutOptions.Start; }
        void OnVerticalCenterClicked(object sender, EventArgs e) { target.VerticalOptions = LayoutOptions.Center; }
        void OnVerticalEndClicked(object sender, EventArgs e) { target.VerticalOptions = LayoutOptions.End; }
        void OnVerticalFillClicked(object sender, EventArgs e) { target.VerticalOptions = LayoutOptions.Fill; }*/

        // exercise tip calc for stack layout + for grid tip calc
        /*void CalculateTip(bool roundUp, bool roundDown)
        {
            double t;
            if (Double.TryParse(billInput.Text, out t) && t > 0)
            {
                double pct = Math.Round(tipPercentSlider.Value);
                double tip = Math.Round(t * (pct / 100.0), 2);

                double final = t + tip;

                if (roundUp)
                {
                    final = Math.Ceiling(final);
                    tip = final - t;
                }
                else if (roundDown)
                {
                    final = Math.Floor(final);
                    tip = final - t;
                }

                tipOutput.Text = tip.ToString("C");
                totalOutput.Text = final.ToString("C");
            }
        }

        void OnNormalTip(object sender, EventArgs e) { tipPercentSlider.Value = 15; }
        void OnGenerousTip(object sender, EventArgs e) { tipPercentSlider.Value = 20; }*/


        // exercise tip calc for shared resource
        void CalculateTip()
        {
            double bill;

            if (Double.TryParse(billInput.Text, out bill) && bill > 0)
            {
                double tip = Math.Round(bill * 0.15, 2);
                double final = bill + tip;

                tipOutput.Text = tip.ToString("C");
                totalOutput.Text = final.ToString("C");
            }
        }

        void OnLight(object sender, EventArgs e)
        {
            /*LayoutRoot.BackgroundColor = colorSilver;

            tipLabel.TextColor = colorNavy;
            billLabel.TextColor = colorNavy;
            totalLabel.TextColor = colorNavy;
            tipOutput.TextColor = colorNavy;
            totalOutput.TextColor = colorNavy;*/

            // dynamic-resource change
            Resources["fgColor"] = colorNavy;
            Resources["bgColor"] = colorSilver;
        }

        void OnDark(object sender, EventArgs e)
        {
            /*LayoutRoot.BackgroundColor = colorNavy;

            tipLabel.TextColor = colorSilver;
            billLabel.TextColor = colorSilver;
            totalLabel.TextColor = colorSilver;
            tipOutput.TextColor = colorSilver;
            totalOutput.TextColor = colorSilver;*/

            Resources["fgColor"] = colorSilver;
            Resources["bgColor"] = colorNavy;
        }

        async void GotoCustom(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync(nameof(CustomTipPage));
        }
    }

    // xaml extension example
    /*public class GlobalFontSizeExtension : IMarkupExtension
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return MainPage.MyFontSize;
        }
    }*/
}