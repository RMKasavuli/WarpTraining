using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Configuration.Common
{
	public class PersonConfiguration : EntityTypeConfiguration<Library.Data.Models.Common.Person>
	{

		public PersonConfiguration()
		{
			//Map to table
			this.ToTable("Person");

			//Define primary key
			this.HasKey(a => a.PersonId);

			#region Foreign Keys



			#endregion

			#region Column Specifications

			this.Property(a => a.Name).HasMaxLength(64).IsOptional();
			this.Property(a => a.Email).HasMaxLength(256).IsRequired();

			#endregion
		}

	}
}
