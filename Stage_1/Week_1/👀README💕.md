# Stage 1 · Week 1

## Console Foundations in C#
This week is about learning the core execution flow of a C# console program and how to build a reliable input‑process‑output pipeline. The “architecture” here is intentionally simple: everything begins in `Program.cs`, and the flow is controlled by the `Main` method.

Rather than writing everything in one large block, you learn to structure the program into clear stages:

1. **Prompt the user** — explain what the program expects.
2. **Read input** — capture raw strings from `Console.ReadLine()`.
3. **Validate** — check for empty input or invalid formats.
4. **Convert types** — safely parse numbers using `TryParse`.
5. **Process** — apply formulas or loop logic.
6. **Output results** — format and display answers.

This is the backbone of every console application you will build later. The goal is not just to “get a result,” but to build a consistent, predictable pipeline that handles user input safely.

## Projects and What They Teach
### `a_FeetToInches`
Teaches a **single‑responsibility program**: read a number, apply a unit conversion, output the result. This is the simplest example of the input → process → output loop.

### `b_Convertings`
Focuses on **type conversion and parsing**. You learn why safe conversion matters and how `TryParse` prevents runtime exceptions.

### `c_Validation`
Introduces **guard clauses** and repeated prompting. The program keeps asking until the user provides valid input, establishing robust input validation patterns.

### `d_LoopExercise`
Explores **iteration**. You learn how to repeat actions, count, and control flow using `for` and `while` loops.

### `e_Week_1_Chalanges`
Combines the week’s ideas into mini‑challenges that require clean input handling, conversion, and looping..
