using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace FFX2SaveEditor
{
    [ValueConversion(typeof(string),typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tag = (string)value;

            switch(tag)
            {
                case "Chapter":
                case "Location":
                    return new BitmapImage(new Uri($"pack://application:,,,/Resources/SmallBar.png"));
                default:
                    return new BitmapImage(new Uri($"pack://application:,,,/Resources/LongBar.png"));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [ValueConversion(typeof(string), typeof(BitmapImage))]
    public class HeaderHAlignConverter : IValueConverter
    {
        public static HeaderHAlignConverter Instance = new HeaderHAlignConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tag = (string)value;

            switch (tag)
            {
                case "Chapter":
                case "Location":
                    return "Center";
                default:
                    return "Left";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
