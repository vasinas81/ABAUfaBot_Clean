
namespace ABBAUfaTBot.Application.Interfaces
{
    public interface IDeserializer<Type>
    {
        Type Deserialize(string obj);
    }
}
