# DTC Protocol Client Library

This project contains a C# library and a sample implementation for accessing services realtime and historical data via the DTC Protocol (www.dtcprotocol.org).

The sample client application is intended to be used as an aid to understanding the DTC Protocol rather than as a standalone data management/viewing tool.

* Only a small number of DTC message types are supported, although any unsupported messages are handled (altough the results are not processed).

* This project compiles x64 using .NET Framework 4.5.1.  

* Other than for the intial negotiation, only Json encoding is supported.

This library was originally developed to allow SmartQuant products (OpenQuant / QuantRouter / QuantBase) to access SierraChart data and execution services and isn't actively maintained publicly due to the use of a commercial TCP library for communications.

