using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo
{
    internal class Program
    {
        public static List<string> taskList = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {
                int selectedOption = ShowMenuMain();
                switch (selectedOption)
                {
                    case 1:
                        ShowMenuAdd();
                        break;
                    case 2:
                        ShowMenuRemove();
                        break;
                    case 3:
                        ShowMenuTaskList();
                        break;
                    case 4:
                        // Exit
                        return;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Show the main menu
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMenuMain()
        {
            PrintSeparator();
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                ShowTaskList();
                PrintSeparator();

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                RemoveItem(indexToRemove);
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                taskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (taskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                PrintSeparator();
                ShowTaskList();
                PrintSeparator();
            }
        }

        private static void ShowTaskList()
        {
            foreach (var (task, i) in taskList.WithIndex())
            {
                Console.WriteLine($"{i + 1}. {task}");
            }
        }

        private static void PrintSeparator()
        {
            Console.WriteLine("----------------------------------------");
        }

        private static void RemoveItem(int index)
        {
            if (index <= -1 || taskList.Count <= 0)
            {
                return;
            }
            string task = taskList[index];
            taskList.RemoveAt(index);
            Console.WriteLine($"Tarea {task} eliminada");
        }
    }

    public static class CustomExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }
    }
}
