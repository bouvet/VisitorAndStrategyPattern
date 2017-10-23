using System.Text;

namespace Company
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder RemoveLastComma(this StringBuilder sb)
        {
            if (sb.Length < 1) return sb;
            sb.Remove(sb.ToString().LastIndexOf(","), 1);
            return sb;
        }
    }
}