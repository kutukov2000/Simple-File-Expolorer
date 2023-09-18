class MyDirectory
{
    private DirectoryInfo? _directoryInfo;
    private Dictionary<int, string> _dirsAndFiles;
    public int SelectedIndex { get; set; }
    public string SelectedDirOrFile { get => _dirsAndFiles[SelectedIndex].ToString(); }
    public MyDirectory(string path)
    {
        _directoryInfo = new DirectoryInfo(path);
        _dirsAndFiles = new Dictionary<int, string>();
    }
    public void PrintAll()
    {
        SelectedIndex = 2;
        MyConsole.MakeItNonPrimary(SelectedIndex);

        foreach (var directory in _directoryInfo.GetDirectories())
        {
            Console.WriteLine($"{directory.Name}");
            _dirsAndFiles[SelectedIndex] = directory.Name;
            SelectedIndex++;
        }
        foreach (var file in _directoryInfo.GetFiles())
        {
            Console.WriteLine($"{file.Name}");
            _dirsAndFiles[SelectedIndex] = file.Name;
            SelectedIndex++;
        }
    }
    public void IncreaseAndPrint()
    {
        if (!isValidToIncrease()) return;

        MyConsole.MakeItNonPrimary(SelectedIndex, SelectedDirOrFile);
        SelectedIndex++;
        MyConsole.MakeItPrimary(SelectedIndex, SelectedDirOrFile);
    }
    public void DecreaseAndPrint()
    {
        if (!isValidToDecrease()) return;

        MyConsole.MakeItNonPrimary(SelectedIndex, SelectedDirOrFile);
        SelectedIndex--;
        MyConsole.MakeItPrimary(SelectedIndex, SelectedDirOrFile);
    }
    private bool isValidToIncrease()
    {
        return SelectedIndex <= _dirsAndFiles.Count;
    }
    private bool isValidToDecrease()
    {
        return SelectedIndex - 1 > 1;
    }
}
