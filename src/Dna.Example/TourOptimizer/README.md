# C# Dna.Examples

C# Dna.Examples are a collection of examples of using the JOpt TourOptimizer suite. The examples are utilizing the Dna.Utils project.

## The Architecture
The utils project is subdivided into different parts:


### TourOptimizer 
Examples dealing with the use of DNA's JOpt containerized TourOptimizer, either via Azure as a service or a local docker instance. Please refer to  <a href="https://github.com/DNA-Evolutions/Docker-REST-TourOptimizer#how-to-start-jopttouroptimizer-docker" target="_blank">"How to start JOpt TourOptimizer in docker"</a> for more help.

**1. optimize\TourOptimizerExample.cs:** Basic example on how to call the JOpt TourOptimizer service

**2. constraint\TourOptimizerConstraintExample.cs:** Basic example on how to set constraints on nodes and resources

**3. optimizeFAF\TourOptimizerFAFExample.cs:** Demonstrates how to run an optimization and save it to the database

**4. searchFAF\TourOptimizerSearchFAFExample.cs:** Shows how to search optimizations within a database and display their meta info

**5. loadFAF\TourOptimizerLoadFAFExample.cs:** Guides how to load an optimization from a database

For setting up a local test enviorment with database support, please refer to the separate **Hands-on Tutorial: Setting Up a Local Fire and Forget TourOptimizer-Database Test Environment** [tutorial](https://github.com/DNA-Evolutions/Docker-REST-TourOptimizer/blob/main/TourOptimizerWithDatabase.md).