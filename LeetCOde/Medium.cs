namespace LeetCOde
{
    public class Medium
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];
            int left = 0, right = numbers.Length - 1;
            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                {
                    result[0] = left + 1;
                    result[1] = right + 1;
                    break;
                }
                else if (sum > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            return result;
        }

        public void Rotate(int[] nums, int k)
        {
            int length = nums.Length;
            if (k % length == 0 || k == 0 || length <= 1) return;
            if (k > length) k = k % length;
            int[] nums2 = new int[length];
            for (int i = 0; i < length - k; i++) nums2[i + k] = nums[i]; ;
            for (int i = length - k; i < length; i++) nums2[i - length + k] = nums[i];

            nums2.CopyTo(nums, 0);
        }
    }
}
