# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory
WORKDIR /app

# Clone the GitHub repository
RUN apt-get update && apt-get install -y git \
    && git clone https://github.com/DNA-Evolutions/C-Sharp-REST-Client-Examples.git .

# Restore dependencies
# RUN dotnet restore

# Build the application
# RUN dotnet publish -c Release -o out

# Use the official code-server image as the base image for the runtime
FROM codercom/code-server:4.91.0-debian

# Switch to root user to install .NET runtime dependencies
USER root

# Install .NET runtime dependencies
RUN apt-get update && apt-get install -y --no-install-recommends \
    libgdiplus \
    libc6-dev \
    libicu-dev \
    wget \
    unzip \
    && rm -rf /var/lib/apt/lists/*

# Set the working directory
WORKDIR /app

# Copy the entire application source from the build environment
COPY --from=build-env /app .

# Change ownership of the /app directory to the coder user
RUN chown -R coder:coder /app

# Copy entrypoint script for starting code-server and the application
COPY ./jopt-docker-entrypoint.sh /usr/bin/

# Change permissions for the entrypoint script
RUN chmod +x /usr/bin/jopt-docker-entrypoint.sh

# Install .NET runtime
RUN wget https://dotnet.microsoft.com/download/dotnet/scripts/v1/dotnet-install.sh
RUN chmod +x dotnet-install.sh
RUN ./dotnet-install.sh --channel 8.0 --install-dir /usr/share/dotnet
ENV PATH="$PATH:/usr/share/dotnet"

# Add dotnet to PATH for the coder user
RUN echo 'export PATH="$PATH:/usr/share/dotnet"' >> /home/coder/.bashrc
RUN echo 'export PATH="$PATH:/usr/share/dotnet"' >> /home/coder/.profile

# Set password for code-server
ENV PASSWORD=jopt

# Download and install the C# extension for code-server
RUN wget https://github.com/muhammadsammy/free-vscode-csharp/releases/download/2.34.12/csharp-platform-neutral-2.34.12.vsix -O csharp.vsix
#RUN code-server --install-extension csharp.vsix

# Clean up
#RUN rm csharp.vsix

# Switch back to coder user
USER coder

RUN code-server --install-extension csharp.vsix

# Start code-server and bind address
ENTRYPOINT ["/usr/bin/jopt-docker-entrypoint.sh", "--bind-addr", "0.0.0.0:8080", "."]

# Expose the port for code-server
EXPOSE 8080
