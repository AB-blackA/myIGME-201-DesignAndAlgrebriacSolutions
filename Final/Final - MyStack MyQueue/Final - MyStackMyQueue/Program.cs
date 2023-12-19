using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Author: Andrew Black since 12/18/23
 * Purpose: program to hold class objects for "imposter" Stack's and Queues for IGME201 Final Exam
 * Limitations: none
 */
namespace Final___MyStackMyQueue
{

    internal class Program
    {

        /*Method: Main
         *Purpose: do various testing on class objects; all code is leftover from testing and none are important
         */
        static void Main(string[] args)
        {

            MyStack stack = new MyStack();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(stack.Peek());
                Console.Write(stack.Pop());
            }

        }
    }

    /*Class: MyStack
     *Purpose: Imitate a Stack object (for integers) by fiddling with a List<int> object. Retains LIFO
     */
    public class MyStack
    {
        private List<int> list;

        /* Constructor: MyStack
         * Default argument creates a list.
         */
        public MyStack()
        {

            list = new List<int>();

        }

        /* Method: Push
         * Purpose: Imitation of Push. Adds int to end of List
         */
        public void Push(int i)
        {
            this.list.Add(i);

        }

        /* Method: Pop
         * Purpose: Imitation of Pop. Remove and return the last int added to List
         */
        public int Pop()
        {
            int popVal = this.list[this.list.Count - 1];
            this.list.RemoveAt(this.list.Count - 1);
            return popVal;
        }

        /* Method: Peek
         * Purpose: Imitation of Peek. Return the last int added to List, but don't remove it
         */
        public int Peek()
        {
            return this.list[this.list.Count - 1];
        }

    }

    /* Class: MyQueue
     * Purpose: Imitation of a Queue object (for integers) by fiddling with a List<Int> object. Retains FIFO
     */
    public class MyQueue
    {
        private List<int> list;

        /* Constructor: MyQueue
         * Default argument creates a list
         */
        public MyQueue()
        {
            this.list = new List<int>();
        }

        /* Method: Enqueue
         * Purpose: Imitation of Enqueue. Adds an integer to the very beginning of the Queue
         */
        public void Enqueue(int i)
        {
            // add int to start by making a new list, adding passed int to it, then copying over old list
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

        /* Method: Dequeue
         * Purpose: Imitation of Dequeue. Removes the first added int
         */
        public int Dequeue()
        {
            int deqVal = this.list[0];
            this.list.RemoveAt(0);
            return deqVal;
        }

        /* Method: Peek
         * Purpose: Imitation of Peek. Return the first int added to List, but don't remove it
         */
        public int Peek()
        {
            return this.list[0];
        }

    }
}