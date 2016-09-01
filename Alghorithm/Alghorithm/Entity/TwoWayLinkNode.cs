using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghorithm.Entity
{
    public class TwoWayLinkNode
    {
        public int Value;
        public TwoWayLinkNode Previous;
        public TwoWayLinkNode Next;

        public override string ToString()
        {
            TwoWayLinkNode tmp = this;
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
