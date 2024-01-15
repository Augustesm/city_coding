using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableLibrary;
using static System.MathF;

using static System.Math;
namespace _09_15_c_sharp
{
    internal partial class Miestas
    {
        private Guid ID;
        private (float length, float width) _size;
        double Area => _size.length * 2 + _size.width * 2;
        private DateTime _foundedTime;
        private bool _hasAirport;
        private string? _cityName;
        private Color _flagColor;
        public string Info => ToString();
    }
    partial class Miestas
    {
        public enum Color
        {
            red,
            blue,
            yellow,
            black
        }
    }
    partial class Miestas //7,2
    {
        public Miestas() : this((2, 10)) { }
        public Miestas((float length, float width) size) : this(size, null, Color.black) { }
        public Miestas((float length, float width) size, string? cityName, Color color)
        {
            ID = Guid.NewGuid();
            _size = size;
            _cityName = cityName;
            _flagColor = color;
            if (cityName != null)
            {
                _hasAirport = true;
                _foundedTime = DateTime.UtcNow;
            }
            else
            {
                _hasAirport = false;
            }

        }

        public void Deconstruct(out (float length, float width) size, out string? cityName, out Color color, out DateTime? foundedTime, out bool hasAirport)
        {
            size = _size;
            cityName = _cityName;
            color = _flagColor;
            foundedTime = _foundedTime;
            hasAirport = _hasAirport;

        }
    }
    partial class Miestas //7.3
    {
        //8
        public override string ToString()
        {
            return $"ID: {ID}\nSize (length, width): {_size}\n" + $"CityName: {_cityName ?? "Empty"}\nColor: (_flagColor)";
        }

        //9
        public override int GetHashCode()
        {
            return (ID.GetHashCode() << 5) ^ Area.GetHashCode();
        }
        //9
        public override bool Equals(object? obj)
        {
            if (obj is Miestas miestas)
                return Equals(miestas);
            else return false;
        }
        //14
        public static Miestas CreateRandomCity(int? id = null)
        {
            Random random = id != null ? new Random(id.Value) : new Random();
            float maxLength = (float)(random.NextDouble() + 0.1) * 10;
            float maxWdith = (float)(random.NextDouble() + 0.1) * 20;
            string? cityName = new string?[] { "Kaunas", "Vilnius", "Klaipeda", null }[random.Next(4)];
            Color[] colors = Enum.GetValues(typeof(Color)).Cast<Color>().ToArray();
            Miestas miestas = new Miestas
                (
                    (maxLength, maxWdith),
                    cityName,
                    colors[random.Next(colors.Length)]
                );
            miestas._foundedTime = miestas._foundedTime.AddSeconds(random.Next(60 * 60 * 24 * 100));
            return miestas;
        }
    }

    partial class Miestas : IEquatable<Miestas?> //7.5; 10
    {
        public bool Equals(Miestas? other) => ID.Equals(other?.ID);
    }
    partial class Miestas //7.4
    {
        //11
        public static bool operator ==(Miestas? first, object second) => first?.Equals(second) ?? second == null;
        public static bool operator !=(Miestas? first, object second) => !first?.Equals(second) ?? second != null;
        //12
        public static bool operator ==(Miestas? first, Miestas? second) => first?.Equals(second) ?? second?.Equals(null) ?? true;
        public static bool operator != (Miestas? first, Miestas? second) => !first?.Equals(second) ?? second?.Equals(null) ?? false;
        //13
        public static bool operator true(Miestas? first) => first?._hasAirport ?? false;
        public static bool operator false(Miestas? first) => !first?._hasAirport ?? true;
    }

    partial class Miestas : ITablePrintable //7.5 ; 15
    {
        public int ElementsCount => 7;

        public string? GetElement(int elIndex) => elIndex switch
        {
            0 => ID.ToString(),
            1 => _size.ToString(),
            2 => Area.ToString(),
            3 => _foundedTime.ToString(),
            4 => _hasAirport.ToString(),
            5 => _cityName?.ToString(),
            6 => _flagColor.ToString(),
            _ => string.Empty
        };
        public string? GetElementName(int elIndex) => elIndex switch
        {
            0 => nameof(ID),
            1 => nameof(_size),
            2 => nameof(Area),
            3 => nameof(_foundedTime),
            4 => nameof(_hasAirport),
            5 => nameof(_cityName),
            6 => nameof(_flagColor),
            _ => string.Empty
        };
    }



    
}
