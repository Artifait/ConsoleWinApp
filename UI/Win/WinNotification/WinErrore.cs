
#nullable enable
namespace QuizTop.UI.Win.WinNotification
{
    public class WinErrore : IWin
    {
        public WindowDisplay windowDisplay = new(MatrixFormater.GetWindowMatrixChar(new string[] { "Ошибка" }, "Errore"));

        public WindowDisplay WindowDisplay
        {
            get => windowDisplay;
            set => windowDisplay = value;
        }

        public Type? ProgramOptionsType => null;

        public Type? ProgramFieldsType => null;

        public void UpdateErroreMsg(string[] ErroreMessages)
        {
            windowDisplay.Fields.Clear();
            for (int index = 0; index < ErroreMessages.Length; ++index)
                windowDisplay.Fields[(index + 1).ToString()] = ErroreMessages[index];
            windowDisplay.UpdateCanvas();
        }

        public int SizeX => windowDisplay.MaxLeft;

        public int SizeY => windowDisplay.MaxTop;

        public void InputHandler()
        {
            Console.ReadKey();
            Console.Clear();
            Application.WinStack.Pop();
        }

        public void Show()
        {
            Console.Clear();
            windowDisplay.Show();
        }
    }
}
