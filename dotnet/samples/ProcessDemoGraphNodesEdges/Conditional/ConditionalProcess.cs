// Copyright (c) Microsoft. All rights reserved.

using System.Diagnostics;
using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public static class ConditionalProcess
{
    public static class ProcessEvents
    {
        public const string StartProcess = nameof(StartProcess);
    }

    public static ProcessBuilder CreateConditionalProcess(string processName = nameof(ConditionalProcess))
    {
        var processBuilder = new ProcessBuilder(processName);

        var checkValueStep = processBuilder.AddStepFromType<CheckValueStep>();
        var positiveStep = processBuilder.AddStepFromType<PositiveStep>();
        var negativeStep = processBuilder.AddStepFromType<NegativeStep>();

        // Start the process
        processBuilder
            .OnInputEvent(ProcessEvents.StartProcess)
            .SendEventTo(new ProcessFunctionTargetBuilder(checkValueStep));

        // Conditional transitions using Func<object, bool>
        checkValueStep
            .OnEvent(CheckValueStep.OutputEvents.Executed)
            .When(data => (int)data > 0)
            .SendEventTo(new ProcessFunctionTargetBuilder(positiveStep));

        checkValueStep
            .OnEvent(CheckValueStep.OutputEvents.Executed)
            .When(data => (int)data <= 0)
            .SendEventTo(new ProcessFunctionTargetBuilder(negativeStep));

        // End the process
        positiveStep
            .OnEvent(PositiveStep.OutputEvents.Executed)
            .StopProcess();

        negativeStep
            .OnEvent(NegativeStep.OutputEvents.Executed)
            .StopProcess();

        return processBuilder;
    }

    public static async Task ExecuteAsync()
    {
        // Create the process builder
        var processBuilder = ConditionalProcess.CreateConditionalProcess();

        // Build the kernel process
        var kernelProcess = processBuilder.Build();

        // Create the kernel (assuming you have a method to create it)
        var kernel = SemanticKernelHelper.CreateKernel();

        // Start the process by emitting the start event
        Console.WriteLine($"=== Start SK Process '{processBuilder.Name}' ===");

        // Create the initial event with data
        var initialEvent = new KernelProcessEvent
        {
            Id = SimpleProcess.ProcessEvents.StartProcess,
            Data = -5 // Change this value to test different paths
        };

        // Start the process
        var runningProcess = await kernelProcess.StartAsync(kernel, initialEvent);

        // Optionally, stop the process if it's still running
        await runningProcess.StopAsync();

        Console.WriteLine($"=== End SK Process '{processBuilder.Name}' ===");
    }
}
