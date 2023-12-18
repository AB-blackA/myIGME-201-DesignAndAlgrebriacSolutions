using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final___Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            MyStack stack = new MyStack();

            for(int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            for(int i = 0;i < 10; i++)
            {
                Console.WriteLine(stack.Peek());
                Console.Write(stack.Pop());
            }

        }
    }

    public class MyStack
    {
        private List<int> list;

        public MyStack()
        {

            list = new List<int>();

        }

        public void Push(int i)
        {
            this.list.Add(i);

            
        }

        public int Pop()
        {
            int popVal = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);
            return popVal;
        }

        public int Peek()
        {
            return this.list[this.list.Count - 1];
        }

    }

    public class MyQueue
    {
        private List<int> list;

        public MyQueue()
        {
            this.list = new List<int>();
        }


        public void Enqueue(int i)
        {
            List<int> copy = new List<int>();
            copy.Add(i);

            if (list.Count > 0)
            {
                foreach (int item in this.list)
                {
                    copy.Add(item);

                }
            }

            this.list.Clear();

            foreach (int item in copy)
            {
                this.list.Add(item);
            }

        }

        public int Dequeue()
        {
            int deqVal = this.list[0];
            this.list.RemoveAt(0);
            return deqVal;
        }

        public int Peek()
        {
            return this.list[0];
        }

    }
}
