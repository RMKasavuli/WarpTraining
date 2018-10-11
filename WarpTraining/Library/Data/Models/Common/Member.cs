using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models.Common
{
	public class Member : BaseEntity
	{
		public int PersonId { get; set; }

		public int GroupId { get; set; }


		#region Navigational Properties

		public Group Group { get; set; }

		public Person Person { get; set; }


		#endregion
	}
}
