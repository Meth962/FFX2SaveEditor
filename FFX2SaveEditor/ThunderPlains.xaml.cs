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
    /// Interaction logic for ThunderPlains.xaml
    /// </summary>
    public partial class ThunderPlains : Window
    {
        public byte Tower1Calibrated { get { return (bool)chkTower1.IsChecked ? (byte)1:(byte)0; } set { chkTower1.IsChecked = value == 1; } }
        public byte Tower2Calibrated { get { return (bool)chkTower2.IsChecked ? (byte)1:(byte)0; } set { chkTower2.IsChecked = value==1; } }
        public byte Tower3Calibrated { get { return (bool)chkTower3.IsChecked ? (byte)1:(byte)0; } set { chkTower3.IsChecked = value==1; } }
        public byte Tower4Calibrated { get { return (bool)chkTower4.IsChecked ? (byte)1:(byte)0; } set { chkTower4.IsChecked = value==1; } }
        public byte Tower5Calibrated { get { return (bool)chkTower5.IsChecked ? (byte)1:(byte)0; } set { chkTower5.IsChecked = value==1; } }
        public byte Tower6Calibrated { get { return (bool)chkTower6.IsChecked ? (byte)1:(byte)0; } set { chkTower6.IsChecked = value==1; } }
        public byte Tower7Calibrated { get { return (bool)chkTower7.IsChecked ? (byte)1:(byte)0; } set { chkTower7.IsChecked = value==1; } }
        public byte Tower8Calibrated { get { return (bool)chkTower8.IsChecked ? (byte)1:(byte)0; } set { chkTower8.IsChecked = value==1; } }
        public byte Tower9Calibrated { get { return (bool)chkTower9.IsChecked ? (byte)1:(byte)0; } set { chkTower9.IsChecked = value==1; } }
        public byte Tower10Calibrated { get { return (bool)chkTower10.IsChecked ? (byte)1 : (byte)0; } set { chkTower10.IsChecked = value==1; } }
        public byte Tower1Attempts { get { return byte.Parse(tbxTower1Attempts.Text); } set { tbxTower1Attempts.Text = value.ToString(); } }
        public byte Tower2Attempts { get { return byte.Parse(tbxTower2Attempts.Text); } set { tbxTower2Attempts.Text = value.ToString(); } }
        public byte Tower3Attempts { get { return byte.Parse(tbxTower3Attempts.Text); } set { tbxTower3Attempts.Text = value.ToString(); } }
        public byte Tower4Attempts { get { return byte.Parse(tbxTower4Attempts.Text); } set { tbxTower4Attempts.Text = value.ToString(); } }
        public byte Tower5Attempts { get { return byte.Parse(tbxTower5Attempts.Text); } set { tbxTower5Attempts.Text = value.ToString(); } }
        public byte Tower6Attempts { get { return byte.Parse(tbxTower6Attempts.Text); } set { tbxTower6Attempts.Text = value.ToString(); } }
        public byte Tower7Attempts { get { return byte.Parse(tbxTower7Attempts.Text); } set { tbxTower7Attempts.Text = value.ToString(); } }
        public byte Tower8Attempts { get { return byte.Parse(tbxTower8Attempts.Text); } set { tbxTower8Attempts.Text = value.ToString(); } }
        public byte Tower9Attempts { get { return byte.Parse(tbxTower9Attempts.Text); } set { tbxTower9Attempts.Text = value.ToString(); } }
        public byte Tower10Attempts { get { return byte.Parse(tbxTower10Attempts.Text); } set { tbxTower10Attempts.Text = value.ToString(); } }

        public ThunderPlains()
        {
            InitializeComponent();
        }

        private void textbox_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            var tbx = (TextBox)sender;
            if (string.IsNullOrEmpty(tbx.Text)) return;

            var qty = int.Parse(tbx.Text);
            if (e.Delta < 0 && qty > 0)
                qty--;
            else if (e.Delta > 0 && qty < 30)
                qty++;

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
