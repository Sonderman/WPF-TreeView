using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace TreeView
{
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            
            var image = "file.png";

            switch((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive: image = "drive.png"; break;
                case DirectoryItemType.Folder: image = "folder.png"; break;
            }
            return new BitmapImage(new Uri($"pack://application:,,,/images/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
