// See https://aka.ms/new-console-template for more information
using Words;

var sortByFrequency = new WordFinder(new string[] { "abug", "nupo", "tguo", "sopd" }).Find(new string[] {
    "bug",
    "up",
    "ants",
    "good",
    "upon"
});

int i = 1;
foreach (var item in sortByFrequency)
{
    Console.WriteLine("{0} {1}", i++, item);
}

var sortByFrequencyTuple = new WordFinder(new string[] { "abug", "nupo", "tguo", "sopd" }).FindTuple(new string[] {
    "bug",
    "up",
    "ants",
    "go",
    "good",
    "upon",
});

i = 1;
foreach (var item in sortByFrequencyTuple)
{
    Console.WriteLine("{0} {1} count: {2}", i++, item.Item1, item.Item2);
}
