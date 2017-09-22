using System;
using System.Globalization;
using System.Windows.Data;



namespace WorkerManagementUI.Converters
{
    [ValueConversion(typeof(bool), typeof(string))]
    class BooleanToSexConverter : IValueConverter
    {
        private const string Male = "мужской";

        private const string Female = "женский";



        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool valueAsBool = (bool)value;

            if (valueAsBool)
                return Male;

            return Female;
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string valueAsString = (string)value;

            if (valueAsString == Male)
                return true;

            return false;
        }
    }
}
