using System.Text;

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

        public bool HasCycle(ListNode head)
        {
            if (head == null) return false;
            ListNode fast = head;
            ListNode slow = head;
            do
            {
                if (fast.next == null || fast.next.next == null) return false;
                slow = slow.next;
                fast = fast.next.next;
            } while (slow != fast);
            return true;
        }

        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            if (headA == null || headB == null) return null;

            while (headA != null)
            {
                var b = headB;

                while (b != null)
                {
                    if (headA == b) return b;

                    b = b.next;
                }
                headA = headA.next;
            }


            return null;
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {

            if (list1 == null && list2 == null) return null;

            var stack = new Stack<int>();
            while (list1 != null || list2 != null)
            {
                if (list1 != null && list2 != null)
                    if (list1.val <= list2.val)
                    {
                        stack.Push(list1.val);
                        list1 = list1.next;
                        continue;
                    }
                    else
                    {
                        stack.Push(list2.val);
                        list2 = list2.next;
                        continue;
                    }
                else
                {
                    if (list2 == null)
                    {
                        stack.Push(list1.val);
                        list1 = list1.next;
                        continue;
                    }
                    if (list1 == null)
                    {
                        stack.Push(list2.val);
                        list2 = list2.next;
                        continue;
                    }
                }
            }

            ListNode merged = null;
            foreach (var item in stack)
                merged = new ListNode(item, merged);


            return merged;
        }

        public ListNode MiddleNode(ListNode head)
        {
            if (head == null) return head;

            var stack = new Stack<int>();

            var count = 0;

            while (head != null)
            {
                stack.Push(head.val);
                head = head.next;
                count++;
            }

            if (count % 2 != 0) count = (count / 2) + 1;
            else count /= 2;

            ListNode result = null;
            foreach (var item in stack)
            {
                if (count == 0) return result;

                result = new ListNode(item, result);
                count--;
            }

            return result;
        }

        public ListNode RemoveElements(ListNode head, int val)
        {

            if (head == null) return null;

            var stack = new Stack<int>();

            while (head != null)
            {
                if (head.val != val) stack.Push(head.val);
                head = head.next;
            }

            ListNode result = null;
            foreach (var item in stack)
                result = new ListNode(item, result);

            return result;

        }


        public void MoveZeroes(int[] nums)
        {
            if (nums.Length > 1)
            {
                int zeroIndex = 0;
                int noZeroIndex = 1;

                while (noZeroIndex < nums.Length)
                {
                    if (nums[zeroIndex] == 0)
                        if (nums[noZeroIndex] != 0)
                        {
                            var temp = nums[zeroIndex];
                            nums[zeroIndex] = nums[noZeroIndex];
                            nums[noZeroIndex] = temp;

                            zeroIndex++;
                            noZeroIndex++;
                        }
                        else
                            noZeroIndex++;
                    else
                    {
                        zeroIndex++;
                        noZeroIndex++;
                    }


                }
            }
        }

        public string RemoveOuterParentheses(string s)
        {
            if (s.Length < 2) return "";

            var count = 0;
            var result = "";

            foreach (var c in s)
            {
                if (c == '(' && count == 0) { count++; continue; }
                if (c == '(' && count > 0) { result += c.ToString(); count++; continue; }

                if (c == ')' && count == 1) { count--; continue; }
                if (c == ')' && count > 1) { result += c.ToString(); count--; continue; }
            }

            return result;
        }

        public bool BackspaceCompare(string s, string t)
        {
            return ApplyBackSpace(s) == ApplyBackSpace(t);
        }

        private string ApplyBackSpace(string s)
        {
            var result = "";
            foreach (var c in s)
                if (c == '#')
                {
                    if (result.Length > 0)
                        result = result.Remove(result.Length - 1);

                }
                else
                    result += c.ToString();
            return result;
        }


        public string RemoveDuplicates(string s)
        {
            var sb = new StringBuilder();

            foreach (var ch in s)
            {
                if (sb.Length > 0 && sb[sb.Length - 1] == ch)
                    sb.Remove(sb.Length - 1, 1);
                else
                    sb.Append(ch);
            }

            return sb.ToString();

        }


    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
