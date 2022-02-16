namespace MemoryCache.NET.CrossCutting.Interceptors;

[AttributeUsage(AttributeTargets.Class
                | AttributeTargets.Method
                | AttributeTargets.Assembly,
    AllowMultiple = true, Inherited = true)]
public abstract class MethodInterceptorAttribute
    : Attribute, IInterceptor
{
    public int Priority { get; set; }


    public virtual void Intercept(IInvocation invocation) { }
}