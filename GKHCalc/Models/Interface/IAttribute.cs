namespace GKHCalc.Enum
{
    public interface IAttribute<T>
    {
        T Value { get; }
    }

    public interface ICompareAttribute<V, T>
    {
        V Value { get; }
        T Type { get; }
    }
}
