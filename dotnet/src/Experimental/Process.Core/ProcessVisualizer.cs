// Copyright (c) Microsoft. All rights reserved.

using System;
using System.Linq;
using System.Text;
using Microsoft.SemanticKernel.Process.Internal;

namespace Microsoft.SemanticKernel;

/// <summary>
/// Provides extension methods to visualize a process as a Mermaid diagram.
/// </summary>
public static class ProcessVisualizer
{
    /// <summary>
    /// Generates a Mermaid diagram from a process builder.
    /// </summary>
    /// <param name="processBuilder"></param>
    /// <returns></returns>
    public static string ToMermaid(this ProcessBuilder processBuilder)
    {
        var process = processBuilder.Build();
        return process.ToMermaid(); //ToMermaid(process);
    }

    /// <summary>
    /// Generates a Mermaid diagram from a kernel process.
    /// </summary>
    /// <param name="process"></param>
    /// <returns></returns>
    public static string ToMermaid(this KernelProcess process)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("flowchart LR");
        //sb.AppendLine("graph LR");

        // Dictionary to map step IDs to step names
        var stepNames = process.Steps.ToDictionary(
            step => step.State.Id,
            step => step.State.Name);

        // Add Start and End nodes with proper Mermaid styling
        sb.AppendLine("Start[Start]");
        sb.AppendLine("End[End]");

        // Handle all edges without a predefined "Start"
        foreach (var kvp in process.Edges)
        {
            var stepId = kvp.Key;
            var edges = kvp.Value;

            foreach (var edge in edges)
            {
                string targetStepName = stepNames[edge.TargetStepId];

                // Link edges without a specific preceding step to the Start node
                if (!process.Steps.Any(s => s.Edges.ContainsKey(stepId)))
                {
                    sb.AppendLine($"Start[Start] --> {targetStepName}[{targetStepName}]");
                }
            }
        }


        // Process each step
        foreach (var step in process.Steps)
        {
            var stepId = step.State.Id;
            var stepName = step.State.Name;

            // Handle edges from this step
            if (step.Edges != null)
            {
                foreach (var kvp in step.Edges)
                {
                    var eventId = kvp.Key;
                    var stepEdges = kvp.Value;

                    foreach (var edge in stepEdges)
                    {
                        string source = $"{stepName}[{stepName}]";
                        string target;

                        // Check if the target step is the end node by function name
                        if (edge.OutputTarget.FunctionName.Equals("end", StringComparison.InvariantCultureIgnoreCase))
                        {
                            target = "End[End]";
                        }
                        else
                        {
                            string targetStepName = stepNames[edge.TargetStepId];
                            target = $"{targetStepName}[{targetStepName}]";
                        }

                        // Handle conditions, if any
                        string conditionLabel = edge.Condition != null ? "|Condition|" : "";

                        // Append the connection without showing IDs
                        sb.AppendLine($"{source} -->{conditionLabel} {target}");
                    }
                }
            }
        }

        return sb.ToString();
    }
}
