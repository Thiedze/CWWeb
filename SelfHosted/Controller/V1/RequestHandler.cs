using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace SelfHosted.Controller.V1;

public static class RequestHandler
{
    public static List<T> GetObjects<T>(HttpRequest request)
    {
        var body = new StreamReader(request.Body).ReadToEndAsync().Result;
        return JsonSerializer.Deserialize<List<T>>(body);
    }

    public static T GetObject<T>(HttpRequest request)
    {
        var body = new StreamReader(request.Body).ReadToEndAsync().Result;
        return JsonSerializer.Deserialize<T>(body);
    }
}