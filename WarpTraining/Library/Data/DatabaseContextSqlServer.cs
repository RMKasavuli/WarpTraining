using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Hosting;
using System.IO;
using Library.Data.Models;

namespace Library.Data
{
	public partial class DatabaseContextSqlServer : DbContext, IDataContext
	{
		#region Constructor
		public DatabaseContextSqlServer(System.Data.Entity.IDatabaseInitializer<DatabaseContextSqlServer> initializer = null)
			: base("name=DatabaseContext")
		{
			this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

			//Set the database initializer (by default use CreateDatabaseIfNotExist<DatabaseContext>())
			if (initializer != null) System.Data.Entity.Database.SetInitializer<DatabaseContextSqlServer>(initializer);

			this.Configuration.LazyLoadingEnabled = false;
			//this.Database.Log = WriteLog;
		}

        public DatabaseContextSqlServer()
            : base("name=DatabaseContext") // Connection string name.
        {
            this.Database.Connection.ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseContext"].ConnectionString;

			this.Configuration.LazyLoadingEnabled = false;
        }

		#endregion

		#region Properties
		/// <summary>
		/// Gets the specified entity set from the context
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public new IDbSet<T> Set<T>() where T : BaseEntity
		{
			return base.Set<T>();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Create the model based on the entity type configuration mappings
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			//Look for and add the entity configurations to the model builder
			modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

			//Don't pluaralize table names
			modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

			base.OnModelCreating(modelBuilder);
		}

		public override int SaveChanges()
		{
			return base.SaveChanges();
		}

		private void WriteLog(String text)
		{
			using (FileStream fs = new FileStream(HostingEnvironment.ApplicationPhysicalPath + "\\log.txt", FileMode.OpenOrCreate, FileAccess.Write))
			{
				var bytes = ASCIIEncoding.ASCII.GetBytes(text);
				fs.Write(bytes, 0, bytes.Length);
				fs.Close();
			}
		}

		/// <summary>
		/// Indicates if the database targeted by the connection string exists
		/// </summary>
		/// <returns>A Boolean object</returns>
		public bool DatabaseExists()
		{
			return this.Database.Exists();
		}

		public void ExecuteSql(String sql)
		{
			this.Database.ExecuteSqlCommand(sql);
		}
		#endregion

        public System.Data.Entity.IDbSet<Library.Data.Models.Common.Person> People { get; set; }

        public System.Data.Entity.DbSet<Library.Data.Models.Common.GroupModel> GroupModels { get; set; }

        public System.Data.Entity.DbSet<Library.Data.Models.Common.Member> Members { get; set; }

        public System.Data.Entity.DbSet<Library.Data.Models.Common.Group> Groups { get; set; }
    }
}
