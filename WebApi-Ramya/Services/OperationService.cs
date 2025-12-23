namespace WebApi_Ramya.Services
{
    public class OperationService : IOperationSingleton, IOperationScoped, IOperationTransient
    {
        
            public Guid OperationId { get; } = Guid.NewGuid();
        }
    }

