# Sendbird

[![Nuget](https://img.shields.io/nuget/v/Sendbird)](https://www.nuget.org/packages/Sendbird)
[![.NET Standard](https://img.shields.io/badge/.NET%20Standard-%3E%3D%202.0-red.svg)](#)

## Description
Sendbird is sync/async .NET client, and a portable class library for the Sendbird API (Unofficial Library)

## Prerequisites
- .NET Standard 2.0

## Installation
Using the [.NET Core command-line interface (CLI) tools]

```sh
dotnet add package Sendbird
```

Using the [NuGet Command Line Interface (CLI)]

```sh
nuget install Sendbird
```

Using the [Package Manager Console]

```powershell
Install-Package Sendbird
```

## Usage
```c#
SendbirdConfiguration.SetAppId("[Your Sendbird Application ID here]");
SendbirdConfiguration.SetApiToken("[Your Sendbird API token here]");

var userService = new UserService();
var channelService = new ChannelService();
var messageService = new MessageService();

```
