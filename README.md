This repo is an example of a working **.NET Console App** that uses [Stream Unity SDK](https://github.com/GetStream/stream-chat-unity).

## How to run?
Open Program.cs and enter your: **API_KEY**, **USER_ID** and **USER_TOKEN** in the top of the file:
```
var authCredentials = new AuthCredentials(
    apiKey: "",
    userId: "",
    userToken: "");
```

- **API_KEY** - get it from [Stream's Dashboard](https://dashboard.getstream.io/)
- **USER_ID** - for the purpose of testing you can create a test user through Dashboards Chat Explorer
- **USER_TOKEN** - for the purpose of testing you can create token with our [online token generator](https://getstream.io/chat/docs/unity/tokens_and_authentication/?language=unity#manually-generating-tokens)

For a more robust testing checkout how to enable [Developer's Tokens](https://getstream.io/chat/docs/unity/tokens_and_authentication/?language=unity#developer-tokens)

## Please note that from the whole SDK package only 2 folders are essential:
- **StreamChat.Core** - main logic of the SDK, contains no dependencies of the **UnityEngine**
- **StreamChat.Libs** - Core dependencies


## In order to run the SDK wihout UnityEngine you need to:
1. Remove Unity implementations from the **StreamChat.Libs**
2. Provide new platform specific implementations


## Steps taken:
1. Create .NET Console Application
2. Copy StreamChat.Core & StreamChat.Libs into the project & Include them in the solution
3. Import Newtonsoft.Json via NuGet
4. Add .NET dependencies to the project:
	- System.Net.Http
	- System.Runtime.Serialization
5. Delete Unity specific files:
	- AuthCredentialsAsset.cs
	- UnityTime.cs
	- UnityLogs.cs
	- TimeLogScope.cs
6. Define alternative implementations of:
	- ILogs
	- ITimeService
7. Modify LibsFactory.cs to replace the ILogs & ITimeService implementations
