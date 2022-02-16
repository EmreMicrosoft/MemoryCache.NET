using System.Reflection;


namespace MemoryCache.NET.CrossCutting.Interceptors;

public interface IInterceptor
{
    void Intercept(IInvocation invocation);
}


public interface IInterceptorSelector
{
    IInterceptor[] SelectInterceptors(
        Type type, MethodInfo method,
        IInterceptor[] interceptors);
}


public interface IInvocation
{
    object[] Arguments { get; }
    Type[] GenericArguments { get; }
    object InvocationTarget { get; }
    MethodInfo Method { get; }
    MethodInfo MethodInvocationTarget { get; }
    object Proxy { get; }
    object ReturnValue { get; set; }
    Type TargetType { get; }
    object GetArgumentValue(int index);
    MethodInfo GetConcreteMethod();
    MethodInfo GetConcreteMethodInvocationTarget();
    void Proceed();
    IInvocationProceedInfo CaptureProceedInfo();
    void SetArgumentValue(int index, object value);
}

public interface IInvocationProceedInfo
{
    void Invoke();
}