# Pipeline Filter Pattern

**Pipeline/Filter Pattern Implementation in C#**

This project contains two implementation :

- Implementation1 : Simpler
- Implementation2 : More Principled

```csharp
Pipeline<string> pipeline = new Pipeline<string>();

pipeline
    .Register(new ReplaceWorld()) // Step1 : Replace "World" with "Mohammad Javad"
    .Register(new UpperCaseString()); // Step2 : ToUpper() string

string input = "Hello World!";

string result = await pipeline.ExecuteAsync(input);

Console.WriteLine(result);

// Output
//-------------------------
// > HELLO MOHAMMAD JAVAD
//-------------------------
```

### More Resources :
- https://michaelscodingspot.com/pipeline-pattern-implementations-csharp/
- https://michaelscodingspot.com/pipeline-pattern-tpl-dataflow/
- https://www.codeproject.com/Articles/1094513/Pipeline-and-Filters-Pattern-using-Csharp
- https://www.codeproject.com/Tips/843127/Simple-Pipeline-Implementation-in-Csharp
