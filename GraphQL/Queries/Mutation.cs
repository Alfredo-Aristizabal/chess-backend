using ChessBackend.Entities;

namespace ChessBackend.GraphQL.Queries
{
    public class Mutation
    {
        public async Task<User> AddUser([Service] ChessBackendDbContext context, string name, string password)
        {
            var user = new User { name = name};
            user.SetPassword(password);
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser([Service] ChessBackendDbContext context, int id, string name, string password)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            user.name = name;
            user.SetPassword(password);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUser([Service] ChessBackendDbContext context, int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
