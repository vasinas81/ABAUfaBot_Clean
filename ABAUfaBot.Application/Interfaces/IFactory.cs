
namespace ABAUfaBot.Application.Interfaces
{
    public interface IFactory<Product>
    {
        Product Create();
    }

    public interface IFactory<Parameter, Product>
    {
        Product Create(Parameter param);
    }

    public interface IFactory<Parameter1, Parameter2, Product>
    {
        Product Create(
            Parameter1 param1,
            Parameter2 param2);
    }
}
