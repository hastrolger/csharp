List<string> TaskLists = new List<string>();

TaskLists = new List<string>();
int seletedMenu = 0;
do
{
    seletedMenu = ShowMainMenu();
    if ((Menu)seletedMenu == Menu.Add)
    {
        ShowMenuAdd();
    }
    else if ((Menu)seletedMenu == Menu.Remove)
    {
        ShowMenuRemove();
    }
    else if ((Menu)seletedMenu == Menu.List)
    {
        ShowMenuListTask();
    }
} while ((Menu)seletedMenu != Menu.Exit);

int ShowMainMenu()
{
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Ingrese la opción a realizar: ");
    Console.WriteLine("1. Nueva tarea");
    Console.WriteLine("2. Remover tarea");
    Console.WriteLine("3. Tareas pendientes");
    Console.WriteLine("4. Salir");

    int userOption = Convert.ToInt32(Console.ReadLine());
    return userOption;
}

void ShowMenuRemove()
{
    try
    {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
    
        showTaskLists();
        
        int indexToRemove = Convert.ToInt32(Console.ReadLine()) - 1;

        if (indexToRemove > (TaskLists.Count - 1) || indexToRemove < 0)
            Console.WriteLine("Numero de tarea fuera de rango");
        else
        {
            if (indexToRemove > -1 && TaskLists.Count > 0)
            {
                string taskToRemove = TaskLists[indexToRemove];
                TaskLists.RemoveAt(indexToRemove);
                Console.WriteLine($"Tarea {taskToRemove} eliminada");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ha ocurrido un error...!");
    }
}

void ShowMenuAdd()
{
    try
    {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string newTask = Console.ReadLine();
        TaskLists.Add(newTask);
        Console.WriteLine("Tarea registrada");
    }
    catch (Exception) { }
}

void ShowMenuListTask()
{
    if (TaskLists?.Count > 0)
    {
        showTaskLists();
    }
    else
    {
        Console.WriteLine("No hay tareas por realizar");
    }
}

void showTaskLists()
{
    var indexTask = 1;
    TaskLists.ForEach(p => Console.WriteLine($"{indexTask++}. {p}"));
    Console.WriteLine("----------------------------------------");
}

enum Menu
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
