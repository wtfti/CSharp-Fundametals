using System;
class ExamSchedule
{
    public static void Main()
    {
        int hoursExamStarts = int.Parse(Console.ReadLine());
        int minutesExamStarts = int.Parse(Console.ReadLine());
        string kindOfDat = Console.ReadLine();
        int hoursExamEnds = int.Parse(Console.ReadLine());
        int minutesExamEnds = int.Parse(Console.ReadLine());
        string result;

        if (kindOfDat == "PM")
        {
            hoursExamStarts += 12;

            if (hoursExamStarts == 24)
            {
                hoursExamStarts = 0;
            }
        }
        TimeSpan timespan = new TimeSpan(hoursExamStarts, minutesExamStarts, 0);
        DateTime dateStartExam = DateTime.Parse(timespan.ToString("t"));
        dateStartExam = dateStartExam.AddHours(hoursExamEnds);
        dateStartExam = dateStartExam.AddMinutes(minutesExamEnds);
        result = dateStartExam.ToString("hh:mm:tt");
        Console.WriteLine(result);
    }
}
