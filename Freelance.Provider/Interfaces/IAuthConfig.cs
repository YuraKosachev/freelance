using Owin;




namespace Freelance.Provider.Interfaces
{
    public interface IAuthConfig
    {
        void Config(IAppBuilder app, string path);
        void ConfigureAuth();
    }
}
