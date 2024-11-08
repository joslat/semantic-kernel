// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace Step00.Steps;

public sealed class StartStep : KernelProcessStep
{
    [KernelFunction()]
    public void ExecuteAsync()
    {
        Console.WriteLine("Step 1 - Start /n");
    }
}
