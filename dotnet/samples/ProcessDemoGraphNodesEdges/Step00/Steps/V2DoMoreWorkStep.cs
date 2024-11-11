// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges.Step00.Steps;
public class V2DoMoreWorkStep : KernelProcessStep
{
    [KernelFunction]
    public async ValueTask ExecuteAsync(KernelProcessStepContext context)
    {
        Console.WriteLine("Step 3 - Doing Yet More Work...\n");
        // No need to emit custom events
    }
}
