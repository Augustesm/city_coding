namespace TableLibrary
{
    /// <summary>
    /// Interface for printing an object using the ConsoleTable class
    /// </summary>
    public interface ITablePrintable
    {
        /// <summary>
        /// Count of fields and properties
        /// </summary>
        int ElementsCount { get; }
        /// <param name="elIndex">Index of field or property</param>
        /// <returns>Value converted to string of class field or property</returns>
        string? GetElement(int elIndex);
        /// <param name="elIndex">Index of field or property</param>
        /// <returns>Name of class field or property</returns>
        string? GetElementName(int elIndex);
    }
}