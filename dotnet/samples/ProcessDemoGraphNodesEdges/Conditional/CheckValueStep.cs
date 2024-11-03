// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public class CheckValueStep : SingleFunctionKernelProcessStep<CheckValueStep>
{
    [KernelFunction(Functions.Execute)]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context, object data)
    {
        Console.WriteLine("CheckValueStep - start");

        int value = data is int intValue ? intValue : 0;
        Console.WriteLine($"Checking value: {value}");

        await context.EmitEventAsync(OutputEvents.Executed, value);
        Console.WriteLine("CheckValueStep - end");
    }

    //public static class OutputEvents
    //{
    //    public static string Checked => $"{nameof(CheckValueStep)}_Checked";
    //}
}
