// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Runtime.Serialization;

namespace Microsoft.SemanticKernel;

/// <summary>
/// A serializable representation of an edge between a source <see cref="KernelProcessStep"/> and a <see cref="KernelProcessFunctionTarget"/>.
/// </summary>
[DataContract]
[KnownType(typeof(KernelProcessFunctionTarget))]
public sealed class KernelProcessEdge
{
    /// <summary>
    /// The unique identifier of the source Step.
    /// </summary>
    [DataMember]
    public string SourceStepId { get; init; }

    /// <summary>
    /// The unique identifier of the target Step.
    /// </summary>
    [DataMember]
    public string TargetStepId { get; init; }

    /// <summary>
    /// The condition that must be met for the edge to be traversed.
    /// </summary>
    [IgnoreDataMember]
    public Func<object, bool>? Condition { get; init; }

    /// <summary>
    /// The collection of <see cref="KernelProcessFunctionTarget"/>s that are the output of the source Step.
    /// </summary>
    [DataMember]
    public KernelProcessFunctionTarget OutputTarget { get; init; }

    /// <summary>
    /// Creates a new instance of the <see cref="KernelProcessEdge"/> class.
    /// </summary>
    public KernelProcessEdge(string sourceStepId, KernelProcessFunctionTarget outputTarget)
    {
        Verify.NotNullOrWhiteSpace(sourceStepId);
        Verify.NotNull(outputTarget);

        this.SourceStepId = sourceStepId;
        this.OutputTarget = outputTarget;
        this.TargetStepId = outputTarget.StepId;
    }

    public KernelProcessEdge(
        string sourceStepId,
        KernelProcessFunctionTarget outputTarget,
        Func<object, bool>? condition)
        : this(sourceStepId, outputTarget)
    {
        this.Condition = condition;
    }
}
