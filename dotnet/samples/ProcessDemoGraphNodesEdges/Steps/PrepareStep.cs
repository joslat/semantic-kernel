using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public class PrepareStep : SingleFunctionKernelProcessStep<PrepareStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("preparing");
        await context.EmitEventAsync(OutputEvents.Executed);
    }
}
