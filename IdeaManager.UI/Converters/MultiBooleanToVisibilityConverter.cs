using System.Globalization;
using System.Windows.Data;

namespace IdeaManager.UI.Converters;

public class MultiBooleanToVisibilityConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2 && values[0] is bool canExecute && values[1] is bool isSubmitting)
            return canExecute && !isSubmitting;
        return false;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}