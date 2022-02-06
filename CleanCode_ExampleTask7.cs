public static void CreateObject()
{
    //Создание объекта на карте
}

public static void ChangeChance()
{
    _chance = Random.Range(0, 100);
}

public static int GetSalary(int hoursWorked)
{
    return _hourlyRate * hoursWorked;
}