using System;
using static System.Console;

namespace Date
{
    public class Date
    {
        public int Day { set; get; }
        public int Month { set; get; }
        public int Year { set; get; }
        public Date() { }
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }
        public void showDate()
        {
            WriteLine($"Date: {Day}.{Month}.{Year}");
        }
    }
    public class DateCalc
    {
        Date date1;
        Date date2;
        public int Day { set; get; }
        public int Month { set; get; }
        public int Year { set; get; }
        
        public static int DayCount(Date date1) // Эта функция посчитает количество дней в дате(учитывая отличия количества дней в месяцах и вис.год)
        {
            int day = 365 * date1.Year + date1.Day;
            for (int i = 1; i <= date1.Month; i++)
            {
                if(i==1 || i==3 || i==5 || i == 7 || i == 8 || i == 10 || i == 12)
                {
                    day += 31;
                }
                if (i == 4 || i == 6 || i == 9 || i == 11)
                {
                    day += 30;
                }
                if (i == 2 && date1.Year % 4 == 0)
                {
                    day += 29;
                }
                if (i == 2 && date1.Year % 4 != 0)
                {
                    day += 28;
                }
            }
            return day;
        }

        public static int DayDiff(Date date1, Date date2) // Эта функция посчитает насколько дней одна дата отличается от другой
        {
            if (DateCalc.DayCount(date1) > DateCalc.DayCount(date2))
            {
                int dayDiff = DateCalc.DayCount(date1) - DateCalc.DayCount(date2);
                return dayDiff;
            }
            else
            {
                int dayDiff = DateCalc.DayCount(date2) - DateCalc.DayCount(date1);
                return dayDiff;
            }
        }

        public static Date addDay(Date date1, int days) // Добавляет к дате заданное количество дней и возвращает новую дату.
        {
            days += DateCalc.DayCount(date1);
            date1.Year = days / 365;
            days = days % 365;
            date1.Month = 0;
            for (int i = 1; i < 12; i++)
            {
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
                {
                    if(days/31 > 0)
                    {
                        date1.Month += 1;
                        days -= 31;
                    }
                    else
                    {
                        date1.Day = days;
                        break;
                    }
                    
                }
                if (i == 4 || i == 6 || i == 9 || i == 11)
                {
                    if (days / 30 > 0)
                    {
                        date1.Month += 1;
                        days -= 30;
                    }
                    else
                    {
                        date1.Day = days;
                        break;
                    }
                }
                if (i == 2 && date1.Year % 4 == 0)
                {
                    if (days / 29 > 0)
                    {
                        date1.Month += 1;
                        days -= 29;
                    }
                    else
                    {
                        date1.Day = days;
                        break;
                    }
                }
                if (i == 2 && date1.Year % 4 != 0)
                {
                    if (days / 28 > 0)
                    {
                        date1.Month += 1;
                        days -= 28;
                    }
                    else
                    {
                        date1.Day = days;
                        break;
                    }
                }
            }
            return date1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Date date1 = new Date(25, 4, 2020);
            Date date2 = new Date(28, 4, 2020);
            Date date3 = new Date();
            WriteLine($"Разность дней: {DateCalc.DayDiff(date1, date2)}");
            date3 = DateCalc.addDay(date2, 487);
            date3.showDate();
        }
    }
}
