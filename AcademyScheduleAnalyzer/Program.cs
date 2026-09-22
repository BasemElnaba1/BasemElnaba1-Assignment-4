using System.Globalization;
using System.Text;
using AcademyScheduleAnalyzer.Benchmarks;
using BenchmarkDotNet.Running;

if (Array.Exists(args, argument => argument.Equals("--benchmark", StringComparison.OrdinalIgnoreCase)))
{
    BenchmarkRunner.Run<StringBenchmark>();
    return;
}

string[] sessionNames =
{
    "C# Basics",
    "Arrays",
    "Functions",
    "Date and Time",
    "Exception Handling"
};

DateTime[] sessionDates =
{
    new DateTime(2026, 9, 10, 18, 0, 0),
    new DateTime(2026, 9, 13, 18, 0, 0),
    new DateTime(2026, 9, 17, 18, 0, 0),
    new DateTime(2026, 9, 20, 18, 0, 0),
    new DateTime(2026, 9, 24, 18, 0, 0)
};

int[] sessionDurations = { 180, 240, 180, 240, 180 };

bool isRunning = true;

while (isRunning)
{
    DisplayMenu();
    int option = ReadMenuOption();
    Console.WriteLine();

    switch (option)
    {
        case 1:
            DisplaySessions(sessionNames, sessionDates, sessionDurations);
            break;
        case 2:
            SearchSession(sessionNames, sessionDates, sessionDurations);
            break;
        case 3:
            DisplaySortedSessionNames(sessionNames);
            break;
        case 4:
            DisplayReversedSessionNames(sessionNames);
            break;
        case 5:
            FindSessionIndex(sessionNames);
            break;
        case 6:
            CheckSessionExists(sessionNames);
            break;
        case 7:
            FindSessionUsingCondition(sessionNames);
            break;
        case 8:
            FindSessionIndexUsingCondition(sessionNames);
            break;
        case 9:
            DemonstrateArrayCopy(sessionNames);
            break;
        case 10:
            DisplayDurationStatistics(sessionDurations);
            break;
        case 11:
            DemonstrateParameterPassing(sessionNames, sessionDurations);
            break;
        case 12:
            DemonstrateParams();
            break;
        case 13:
            ShowSessionDateDetails(sessionNames, sessionDates, sessionDurations);
            break;
        case 14:
            DisplayPastAndUpcomingSessions(sessionNames, sessionDates);
            break;
        case 15:
            FindNextSession(sessionNames, sessionDates);
            break;
        case 16:
            CompareSessionDates(sessionNames, sessionDates);
            break;
        case 17:
            DisplayDateFormats(sessionNames, sessionDates);
            break;
        case 18:
            DateTime customDate = ReadSessionDate();
            Console.WriteLine($"Valid date: {customDate:yyyy-MM-dd HH:mm}");
            break;
        case 19:
            SelectSessionByIndex(sessionNames);
            break;
        case 20:
            ValidateDurationOperation();
            break;
        case 21:
            Console.WriteLine(BuildReportUsingString(sessionNames, sessionDates, sessionDurations));
            break;
        case 22:
            Console.WriteLine(BuildReportUsingStringBuilder(sessionNames, sessionDates, sessionDurations));
            break;
        case 0:
            isRunning = false;
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Please choose an option from the menu.");
            break;
    }

    if (isRunning)
    {
        Console.WriteLine("\nPress Enter to return to the menu.");
        Console.ReadLine();
        Console.Clear();
    }
}

static void DisplayMenu()
{
    Console.WriteLine("===================================");
    Console.WriteLine("Academy Schedule Analyzer");
    Console.WriteLine("===================================");
    Console.WriteLine("1.  Display all sessions");
    Console.WriteLine("2.  Search for a session");
    Console.WriteLine("3.  Sort session names");
    Console.WriteLine("4.  Reverse session names");
    Console.WriteLine("5.  Find session index");
    Console.WriteLine("6.  Check if session exists");
    Console.WriteLine("7.  Find a session using a condition");
    Console.WriteLine("8.  Find an index using a condition");
    Console.WriteLine("9.  Demonstrate Array.Copy");
    Console.WriteLine("10. Show duration statistics");
    Console.WriteLine("11. Demonstrate ref, out, and reference types");
    Console.WriteLine("12. Demonstrate params");
    Console.WriteLine("13. Show session date details");
    Console.WriteLine("14. Show past and upcoming sessions");
    Console.WriteLine("15. Find next session");
    Console.WriteLine("16. Compare two session dates");
    Console.WriteLine("17. Display date formats");
    Console.WriteLine("18. Read and validate a custom date");
    Console.WriteLine("19. Select session by index");
    Console.WriteLine("20. Validate session duration");
    Console.WriteLine("21. Generate report using string");
    Console.WriteLine("22. Generate report using StringBuilder");
    Console.WriteLine("0.  Exit");
}

static int ReadMenuOption()
{
    while (true)
    {
        Console.Write("Choose an option: ");

        try
        {
            string? input = Console.ReadLine();
            return int.Parse(input ?? string.Empty);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid menu option. Enter a number.");
        }
    }
}

static void DisplaySessions(string[] names, DateTime[] dates, int[] durations)
{
    for (int index = 0; index < names.Length; index++)
    {
        Console.WriteLine($"{index + 1}. {names[index]}");
        DisplaySessionDetails(names[index], dates[index], durations[index]);
        Console.WriteLine();
    }
}

static void DisplaySessionDetails(string name, DateTime date, int duration)
{
    Console.WriteLine($"Name: {name}");
    Console.WriteLine($"Date: {date:dd MMMM yyyy}");
    Console.WriteLine($"Start Time: {date:hh:mm tt}");
    Console.WriteLine($"Duration: {duration} minutes");
}

static void SearchSession(string[] names, DateTime[] dates, int[] durations)
{
    Console.Write("Enter session name: ");
    string searchName = Console.ReadLine() ?? string.Empty;
    int index = Array.FindIndex(names,
        name => name.Equals(searchName, StringComparison.OrdinalIgnoreCase));

    if (index == -1)
    {
        Console.WriteLine("Session not found.");
        return;
    }

    DisplaySessionDetails(names[index], dates[index], durations[index]);
}

static void DisplaySortedSessionNames(string[] names)
{
    string[] copy = new string[names.Length];
    Array.Copy(names, copy, names.Length);
    Array.Sort(copy, StringComparer.OrdinalIgnoreCase);

    Console.WriteLine("Session names in alphabetical order:");
    foreach (string name in copy)
    {
        Console.WriteLine(name);
    }
}

static void DisplayReversedSessionNames(string[] names)
{
    string[] copy = new string[names.Length];
    Array.Copy(names, copy, names.Length);
    Array.Reverse(copy);

    Console.WriteLine("Session names in reverse order:");
    foreach (string name in copy)
    {
        Console.WriteLine(name);
    }
}

static void FindSessionIndex(string[] names)
{
    Console.Write("Enter session name: ");
    string searchName = Console.ReadLine() ?? string.Empty;
    int index = Array.IndexOf(names, searchName);
    Console.WriteLine(index >= 0 ? $"Index: {index}" : "Session not found.");
}

static void CheckSessionExists(string[] names)
{
    Console.Write("Enter session name: ");
    string searchName = Console.ReadLine() ?? string.Empty;
    bool exists = Array.Exists(names,
        name => name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
    Console.WriteLine(exists ? "Session exists." : "Session does not exist.");
}

static void FindSessionUsingCondition(string[] names)
{
    Console.Write("Enter text that the session name should contain: ");
    string searchText = Console.ReadLine() ?? string.Empty;
    string? match = Array.Find(names,
        name => name.Contains(searchText, StringComparison.OrdinalIgnoreCase));
    Console.WriteLine(match is null ? "No matching session." : $"Found: {match}");
}

static void FindSessionIndexUsingCondition(string[] names)
{
    Console.Write("Enter text that the session name should contain: ");
    string searchText = Console.ReadLine() ?? string.Empty;
    int index = Array.FindIndex(names,
        name => name.Contains(searchText, StringComparison.OrdinalIgnoreCase));
    Console.WriteLine(index >= 0 ? $"Index: {index}" : "No matching session.");
}

static void DemonstrateArrayCopy(string[] names)
{
    string[] copy = new string[names.Length];
    Array.Copy(names, copy, names.Length);
    copy[0] = "Changed only in the copy";

    Console.WriteLine("Original array:");
    foreach (string name in names)
    {
        Console.WriteLine(name);
    }

    Console.WriteLine("\nCopied array after changing its first element:");
    foreach (string name in copy)
    {
        Console.WriteLine(name);
    }
}

static int GetTotalDuration(int[] durations)
{
    int total = 0;
    foreach (int duration in durations)
    {
        total += duration;
    }

    return total;
}

static double GetAverageDuration(int[] durations)
{
    return durations.Length == 0 ? 0 : (double)GetTotalDuration(durations) / durations.Length;
}

static int GetShortestDuration(int[] durations)
{
    if (durations.Length == 0)
    {
        throw new ArgumentException("The duration array cannot be empty.", nameof(durations));
    }

    int shortest = durations[0];
    for (int index = 1; index < durations.Length; index++)
    {
        if (durations[index] < shortest)
        {
            shortest = durations[index];
        }
    }

    return shortest;
}

static int GetLongestDuration(int[] durations)
{
    if (durations.Length == 0)
    {
        throw new ArgumentException("The duration array cannot be empty.", nameof(durations));
    }

    int longest = durations[0];
    for (int index = 1; index < durations.Length; index++)
    {
        if (durations[index] > longest)
        {
            longest = durations[index];
        }
    }

    return longest;
}

static void DisplayDurationStatistics(int[] durations)
{
    Console.WriteLine($"Total Duration: {GetTotalDuration(durations)} minutes");
    Console.WriteLine($"Average Duration: {GetAverageDuration(durations):0.##} minutes");
    Console.WriteLine($"Shortest Duration: {GetShortestDuration(durations)} minutes");
    Console.WriteLine($"Longest Duration: {GetLongestDuration(durations)} minutes");

    int[] sortedDurations = new int[durations.Length];
    Array.Copy(durations, sortedDurations, durations.Length);
    Array.Sort(sortedDurations);
    Console.WriteLine($"Sorted Durations: {string.Join(", ", sortedDurations)}");
}

static void AddThirtyMinutes(ref int duration)
{
    duration += 30;
}

static bool TryGetSessionInformation(
    string[] names,
    int[] durations,
    string sessionName,
    out int sessionIndex,
    out int sessionDuration)
{
    sessionIndex = Array.FindIndex(names,
        name => name.Equals(sessionName, StringComparison.OrdinalIgnoreCase));

    if (sessionIndex == -1)
    {
        sessionDuration = 0;
        return false;
    }

    sessionDuration = durations[sessionIndex];
    return true;
}

static void ChangeFirstElement(string[] values)
{
    if (values.Length > 0)
    {
        values[0] = "Changed inside the function";
    }
}

static void DemonstrateParameterPassing(string[] names, int[] durations)
{
    int duration = 120;
    Console.WriteLine($"ref value before: {duration}");
    AddThirtyMinutes(ref duration);
    Console.WriteLine($"ref value after: {duration}");

    Console.Write("\nEnter a session name for the out example: ");
    string searchName = Console.ReadLine() ?? string.Empty;
    if (TryGetSessionInformation(names, durations, searchName, out int index, out int foundDuration))
    {
        Console.WriteLine($"Index: {index}");
        Console.WriteLine($"Duration: {foundDuration} minutes");
    }
    else
    {
        Console.WriteLine("Session not found.");
    }

    string[] referenceTypeExample = new string[names.Length];
    Array.Copy(names, referenceTypeExample, names.Length);
    Console.WriteLine($"\nArray value before normal parameter call: {referenceTypeExample[0]}");
    ChangeFirstElement(referenceTypeExample);
    Console.WriteLine($"Array value after normal parameter call: {referenceTypeExample[0]}");
}

static int CalculateTotalDuration(params int[] durations)
{
    return GetTotalDuration(durations);
}

static void DemonstrateParams()
{
    Console.WriteLine(CalculateTotalDuration(120, 180));
    Console.WriteLine(CalculateTotalDuration(120, 180, 240));
    Console.WriteLine(CalculateTotalDuration(60, 90, 120, 180, 240));
}

static DateTime GetSessionEndTime(DateTime startTime, int duration)
{
    return startTime.AddMinutes(duration);
}

static int ReadSessionIndexByName(string[] names)
{
    Console.Write("Enter session name: ");
    string searchName = Console.ReadLine() ?? string.Empty;
    return Array.FindIndex(names,
        name => name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
}

static void ShowSessionDateDetails(string[] names, DateTime[] dates, int[] durations)
{
    int index = ReadSessionIndexByName(names);
    if (index == -1)
    {
        Console.WriteLine("Session not found.");
        return;
    }

    DateTime date = dates[index];
    Console.WriteLine($"Session: {names[index]}");
    Console.WriteLine($"Date: {date:dd MMMM yyyy}");
    Console.WriteLine($"Day: {date.DayOfWeek}");
    Console.WriteLine($"Year: {date.Year}");
    Console.WriteLine($"Month: {date.Month}");
    Console.WriteLine($"Day Number: {date.Day}");
    Console.WriteLine($"Start Time: {date:hh:mm tt}");
    Console.WriteLine($"Duration: {durations[index]} minutes");
    Console.WriteLine($"End Time: {GetSessionEndTime(date, durations[index]):hh:mm tt}");
}

static void CompareSessionDates(string[] names, DateTime[] dates)
{
    Console.WriteLine("First session:");
    int firstIndex = ReadSessionIndexByName(names);
    Console.WriteLine("Second session:");
    int secondIndex = ReadSessionIndexByName(names);

    if (firstIndex == -1 || secondIndex == -1)
    {
        Console.WriteLine("One or both sessions were not found.");
        return;
    }

    TimeSpan difference = dates[secondIndex] - dates[firstIndex];
    difference = difference.Duration();
    Console.WriteLine("Difference:");
    Console.WriteLine($"{difference.TotalDays:0.##} days");
    Console.WriteLine($"{difference.TotalHours:0.##} hours");
}

static void DisplayPastAndUpcomingSessions(string[] names, DateTime[] dates)
{
    DateTime now = DateTime.Now;
    for (int index = 0; index < names.Length; index++)
    {
        string status = dates[index] < now ? "Past" : "Upcoming";
        Console.WriteLine($"{names[index]}: {status}");
    }
}

static void FindNextSession(string[] names, DateTime[] dates)
{
    DateTime now = DateTime.Now;
    int nextIndex = -1;

    for (int index = 0; index < dates.Length; index++)
    {
        if (dates[index] > now && (nextIndex == -1 || dates[index] < dates[nextIndex]))
        {
            nextIndex = index;
        }
    }

    if (nextIndex == -1)
    {
        Console.WriteLine("There are no upcoming sessions.");
        return;
    }

    TimeSpan remaining = dates[nextIndex] - now;
    Console.WriteLine("Next Session:");
    Console.WriteLine(names[nextIndex]);
    Console.WriteLine(dates[nextIndex].ToString("dd MMMM yyyy"));
    Console.WriteLine(dates[nextIndex].ToString("hh:mm tt"));
    Console.WriteLine("Time Remaining:");
    Console.WriteLine($"{remaining.Days} days");
    Console.WriteLine($"{remaining.Hours} hours");
}

static void DisplayDateFormats(string[] names, DateTime[] dates)
{
    int index = ReadSessionIndexByName(names);
    if (index == -1)
    {
        Console.WriteLine("Session not found.");
        return;
    }

    DateTime date = dates[index];
    Console.WriteLine(date.ToString("yyyy-MM-dd"));
    Console.WriteLine(date.ToString("dd/MM/yyyy"));
    Console.WriteLine(date.ToString("dd MMMM yyyy"));
    Console.WriteLine(date.ToString("dddd, dd MMMM yyyy"));
    Console.WriteLine(date.ToString("hh:mm tt"));
}

static DateTime ReadSessionDate()
{
    const string format = "yyyy-MM-dd HH:mm";

    while (true)
    {
        Console.Write($"Enter a date ({format}): ");
        string input = Console.ReadLine() ?? string.Empty;

        if (DateTime.TryParseExact(
                input,
                format,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime validDate))
        {
            return validDate;
        }

        Console.WriteLine("Invalid date. Please use the exact format yyyy-MM-dd HH:mm.");
    }
}

static void SelectSessionByIndex(string[] names)
{
    try
    {
        Console.Write("Enter session index: ");
        int index = int.Parse(Console.ReadLine() ?? string.Empty);
        Console.WriteLine($"Session: {names[index]}");
    }
    catch (FormatException)
    {
        Console.WriteLine("The session index must be a number.");
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("The selected session index is out of range.");
    }
    finally
    {
        Console.WriteLine("Input operation finished.");
    }
}

static void ValidateSessionDuration(int duration)
{
    if (duration <= 0)
    {
        throw new ArgumentException("Duration must be greater than zero.");
    }
}

static void ValidateDurationOperation()
{
    try
    {
        Console.Write("Enter duration: ");
        int duration = int.Parse(Console.ReadLine() ?? string.Empty);
        ValidateSessionDuration(duration);
        Console.WriteLine("Duration accepted.");
    }
    catch (FormatException)
    {
        Console.WriteLine("Duration must be a number.");
    }
    catch (ArgumentException exception)
    {
        Console.WriteLine(exception.Message);
    }
}

static string BuildReportUsingString(string[] names, DateTime[] dates, int[] durations)
{
    string result = string.Empty;
    for (int index = 0; index < names.Length; index++)
    {
        result += $"{names[index]} - {dates[index]:dd/MM/yyyy hh:mm tt} - {durations[index]} minutes";
        result += Environment.NewLine;
    }

    return result;
}

static string BuildReportUsingStringBuilder(string[] names, DateTime[] dates, int[] durations)
{
    StringBuilder result = new StringBuilder();
    for (int index = 0; index < names.Length; index++)
    {
        result.Append(names[index]);
        result.Append(" - ");
        result.Append(dates[index].ToString("dd/MM/yyyy hh:mm tt"));
        result.Append(" - ");
        result.Append(durations[index]);
        result.AppendLine(" minutes");
    }

    return result.ToString();
}
