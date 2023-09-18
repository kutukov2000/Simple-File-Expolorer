class MyDrives
{
    private DriveInfo[] _drives;
    private int _selectedDriveIndex;
    private string SelectedDrive { get => _drives[_selectedDriveIndex].ToString(); }
    public MyDrives()
    {
        _drives = DriveInfo.GetDrives();
    }
    public string SelectDrive()
    {
        Console.Clear();

        this.PrintAll();

        _selectedDriveIndex = 0;
        MyConsole.MakeItPrimary(_selectedDriveIndex, SelectedDrive);

        return ReadKeys();
    }
    private string ReadKeys()
    {
        while (true)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    this.IncreaseAndPrint();
                    break;
                case ConsoleKey.UpArrow:
                    this.DecreaseAndPrint();
                    break;
                case ConsoleKey.Enter:
                    Console.Clear();
                    return SelectedDrive;
            }
        }
    }
    private void PrintAll()
    {
        MyConsole.DarkGreyForeground();

        foreach (var item in _drives)
        {
            Console.WriteLine(item);
        }
    }
    private bool isValidToIncrease()
    {
        return _selectedDriveIndex + 1 < _drives.Length;
    }
    private bool isValidToDecrease()
    {
        return _selectedDriveIndex != 0;
    }
    private void IncreaseAndPrint()
    {
        if (!isValidToIncrease()) return;

        MyConsole.MakeItNonPrimary(_selectedDriveIndex, SelectedDrive);
        _selectedDriveIndex++;
        MyConsole.MakeItPrimary(_selectedDriveIndex, SelectedDrive);
    }
    private void DecreaseAndPrint()
    {
        if (!isValidToDecrease()) return;

        MyConsole.MakeItNonPrimary(_selectedDriveIndex, SelectedDrive);
        _selectedDriveIndex--;
        MyConsole.MakeItPrimary(_selectedDriveIndex, SelectedDrive);
    }
}
