﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;

namespace DateTimeLab
{
    public class DateTimeLabCode
    {
        /// <summary>
        /// Returns a DateTime object that is
        /// set to the current day's date.
        /// </summary>
        public DateTime GetTheDateToday()
        {
            DateTime localDateTime;
            localDateTime = DateTime.Today;
            return localDateTime;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a string that represents the date for 
        /// the month day and year passed into the method parameters 
        /// as integers. Expected Return value should be in format
        /// "12/25/15"
        /// </summary>
        public string GetShortDateStringFromParamaters(int month, int day, int year)
        {
            string returnString;
            DateTime localDateTime = DateTime.Parse($"{month}/{day}/{year}");
                returnString = localDateTime.ToString($"M/d/yy");
            return returnString;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a DateTime object that is created based on
        /// a string representation provided by the user.  Should
        /// handle date formats such as "4/1/2015", "04.01.15", 
        /// "April 1, 2015", "25 Dec 2015"
        /// </summary>
        public DateTime GetDateTimeObjectFromString(string date)
        {
            return DateTime.Parse(date);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a formatted date string based on a string
        /// object passed in from the calling code.  Format should
        /// be in the form "09.02.2005 01:55 PM"
        /// </summary>
        public string GetFormatedDateString(string date)
        {
            string result;
            DateTime localDate = DateTime.Parse(date);
            result = localDate.ToString("MM.dd.yyyy hh:mm tt");
            return result;
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a formatted date string that is six
        /// months in the future from the date passed in.
        /// The result should be formatted like "July 4, 1776"
        /// </summary>
        public string GetDateInSixMonths(string date)
        {
            DateTime localDate = DateTime.Parse(date);
            localDate = localDate.AddMonths(6);
            return localDate.ToString("MMMM d, yyyy");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a formatted date string that is thirty
        /// days in the past from the date passed in.
        /// The result should be formatted like "January 1, 2005"
        /// </summary>
        public string GetDateThirtyDaysInPast(string date)
        {
            return DateTime.Parse(date).AddDays(-30).ToString("MMMM d, yyyy");
            throw new NotImplementedException();
        }


        /// <summary>
        /// Returns an array of DateTime objects containing the next count
        /// number of wednesdays on or after the given date
        /// </summary>
        /// <param name="count">the number of wednesdays to return</param>
        /// <param name="startDate">the starting date</param>
        /// <returns>An array of date objects of size count</returns>
        public DateTime[] GetNextWednesdays(int count, string startDate)
        {
            DateTime dateToChange = DateTime.Parse(startDate);
            DateTime[] dates = new DateTime[count];
            int index = 0;

            for (int i = 0; i < 7*count; i++)
            {
                {
                    if (dateToChange.DayOfWeek == DayOfWeek.Wednesday)
                    {
                        dates[index] = dateToChange;
                        index++;
                    }
                    dateToChange = dateToChange.AddDays(1);
                }
            }
            Console.WriteLine(CultureInfo.CurrentCulture.Name);
            return dates;
            throw new NotImplementedException();
        }
    }
}
