#!/bin/sh
set -eu

echo "Trying to download C-Sharp-REST-Client-Examples"

folder="/home/coder/project/csharp.rest.examples/"
url="https://github.com/DNA-Evolutions/C-Sharp-REST-Client-Examples.git"

# Clone the repository if the folder does not exist
if [ ! -d "${folder}" ]; then
    echo "Cloning repository from ${url} to ${folder}"
    git clone "${url}" "${folder}"
else
    echo "Clone skipped as the folder ${folder} already exists. If you want a 'fresh' clone, choose another volume or rename the existing folder."
fi

# Build in specific project dir
cd ${folder}


echo "Trying to restore and build projects"
dotnet restore
dotnet build


echo "Starting code-server"

# Start code-server
dumb-init /usr/bin/code-server "$@"