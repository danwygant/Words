namespace Words;

public interface IWordFinder
{
    IEnumerable<string> Find(IEnumerable<string> wordstream);
    IEnumerable<Tuple<string,int>> FindTuple(IEnumerable<string> wordstream);
}