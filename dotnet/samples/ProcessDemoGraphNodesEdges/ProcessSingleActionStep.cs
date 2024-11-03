using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public static class SimpleProcess
{
    public static class ProcessEvents
    {
        public const string StartProcess = nameof(StartProcess);
    }

    public static ProcessBuilder CreateProcess(string processName = nameof(SimpleProcess))
    {
        var processBuilder = new ProcessBuilder(processName);

        // Add steps
        var startStep = processBuilder.AddStepFromType<StartProcessStep>();
        var prepareStep = processBuilder.AddStepFromType<PrepareStep>();
        var doingWorkStep = processBuilder.AddStepFromType<DoingWorkStep>();
        var finishingStep = processBuilder.AddStepFromType<FinishingStep>();

        // Configure the process transitions
        processBuilder
            .OnInputEvent(ProcessEvents.StartProcess)
            .SendEventTo(new ProcessFunctionTargetBuilder(startStep));

        // When the intro is complete, notify the userInput step
        //startStep
        //    .OnFunctionResult(nameof(StartProcessStep.ExecuteAsync))
        //    .SendEventTo(new ProcessFunctionTargetBuilder(prepareStep));

        startStep
            .OnEvent(StartProcessStep.OutputEvents.Executed)
            .SendEventTo(new ProcessFunctionTargetBuilder(prepareStep));

        prepareStep
            .OnEvent(PrepareStep.OutputEvents.Executed)
            .SendEventTo(new ProcessFunctionTargetBuilder(doingWorkStep));

        doingWorkStep
            .OnEvent(DoingWorkStep.OutputEvents.Executed)
            .SendEventTo(new ProcessFunctionTargetBuilder(finishingStep));

        // Optionally, you can define what happens after finishing
        finishingStep
            .OnEvent(FinishingStep.OutputEvents.Executed)
            .StopProcess(); // Ends the process

        return processBuilder;
    }

    public static async Task ExecuteAsync()
    {
        // Create the process builder
        var processBuilder = SimpleProcess.CreateProcess();

        // Build the kernel process
        var kernelProcess = processBuilder.Build();

        // Create the kernel (assuming you have a method to create it)
        var kernel = SemanticKernelHelper.CreateKernel();

        // Start the process by emitting the start event
        Console.WriteLine($"=== Start SK Process '{processBuilder.Name}' ===");
        using var runningProcess = await kernelProcess.StartAsync(kernel, new KernelProcessEvent
        {
            Id = SimpleProcess.ProcessEvents.StartProcess,
            Data = null
        });
        Console.WriteLine($"=== End SK Process '{processBuilder.Name}' ===");
    }

}
