using ChessBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChessBackend.GraphQL.Queries
{
    public class UserData
    {

        [UseProjection]
        [HotChocolate.Data.UseFiltering]
        [HotChocolate.Data.UseSorting]
        public List<User> GetUsers([Service] ChessBackendDbContext context)
        {
            return context.Users.ToList();
        }

        public class VerifyPasswordResult
        {
            public bool UserFound { get; set; }
            public bool PasswordCorrect { get; set; }
        }

        public async Task<VerifyPasswordResult> VerifyPassword([Service] ChessBackendDbContext context, string name, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.name == name);
            if (user == null)
            {
                return new VerifyPasswordResult { UserFound = false, PasswordCorrect = false };
            }

            return new VerifyPasswordResult { UserFound = true, PasswordCorrect = user.VerifyPassword(password) };
        }


        public async Task<bool> VerifyUsernameExist([Service] ChessBackendDbContext context, string name)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.name == name);
            if (user == null)
            {

                return false;
            }
            else {
                return true;
            }

        }
    }
}
