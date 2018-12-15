# Benchmarks

## Delegate vs Interface

```
BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.134 (1809/October2018Update/Redstone5)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.100
  [Host] : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3190.0
  Core   : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


    Method |  Job | Runtime |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |
---------- |----- |-------- |---------:|----------:|----------:|---------:|------:|--------:|
    Direct |  Clr |     Clr | 4.727 ns | 0.1549 ns | 0.1293 ns | 4.722 ns |  1.00 |    0.00 |
  Delegate |  Clr |     Clr | 5.619 ns | 0.4763 ns | 1.3667 ns | 5.059 ns |  1.42 |    0.24 |
 Interface |  Clr |     Clr | 4.509 ns | 0.1426 ns | 0.1264 ns | 4.467 ns |  0.95 |    0.04 |
           |      |         |          |           |           |          |       |         |
    Direct | Core |    Core | 4.298 ns | 0.1703 ns | 0.2091 ns | 4.278 ns |  1.00 |    0.00 |
  Delegate | Core |    Core | 4.364 ns | 0.1193 ns | 0.1116 ns | 4.368 ns |  1.00 |    0.05 |
 Interface | Core |    Core | 4.530 ns | 0.1516 ns | 0.1418 ns | 4.499 ns |  1.03 |    0.05 |
```

## Equals: OrdinalIgnoreCase vs InvariantCultureIgnoreCase vs ToUpper

```
BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.194 (1809/October2018Update/Redstone5)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.2.100
  [Host] : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT
  Clr    : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3260.0
  Core   : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT


                           Method |  Job | Runtime |      Mean |      Error |    StdDev |    Median | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
--------------------------------- |----- |-------- |----------:|-----------:|----------:|----------:|------------:|------------:|------------:|--------------------:|
          EqualsOrdinalIgnoreCase |  Clr |     Clr |  15.76 ns |  0.4849 ns |  1.407 ns |  15.66 ns |           - |           - |           - |                   - |
 EqualsInvariantCultureIgnoreCase |  Clr |     Clr | 106.85 ns |  2.9591 ns |  8.150 ns | 108.23 ns |           - |           - |           - |                   - |
                    EqualsToUpper |  Clr |     Clr | 276.29 ns | 16.7876 ns | 46.518 ns | 258.82 ns |      0.0186 |           - |           - |                80 B |
          EqualsOrdinalIgnoreCase | Core |    Core |  25.55 ns |  0.6241 ns |  1.750 ns |  25.41 ns |           - |           - |           - |                   - |
 EqualsInvariantCultureIgnoreCase | Core |    Core | 105.41 ns |  2.1510 ns |  2.944 ns | 104.53 ns |           - |           - |           - |                   - |
                    EqualsToUpper | Core |    Core | 104.47 ns |  2.1157 ns |  5.499 ns | 103.42 ns |      0.0190 |           - |           - |                80 B |
```