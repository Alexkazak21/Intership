namespace Task12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var t = TextRotate("abcde","cdeab");
            var t1 = TextRotate("abcde", "abced");
            var t2 = TextRotate("abc", "cab");
            var t3 = TextRotate("aaa", "aaa");
            var t4 = TextRotate("abca", "bcab");
            var t5 = TextRotate("abcd", "cdab");
            var t6 = TextRotate("abc", "acb");
        }

        public static bool TextRotate(string firstStr, string secondStr)
        {
            string endpartOfFirst = firstStr.Substring(firstStr.IndexOf(secondStr[0]));
            var startpartOfFirst = firstStr.Replace(endpartOfFirst, "");
            return secondStr.Equals(endpartOfFirst+startpartOfFirst);
        }
    }
}
