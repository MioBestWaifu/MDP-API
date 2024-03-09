namespace MDP.Utils
{
    /// <summary>
    /// Essa classe existe porque o connector MySQL não consegue adicionar corretamente listas nos parametros.
    /// </summary>
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
