﻿using ABAGoogleDocs.Models;
using ABAUfaBot.Application.Interfaces;
using ABAUfaBot.Domain;
using ABAUfaBot.Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABAUfaBot.Infrastructure.ABATableProviders
{
    public class UserABATableProvider : IUserABATableProvider
    {
        private const string _spreadsheetId = "1nvTf3kF80pZs97l5SvX6eF45Q6Ti5UOOxWW0Xcwm92A";
        private const string _range = "Persons!A:D";

        public ABAGoogleTableService _currentABAGoogleTableService { get; }

        public UserABATableProvider(ABAGoogleTableService currentABAGoogleTableService)
        {
            _currentABAGoogleTableService = currentABAGoogleTableService;
        }

        public async Task<List<IABAUser>> ReadAllAsync()
        {
            var usersData = await _currentABAGoogleTableService.ReadGoogleSheetAsync(_spreadsheetId, _range);
            List<IABAUser> usersList = new List<IABAUser>();

            foreach (var userRow in usersData)
            {
                ABAUser user = new ABAUser()
                {
                    Account = userRow.ToArray()[0].ToString(),
                    Name = userRow.ToArray()[1].ToString(),
                    Role = userRow.ToArray()[2].ToString(),
                };

                if (user.Role == "employee")
                {
                    if (userRow.ToArray().Length > 2)
                    {
                        user.TableId = userRow.ToArray()[3].ToString();
                    }
                }
                usersList.Add(user);
            }
            return usersList;
        }

        public async Task<IABAUser> ReadByNameAsync(string userName)
        {
            List<IABAUser> usersList = await ReadAllAsync();

            return usersList.Where(u => u.Name == userName).FirstOrDefault();
        }
    }
}
