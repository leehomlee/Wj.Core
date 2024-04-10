namespace Wj.Bizlogic.ExceptionHandling
{
    /// <summary>
    /// 错误 详细信息
    /// </summary>
    public interface IHasErrorDetails
    {
        string? Details { get; }
    }
}

