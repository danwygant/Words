namespace Words;

using System;
using System.Collections.Generic;
using System.Linq;

public interface IWordFinder
{
    IEnumerable<string> Find(IEnumerable<string> wordstream);
}

public class WordFinder : IWordFinder
{
    private readonly IEnumerable<string> _matrix;
    private readonly int _rows;
    private readonly int _cols;

    public WordFinder(IEnumerable<string> matrix)
    {
        // Store the matrix and its dimensions
        _matrix = matrix;
        _rows = matrix.Count();
        _cols = matrix.First().Length;

        // safety check <= 64x64
        if (_rows > 64
         || _cols > 64)
            throw new ArgumentException($"Rows {_rows} or Columns {_cols} are more than 64");
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        var wordFrequency = new Dictionary<string, int>();

        foreach (var word in wordstream.Distinct())
        {
            int count = SearchWordInMatrix(word);
            if (count > 0)
            {
                // GetValueOrDefault retrieves the value with just one dictionary access/more readable
                // 2 accesses for: wordFrequency[word]=wordFrequency.Keys.Contains(word)?wordFrequency[word]++:1;
                wordFrequency[word] = wordFrequency.GetValueOrDefault(word, 0) + 1;
            }
        }

        // Sort by frequency and return top 10 most repeated words
        return wordFrequency.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key);
    }

    private int SearchWordInMatrix(string word)
    {
        // Check horizontally: use linq to sum count for all rows occurences of the word, most efficiently
        int count = _matrix.Sum(row => CountOccurrences(row, word));

        // Check vertically
        for (int col = 0; col < _cols; col++)
        {
            // use linq to select the 1-char for col and join into a string most efficiently
            string column = string.Join(string.Empty, _matrix.Select(row => row[col]));
            count += CountOccurrences(column, word);
        }

        return count;
    }

    private int CountOccurrences(string source, string word)
    {
        int count = 0;
        int index = 0;

        // go through the whole string looking for word start not -1 and add to count
        while ((index = source.IndexOf(word, index)) != -1)
        {
            count++;
            index += word.Length;
        }

        return count;
    }
}
