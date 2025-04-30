## Note
This is my solution to the problem described above.
The most challenging part for me was finding the right balance between an overengineered approach and one that was overly simplistic (like a single-file implementation).  
I believe mine leans more toward simplicity than sophistication. Apporach here is to deliver a basic working version quickly, gather feedback, iterate, and move forward, rather than solve a problem that you don't have enough information about.  

## How to run
There is a console application `PointOfSaleScanner.Console` added specifically to run a library app. This is a just a wrapper to run a code from library. Please use it.
You can also find unit tests that validates different part of the solution alongside with PointOfSaleTerminal - an entry point to the code.

### Prerequisites 
- You'll need dotnet 8 installed on your machine
- Also dotnet cli to run the code \ IDE (Visual Studio, Rider, etc) to test or debug

### Run the code

1. open solution folder
2. run in the cmd

```
cd PointOfSaleScanner.Console
```  
```
dotnet run
```  


