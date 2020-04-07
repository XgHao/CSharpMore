using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Models
{
    public class Node
    {
        object data;
        Node next;

        public Node(Object _data)
        {
            data = _data;
            next = null;
        }

        public Object Data { get; set; }

        public Node Next { get; set; }

        public void Append(Node newNode)
        {
            if (next == null)
            {
                next = newNode;
            }
            else
            {
                next.Append(newNode);
            }
        }

        public override string ToString()
        {
            string output = data.ToString();
            if (next != null) 
            {
                output += ", " + next.ToString();
            }
            return output;
        }
    }
}
