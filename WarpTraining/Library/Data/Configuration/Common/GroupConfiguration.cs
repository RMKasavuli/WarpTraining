using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Configuration.Common
{
	public class GroupConfiguration : EntityTypeConfiguration<Library.Data.Models.Common.Group>
	{

		public GroupConfiguration()
		{
			//Map to table
			this.ToTable("Group");

			//Define primary key
			this.HasKey(a => a.GroupId);

			#region Foreign Keys

			#endregion

			#region Column Specifications

			this.Property(a => a.Name).HasMaxLength(64).IsOptional();

			#endregion
		}
	}
}
