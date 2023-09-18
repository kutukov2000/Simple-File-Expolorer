static class MyConsole
{
    static MyConsole()
    {
        Console.CursorVisible = false;
    }
    static public void DarkGreyForeground()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
    static public void MakeItPrimary(int selectedLine, string text = "")
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(0, selectedLine);

        if (!string.IsNullOrEmpty(text)) Console.Write(text);
    }
    static public void MakeItNonPrimary(int selectedLine, string text = "")
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.SetCursorPosition(0, selectedLine);

        if (!string.IsNullOrEmpty(text)) Console.Write(text);
    }

}
