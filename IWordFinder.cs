namespace Words;

public interface IWordFinder
{
    IEnumerable<string> Find(IEnumerable<string> wordstream);
}