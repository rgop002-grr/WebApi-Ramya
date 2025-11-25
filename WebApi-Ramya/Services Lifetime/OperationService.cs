namespace WebApi_Ramya.Services_Lifetime
{
    public class OperationService:IOperationSingleton, IOperationScoped, IOperationTransient
    {
        public Guid OperationId { get; } = Guid.NewGuid();
    }

}

