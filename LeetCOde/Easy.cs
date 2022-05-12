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
    }
}
