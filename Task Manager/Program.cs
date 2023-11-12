using System.Diagnostics;
using System.Timers;

namespace TaskManager
{
    public class Program
    {
        public static Process[] processCollection = Process.GetProcesses();
        static void Main()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(GetProcesses);
            timer.Interval = 100;
            timer.Enabled = true;


            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("Task Manager\n\n\n");
            Console.WriteLine("1. Show all Tasks");
            Console.WriteLine("2. Close a Task");
            var answer = Console.ReadLine();
            if (answer == "1")
            {
                ShowTasks();
            }
            if (answer == "2")
            {
                KillProcess();
            }
            Main();
        }

        private static void GetProcesses(object source, ElapsedEventArgs e)
        {
           processCollection = Process.GetProcesses();
        }
        static void ShowTasks()
        {
            foreach (Process p in processCollection)
            {
                Console.WriteLine($"{p.ProcessName}.exe    {p.Id}");
            }
            Console.ReadLine(); Main();
        }

        static void KillProcess()
        {
            Console.Clear();
            Console.WriteLine("1. Kill Process by PID");
            Console.WriteLine("2. Kill Process by name");
            var answer = Console.ReadLine();
            if (answer == "1")
            {
                Console.Clear(); Console.WriteLine("State Pid:\n\n");
                if (int.TryParse(Console.ReadLine(), out var pid)) KillProcessbyPid(pid);
            }
            if (answer == "2")
            {
                Console.Clear(); Console.WriteLine("State Name:\n\n");
                var name = Console.ReadLine();
                if (name != null) KillProcessbyName(name);
            }
            Main();
        }

        static void KillProcessbyPid(int pid)
        {
            try
            {
                foreach (Process p in processCollection)
                {
                    if (p.Id == pid)
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success"); Thread.Sleep(2000);
            Console.Clear(); Main();
        }

        static void KillProcessbyName(string name)
        {
            try
            {
                foreach (Process p in processCollection)
                {
                    if (p.ProcessName == name)
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success"); Thread.Sleep(2000);
            Console.Clear(); Main();
        }
    }
}
