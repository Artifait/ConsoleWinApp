
using QuizTop.UI;
using QuizTop.UI.Win.ApplicationWin;

#nullable enable
namespace QuizTop
{
    public static class Application
    {
        public static Stack<IWin> WinStack = new();
        public static bool IsRunning = false;
        public static string PathData = Directory.GetCurrentDirectory();

        public static bool CursorVisible { get; set; } = false;

        private static void Init()
        {
            Console.Title = "Art Quiz Top";
            Console.SetWindowSize(80, 40);
            WinStack.Push(WindowsHandler.GetWindow<WinStart>());            
        }

        public static void Run()
        {
            if (IsRunning) return;
            IsRunning = true;
            Init();
            while (IsRunning && WinStack.Count > 0)
            {
                WinStack.Peek().Show();
                Console.CursorVisible = CursorVisible;
                try { WinStack.Peek().InputHandler(); }
                catch (Exception ex) { WindowsHandler.AddErroreWindow(new string[] { ex.Message }); }
            }
        }
    }
}
