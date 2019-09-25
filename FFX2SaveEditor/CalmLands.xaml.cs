using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FFX2SaveEditor
{
    /// <summary>
    /// Interaction logic for CalmLands.xaml
    /// </summary>
    public partial class CalmLands : Window
    {
        public uint OpenAirCredits
        {
            get { return uint.Parse(tbxOpenAirCredits.Text); }
            set { tbxOpenAirCredits.Text = value.ToString(); }
        }
        public uint OpenAirPoints
        {
            get { return uint.Parse(tbxOpenAirPoints.Text); }
            set { tbxOpenAirPoints.Text = value.ToString(); }
        }
        public uint ArgentCredits
        {
            get { return uint.Parse(tbxArgentCredits.Text); }
            set { tbxArgentCredits.Text = value.ToString(); }
        }
        public uint ArgentPoints
        {
            get { return uint.Parse(tbxArgentPoints.Text); }
            set { tbxArgentPoints.Text = value.ToString(); }
        }
        public uint MarraigePoints
        {
            get { return uint.Parse(tbxMarraigePoints.Text); }
            set { tbxMarraigePoints.Text = value.ToString(); }
        }
        public uint CreditsCh5
        {
            get { return uint.Parse(tbxCreditsCh5.Text); }
            set { tbxCreditsCh5.Text = value.ToString(); }
        }
        public uint Credits2Ch5
        {
            get { return uint.Parse(tbxCredits2Ch5.Text); }
            set { tbxCredits2Ch5.Text = value.ToString(); }
        }
        public uint HoverRides
        {
            get { return uint.Parse(tbxHoverRides.Text); }
            set { tbxHoverRides.Text = value.ToString(); }
        }

        public CalmLands()
        {
            InitializeComponent();
        }

        private void textbox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var tbx = (TextBox)sender;
            if (string.IsNullOrEmpty(tbx.Text)) return;

            var qty = int.Parse(tbx.Text);
            if (e.Delta < 0 && qty > 0)
                qty-=1000;
            else if (e.Delta > 0 && qty < 1000000000)
                qty+=1000;

            if (qty > 999999999)
                qty = 999999999;

            tbx.Text = qty.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            bool oversized = false;

            if (!string.IsNullOrWhiteSpace(e.Text) && !string.IsNullOrWhiteSpace(textBox.Text))
                oversized = textBox.Text.Length + e.Text.Length - textBox.SelectionLength > 9;

            e.Handled = oversized || Regex.IsMatch(e.Text, "[^0-9]+");
        }
    }
}
