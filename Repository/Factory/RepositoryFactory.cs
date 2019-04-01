namespace Repository.Factory
{
    public class RepositoryFactory
    {
        public static IAuthenticationRepo GetAuthenticationRepo()
        {
            return new AuthenticationRepo();
        }

        public static IUserRepo GetUserRepo()
        {
            return new UserRepo();
        }

    }
}
