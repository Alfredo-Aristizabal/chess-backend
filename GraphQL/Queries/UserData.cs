using ChessBackend.Entities;

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

    }
}
