using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ColorButton
{
    public class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {
            ChangeColor = new AsyncCommand(OnColorChange);
        }

        public ICommand ChangeColor { get; }

        private Color buttonColor;

        public Color ButtonColor
        {
            get => buttonColor;
            set => SetProperty(ref buttonColor, value);
        }

        async Task OnColorChange()
        {
            await Task.Delay(100);
            Random r = new Random();
            int intButtonColorR = r.Next(256);
            int intButtonColorG = r.Next(256);
            int intButtonColorB = r.Next(256);
            Color hexButtonColor = Color.FromRgb(intButtonColorR, intButtonColorG, intButtonColorB);
            ButtonColor = hexButtonColor;
        }
    }
}
