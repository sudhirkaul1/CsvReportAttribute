// See https://aka.ms/new-console-template for more information
using ConsoleApp2;
using System.Collections.Generic;

Console.WriteLine("Hello, World!");
//new CSVGenerator<Book>(BookData.Books, "Books").Generate();
//new CSVGenerator<Weather>(WeatherData.Weather, "Weather").Generate();

new CSVGenerator<Book>(BookData.Books,"Books").Generate();
//new CSVGenerator<Weather>(WeatherData.Weather,"Weather").Generate();