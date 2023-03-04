List<string> taskList = new List<string>();


// Main code
while (ShowMenuMain()) ;

// -------------------------- Functions --------------------------

IEnumerable<(T item, int index)> WithIndex<T>(IEnumerable<T> source)
{
    return source.Select((item, index) => (item, index));
}

/// <summary>
/// Show the main menu
/// </summary>
/// <returns>Returns wether the user has not chose to exit</returns>
bool ShowMenuMain()
{
    PrintSeparator();
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine($"{(int)Menu.Add}. Nueva tarea");
    Console.WriteLine($"{(int)Menu.Remove}. Remover tarea");
    Console.WriteLine($"{(int)Menu.TaskList}. Tareas pendientes");
    Console.WriteLine($"{(int)Menu.Exit}. Salir");

    Menu selectedOption = (Menu)Convert.ToInt32(Console.ReadLine());

    static bool RunAndTrue(Action func) { func(); return true; }
    return (selectedOption) switch
    {
        (Menu.Add) => RunAndTrue(ShowMenuAdd),
        (Menu.Remove) => RunAndTrue(ShowMenuRemove),
        (Menu.TaskList) => RunAndTrue(ShowMenuTaskList),
        (Menu.Exit) => false,
        _ => true
    };
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

void ShowMenuRemove()
{
    Console.WriteLine("Ingrese el número de la tarea a remover: ");
    ShowTaskList();
    PrintSeparator();

    int? selectedInt = ReadIntSafely();
    if (selectedInt == null) return;
    int indexToRemove = (int)selectedInt - 1;

    RemoveItemFromTaskList(indexToRemove);
}

void ShowMenuAdd()
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

void ShowMenuTaskList()
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

void PrintSeparator() => Console.WriteLine("----------------------------------------");

enum Menu
{
    Add = 1,
    Remove = 2,
    TaskList = 3,
    Exit = 4
}
