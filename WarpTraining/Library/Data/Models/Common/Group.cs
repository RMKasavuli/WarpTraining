using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models.Common
{
	public class Group : BaseEntity
	{
		public Group()
		{
            this.Members = new HashSet<Member>();
        }

		public int GroupId { get; set; }
		public String Name { get; set; }

		#region Navigational Properties

		public ICollection<Member> Members { get; set; }

		#endregion
	}
}
