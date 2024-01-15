using System;
using System.Collections.Generic;
using System.Linq;

namespace TableLibrary
{
    public static class TablePrinter
    {
        public static void Print(IEnumerable<ITablePrintable> printables)
        {
            if (printables == null || printables.Count(x => true) <= 0)
                throw new ArgumentException("Invalid argument", nameof(printables));

            string[] columns = Enumerable.Range(0, printables.First().ElementsCount)
                .Select(x => printables.First().GetElementName(x) ?? string.Empty).ToArray();
            ConsoleTable consoleTable = new ConsoleTable(columns);

            foreach (var p in printables)
            {
                string[] row = Enumerable.Range(0, p.ElementsCount)
                    .Select(x => p.GetElement(x) ?? string.Empty).ToArray();
                consoleTable.AddRow(row);
            }
            consoleTable.Write();
        }
    }
}
