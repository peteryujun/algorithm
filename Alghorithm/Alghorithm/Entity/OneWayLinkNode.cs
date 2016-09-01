using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alghorithm.Entity
{
    public class OneWayLinkNode
    {
        public int Value;
        public OneWayLinkNode Next;

        public override string ToString()
        {
            OneWayLinkNode tmp = this;
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
