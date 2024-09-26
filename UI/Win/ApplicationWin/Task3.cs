﻿using QuizTop.UI;
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

        private void DisplayAllInfo()
        {
            var results = db.GetAllInfo();
            foreach (var row in results)
            {
                Console.WriteLine($"ID: {row.Id}, Name: {row.Name}, Type: {row.Type}, Color: {row.Color}, Calories: {row.Calories}");
            }
        }

        private void DisplayAllNames()
        {
            var names = db.GetAllNames();
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private void DisplayAllColors()
        {
            var colors = db.GetAllColors();
            foreach (var color in colors)
            {
                Console.WriteLine(color);
            }
        }

        private void DisplayMaxCalories()
        {
            var maxCalories = db.GetMaxCalories();
            Console.WriteLine($"Max Calories: {maxCalories}");
        }

        private void DisplayMinCalories()
        {
            var minCalories = db.GetMinCalories();
            Console.WriteLine($"Min Calories: {minCalories}");
        }

        private void DisplayAvgCalories()
        {
            var avgCalories = db.GetAvgCalories();
            Console.WriteLine($"Average Calories: {avgCalories}");
        }

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