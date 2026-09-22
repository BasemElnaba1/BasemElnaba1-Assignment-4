// LeetCode 242: Valid Anagram
// Submit this file separately on LeetCode.
public class Solution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        int[] frequencies = new int[26];

        for (int index = 0; index < s.Length; index++)
        {
            frequencies[s[index] - 'a']++;
            frequencies[t[index] - 'a']--;
        }

        foreach (int frequency in frequencies)
        {
            if (frequency != 0)
            {
                return false;
            }
        }

        return true;
    }
}
