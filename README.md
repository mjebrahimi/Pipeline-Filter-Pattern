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