namespace WebApi_Ramya.Services_Lifetime
{
    public interface IOperation
    {
       
            Guid OperationId { get; }
    }

        public interface IOperationSingleton : IOperation { }
        public interface IOperationScoped : IOperation { }
        public interface IOperationTransient : IOperation { }

}
