# Stage 1 · Week 4

## Abstraction, Interfaces, and Collections
Week 4 teaches how to design **contracts** and manage **groups of objects**. The architecture includes abstract base classes and interfaces that define what a class must do, while concrete classes define how they do it.

This pushes you toward **extensible design**: new types can be added without changing the processing logic.

## Architecture Pattern
1. **Abstract base class** — shared state and method templates.
2. **Interface contracts** — define required behaviors.
3. **Concrete implementations** — provide the actual logic.
4. **Collections** — store multiple objects in `List<T>`.
5. **Orchestration** — loop over objects and call shared methods.

## Projects and What They Teach
### `EmployeeWithAbstractAnList`
Demonstrates abstract classes plus lists of employees for unified processing.

### `InterfaceExercise`
Highlights interfaces and polymorphism across unrelated types.

### `z_Competency`
Applies abstraction and interfaces to a banking/account domain model.
