internal class Program
{
    static DriveInfo[] drives = DriveInfo.GetDrives();
    static List<string> parrent = new List<string>();
    static string SelectDrive()
    {
        Console.Clear();
        string root = string.Empty;
        Console.ForegroundColor = ConsoleColor.DarkGray;

        foreach (var item in drives)
        {
            Console.WriteLine(item);
        }

        int drives_k = 0;
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, drives_k);
        Console.Write(drives[drives_k]);
        while (string.IsNullOrEmpty(root))
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    root = drives[drives_k].ToString();
                    break;
                case ConsoleKey.DownArrow:
                    if (drives_k <= drives.Length)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.SetCursorPosition(0, drives_k);
                        Console.Write(drives[drives_k]);
                        drives_k++;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, drives_k);
                        Console.Write(drives[drives_k]);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (drives_k != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.SetCursorPosition(0, drives_k);
                        Console.Write(drives[drives_k]);
                        drives_k--;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, drives_k);
                        Console.Write(drives[drives_k]);
                    }
                    break;
            }
        }
        parrent.Clear();
        Console.Clear();
        return root;
    }
    private static void Main()
    {
        Console.CursorVisible = false;
        string root = SelectDrive();
        parrent.Add(root);
        do
        {
            Console.WriteLine($"Path: {root}");
            DirectoryInfo dir = new DirectoryInfo(root);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 2);
            int k = 2;
            Dictionary<int, string> dirs_files = new Dictionary<int, string>();
            foreach (var d in dir.GetDirectories())
            {
                Console.WriteLine($"{d.Name}");
                dirs_files[k] = d.Name;
                k++;
            }
            foreach (var d in dir.GetFiles())
            {
                Console.WriteLine($"{d.Name}");
                dirs_files[k] = d.Name;
                k++;
            }
            k = 2;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, k);
            Console.Write(dirs_files[k]);
            bool a = true;
            while (a)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        if (k != dirs_files.Count + 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.SetCursorPosition(0, k);
                            Console.Write(dirs_files[k]);
                            k++;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(0, k);
                            Console.Write(dirs_files[k]);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (k != 2)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.SetCursorPosition(0, k);
                            Console.Write(dirs_files[k]);
                            k--;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(0, k);
                            Console.Write(dirs_files[k]);
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (parrent.Count == 0)
                        {
                            root = SelectDrive();
                            a = false;
                            break;
                        }
                        root = parrent[parrent.Count - 1];
                        foreach (var item in drives)
                        {
                            if (root == item.ToString()) root = SelectDrive();
                            a = false;
                            break;
                        }
                        parrent.Remove(root);
                        a = false;
                        break;
                    case ConsoleKey.Enter:
                        parrent.Add(root);
                        root += dirs_files[k] + @"\";
                        a = false;
                        break;
                    case ConsoleKey.Delete:
                        Directory.Delete(root + dirs_files[k]);
                        dirs_files.Remove(k);
                        a = false;
                        break;
                }
            }
            Console.Clear();
        } while (true);
    }
}