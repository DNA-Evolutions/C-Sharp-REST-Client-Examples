# C# Dna.Examples

C# Dna.Examples are a collection of examples of using the JOpt TourOptimizer suite. The examples are utilizing the Dna.Utils project.

## The Architecture
The utils project is subdivided into different parts:


### TourOptimizer 
Examples dealing with the use of DNA's JOpt containerized TourOptimizer, either via Azure as a service or a local docker instance. Please refer to  <a href="https://github.com/DNA-Evolutions/Docker-REST-TourOptimizer#how-to-start-jopttouroptimizer-docker" target="_blank">"How to start JOpt TourOptimizer in docker"</a> for more help.

**1. optimize\TourOptimizerExample.cs:** Basic example on how to call the JOpt TourOptimizer service

**2. constraint\TourOptimizerConstraintExample.cs:** Basic example on how to set constraints on nodes and resources