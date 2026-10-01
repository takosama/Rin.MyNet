# Query encoding regression

Run `dotnet run --project tests/RegressionTests.csproj -c Release` with .NET 8.

Tests link UrlParameter.cs directly and parse the resulting query with System.Web.HttpUtility. Cases cover delimiter-containing keys, fragments, spaces, Unicode, literal plus/percent, array values and existing simple query output. Encoding applies to both keys and values; it does not validate a caller's target URL or authorize particular parameter names.
