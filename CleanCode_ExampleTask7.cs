public static void CreateObject()
{
    throw new NotImplementedException();
}

public static void RandomiseChance()
{
    _chance = Random.Range(0, 100);
}

public static int GetSalary(int hoursWorked)
{
    return _hourlyRate * hoursWorked;
}