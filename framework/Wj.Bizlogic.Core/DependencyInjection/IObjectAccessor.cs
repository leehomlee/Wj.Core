namespace Wj.Bizlogic.DependencyInjection
{
    public interface IObjectAccessor<out T>
    {
        T? Value { get; }
    }
}

