using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseLib
{
    public class Courses
    {
        SortedList<string, Course> sortedList = new SortedList<string, Course>();

        public void Remove(string courseCode)
        {
            try
            {
                sortedList.Remove(courseCode);
            }catch (Exception ex)
            {
                Console.WriteLine("{0} does not exist within object.", courseCode);
            }
        }

        public Course this[string courseCode]
        {
            get
            {
                Course returnVal;
                try
                {
                    returnVal = (Course)sortedList[courseCode];
                }
                catch
                {
                    returnVal = null;
                }

                return (returnVal);
            }

            set
            {
                try
                {
                    // we can add to the list using these 2 methods
                    //      sortedList.Add(email, value);
                    sortedList[courseCode] = value;
                }
                catch
                {
                    // an exception will be raised if an entry with a duplicate key is added
                    // duplicate key handling (currently ignoring any exceptions)
                }
            }
        }
    }

    public class Course { }

}
