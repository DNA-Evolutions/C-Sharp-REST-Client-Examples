#!/bin/sh
set -eu

# Start the .NET application
#dotnet TourOptimizerConstraintExample.dll &

dotnet restore
dotnet build

# Start code-server
dumb-init /usr/bin/code-server "$@"