# What is this?

The following is a RESTful API in C# .Net Core 3.1, XUnit and FluentAssertions for unit testing.
This API takes an input file in JSON format.

## Overview

RESTful API that injects a Service class to deserialize a string to a JSON Object.
This Service class also adds the IDs of the Items if a Label exist.

## Requirements:

- Install .Net Core 3.1 SDK on the machine that will build and run the API
you can get it from https://dotnet.microsoft.com/download/dotnet/current
- VSCode to view source code
- PostMan to call API 

## Run Test Cases:

- Copy the source code folders to local machine
	- For example `D:\Code\MenuSumIds`
- Using a command line change directory to base of your source code
	- For Example on windows cd `D:\Code\MenuSumIds`
- To run the test cases execute the following command `dotnet test`
this will show the results of the unit test and show result.

## Run API and Call using PostMan:

- Create an `input.txt` file to a desire location
	- For example on windows `D:\Code\inut.txt`
- Using a command line change directory to API project source code
	- For Example on windows cd `D:\Code\MenuSumIds\MenuSumIdsApi`
- To run the API execute the following command `dotnet run` 
- Using PostMan create a new POST Request URL:
	- https://localhost:5001/MenuOperation/ReadMenuFile
	- Header: Key = Content-Type; VALUE = multipart/form-data
	- Body: form-data => Key = inputFile; VALUE = `YourInputFIle.txt`
- Send the POST Request and result will be in Response Body.
