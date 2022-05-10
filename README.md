This repo is an example of a working **.NET Console App** that uses [Stream Unity SDK](https://github.com/GetStream/stream-chat-unity).


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
