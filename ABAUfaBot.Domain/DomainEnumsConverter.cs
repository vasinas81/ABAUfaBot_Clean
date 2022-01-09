﻿using System;

namespace ABAUfaBot.Domain
{
    class DomainEnumsConverter
    {
        public static UserRoles? ConvertRole(string role)
        {
            if (Enum.TryParse(typeof(UserRoles), role, out var parsedResult))
                return (UserRoles?)parsedResult;
            return null;
        }
    }
}
