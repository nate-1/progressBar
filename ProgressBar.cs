using System;
namespace ConsoleP
{
    public class ProgressBar
    {
        private int currentValue;
        private int max;
        private const char BODY = '=';
        private const char HEAD = '>';
        public ProgressBar(int maxValue = 100, int initValue = 0)
        {
            this.max = maxValue;
            this.currentValue = initValue;    
            
        }
        private void Update(bool firstTime = false)
        {
            if(!firstTime)
                Console.SetCursorPosition(0, Console.CursorTop-1);
            string toDisplay = "";
            int currentPercentage = ChangeScale(this.max, this.currentValue, 100);
            if(currentPercentage <10) 
                toDisplay = toDisplay + "0";
            toDisplay = toDisplay+ currentPercentage+"% [";
            int width = Console.WindowWidth - 10;
            int charToWrite =  ChangeScale(this.max, this.currentValue, width);
            for (int i = 0; i <= width; i++)
            {
                if(i < charToWrite)
                    toDisplay = toDisplay + BODY;
                else if( i == charToWrite) 
                    toDisplay = toDisplay + HEAD;
                else if(i > charToWrite) 
                    toDisplay = toDisplay + ' ';
            }    
            Console.WriteLine(toDisplay + "]");
            if(width == charToWrite)
                this.Done();
        }
        private void Done()
        {
            string toWrite = "";
            int width = Console.WindowWidth;
            for (int i = 0; i < width; i++)
            {
                toWrite = toWrite + ' ';
            }
            Console.SetCursorPosition(0, Console.CursorTop-1);
            Console.WriteLine(toWrite);
        }
        private int ChangeScale(double maxValue, double currentValue, int scale) 
        {
            if(scale == maxValue)
                return Convert.ToInt32(currentValue);
            else 
                return Convert.ToInt32((currentValue /maxValue)* scale);
        }
        public void Update(int value) 
        {
            this.currentValue = value;
            this.Update();
        }
    }
}
