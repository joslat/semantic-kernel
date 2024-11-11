// Copyright (c) Microsoft. All rights reserved.

using ProcessDemoGraphNodesEdges;
using ProcessDemoGraphNodesEdges.Step00;

Console.WriteLine("Hello, Process Framework!");

//await SimpleProcess.ExecuteAsync();
//await ConditionalProcess.ExecuteAsync();
//await SimplestProcess.ExecuteAsync();

await V2SimplestProcess.ExecuteAsync();
