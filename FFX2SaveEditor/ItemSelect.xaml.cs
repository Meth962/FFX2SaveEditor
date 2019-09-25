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
    public enum MenuType
    {
        Items,
        Accessories,
        Dressphere
    }

    /// <summary>
    /// Interaction logic for ItemSelect.xaml
    /// </summary>
    public partial class ItemSelect : Window
    {
        private MenuType menuType;

        public ItemSelect(MenuType type)
        {
            menuType = type;
            InitializeComponent();
        }

        public byte ItemId
        {
            get { return (byte)cbxItem.SelectedValue; }
            set { cbxItem.SelectedValue = value; }
        }

        public byte Quantity
        {
            get { return byte.Parse(tbxQuantity.Text); }
            set { tbxQuantity.Text = value.ToString(); }
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxItem.DisplayMemberPath = "Value";
            cbxItem.SelectedValuePath = "Key";

            switch (menuType)
            {
                case MenuType.Items:
                    cbxItem.ItemsSource = Globals.Items;
                    break;
                case MenuType.Accessories:
                    cbxItem.ItemsSource = Globals.Accessories;
                    break;
                case MenuType.Dressphere:
                    //cbxItem.ItemsSource = Globals.Dresspheres;
                    cbxItem.IsEditable = true;
                    cbxItem.IsReadOnly = true;
                    break;
            }
        }

        private void PreviewTextInputHandler(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            bool oversized = false;

            if (!string.IsNullOrWhiteSpace(e.Text) && !string.IsNullOrWhiteSpace(textBox.Text))
                oversized = textBox.Text.Length + e.Text.Length - textBox.SelectionLength > 2;

            e.Handled = oversized || Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void tbxQuantity_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbxQuantity.Text)) return;

            var qty = int.Parse(tbxQuantity.Text);
            if (e.Delta < 0 && qty > 0)
                qty--;
            else if (e.Delta > 0 && qty < 99)
                qty++;

            tbxQuantity.Text = qty.ToString();
        }
    }
}
