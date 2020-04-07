using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Models
{
    public class LinkedList
    {
        Node headNode = null;

        public void Add(object data)
        {
            if (headNode == null) 
            {
                headNode = new Node(data);
            }
            else
            {
                headNode.Append(new Node(data));
            }
        }

        public object this[int index]
        {
            get
            {
                int ctr = 0;
                Node node = headNode;

                while (node != null && ctr <= index) 
                {
                    if (ctr == index) 
                    {
                        return node.Data;
                    }
                    else
                    {
                        node = node.Next;
                    }
                    ctr++;
                }

                return null;
            }
        }

        public override string ToString()
        {
            if (headNode != null) 
            {
                return headNode.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
