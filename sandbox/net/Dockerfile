# Use the official .NET SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# Set the working directory
WORKDIR /home/coder/project


# Clone the GitHub repository
RUN apt-get update && apt-get install -y git

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
WORKDIR /home/coder/project

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
ENV PASSWORD=joptrest

# Download and install the C# extension for code-server
RUN wget https://github.com/muhammadsammy/free-vscode-csharp/releases/download/2.34.12/csharp-platform-neutral-2.34.12.vsix -O csharp.vsix


# Switch back to coder user
USER coder
RUN code-server --install-extension csharp.vsix

USER root
# Clean up
RUN rm csharp.vsix

USER coder
# Start code-server and bind address
ENTRYPOINT ["/usr/bin/jopt-docker-entrypoint.sh", "--bind-addr", "0.0.0.0:8080", "."]

# Expose the port for code-server
EXPOSE 8080
