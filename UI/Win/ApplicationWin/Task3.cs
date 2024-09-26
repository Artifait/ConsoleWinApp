using QuizTop.UI;
using QuizTop;
using System;
using System.Data.SqlClient;

namespace ConsoleWinApp.UI.Win.ApplicationWin
{
    public class Task3 : IWin
    {
        public WindowDisplay windowDisplay = new("Task Three", typeof(ProgramOptions));
        private PointDB db;

        public Task3()
        {
            db = Application.dB; // Используем подключение к базе данных
        }

        public WindowDisplay WindowDisplay
        {
            get => windowDisplay;
            set => windowDisplay = value;
        }

        public Type? ProgramOptionsType => typeof(ProgramOptions);
        public Type? ProgramFieldsType => null;

        public int SizeX => windowDisplay.MaxLeft;
        public int SizeY => windowDisplay.MaxTop;

        public void Show() => windowDisplay.Show();
        public void InputHandler()
        {
            char lower = char.ToLower(Console.ReadKey().KeyChar);

            WindowTools.UpdateCursorPos(lower, ref windowDisplay, (int)ProgramOptions.CountOptions);

            if (WindowTools.IsKeySelect(lower)) HandlerMetodMenu();
        }

        private void HandlerMetodMenu()
        {
            Console.Clear();
            Console.CursorTop = SizeY;
            switch ((ProgramOptions)windowDisplay.CursorPosition)
            {
                case ProgramOptions.DisplayAllInfo:
                    DisplayAllInfo();
                    break;
                case ProgramOptions.DisplayAllNames:
                    DisplayAllNames();
                    break;
                case ProgramOptions.DisplayAllColors:
                    DisplayAllColors();
                    break;
                case ProgramOptions.DisplayMaxCalories:
                    DisplayMaxCalories();
                    break;
                case ProgramOptions.DisplayMinCalories:
                    DisplayMinCalories();
                    break;
                case ProgramOptions.DisplayAvgCalories:
                    DisplayAvgCalories();
                    break;
                case ProgramOptions.Back:
                    Application.WinStack.Pop();
                    break;
            }
        }

        private void DisplayAllInfo() => TV.DisplayTable(db.GetAllInfo());
        private void DisplayAllNames() => TV.DisplayTable(db.GetAllNames());
        private void DisplayAllColors() => TV.DisplayTable(db.GetAllColors());
        private void DisplayMaxCalories() => TV.DisplayTable(db.GetMaxCalories());
        private void DisplayMinCalories() => TV.DisplayTable(db.GetMinCalories());
        private void DisplayAvgCalories() => TV.DisplayTable(db.GetAvgCalories());


        public enum ProgramOptions
        {
            DisplayAllInfo,
            DisplayAllNames,
            DisplayAllColors,
            DisplayMaxCalories,
            DisplayMinCalories,
            DisplayAvgCalories,
            Back,
            CountOptions,
        }
    }
}
