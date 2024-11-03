// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public static class KernelProcessStepContextExtensions
{
    public static ValueTask EmitEventAsync(
        this KernelProcessStepContext context,
        string eventId,
        object data = null)
    {
        return context.EmitEventAsync(new KernelProcessEvent { Id = eventId, Data = data });
    }
}
