using System.Globalization;
using System.Windows.Data;

namespace IdeaManager.UI.Converters
{
    public class EnumToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;
            string enumValue = value.ToString();
            string targetValue = parameter.ToString();
            return enumValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return null;
            return Enum.Parse(targetType, parameter.ToString());
        }
    }
}
