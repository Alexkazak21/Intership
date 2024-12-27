using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.Mappers;

public class CustomToDoubleConverter : DefaultTypeConverter
{
    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        //if (text.Contains(','))
        //{
        //    // Remove quotes and replace ',' with '.'
        //    text = text.Replace(',', '.');
        //}
        if (double.TryParse(text, out var value))
        {
            return value;
        }

        return null;
    }
}
