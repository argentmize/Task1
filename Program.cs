using System.Text;

var input = "aaabbcccdde";
var compressed = Compress(input);
var decompressed = Decompress(compressed);

Console.WriteLine($"Сжатая строка:\t{compressed}");
Console.WriteLine($"Восстановленная строка:\t{decompressed}");
Console.WriteLine($"Исходная строка:\t{input}");

string Compress(string input)
{
    if (string.IsNullOrEmpty(input)) return input;
    StringBuilder result = new();
    var count = 1;
    var length = input.Length;
    for (var i = 0; i < length; i++)
    {
        var current = input[i];
        if (i + 1 < length && current == input[i + 1]) count++;
        else
        {
            result.Append(current);
            if (count > 1) result.Append(count);
            count = 1;
        }
    }
    return result.ToString();
}

string Decompress(string input)
{
    if (string.IsNullOrEmpty(input)) return input;
    StringBuilder result = new();
    var length = input.Length;
    for (var i = 0; i < length; i++)
    {
        var current = input[i];
        result.Append(current);
        if (i + 1 < length && char.IsDigit(input[i + 1]))
        {
            var count = int.Parse(input[i + 1].ToString());
            for (int j = 1; j < count; j++)
                result.Append(current);
            i++;
        }
    }
    return result.ToString();
}