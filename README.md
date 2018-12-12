# Benchmarks

## Delegate vs Interface

```
BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.134 (1809/October2018Update/Redstone5)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.100
  [Host] : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3190.0
  Core   : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


    Method |  Job | Runtime |     Mean |     Error |    StdDev |
---------- |----- |-------- |---------:|----------:|----------:|
  Delegate |  Clr |     Clr | 3.533 ns | 0.1081 ns | 0.1367 ns |
 Interface |  Clr |     Clr | 3.933 ns | 0.1139 ns | 0.1118 ns |
  Delegate | Core |    Core | 3.503 ns | 0.0888 ns | 0.0831 ns |
 Interface | Core |    Core | 4.304 ns | 0.0965 ns | 0.0806 ns |
```