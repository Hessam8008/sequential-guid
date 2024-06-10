// See https://aka.ms/new-console-template for more information
namespace SquentialGUID;

public abstract class SuperClass
{
    public Guid Id { get; }

    public SuperClass()
    {
        Id = CreateId();
    }

    protected Guid CreateId()
    {
        Guid sequentialUuid = this.GetType().Name.NewSequentialGuid();
        return sequentialUuid;
    }
}
