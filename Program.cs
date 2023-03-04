﻿List<string> taskList = new List<string>();


// Main code
while (MenuMain()) ;

// -------------------------- Functions --------------------------

// -------------------------- Menus --------------------------

/// <summary>
/// Show the main menu
/// </summary>
/// <returns>Returns wether the user has not chose to exit</returns>
bool MenuMain()
{
    PrintSeparator();
    PrintMainMenuOptions();

    Menu? selectedOption = (Menu?)ReadIntSafely();

    static bool RunAndTrue(Action func) { func(); return true; }
    return (selectedOption) switch
    {
        (Menu.Add) => RunAndTrue(MenuAdd),
        (Menu.Remove) => RunAndTrue(MenuRemove),
        (Menu.TaskList) => RunAndTrue(MenuTaskList),
        (Menu.Exit) => false,
        _ => true
    };
}

void MenuRemove()
{
    Console.WriteLine("Ingrese el número de la tarea a remover: ");
    ShowTaskList();
    PrintSeparator();

    int? selectedInt = ReadIntSafely();
    if (selectedInt == null) return;
    int indexToRemove = (int)selectedInt - 1;

    RemoveItemFromTaskList(indexToRemove);
}

void MenuAdd()
{
    Console.WriteLine("Ingrese el nombre de la tarea: ");
    string task = Console.ReadLine();
    taskList.Add(task);
    Console.WriteLine("Tarea registrada");
}

void MenuTaskList()
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

// -------------------------- Helpers --------------------------

IEnumerable<(T item, int index)> WithIndex<T>(IEnumerable<T> source)
{
    return source.Select((item, index) => (item, index));
}

void RemoveItemFromTaskList(int index)
{
    if (index < 0 || taskList.Count <= index)
    {
        return;
    }
    string task = taskList[index];
    taskList.RemoveAt(index);
    Console.WriteLine($"Tarea {task} eliminada");
}

int? ReadIntSafely()
{
    return int.TryParse(Console.ReadLine(), out int selectedInt) ? selectedInt : null;
}

void ShowTaskList()
{
    foreach (var (task, i) in WithIndex(taskList))
    {
        Console.WriteLine($"{i + 1}. {task}");
    }
}

void PrintMainMenuOptions()
{
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine($"{(int)Menu.Add}. Nueva tarea");
    Console.WriteLine($"{(int)Menu.Remove}. Remover tarea");
    Console.WriteLine($"{(int)Menu.TaskList}. Tareas pendientes");
    Console.WriteLine($"{(int)Menu.Exit}. Salir");
}

void PrintSeparator() => Console.WriteLine("----------------------------------------");

// -------------------------- Enums --------------------------

enum Menu
{
    Add = 1,
    Remove = 2,
    TaskList = 3,
    Exit = 4
}
