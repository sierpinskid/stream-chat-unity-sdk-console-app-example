This repo is an example of a working **.NET Console App** that uses [Stream Unity SDK](https://github.com/GetStream/stream-chat-unity) v4.1.0.

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

---
Stream Unity SDK is designed in a way to have the core logic written in pure .NET/C# and have all of the Unity Engine dependencies externally injected. This enables additional scenarios possible e.g.:
- run a backend multiplayer simulation as a C# Console App
- run C# Desktop Apps
- run Xamarin/.NET MAUI cross-platform app
