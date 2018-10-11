using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models.Common
{
	public class PersonModel 
	{
		public PersonModel()
		{

		}

      
		public int PersonId { get; set; }

        [Required]
        public String Name { get; set; }

		public String Email { get; set; }

		public String FullName { get; set; }

	}
}
