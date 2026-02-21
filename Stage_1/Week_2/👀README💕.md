# Stage 1 · Week 2

## Arrays and File Handling in C#
Week 2 expands the architecture from single values to **collections** and **persistence**. Instead of one input producing one output, you now manage **multiple items** using arrays and store them in text files so the program can remember data between runs.

The architecture evolves into a 5‑stage pipeline:

1. **Load** — read saved data from a file into memory.
2. **Input loop** — accept multiple values or commands.
3. **Process** — search arrays, update entries, or compute results.
4. **Persist** — save updated arrays back to the file.
5. **Display** — print formatted output.

This week teaches that data structures and persistence change how you design your program. You must think about storage limits, indexing, and how to prevent out‑of‑range errors.

## Projects and What They Teach
### `1_Aray`
Introduces array creation, indexing, and iteration. You learn how to store multiple values and access them safely.

### `ChalangeArrays`
Focuses on problem solving with arrays: searching, filtering, and counting elements.

### `FileHandling`
Demonstrates file persistence. You learn how to **load** data with `StreamReader` and **append/save** with `StreamWriter`.

### `Week_Chalange`
Combines arrays and file handling into a larger challenge. This is the first step toward designing a small system rather than a single‑purpose script.
