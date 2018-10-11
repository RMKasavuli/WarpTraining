using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Models.Common
{
    public class GroupModel
    {
        public GroupModel()
        {
            
        }

        [Key]
        public int GroupId { get; set; }

        [Required]
        public String Name { get; set; }

    }
}
