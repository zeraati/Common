namespace Common;
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public class OrderAttribute : Attribute
{
    public int Order { get; }
    public OrderAttribute(int order)=> Order = order;
}
