using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using BLL;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PubCompanyWinCore
{
    public class Startup
    {
      public Startup()
      {
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection, new DbContextOptionsBuilder());

            var _serviceProvider = serviceCollection.BuildServiceProvider();
            
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainView view = _serviceProvider.GetService<MainView>();
            
            Application.Run(view);
      }
       
      private void ConfigureServices(IServiceCollection services, DbContextOptionsBuilder optionsBuilder)
      {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  //location of the exe file
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();

            var connectionstring = configuration.GetConnectionString("DefaultConnection");

            //BLL
            services.AddTransient<IPayRollDM, PayRollDM>();
            services.AddTransient<IAuthorDM, AuthorDM>();

            //DAL
            services.AddTransient<IDaoAuthor, DaoAuthor>();
            services.AddTransient<IDaoPayroll, DaoPayroll>();
            services.AddTransient<IDaoArticle, DaoArticle>();
            services.AddDbContext<PublishingCompanyContext>(options => options.UseSqlServer(connectionstring));

            //Presentation
            services.AddSingleton<MainView>();
            services.AddSingleton<PayRollView>();
            services.AddSingleton<AuthorView>();
      }  
    }
}
