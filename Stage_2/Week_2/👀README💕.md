# Stage 2 · Week 2

## API‑Driven Architecture
Week 2 introduces **external data sources** and asynchronous logic. The architecture expands to include a **data access layer** that fetches remote JSON, transforms it into display models, and renders results into the UI.

## Architecture Pattern
1. **Fetch** — call APIs using `fetch()` or framework HTTP tools.
2. **Parse** — turn JSON into JavaScript/TypeScript objects.
3. **Transform** — map raw API fields into display‑friendly structures.
4. **Render** — update DOM or component state.
5. **Error handling** — show user‑friendly failure messages.

## Projects and What They Teach
### `GitHub_Api`
Profile lookup and rendering from GitHub data.

### `Reddit_Api`
List rendering and iteration over remote data.

### `Weather_Api`
Live data retrieval and structured display.

### `First-angular-app`
Framework‑based component structure and data flow.

### `z_Chalange`
Aviation tracker that combines API calls, DOM updates, and modal UI patterns.
