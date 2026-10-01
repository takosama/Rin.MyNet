using Rin.MyNet;
using System.Web;

int checks = 0;
foreach (string key in new[] { "q=one&other", "a#fragment", "", "日本語 キー", "a+b%20c", "plain" })
{
    string query = UrlParameter.Join(new UrlParameter(key, "value&=#+日本語"));
    var parsed = HttpUtility.ParseQueryString(query);
    if (parsed.Count != 1 || parsed[key] != "value&=#+日本語") throw new Exception($"Round trip failed: {key}");
    checks++;
}
string arrayQuery = UrlParameter.Join(new UrlParameter("x&injected", new[] { "one", "two&three" }));
var array = HttpUtility.ParseQueryString(arrayQuery);
if (array.Count != 1 || array["x&injected"] != "one,two&three") throw new Exception("Array key encoding failed"); checks++;
if (UrlParameter.Join(("a", "1"), ("b", "2")) != "?a=1&b=2") throw new Exception("Simple query compatibility changed"); checks++;
Console.WriteLine($"PASS {checks} URL parameter encoding cases.");
