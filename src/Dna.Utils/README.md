# C# Dna.Utils

C# Dna.Utils is a collection of wrapper classes to use the JOpt TourOptimizer suite.

## The Architecture
The utils project is subdivided into different parts:

1. **endpoints:** The definition of the default endpoints to be used for Azure and the local TourOptimizer instance. (Please modify to your needs)
2. **json:** Custom JsonConverter implemnations for `CoreBuildOptions` and `OptimizationOptions`. If not invoked, the JSON-serialization with Newtonsoft will fail!
3. **restcaller**: The default entry point to start an optimization run. An `HttpClient` is created, and all necessary protocols, converters etc., are invoked. 
4. **testinputcreation**: Helper classes for generating test input.  (Please modify to your needs)
