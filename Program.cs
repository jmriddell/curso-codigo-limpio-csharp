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
            while (ShowMenuMain()) ;
        }

        /// <summary>
        /// Show the main menu
        /// </summary>
        /// <returns>Returns wether the user has not chose to exit</returns>
        public static bool ShowMenuMain()
        {
            PrintSeparator();
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine($"{(int)Menu.Add}. Nueva tarea");
            Console.WriteLine($"{(int)Menu.Remove}. Remover tarea");
            Console.WriteLine($"{(int)Menu.TaskList}. Tareas pendientes");
            Console.WriteLine($"{(int)Menu.Exit}. Salir");

            // Read line
            Menu selectedOption = (Menu)Convert.ToInt32(Console.ReadLine());

            switch (selectedOption)
            {
                case Menu.Add:
                    ShowMenuAdd();
                    break;
                case Menu.Remove:
                    ShowMenuRemove();
                    break;
                case Menu.TaskList:
                    ShowMenuTaskList();
                    break;
                case Menu.Exit:
                    // Exit
                    return false;
                default:
                    break;
            }
            return true;
        }

        public static void ShowMenuRemove()
        {
            Console.WriteLine("Ingrese el número de la tarea a remover: ");
            ShowTaskList();
            PrintSeparator();

            string line = Console.ReadLine();
            if (!int.TryParse(line, out int selectedInt)) return;
            int indexToRemove = selectedInt - 1;

            RemoveItem(indexToRemove);
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
                return;
            }
            PrintSeparator();
            ShowTaskList();
            PrintSeparator();
        }

        private static void ShowTaskList()
        {
            foreach (var (task, i) in taskList.WithIndex())
            {
                Console.WriteLine($"{i + 1}. {task}");
            }
        }

        private static void PrintSeparator() => Console.WriteLine("----------------------------------------");

        private static void RemoveItem(int index)
        {
            if (index < 0 || taskList.Count <= index)
            {
                return;
            }
            string task = taskList[index];
            taskList.RemoveAt(index);
            Console.WriteLine($"Tarea {task} eliminada");
        }
    }

    public enum Menu
    {
        Add = 1,
        Remove = 2,
        TaskList = 3,
        Exit = 4
    }

    public static class CustomExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source)
        {
            return source.Select((item, index) => (item, index));
        }
    }
}
