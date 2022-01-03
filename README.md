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

## Features
- User
  - Create a user
  - Update a user
  - Delete a user
  - List users
  - View a user
  - List my group channels
  - View push preferences

- Open channel
  - Create a channel
  - Update a channel
  - Delete a channel
  - List channels
  - View a channel

- Group channel
  - Create a channel
  - Update a channel
  - Delete a channel
  - List channels
  - View a channel
  - Invite
  - Leave

- Messages
  - Send a message (text/admin message)
  - Update a message (text/admin message)
  - List messages

## Usage
```c#
SendbirdConfiguration.SetAppId("[Your Sendbird Application ID here]");
SendbirdConfiguration.SetApiToken("[Your Sendbird API token here]");

var userService = new UserService();
var channelService = new ChannelService();
var messageService = new MessageService();

```

## Documentation
These API examples follows [Prepare to use API - Sendbird](https://sendbird.com/docs/chat/v3/platform-api/getting-started/prepare-to-use-api).
