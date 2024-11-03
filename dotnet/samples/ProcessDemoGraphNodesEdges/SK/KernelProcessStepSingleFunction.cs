// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace ProcessDemoGraphNodesEdges;

public abstract class SingleFunctionKernelProcessStep<TStep> :
    KernelProcessStep where TStep :
    SingleFunctionKernelProcessStep<TStep>
{
    public static class Functions
    {
        public const string Execute = nameof(Execute);
    }

    public static class OutputEvents
    {
        public static string Executed => $"{typeof(TStep).Name}_{nameof(Executed)}";
    }

    public abstract ValueTask ExecuteAsync(KernelProcessStepContext context);
}

public abstract class SingleFunctionKernelProcessStep<TStep, TState> : KernelProcessStep<TState>
    where TStep : SingleFunctionKernelProcessStep<TStep, TState>
    where TState : class, new()
{
    public static class Functions
    {
        public static string Execute => nameof(Execute);
    }

    public static class OutputEvents
    {
        public static string Executed => $"{typeof(TStep).Name}_{nameof(Executed)}";
    }

    public abstract ValueTask ExecuteAsync(KernelProcessStepContext context);
}
