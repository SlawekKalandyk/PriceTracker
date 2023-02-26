using System.ComponentModel;

namespace PriceTracker.WinForms.Controls
{
    [ToolboxItem(true)]
    public class CurrencySpin : NumericUpDown
    {
        public CurrencySpin()
        {
            ThousandsSeparator = true;
            DecimalPlaces = 2;
            Maximum = 999999999;
            Validating += CurrencySpin_Validating;
        }

        private void CurrencySpin_Validating(object? sender, CancelEventArgs e)
        {
            Value = Math.Round(Value, DecimalPlaces, MidpointRounding.AwayFromZero);
        }
    }
}
