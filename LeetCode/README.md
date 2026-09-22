# LeetCode Submissions

## LeetCode Account

Profile URL: `<add-your-leetcode-profile-url>`

## Valid Anagram

- Problem: [Valid Anagram](https://leetcode.com/problems/valid-anagram/)
- Solution: [ValidAnagram.cs](ValidAnagram.cs)
- Accepted screenshot: [valid-anagram-accepted.png](images/valid-anagram-accepted.png)

Add your accepted-submission screenshot to `LeetCode/images/valid-anagram-accepted.png`.

### How the solution works

If the two strings have different lengths, they cannot be anagrams. Otherwise, an array of 26 integers counts lowercase English letters. Each character from `s` increases its count, while the character at the same position in `t` decreases its count. If every final count is zero, both strings contain exactly the same character frequencies.

- Time complexity: `O(n)`
- Space complexity: `O(1)` because the frequency array always contains 26 integers

## Greatest Common Divisor of Strings

- Problem: [Greatest Common Divisor of Strings](https://leetcode.com/problems/greatest-common-divisor-of-strings/)
- Solution: [GreatestCommonDivisorOfStrings.cs](GreatestCommonDivisorOfStrings.cs)
- Accepted screenshot: [gcd-of-strings-accepted.png](images/gcd-of-strings-accepted.png)

Add your accepted-submission screenshot to `LeetCode/images/gcd-of-strings-accepted.png`.

### How the solution works

One string divides another when repeating it creates the other string. If `str1 + str2` is different from `str2 + str1`, the strings do not share one repeating base pattern, so the answer is empty. Otherwise, Euclid's algorithm finds the greatest common divisor of their lengths, and the prefix of that length is the greatest common divisor string.

- Time complexity: `O(n + m)` for the concatenation comparison
- Space complexity: `O(n + m)` in C# because the concatenated strings are created for the compatibility check
