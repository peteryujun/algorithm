using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghorithm
{
    public class TreeNode
    {
        public int Value;
        public TreeNode LeftChild;
        public TreeNode RightChild;
    }

    public class LinkNode
    {
        public int Value;
        public LinkNode Previous;
        public LinkNode Next;

        public override string ToString()
        {
            LinkNode tmp = this;
            string s = tmp.Value.ToString();

            while (tmp.Next != null)
            {
                s += "->" + tmp.Next.Value;
                tmp = tmp.Next;
            }

            return s;
        }
    }
}
