<div align="center">
  <h1 align="center">Movie Characters API</h1>
  <h3 align="center">Entity Framework Core Database</h3>
  <p align="center">
    Entity Framework Code First workflow and an ASP.NET Core Web API in C#.
  </p>
</div>

<br>

## Table of contents

- [About The Project](#about-the-project)
- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Tools Used](#tools-used)
- [Installation](#installation)
- [Content and Functionality](#content-and-functionality)
- [Creators](#creators)

## About The Project

This is an ASP.NET Core Web API developed in C# using Entity Framework Code First. The API provides a way to manage movie franchises, characters, and movies associated with them.

## Getting Started

The application is made with C# and created in Visual Studio.

### Prerequisites

You need to install Visual Studio and use the C# extension and prerequisites while downloading the IDE.

#### NuGet packages:

- AutoMapper extensions for ASP.NET Core

- Microsoft.EntityFrameworkCore

- Microsoft.EntityFrameworkCore.SqlServer

- Microsoft.EntityFrameworkCore.Tools

- Microsoft.OpenApi

- Microsoft.VisualStudio.Web.CodeGeneration.Design

- Swashbuckle.AspNetCore


### Tools Used

Tools that were used in this project:

- [Visual Studio](https://visualstudio.microsoft.com/)
- [Marktext (Editor)](https://github.com/marktext/marktext)

## Installation

clone the repo like this:
`git clone https://github.com/bavelibrahim/EFCoreDb-project.git`

It is also possible to download the repo as a .zip.

## Content and Functionality

### Entity Framework Code First Workflow
The database schema is created using Entity Framework Code First workflow and should have the following requirements:

- Models and DbContext have been created to cater for the specifications mentioned in Appendix A.
- Data attributes have been used for proper configuration of datatypes.
- Navigation properties have been commented in each of the classes showing aspects of DbContext.
- Connection String has not been hard-coded into DbContext.

### Web API in ASP.NET Core
An ASP.NET Core Web API has been created and should have the following requirements:

- Controllers and DTOs have been created according to the specifications mentioned in Appendix B.
- DbContext has been encapsulated into Services for each domain entity, i.e. Movie, Character, and Franchise.
- Swagger/Open API documentation has been provided using annotations.
- Summary (///) tags have been provided for each method explaining what the method does, any exceptions it can throw, and what data it returns (if applicable). Overloaded methods do not have summary tags.

### Missing
- Getting Movies from Characters.
- Getting Characters from Movies.
- Getting Franchise from Movies.
- Updating Movies in Character.
- Updating Characters in Movies.
- Updating Franchises in Movies.

## Creators
Pavel Ibrahim & Johann Braaten
