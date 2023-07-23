using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2;

public class CSVGenerator<T>
{
    private IEnumerable<T> Data;
    private string FileName;
    private Type _type;

    public CSVGenerator(IEnumerable<T> data, string fileName)
    {
        Data = data;
        FileName = fileName;
        _type = typeof(T);
    }

    public void Generate()
    {
        var csv = new List<string>();

        csv.Add(CreateHeader());
        
        foreach (var row in  Data)
        {
            var rowSb = new StringBuilder();
            rowSb.Append(CreateRow(row));

            csv.Add(rowSb.ToString());
        }

        foreach (var item in csv) 
        {
            Console.WriteLine(item);
        }


        
    }

    private string CreateRow(T item)
    {
        var properties = _type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderedProps = properties.OrderBy(p => p.GetCustomAttribute<CsvAttribute>().ColoumnOrder);
        var rowString = new StringBuilder();
        foreach (var prop in orderedProps)
        {
            rowString.Append(CreateItem(prop,item)).Append(",");
            //var i = prop.GetValue(item);
            //var attr = prop.GetCustomAttribute<CsvAttribute>();
            //rowString.Append(String.Format($"{{0:{attr.Format}}}{attr.Units}", i)).Append(",");
        }
        return rowString.ToString()[..^1];
    }

    private string CreateItem(PropertyInfo? prop, T item)
    {
        var attr = prop.GetCustomAttribute<CsvAttribute>();

        return string.Format($"{{0:{attr.Format}}}{attr.Units}", prop.GetValue(item));
    }

    private string CreateHeader()
    {
        var properties = _type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
        
        var orderedProperties = properties.OrderBy(p => p.GetCustomAttribute<CsvAttribute>().ColoumnOrder);

        var header = new StringBuilder();
        foreach (var item in orderedProperties)
        {
            var attr = item.GetCustomAttribute<CsvAttribute>();
            header.Append(attr.Heading ?? item.Name).Append(",");

        }
        return header.ToString()[..^1];
    }

     

}