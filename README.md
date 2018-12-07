# Saab Student Project 2018
## Table of Contents
* [About](#About)
* [Get Started](#Get-Started)
    * [Required Software](#Required-Software)
    * [Software for Debugging](#Software-for-Debugging)
* [Project Details](#Project-Details)
    * [Folder Structure](#Folder-Structure)
    * [Common errors](#Common-errors)
    * [Project Documentation](#Project-Documentation)
    * [External Documentation](#External-Documentation)
## About
This is a Student Project made in cooperation with Saab. The aspiration of this project is to produce a prototype to meliorate the task of constructing Standard Instrument Arrival (STAR) along with the Standard Instrument Departure (SID) routes for Saabs flight leader training and simulation system.
## Get Started
### Required Software
This software is developed in C# on the .NET Framework, in order to compile this project, a copy of Visual Studio is required. The SQLiteDatabaseCommunicator requires the SQLite library in order to function. This can be acquired either from the SQLite website ([SQLite](https://sqlite.org/)) or from this repository (Check the project folder).
### Software for Debugging
Visual Studio includes a debugger, therefore the only external software to ease debugging is DB Browser for SQLite. This should allow opening, reading and writing to the database file.
## Project Details
### Folder Structure
![Folder Diagram](/Diagrams/Folders.PNG)

This folder tree is indented as a waypointer to find files in the project. The Database folder contains the SQlite database where the downloaded data is recorded. 
### Common errors
Common errors that may occur when compiling or running the project:
* Unimported Libraries
    * Make sure to import the SQLite Libraries, the library containing System.Web.script and Systems.xml from .NET.
* Solution unable to find Database or errors with the database
    * Make sure the database folder folder contains a correct database. This can just be cloned again in case the database structure has been tampered with.
* Problems connecting to the Remote LFV server.
    * Check your network connection and that you are able to connect to to LFV's WFS server (See: [External Dependencies](#External-Dependencies))
### External Dependencies
The system has an external depencies to the WFS service provided by LFV (Luftfartsverket).
```` C#
fixpoints = wc.DownloadString("http://daim.lfv.se/geoserver/ows?service=WFS&version=1.0.0&request=GetFeature&typeName=mais%3AWPT&outputFormat=json&name=test");

designated = wc.DownloadString("https://daim.lfv.se/geoserver/mais/ows?service=WFS&version=1.0.0&request=GetFeature&typeName=mais:DNPT&outputFormat=application%2Fjson");

dme = wc.DownloadString("https://daim.lfv.se/geoserver/mais/ows?service=WFS&version=1.0.0&request=GetFeature&typeName=mais:DME&outputFormat=application%2Fjson");
````
If the system is unable to connect to this service, the problem is probably on LFV's side, if the network does not block the connections. In the worst case a new data source needs to be procured. These are HTTP requests, therefore the respective JSON objects can be queried using for example a web browser.
### Project Documentation
There are two documents that document the system and its development. These are also located within this repository.
these documents are:

* [SRS - Software Requirements Specification](/docs/SRS_Flight_Route_Generator.pdf): Flight Route Generator
* [User Manual](/docs/Manual_Flight_Route_Generator.pdf): Flight Route Generator
### External Documentation
 * [SQLite Docs](https://sqlite.org/docs.html): The documentation for SQLite
 * [Microsoft .NET JSON Deserialization](https://docs.microsoft.com/en-us/dotnet/api/system.web.script.serialization.javascriptserializer.deserialize?view=netframework-4.7.2): The documentation for .NET desrialization from JSON
 * [Microsoft .NET XML Serialization](https://docs.microsoft.com/en-us/dotnet/api/system.xml.serialization?view=netframework-4.7.2): The documentation for .NET serialization to XML


