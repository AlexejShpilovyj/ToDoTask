using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;
using static System.Console;
using System.IO;
namespace todo_list
{
    enum MenuItem { AddTask = 1, CompleteTask = 2 ,ShowTask = 3, Exit = 4 }
    class TodoList
    {
        List<Tasks> tasks = new List<Tasks>();
        public void Menu()
        {
            MenuItem chooseMenuItem;
            while (true)
            {
                WriteLine("Please, choose:");
                foreach (MenuItem item in Enum.GetValues(typeof(MenuItem)))
                {
                    WriteLine($"{(int)item,5}{item}");
                }
                chooseMenuItem = (MenuItem)Enum.Parse(typeof(MenuItem), ReadLine());
                switch (chooseMenuItem)
                {
                    case MenuItem.AddTask:
                        CreateTask();
                        break;
                    case MenuItem.CompleteTask:
                        CompleteTask();
                        break;
                    case MenuItem.ShowTask:
                        ShowTask();
                        break;
                    case MenuItem.Exit:
                        Exit();
                        break;
                    default:
                        break;
                }

            }
        }
        public void ShowTask()
        {
            WriteLine($"{"ID|",10}{"Task|",30}{"Priotity|",10}{"Date|",30}{"Deadline|",30}");
            foreach (Tasks item in tasks)
            {
                WriteLine(item.ToString());

            }
        }
        public void Reminding()
        {
            foreach (Tasks item in tasks)
            {
                if(item.deadline.Date==DateTime.Now.Date)
                {
                    WriteLine("You need:{0} ", item.name);
                }

            }

        }
    public void AddTask(Tasks task)
        {
            tasks.Add(task);
        }
      
        public void Exit()
        {
            FileStream file3 = new FileStream("Task.txt", FileMode.Truncate);
            file3.Close();
            foreach (Tasks task in tasks)
            {
                File.AppendAllText("Task.txt", task.ToString() + "\n");
            }
        }
       
        public void ReadTask()
        {
            StreamReader streamReader=new StreamReader("Task.txt");
            while (streamReader.Peek()!=-1)
            {
                string s = streamReader.ReadLine();
                string[] words = s.Split('|');
                AddTask(new Tasks(int.Parse(words[0]), words[1], int.Parse(words[2]), Convert.ToDateTime(words[3]), Convert.ToDateTime(words[4])));
            }
            streamReader.Close();
        }
        public void CreateTask()
        {
            string name;
            Write($"task:\t");
            name = ReadLine();
            int priority;
            Write($"priority:\t");
            priority =int.Parse(ReadLine());
            WriteLine($"Enter deadline");
            DateTime newdate;
            newdate = Convert.ToDateTime(ReadLine());
            AddTask(new Tasks(priority,name,newdate));
            //WriteTask(new Tasks(priority, name, newdate));
        }
        public void DeleteTask(Tasks task)
        {
            tasks.Remove(task);

        }
        public void CompleteTask()
        {
            int n = 0;
            WriteLine($"Enter tasks ID");
            n = int.Parse(ReadLine());
            DeleteTask(tasks[n-1]);
        }

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            TodoList todoList = new TodoList();
            todoList.ReadTask();
            todoList.Reminding();
            todoList.Menu();
            
        }

    }
}
