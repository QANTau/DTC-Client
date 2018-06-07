# DTC Protocol Client Library

This project contains a C# library and a sample implementation for accessing services realtime and historical data via the DTC Protocol (www.dtcprotocol.org).

The library has no external dependencies, although the sample client application uses an external library to aid in display of message results.

## Important Notes 

* This library was originally developed to allow SmartQuant products (OpenQuant / QuantRouter / QuantBase) to access SierraChart data feeds.  There is a SmartQuant Provider that uses this library available [here](https://github.com/QANTau/DTC-SmartQuant-Provider).

* Only a small number of DTC message types are supported, although any unsupported messages are handled (altough the results are not processed).

* This project compiles x64 using .NET Framework 4.5.1.  

* Only Binary encoding is currently supported.




