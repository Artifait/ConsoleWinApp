using QuizTop;
using QuizTop.UI;
using System.Data;

namespace ConsoleWinApp.UI.Win.ApplicationWin
{
    public class Task4 : IWin
    {
        public WindowDisplay windowDisplay = new("Task Four", typeof(ProgramOptions));

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
            PointDB db = Application.dB;
            Console.CursorTop = SizeY;
            switch ((ProgramOptions)windowDisplay.CursorPosition)
            {
                case ProgramOptions.ShowVegetableCount:
                    Console.WriteLine("Количество овощей: " + db.GetVegetableCount());
                    break;

                case ProgramOptions.ShowFruitCount:
                    Console.WriteLine("Количество фруктов: " + db.GetFruitCount());
                    break;

                case ProgramOptions.ShowByColor:
                    Console.WriteLine("Введите цвет: ");
                    string color = Console.ReadLine();
                    Console.WriteLine($"Количество фруктов и овощей цвета {color}: {db.GetCountByColor(color)}");
                    break;

                case ProgramOptions.ShowAllByColor:
                    TV.DisplayTable(db.GetCountForEachColor());
                    break;

                case ProgramOptions.ShowByCaloriesBelow:
                    Console.Write("Введите максимальную калорийность: ");
                    int maxCalories = int.Parse(Console.ReadLine());
                    var below = db.GetByCaloriesBelow(maxCalories);
                    TV.DisplayTable(below);
                    break;

                case ProgramOptions.ShowByCaloriesAbove:
                    Console.Write("Введите минимальную калорийность: ");
                    int minCalories = int.Parse(Console.ReadLine());
                    var above = db.GetByCaloriesAbove(minCalories);
                    TV.DisplayTable(above);
                    break;

                case ProgramOptions.ShowByCaloriesRange:
                    Console.Write("Введите минимальную калорийность: ");
                    int minRange = int.Parse(Console.ReadLine());
                    Console.Write("\nВведите максимальную калорийность: ");
                    int maxRange = int.Parse(Console.ReadLine());
                    var range = db.GetByCaloriesInRange(minRange, maxRange);
                    TV.DisplayTable(range);
                    break;

                case ProgramOptions.ShowRedOrYellow:
                    var redYellow = db.GetByColorRedOrYellow();
                    TV.DisplayTable(redYellow);
                    break;

                case ProgramOptions.Back:
                    Application.WinStack.Pop();
                    break;
            }
        }

        public enum ProgramOptions
        {
            ShowVegetableCount,
            ShowFruitCount,
            ShowByColor,
            ShowAllByColor,
            ShowByCaloriesBelow,
            ShowByCaloriesAbove,
            ShowByCaloriesRange,
            ShowRedOrYellow,
            Back,
            CountOptions
        }
    }
}
