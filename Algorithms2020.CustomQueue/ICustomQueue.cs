using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2020.CustomQueue
{
    public interface ICustomQueue
    {
        void Enqueue(int num);
        void Dequeue();
        bool IsEmpty();
        bool IsFull();
        void Peek();
    }
}
