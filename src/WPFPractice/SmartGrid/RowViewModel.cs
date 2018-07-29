
namespace WPFPractice.SmartGrid
{
    public interface IRowViewModel
    {
    }

    public class RowViewModel : IRowViewModel
    {
        private string[] values = new string[100];
        
        public RowViewModel()
        {
        }

        public string this[int number]
        {
            get
            {
                if(number>0 && number< values.Length)
                {
                    return values[number];
                }
                return "Error";
            }
            set
            {
                if (number > 0 && number < values.Length)
                {
                    values[number] = value;
                }
            }
        }
    }
}
