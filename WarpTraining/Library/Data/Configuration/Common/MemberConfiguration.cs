using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Configuration.Common
{
	public class MemberConfiguration: EntityTypeConfiguration<Library.Data.Models.Common.Member>
	{

		public MemberConfiguration()
		{
			//Map to table
			this.ToTable("Member");

			//Define primary key
			this.HasKey(a => new { a.PersonId, a.GroupId } );

			#region Foreign Keys

			this.HasRequired(m=>m.Person)
			.WithMany(p=>p.Members)
			.HasForeignKey(p=>p.PersonId);
			
			this.HasRequired(m=>m.Group)
			.WithMany(p=>p.Members)
			.HasForeignKey(p=>p.GroupId);

			#endregion

			#region Column Specifications


			#endregion
		}
	
	}
}
