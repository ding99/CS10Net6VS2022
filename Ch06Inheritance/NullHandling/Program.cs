using static System.Console;

ForegroundColor = ConsoleColor.Yellow;

int thisCannotBeNull = 4;
//thisCannotBeNull = null;
int? thisCouldBeNull = null;
WriteLine($"null: [{thisCouldBeNull}]");
WriteLine($"null default: [{thisCouldBeNull.GetValueOrDefault()}]");
thisCouldBeNull = 7;
WriteLine($"7: [{thisCouldBeNull}]");
WriteLine($"7 default: [{thisCouldBeNull.GetValueOrDefault()}]");


