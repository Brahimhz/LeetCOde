namespace LeetCOde
{
    public class Easy
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < (nums.Length - 1); i++)
                for (int j = i + 1; j < nums.Length; j++)
                    if ((nums[i] + nums[j]) == target)
                        return new int[] { i, j };
            return new int[] { -1, -1 };
        }

        internal int RomanToInt(string s)
        {
            var d = new Dictionary<char, int>();
            d.Add('I', 1);
            d.Add('V', 5);
            d.Add('X', 10);
            d.Add('L', 50);
            d.Add('C', 100);
            d.Add('D', 500);
            d.Add('M', 1000);

            var list = new List<int>();
            foreach (var c in s)
            {
                list.Add(d[c]);

                if (list.Count > 1)
                    if (list[list.Count - 2] < d[c])
                        list[list.Count - 2] *= -1;
            }


            return list.Sum();
        }

        public string LongestCommonPrefix(string[] strs)
        {
            string result = "";
            int count = 0;

            foreach (var c in strs[0])
            {
                try
                {
                    foreach (var s in strs)
                        if (c != s[count]) return result;

                    result += c;
                    count++;
                }
                catch { return result; }

            }


            return result;

        }

        public bool IsPalindrome(int x)
        {
            return String.Join("", x.ToString().Reverse().Select(c => c.ToString())) == x.ToString();
        }

        public bool IsValid(string s)
        {
            Dictionary<char, char> _pairs = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
            };
            if (s.Count() == 0) { return true; }

            Stack<char> brackets = new Stack<char>();

            foreach (char i in s)
            {
                if (_pairs.ContainsKey(i))
                {
                    brackets.Push(i);
                }
                else if (_pairs.Values.Contains(i))
                {
                    if (brackets.Count == 0) return false;

                    var openingBracket = brackets.Pop();
                    if (_pairs[openingBracket] != i)
                    {
                        return false;
                    }
                }
            }
            return brackets.Count == 0;
        }
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;
            var index = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[index - 1])
                {
                    nums[index] = nums[i];
                    index++;
                }
            }
            return index;
        }

        public int RemoveElement(int[] nums, int val)
        {
            var numsLength = nums.Length;
            if (numsLength == 0 || nums == null) return 0;
            var index = 0;
            for (var i = 0; i < numsLength; i++)
            {
                if (nums[i] != val)
                {
                    nums[index] = nums[i];
                    index++;
                }
            }
            return index;
        }

    }
}
