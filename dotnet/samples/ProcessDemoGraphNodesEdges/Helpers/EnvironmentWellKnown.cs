using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public static class EnvironmentWellKnown
{
    private static string? s_deploymentName;
    public static string DeploymentName => s_deploymentName ??= Environment.GetEnvironmentVariable("AzureOpenAI_Model");

    private static string? s_endpoint;
    public static string Endpoint => s_endpoint ??= Environment.GetEnvironmentVariable("AzureOpenAI_Endpoint");

    private static string? s_apiKey;
    public static string ApiKey => s_apiKey ??= Environment.GetEnvironmentVariable("AzureOpenAI_ApiKey");

    private static string? s_bingApiKey;
    public static string BingApiKey => s_bingApiKey ??= Environment.GetEnvironmentVariable("Bing_ApiKey");
}
