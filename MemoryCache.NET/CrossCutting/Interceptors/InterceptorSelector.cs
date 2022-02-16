using System.Reflection;


namespace MemoryCache.NET.CrossCutting.Interceptors;

public class InterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type,
        MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type
            .GetCustomAttributes<MethodInterceptorAttribute>(true)
            .ToList();

        var methodAttributes = type
            .GetMethod(method.Name)!
            .GetCustomAttributes<MethodInterceptorAttribute>(true);

        classAttributes.AddRange(methodAttributes);

        return classAttributes
            .OrderBy(x => x.Priority)
            .ToArray<IInterceptor>();
    }
}