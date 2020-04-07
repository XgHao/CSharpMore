using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Yield
{
    class Program
    {
        static void Main(string[] args)
        {
        }



        public class HelloCollection : IEnumerable
        {
            public IEnumerator GetEnumerator()
            {
                throw new NotImplementedException();
            }

            public class Enumerator : IEnumerator, IDisposable
            {
                private int state;
                public object current;

                public object Current { get { return current; } }

                public Enumerator(int _state)
                {
                    state = _state;
                }

                public bool MoveNext()
                {
                    switch (state)
                    {
                        case 0:
                            current = "Hello";
                            state = 1;
                            return true;
                        case 1:
                            current = "World";
                            state = 2;
                            return true;
                        default:
                            break;
                    }
                    return false;
                }

                public void Reset()
                {
                    throw new NotSupportedException();
                }

                public void Dispose()
                {
                }

            }
        }
    }
}
