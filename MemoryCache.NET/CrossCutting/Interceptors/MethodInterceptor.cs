namespace MemoryCache.NET.CrossCutting.Interceptors;

public class MethodInterceptor : MethodInterceptorAttribute
{
    public override void Intercept(IInvocation invocation)
    {
        var success = true;
        OnBefore(invocation);

        try { invocation.Proceed(); }
        catch (Exception ex)
        {
            success = false;
            OnException(invocation, ex);
            throw;
        }
        finally
        {
            if (success)
                OnSuccess(invocation);
        }

        OnAfter(invocation);
    }

    public virtual void OnBefore(IInvocation invocation) { }
    public virtual void OnAfter(IInvocation invocation) { }
    public virtual void OnSuccess(IInvocation invocation) { }
    public virtual void OnException(IInvocation invocation, Exception ex) { }
}