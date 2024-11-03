using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;


public sealed class StartProcessStepSimple : KernelProcessStep
{
    [KernelFunction()]
    public void ExecuteAsync()
    {
        Console.WriteLine("start /n");
    }
}


public sealed class StartProcessStep : SingleFunctionKernelProcessStep<StartProcessStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("start /n");
        await context.EmitEventAsync(OutputEvents.Executed);
    }
}
