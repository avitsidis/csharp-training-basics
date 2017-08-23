# First exercice : Hello C# !

## Configuration, Assemblies, Types & Properties

### Configuration file

- add an appSettings entry named 'myparameter' with value 'foobar'
- Access Configuration content with System.Configuration.ConfigurationManager.AppSettings and print myparameter value in console output 

### Class Library
- create new assembly named Model
- create a class Person 
- add a string property LastName in Person
- add a string property FirstName in Person
- add a string property NISS in Person (NISS can only contain digits)
- add reference in HelloWorld to Model
- in HelloWorld assembly, instanciate some Person objects and print them in the console
- override ToString() method in class Person (returns "FirstName LastName(NISS)")
- add a DateTime property Birthdate in Person
- add a Computed int property Age in Person (get only, no set)
- create a class Consultant that inherits from Person
- add a Date property HireDate
- reimplement Birthdate to enforce that consultants must be older than 18 years old
- override ToString() method in class Person (returns "FirstName LastName(NISS) # years of experience")
- change assembly version of Model to 2.0.0.0

### Nuget packages
- Install nuget package Colorful.Console
- use this library to change output to yellow in console