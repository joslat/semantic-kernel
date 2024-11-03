using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public static class SemanticKernelHelper
{
    public static Kernel CreateKernel()
    {
        var builder = Kernel.CreateBuilder();
        builder.Services.AddSingleton<IFunctionInvocationFilter, SearchFunctionFilter>();

        Kernel kernel = builder.AddAzureOpenAIChatCompletion(
                            deploymentName: EnvironmentWellKnown.DeploymentName,
                            endpoint: EnvironmentWellKnown.Endpoint,
                            apiKey: EnvironmentWellKnown.ApiKey)
                        .Build();

        return kernel;
    }
}
