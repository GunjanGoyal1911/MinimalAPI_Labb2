using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MinimalAPI_Labb2.Models;

namespace MinimalAPI_Labb2.DB
{
	public class ProductContext: DbContext
	{
		private readonly IConfiguration _configuration;

		public ProductContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public DbSet<Product> Products { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			var connectionString = _configuration.GetConnectionString("ProductConnectionString");
			options.UseSqlServer(connectionString);
		}
	}
}
