using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models.Common
{
	public class Person : BaseEntity
	{
		public Person()
        {
			this.Members = new HashSet<Member>();
		}

		public int PersonId { get; set; }

		public String Name { get; set; }

		public String Email { get; set; }

		#region Navigational Properties

		public ICollection<Member> Members { get; set; }


		#endregion

	}
}
