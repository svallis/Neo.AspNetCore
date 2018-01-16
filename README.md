# Neo.AspNetCore

Provides interactions with the NEO blockchain to .NET Core applications. Designed for dependency injection and convention based configuration. Integrates fully with ASP.NET Core Razor Pages and MVC web applications.

## Features

- .NET Core DI Service
- Minimal required configuration
- Supports configuration via `appsettings.json`
- Query NEO and GAS wallet balance
- Query wallet transactions
- Query current block height
- Query best current node
- Generate new wallet private keys

## Getting Started

- Ensure you have the latest .NET Core SDK installed
- Clone this repository
- `cd .\Neo.AspNetCore\Neo.AspNetCore.Demo\`
- `dotnet restore`
- `dotnet run`
- Connect a browser to localhost on the specified port
- Edit some code in VS Code or VS Community Edition

## Installation (ASP.NET Core)

1. Acquire NuGet package for `Neo.AspNetCore` (TBC)
2. Set `MainNet` or `TestNet` in configuration (See *Examples*), or during run-time with `NeoService.SetNetwork()`
3. Call `services.AddNeo(Configuration)` in your `ConfigureServices()` method within `Startup.cs`
4. *Optional:* Add `@using Neo.AspNetCore` to `_ViewImports.cshtml` to ensure all extension methods are available in all views
5. See *Examples* for usage

## Examples

Configuration in `appsettings.json`:

```json
{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "Neo": {
    "Network": "TestNet"
  }
}
```

Get the NEO balance from a wallet's public address:

```c#
@inject INeoService Neo
@{
    var response = Neo.GetBalance("<public wallet address>");
}
<ul>
    <li><strong>Address:</strong> @response.Address</li>
    <li><strong>NEO:</strong> @response.Neo.Balance</li>
    <li><strong>GAS:</strong> @response.Gas.Balance</li>
    <li><strong>Network: </strong> @response.Net</li>
</ul>
```

Generate a new wallet private key, check its balance, and resolve the public key:

```c#
@inject INeoService Neo
@{
    var key = Neo.GeneratePrivateKey();
    var response = Neo.GetBalance(key.ToAddress());
}
<ul>
    <li><strong>Private Key:</strong> @key.PrivateKey.ToHexString()</li>
    <li><strong>Address:</strong> @response.Address</li>
    <li><strong>NEO:</strong> @response.Neo.Balance</li>
    <li><strong>GAS:</strong> @response.Gas.Balance</li>
    <li><strong>Network: </strong> @response.Net</li>
</ul>
```

## Roadmap

- Get NEP-5 token balances
- Custom token/asset definitions via configuration
- Implement additional wallet API end points
- Implement `ClaimsResponse` claims collection
- Create a `dotnet new` template
- Tutorials and examples
- Implement RPC layer
- Allow creating NEO and GAS transactions
- Allow claiming GAS
- Integrate with .NET Core `Identity` to allow streamlined individual user account wallets
- Invoke smart contracts
- Retrieve smart contract storage data
- Test suite

## Contributions

Use, testing, suggestions, issues, and pull requests always welcome.

## License

- Open Source MIT
