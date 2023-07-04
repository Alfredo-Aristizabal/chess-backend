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

        public async Task<bool> VerifyPassword([Service] ChessBackendDbContext context, string name, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.name == name);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user.VerifyPassword(password);
        }

    }
}
