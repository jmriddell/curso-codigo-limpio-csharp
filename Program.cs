﻿using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> taskList { get; set; }

        static void Main(string[] args)
        {
            taskList = new List<string>();
            int selectedOption = 0;
            do
            {
                selectedOption = ShowMenuMain();
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
                    default:
                        break;
                }
            } while (selectedOption != 4);
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
                // Show current taks
                for (int i = 0; i < taskList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + taskList[i]);
                }
                PrintSeparator();

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1)
                {
                    if (taskList.Count > 0)
                    {
                        string task = taskList[indexToRemove];
                        taskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");
                    }
                }
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
            if (taskList == null || taskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                PrintSeparator();
                for (int i = 0; i < taskList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + taskList[i]);
                }
                PrintSeparator();
            }
        }

        private static void PrintSeparator()
        {
            Console.WriteLine("----------------------------------------");
        }
    }
}
