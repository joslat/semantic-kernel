// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;
using ProcessDemoGraphNodesEdges.Step00.Steps;

namespace ProcessDemoGraphNodesEdges.Step00;

public static class V2SimplestProcess
{
    public static class ProcessEvents
    {
        public const string StartProcess = nameof(StartProcess);
    }

    public static ProcessBuilder CreateProcess(string processName = nameof(SimplestProcess))
    {
        var processBuilder = new ProcessBuilder(processName);

        // Add steps
        var startStep = processBuilder.AddStepFromType<V2StartStep>();
        var doSomeWorkStep = processBuilder.AddStepFromType<V2DoSomeWorkStep>();
        var doMoreWorkStep = processBuilder.AddStepFromType<V2DoMoreWorkStep>();
        var endStep = processBuilder.AddStepFromType<V2EndStep>();

        // Configure the process flow 
        processBuilder
            .OnInputEvent(ProcessEvents.StartProcess)
            .SendEventTo(new ProcessFunctionTargetBuilder(startStep));

        startStep
            .OnFunctionResult()
            .SendEventTo(new ProcessFunctionTargetBuilder(doSomeWorkStep));

        doSomeWorkStep
            .OnFunctionResult()
            .SendEventTo(new ProcessFunctionTargetBuilder(doMoreWorkStep));

        doMoreWorkStep
            .OnFunctionResult()
            .SendEventTo(new ProcessFunctionTargetBuilder(endStep));

        endStep
            .OnFunctionResult()
            .StopProcess();

        return processBuilder;
    }

    public static async Task ExecuteAsync()
    {
        var processBuilder = CreateProcess();

        var kernelProcess = processBuilder.Build();

        var kernel = SemanticKernelHelper.CreateKernel();

        // Start the process by emitting the start event
        Console.WriteLine($"=== Start SK Process '{processBuilder.Name}' ===");
        using var runningProcess = await kernelProcess.StartAsync(kernel, new KernelProcessEvent
        {
            Id = ProcessEvents.StartProcess,
            Data = null
        });
        Console.WriteLine($"=== End SK Process '{processBuilder.Name}' ===");
    }
}
