// LeetCode 1071: Greatest Common Divisor of Strings
// Submit this file separately on LeetCode.
public class Solution
{
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1)
        {
            return string.Empty;
        }

        int length = GreatestCommonDivisor(str1.Length, str2.Length);
        return str1.Substring(0, length);
    }

    private static int GreatestCommonDivisor(int first, int second)
    {
        while (second != 0)
        {
            int remainder = first % second;
            first = second;
            second = remainder;
        }

        return first;
    }
}
