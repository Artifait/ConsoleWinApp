﻿
using QuizTop.UI;
using QuizTop.UI.Win.ApplicationWin;
using System.Data;

#nullable enable
namespace QuizTop
{
    public static class Application
    {
        public static Stack<IWin> WinStack = new();
        public static bool IsRunning = false;
        public static string PathData = Directory.GetCurrentDirectory();
        public static PointDB dB = new();
        public static bool CursorVisible { get; set; } = false;

        private static void Init()
        {
            Console.Title = "Tasks";
            Console.SetWindowSize(80, 40);
            WinStack.Push(WindowsHandler.GetWindow<WinStart>());

            dB.OpenDB();
            if (!dB.IsWork())
            {
                Console.Clear();
                Console.WriteLine("НЕ удалось открыть бд");
                return;
            }
            else { WindowsHandler.AddInfoWindow(new string[] { "БД Открылась!:)" }); }
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
