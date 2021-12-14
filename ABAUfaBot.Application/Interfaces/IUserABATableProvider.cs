using ABAUfaBot.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABAUfaBot.Application.Interfaces
{
    public interface IUserABATableProvider
    {
        Task<List<IABAUser>> ReadAllAsync();
        Task<IABAUser> ReadByNameAsync(string userName);
    }
}
