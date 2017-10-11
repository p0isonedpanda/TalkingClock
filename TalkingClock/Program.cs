using System;
using System.Speech.Synthesis;

namespace TalkingClock
{
    class Program
    {
        static string[] ones = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                                               "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seveteen", "eighteen", "nineteen" };
        static string[] tens = new string[] { "ten", "twenty", "thirty", "fourty", "fifty" };

        static void Main(string[] args)
        {
            int hours = DateTime.Now.Hour;
            int minutes = DateTime.Now.Minute;
            bool morning = true;
            string outputTime = "The time is ";

            if (hours >= 12 && hours != 24)
            {
                if (hours != 12)
                    hours -= 12;

                morning = false;
            }
            else if (hours == 0 || hours == 24)
                hours = 12;

            outputTime += ones[hours];

            if (minutes < 20)
            {
                if (minutes == 0)
                    outputTime += " o'clock";
                else if (minutes < 10)
                    outputTime += " oh " + ones[minutes];
                else
                    outputTime += " " + ones[minutes];
            }
            else
            {
                if (minutes % 10 == 0)
                    outputTime += " " + tens[minutes - 1];
                else
                    outputTime += " " + tens[(minutes - (minutes % 10)) / 10 - 1] + " " + ones[minutes % 10];
            }

            if (morning)
                outputTime += " AM";
            else
                outputTime += " PM";

            Console.WriteLine(outputTime);

            SpeechSynthesizer spokenTime = new SpeechSynthesizer();
            spokenTime.Volume = 100;
            spokenTime.Rate = -2;
            spokenTime.Speak(outputTime);
        }
    }
}
