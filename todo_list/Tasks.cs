using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace todo_list
{
    public  class Tasks
    {
        private static int counter = 0;
        public int ID { get; private set; }
        public DateTime date { get; private set; }
        public int priority { get; private set; }
        public string name;
        public bool is_completed;
        public DateTime deadline { get;set; }
        public Tasks()
        {
            ID = ++counter;
            date = new DateTime();
            priority = 0;
            name = " ";
            is_completed = false;
            deadline = new DateTime();
        }
        public Tasks( int priorityTask, string nameTask, DateTime dateTime)
        {
            ID = ++counter;
            date =DateTime.Now;
            priority =priorityTask ;
            name =nameTask;
            is_completed = false;
            deadline = dateTime;
        }
        public Tasks(int id, string newname, int pr, DateTime dateTime, DateTime newdateTime)
        {
            ID = id;
            date = dateTime;
            priority = pr;
            name = newname;
            deadline = newdateTime;
        }
        public override string ToString()
        {
            return $"{1+"|",10}{name+"|",30}{priority+"|",10}{date+"|",30}{deadline+"|",30}";
        }
        //public static bool operator == (Tasks t1)
        //{
        //    return (t1.date == t1.deadline) ? true : false;
        //}
        //public static bool operator != (Tasks t1)
        //{
        //    return (t1.date != t1.deadline) ? true : false;

        //}
    }
}
