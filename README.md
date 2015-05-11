# WCFJsonIO
A WCF (C#) project with a I/O complex JSON data

#Introduction

I developed this project/tutorial, to implement a WCF Service with a method (named MyMethod...it's better than HelloWorld ;-) ) with a complex input/output data (see WCFJsonIO.Services.Contracts.ServiceJSONInput and WCFJsonIO.Services.Contracts.ServiceJSONResult).
<br/>
With this tutorial I will also show you how can you call (consume) a WCF method by passing data with JSON format via $http AngularJS service (see \Clients\Javascript\Client_AngularJS) and with jQuery $.ajax method (see \Clients\Javascript\Client_jQuery).
<br/>
This service also is configured (see Web.config of WCFJsonIO .Net solution) to return a JSON output of a ServiceJSONResult object.
<br/>
However, you can change the response format by setting to "Xml" the value of the attribute defaultOutgoingResponseFormat on the Web.config
<br/>
In a real scenario you can use this project as template to develop a WCF project with input/output complex data.

#How to use

- open the WCFJsonIO solution and start the project on the ServiceJSON.svc
- copy your server address
- setup Javascript clients source code (see Clients\Javascript) on your IDE

#AngularJS Client

Folder:\Clients\Javascript\Client_AngularJS
<br/>
See ClientController.js to understand how the WCF service method request works.
<br/>
However It's very simple:
<br/>
1) Define a scope variable for your input JSON data
<br/>
2) Perform a request with $http service


#jQuery Client

Folder:\Clients\Javascript\Client_jQuery
<br/>
See client.js to understand how the WCF service method request works.
<br/>
However It's very simple:
<br/>
1) Define a variable for your input JSON data
<br/>
2) Perform an ajax request with $.ajax method

<br/>
To test the javascript clients start the project with index.html file, insert your server address  (e.g http://localhost:60312/ServiceJSON.svc) click on the invoke button and see the service response on the browser javascript console.
<br/>
Into the client folder you can also find a WPF.Net client with an async call.


#Tests

Tests are implemented with NUnit framework.
<br/>
- ServiceJSONTest.cs:
<br/>
a) Call_MyMethod_With_No_Input_Data: it tests if MyMethod respond with an excpetion if input parameter is null
<br/>
b) Call_MyMethod_With_Input_Data: it tests if MyMethod called with a valid input data, will respond with a null exception, a not null message and with a customer equal to the input customer sent.
	


