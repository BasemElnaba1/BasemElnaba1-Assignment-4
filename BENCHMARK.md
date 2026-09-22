# BenchmarkDotNet Results

Run the benchmark on your own machine in Release mode:

```bash
dotnet run -c Release --project AcademyScheduleAnalyzer -- --benchmark
```

Paste the BenchmarkDotNet result table below. The assignment requires results produced on your own machine.

```text
<paste-your-BenchmarkDotNet-results-here>
```

## Analysis

### Which approach was faster with 100 iterations?

Complete this answer using your measured results: `<answer>`

### Which approach was faster with 100,000 iterations?

Complete this answer using your measured results: `<answer>`

### Which approach allocated more memory?

Complete this answer using the `Allocated` column: `<answer>`

### What happened to string concatenation performance as the loop size increased?

Repeated concatenation became increasingly expensive as the result grew because each operation had to create and populate another string. Confirm this statement using your measured timings.

### Why does repeated string concatenation create additional allocations?

`string` is immutable. Concatenation cannot modify the existing string, so it creates a new string containing the previous text plus the appended text.

### Why does StringBuilder usually perform better when text is repeatedly appended?

`StringBuilder` appends into a reusable, growable buffer. This normally avoids creating a new complete string for every append operation.

### Is StringBuilder always better than normal string operations?

No. Simple interpolation or a small number of concatenations is clearer and may be equally fast or faster. `StringBuilder` is most useful for repeated or dynamic appends, especially inside large loops. Use your benchmark results to support the final wording.
