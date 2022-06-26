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

        public string FrequencySort(string s)
        {
            var dic = new Dictionary<char, int>();
            foreach (var c in s)
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);

            var result = "";
            foreach (var item in dic.OrderByDescending(kv => kv.Value))

                result += new String(item.Key, item.Value);

            return result;
        }

        public int FindPeakElement(int[] nums)
        {
            return Array.IndexOf(nums, nums.Max());
        }
    }


    public class LRUCache
    {
        private readonly int capacity;
        private readonly IDictionary<int, DoubleLinkNode> hashMap;
        private readonly DoubleLinkNode dummyHead;
        private readonly DoubleLinkNode dummyTail;
        private int size;

        public LRUCache(int capacity)
        {
            this.size = 0;
            this.capacity = capacity;
            this.hashMap = new Dictionary<int, DoubleLinkNode>();
            this.dummyHead = new DoubleLinkNode();
            this.dummyTail = new DoubleLinkNode();

            dummyHead.Next = dummyTail;
            dummyTail.Prev = dummyHead;
        }

        public int Get(int key)
        {
            if (!hashMap.ContainsKey(key)) return -1;

            var node = hashMap[key];
            MoveNodeToHead(node);
            return node.Value;
        }

        public void Put(int key, int value)
        {
            if (hashMap.ContainsKey(key))
            {
                var node = hashMap[key];
                node.Value = value;
                MoveNodeToHead(node);
                return;
            }

            var newNode = new DoubleLinkNode()
            {
                Key = key,
                Value = value
            };
            hashMap.Add(key, newNode);
            AddNodeToHead(newNode);
            size++;

            if (size > capacity)
            {
                var node = RemoveLatestNode();
                hashMap.Remove(node.Key);
                size--;
            }
        }


        private void MoveNodeToHead(DoubleLinkNode node)
        {
            RemoveNode(node);
            AddNodeToHead(node);
        }

        private void RemoveNode(DoubleLinkNode node)
        {
            var previous = node.Prev;
            var next = node.Next;

            previous.Next = next;
            next.Prev = previous;
        }

        private void AddNodeToHead(DoubleLinkNode node)
        {
            var next = dummyHead.Next;

            node.Next = next;
            next.Prev = node;

            dummyHead.Next = node;
            node.Prev = dummyHead;
        }

        private DoubleLinkNode RemoveLatestNode()
        {
            var last = dummyTail.Prev;
            RemoveNode(last);
            return last;
        }


        public class DoubleLinkNode
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public DoubleLinkNode Prev { get; set; }
            public DoubleLinkNode Next { get; set; }
        }
    }
}
