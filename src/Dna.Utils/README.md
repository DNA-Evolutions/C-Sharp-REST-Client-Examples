# C# Dna.Utils

C# Dna.Utils is a collection of wrapper classes to use the JOpt TourOptimizer suite.

**Requires JOpt TourOptimizer Server 1.3.5 or newer.**

## The Architecture
The utils project is subdivided into different parts:

1. **endpoints/** (`Endpoints.cs`): Predefined server URL constants for Azure, local, and Docker-internal TourOptimizer instances. Modify these to match your deployment.

2. **restcaller/** (`TourOptimizerRestCaller.cs`): The main entry point for interacting with the TourOptimizer API. Wraps the generated `OptimizationApi` (for synchronous runs using `runId`) and `JobApi` (for asynchronous fire-and-forget jobs using `jobId`). Handles the full optimization lifecycle: submitting runs, subscribing to SSE streams for real-time progress/status, and retrieving results. Also supports database operations for persisted job management (search, load).

3. **testinputcreation/**: Helper classes for generating test input:
   - `TestRestOptimizationCreator.cs` - Factory for creating default `RestOptimization` inputs with license key, algorithm properties, and timeout settings.
   - `TestElementCreator.cs` - Factory for creating default `Node` and `Resource` instances with working hours, opening hours, constraints, and qualifications (type-based and zone-based).
   - `TestPositionsInput.cs` - Predefined geographic position sets for Sydney (Australia) and New York area (Manhattan, New Jersey City) test scenarios.
