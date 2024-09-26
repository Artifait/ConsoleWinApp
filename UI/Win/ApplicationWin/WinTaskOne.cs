

using QuizTop;
using QuizTop.UI;

namespace NewQuizTop.UI.Win.ApplicationWin
{
    public class WinTaskOne : IWin
    {
        public WindowDisplay windowDisplay = new("Quiz Application", typeof(ProgramOptions));

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
                case ProgramOptions.Back:
                    Application.WinStack.Pop();
                    break;
            }
        }

        public enum ProgramOptions
        {
            Back,
            CountOptions,
        }
    }
}
