using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABAGoogleDocs;

namespace ABBAUfaTBot.Application.Interfaces
{
    public interface IBotCommand
    {
        string Name { get; }
        IReadOnlyCollection<string> Parameters { get; }

        Task<string> RunAsync();
    }
}
