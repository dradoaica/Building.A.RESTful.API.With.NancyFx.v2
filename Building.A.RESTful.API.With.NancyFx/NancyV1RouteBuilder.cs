using Nancy;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Building.A.RESTful.API.With.NancyFx;

public class NancyV1RouteBuilder
{
    public enum HttpMethod
    {
        Get,
        Put,
        Post,
        Delete,
        Head,
        Options,
        Patch
    }

    private readonly HttpMethod _httpMethod;

    private readonly NancyModule _module;

    public NancyV1RouteBuilder(NancyModule module, HttpMethod httpMethod)
    {
        _module = module;
        _httpMethod = httpMethod;
    }

    public Func<dynamic, CancellationToken, Task<object>> this[string path, bool async]
    {
        set => UpgradeAsync(null, path, value);
    }

    public Func<dynamic, CancellationToken, Task<object>> this[string name, string path, bool async]
    {
        set => UpgradeAsync(null, path, value);
    }

    public Func<dynamic, object> this[string name, string path]
    {
        set => UpgradeSync(name, path, value);
    }

    public Func<dynamic, object> this[string path]
    {
        set => UpgradeSync(null, path, value);
    }

    private void UpgradeSync(string name, string path, Func<dynamic, object> value)
    {
        switch (_httpMethod)
        {
            case HttpMethod.Get:
                _module.Get(path, value, null, name);
                break;
            case HttpMethod.Put:
                _module.Put(path, value, null, name);
                break;
            case HttpMethod.Post:
                _module.Post(path, value, null, name);
                break;
            case HttpMethod.Delete:
                _module.Delete(path, value, null, name);
                break;
            case HttpMethod.Head:
                _module.Head(path, value, null, name);
                break;
            case HttpMethod.Patch:
                _module.Patch(path, value, null, name);
                break;
            case HttpMethod.Options:
                _module.Options(path, value, null, name);
                break;
        }
    }

    private void UpgradeAsync(string name, string path, Func<dynamic, CancellationToken, Task<object>> value)
    {
        switch (_httpMethod)
        {
            case HttpMethod.Get:
                _module.Get(path, value, null, name);
                break;
            case HttpMethod.Put:
                _module.Put(path, value, null, name);
                break;
            case HttpMethod.Post:
                _module.Post(path, value, null, name);
                break;
            case HttpMethod.Delete:
                _module.Delete(path, value, null, name);
                break;
            case HttpMethod.Head:
                _module.Head(path, value, null, name);
                break;
            case HttpMethod.Patch:
                _module.Patch(path, value, null, name);
                break;
            case HttpMethod.Options:
                _module.Options(path, value, null, name);
                break;
        }
    }
}