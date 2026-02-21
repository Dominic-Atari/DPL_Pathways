# Stage 2 · Week 1

## JavaScript/TypeScript Architecture Basics
Stage 2 begins the transition from console apps to **browser‑based applications**. Your program is now split into three layers:

- **HTML** defines structure.
- **CSS** defines presentation.
- **JavaScript/TypeScript** defines behavior.

Instead of `Main`, the entry point is the **DOM event lifecycle**: once the page loads, your scripts wire up event listeners and respond to user actions.

## Architecture Pattern
1. **DOM elements** — inputs, buttons, and containers in HTML.
2. **Event listeners** — `click`, `submit`, `input` drive execution.
3. **Processing functions** — handle math, string logic, or list changes.
4. **Render step** — write results back into the DOM.
5. **Session state** — arrays/objects hold in‑memory data.

## Projects and What They Teach
### `HelloWorld`
Simple wiring from JavaScript into the HTML page.

### `Exercise`
Multiple DOM input/output mini‑flows.

### `ListPractice`
Dynamic lists and rendering updated content.

### `MeanModeMedian`
Data processing with clear separation of calculation vs. rendering.

### `Palindrome`
String validation and feedback patterns.

### `Survey`
Form input collection and display.

### `ToDoList`
CRUD flow in the browser with UI updates.

### `TypeScriptExample`
Introduction to typing and the compile‑to‑JS workflow.
