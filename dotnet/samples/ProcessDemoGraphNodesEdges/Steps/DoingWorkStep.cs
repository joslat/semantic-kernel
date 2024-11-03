using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public class DoingWorkStep : SingleFunctionKernelProcessStep<DoingWorkStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("doing work");
        await context.EmitEventAsync(OutputEvents.Executed);
    }
}
