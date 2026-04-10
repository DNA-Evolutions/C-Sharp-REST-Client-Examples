/*-
 * #%L
 * JOpt C# REST Client Examples
 * %%
 * Copyright (C) 2017 - 2022 DNA Evolutions GmbH
 * %%
 * This file is subject to the terms and conditions defined in file 'LICENSE.md',
 * which is part of this repository.
 *
 * If not, see <https://www.dna-evolutions.com/agb-conditions-and-terms/>.
 * #L%
 */

namespace Utils
{
    /// <summary>
    /// Provides predefined base URLs for connecting to JOpt TourOptimizer server instances.
    /// </summary>
    public static class Endpoints {

    /// <summary>
    /// Base URL for a locally running TourOptimizer server (default port 8081).
    /// </summary>
    public static string LOCAL_SWAGGER_TOUROPTIMIZER_URL = "http://localhost:8081";

    /// <summary>
    /// Base URL used when the client runs inside a Docker container and needs to reach
    /// a TourOptimizer server on the Docker host.
    /// </summary>
    public static string LOCAL_SWAGGER_TOUROPTIMIZER_FROM_DOCKER_URL = "http://host.docker.internal:8081";

    /// <summary>
    /// Base URL for the Azure-hosted TourOptimizer instance behind the API Management gateway.
    /// Requires an <c>Ocp-Apim-Subscription-Key</c> header.
    /// </summary>
    public static string AZURE_SWAGGER_TOUROPTIMIZER_URL = "https://joptaas.azure-api.net/touroptimizer/v2/";

}
}
