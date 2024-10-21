// See https://aka.ms/new-console-template for more information
using Words;

var sortByFrequency = new WordFinder(new string[] { "abug","nupo","tguo","sopd" }).Find(new string[] {
    "bug",
    "up",
    "ants",
    "good",
    "upon"
});

foreach (var item in sortByFrequency)
{
    Console.WriteLine(item);
}
