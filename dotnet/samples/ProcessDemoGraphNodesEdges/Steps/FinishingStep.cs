using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public class FinishingStep : SingleFunctionKernelProcessStep<FinishingStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("finishing");
        await context.EmitEventAsync(OutputEvents.Executed);
    }
}
