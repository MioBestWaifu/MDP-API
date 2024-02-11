namespace MDP.Utils
{
    public static class ListInserter
    {
        public static string InsertInts(string original, string parameter, List<int> list)
        {
            string firstHalf = original.Substring(0, original.IndexOf(parameter));
            string secondHalf = original.Substring(original.IndexOf(parameter) + parameter.Length);

            string firstHalfModified = string.Join(",", list);
            string modifiedString = firstHalf + firstHalfModified + secondHalf;

            return modifiedString;
        }
    }
}
