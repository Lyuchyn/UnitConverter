using Microsoft.Extensions.CommandLineUtils;
using System;
using UnitConverter.Converters;

namespace UnitConverter
{
    class Program
    {
        static int Main(string[] args)
        {
            var app = new CommandLineApplication
            {
                Name = "Units Converter"
            };
            app.HelpOption("-?|-h|--help");

            var fromUnit = app.Option("-f|--from", "from unit", CommandOptionType.SingleValue);
            var toUnit = app.Option("-t|--to", "to unit", CommandOptionType.SingleValue);
            var value = app.Option("-v|--value", "value to convert", CommandOptionType.SingleValue);

            app.OnExecute(() =>
            {
                if (!fromUnit.HasValue() || !toUnit.HasValue() || !value.HasValue())
                {
                    Console.WriteLine("Please provide all required arguments.");
                    app.ShowHelp();
                    return 1;
                }

                var toUnitValue = toUnit.Value();
                var result = new UnitConverterFacade().Convert(fromUnit.Value(), toUnitValue, double.Parse(value.Value()));

                Console.WriteLine($"Result: {result} {toUnitValue}");

                return 0;
            });

            try
            {
                return app.Execute(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
    }
}
