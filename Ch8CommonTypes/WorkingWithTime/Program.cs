Console.ForegroundColor = ConsoleColor.Yellow;

Console.WriteLine("Earliest date/time value is: {0}", arg0:DateTime.MinValue);
Console.WriteLine("UNIX epoch date/time value is: {0}", arg0:DateTime.UnixEpoch);
Console.WriteLine("Date/time value Now is: {0}", arg0:DateTime.Now);
Console.WriteLine("Date/time value Today is: {0}", arg0:DateTime.Today);

Console.WriteLine();

DateTime christmas = new(year:2023, month:12, day:25);
Console.WriteLine("Christmas: {0}", arg0:christmas);
Console.WriteLine("Christmas: {0:dddd, dd MMMM yyyy}", arg0:christmas);
Console.WriteLine("Christmas is in month {0} of the year.", arg0: christmas.Month);
Console.WriteLine("Christmas is day {0} of the year.", arg0:christmas.DayOfYear);
Console.WriteLine("Christmas {0} is on a {1}.", arg0:christmas.Year, arg1:christmas.DayOfWeek);

Console.ResetColor();
