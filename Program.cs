namespace AddTwoNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Solution.AddTwoNumbers(new ListNode(9), new ListNode(1, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))))))))))));
            Console.ReadKey();
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static class Solution
    {
        private static List<int> L1 = new();

        private static List<int> L2 = new();
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            GetL1Node(l1);

            GetL2Node(l2);

            L1.Reverse();
            L2.Reverse();

            string s1 = string.Empty;

            string s2 = string.Empty;

            foreach (var item in L1)
            {
                s1 = $"{s1}{item}";
            }

            foreach (var item in L2)
            {
                s2 = $"{s2}{item}";
            }

            long numS1 = (long)Convert.ToUInt64(s1);

            long numS2 = (long)Convert.ToUInt64(s2);

            long sum = numS1 + numS2;

            List<short> chars = sum.ToString().Select(item => Convert.ToInt16(item.ToString())).ToList();

            chars.Reverse();

            ListNode listNode = new((int)Convert.ToUInt64(chars[0]));

            for (int i = 1; i < chars.Count; i++)
            {
                push_back(chars[i], listNode);
                
            }

            return listNode;
        }


        public static void push_back(int newElement, ListNode head)
        {
            ListNode newNode = new();
            newNode.val = newElement;
            ListNode temp;
            temp = head;
            while (temp.next != null)
                temp = temp.next;
            temp.next = newNode;
        }

        private static void GetL1Node(ListNode l1)
        {
            L1.Add(l1.val);
            if (l1.next != null)
            {
                GetL1Node(l1.next);
            }
        }

        private static void GetL2Node(ListNode l2)
        {
            L2.Add(l2.val);
            if (l2.next != null)
            {
                GetL2Node(l2.next);
            }
        }
    }
}