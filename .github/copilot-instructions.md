# DPL Pathways - AI Coding Agent Instructions

## Project Overview
This is a C# learning pathway repository organized by stages and weeks, focusing on fundamental programming concepts through console applications. Each week builds on previous concepts with exercises and challenges.

## Project Structure
```
Stage_1/
  Week_1/  - Basic I/O, conversions, loops, validation
  Week_2/  - Arrays and file handling  
  Week_3/  - OOP concepts (encapsulation, inheritance)
  Week_4/  - (Future content)
```

Each exercise is a standalone .NET console project with its own `.csproj` file.

## Building & Running Projects
Navigate to specific project folders and use:
```bash
cd Stage_1/Week_X/ProjectName
dotnet run
```

The solution file `DPL_Pathways.sln` at the root can build all projects, but individual projects are typically run independently.

## Code Conventions & Patterns

### Naming Patterns
- **Folder names**: Use underscores and mixed case (e.g., `e_Week_1_Chalanges`, `1_Aray`)
- **Class names**: Often match assignment context (e.g., `Week_Chalange`, `Day_1`)
- **Variables**: camelCase with descriptive names, nullable strings marked with `?`

### Console I/O Pattern
Standard pattern used across exercises:
```csharp
Console.WriteLine("Prompt message");
string? input = Console.ReadLine();
```

### Input Validation Pattern
Common regex-based validation approach seen in Week 3:
```csharp
while (true)
{
    Console.WriteLine("Enter input");
    string? input = Console.ReadLine();
    
    if (!string.IsNullOrWhiteSpace(input) && Regex.IsMatch(input, @"pattern"))
    {
        property = input.Trim();
        break;
    }
    Console.WriteLine("Error: validation message");
}
```

Key patterns:
- Use `!string.IsNullOrWhiteSpace()` before regex validation
- Apply `.Trim()` when storing valid input
- Star ratings use pattern `@"^\*{1,5}$"` (1-5 asterisks)
- Letter-only inputs use `@"^[a-zA-Z ]+$"`

### File Handling Pattern
Text file persistence pattern (Week 3 restaurant tracker):
```csharp
string mainFile = "mainFile.txt";

// Reading
using (StreamReader read = File.OpenText(mainFile))
{
    string s = "";
    while ((s = read.ReadLine()) != null)
    {
        // Process line
    }
}

// Writing (append mode)
using (StreamWriter writer = new StreamWriter(mainFile, append: true))
{
    writer.WriteLine($"{field1.PadRight(28)}{field2.PadRight(28)}{field3}");
}
```

Notes:
- Fixed-width formatting using `.PadRight(28)` for columnar data
- Array limit checking before file operations (e.g., 25 restaurant limit)
- Manual line counting to enforce capacity limits

### OOP Patterns (Week 3)

**Encapsulation** (`Restaurant.cs`):
- Auto-properties preferred over manual getters/setters (commented out old approach)
- Constructor-based initialization
- Override `ToString()` for display logic

**Inheritance** (`EmployeesBase`, `Developers`, `Managers`):
- Base class pattern with `base()` constructor calls
- Method overriding for specialized behavior (e.g., `SalaryWithTax`)
- Department/role hierarchy modeling

### Common Issues to Watch For
1. **Undeclared variables**: In the current code, `update` variable is used without declaration (line 262 in Program.cs)
2. **File existence**: Check `File.Exists()` before reading when file may not exist
3. **Index boundaries**: User-facing indices are 1-based; convert to 0-based for arrays
4. **Null handling**: Use nullable types (`string?`) and null-conditional operators (`?.`)

## Testing Approach
- Manual testing via console interaction
- No automated test framework currently in use
- Error messages follow pattern: `"Error: <specific reason>"`

## Comments Style
- Block comments at method start explain requirements/logic
- Inline comments explain specific steps with numbering: `[1]`, `[2]`
- Commented-out code preserved for learning reference (old approaches)
