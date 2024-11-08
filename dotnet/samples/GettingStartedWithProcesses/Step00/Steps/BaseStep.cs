// Copyright (c) Microsoft. All rights reserved.

using Microsoft.SemanticKernel;

namespace Step00.Steps;

public abstract class BaseStep<TStep> :
    KernelProcessStep where TStep :
    BaseStep<TStep>
{
    public static class Functions
    {
        public const string Execute = nameof(Execute);
    }

    public static class OutputEvents
    {
        public static string Executed => $"{typeof(TStep).Name}_{nameof(Executed)}";
    }
}
