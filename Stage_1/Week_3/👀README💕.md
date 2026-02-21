# Stage 1 · Week 3

## Object‑Oriented Design in C#
Week 3 moves from procedural programs to **object‑oriented architecture**. The key shift is **separation of concerns**: instead of storing all logic in `Program.cs`, the design introduces classes that each represent a clear domain concept.

The architecture is now layered:

1. **Domain classes** — own their data and behavior.
2. **Constructors** — guarantee valid initialization.
3. **Methods** — encapsulate logic inside the class.
4. **Program orchestrator** — creates objects and coordinates flow.

This creates a system that is easier to extend without rewriting existing logic.

## Projects and What They Teach
### `Encapsulation`
Demonstrates how private fields and public properties protect data. Logic stays inside the class, not in `Main`.

### `Inheritance`
Introduces base and derived classes. Common fields and behavior live in the base class, while specialized behavior lives in subclasses.

### `Polymorphism`
Shows runtime polymorphism: code works with a base type while derived classes provide specific behavior. This eliminates long `if/else` chains.

### `z_Competency`
Combines encapsulation, inheritance, and polymorphism in a competency project that simulates real system design.
