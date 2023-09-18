class FileExplorer
{
    private List<string> _parents;
    private string? _root;
    private MyDirectory? _dirsAndFiles;
    private MyDrives? _drives;
    public FileExplorer()
    {
        _parents = new List<string>();
        _drives = new MyDrives();

    }
    public void Run()
    {
        _root = _drives?.SelectDrive();
        _parents.Add(_root);
        do
        {
            Console.WriteLine($"Path: {_root}");

            _dirsAndFiles = new MyDirectory(_root);
            _dirsAndFiles.PrintAll();

            _dirsAndFiles.SelectedIndex = 2;
            MyConsole.MakeItPrimary(_dirsAndFiles.SelectedIndex, _dirsAndFiles.SelectedDirOrFile);

            ReadKeys();

            Console.Clear();
        } while (true);
    }
    private void ReadKeys()
    {
        while (true)
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.DownArrow:
                    _dirsAndFiles?.IncreaseAndPrint();
                    break;
                case ConsoleKey.UpArrow:
                    _dirsAndFiles?.DecreaseAndPrint();
                    break;
                case ConsoleKey.Backspace:
                    if (_parents.Count == 0)
                    {
                        _root = _drives.SelectDrive();
                        return;
                    }

                    _root = _parents[_parents.Count - 1];
                    _parents.Remove(_root);

                    return;
                case ConsoleKey.Enter:
                    _parents.Add(_root);
                    _root += _dirsAndFiles?.SelectedDirOrFile + @"\";
                    return;
                    //case ConsoleKey.Delete:
                    //    Directory.Delete(root + MyDirectory.SelectedDirOrFile);
                    //    dirs_files.Remove(selectedLine);
                    //    a = false;
                    //    break;
            }
        }
    }
}
