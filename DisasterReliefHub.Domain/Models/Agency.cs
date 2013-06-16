using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

using DisasterReliefHub.Domain.Repository;

namespace DisasterReliefHub.Domain.Models
{
    [Table("Agency")]
    public class Agency : Entity
    {
        public string Name { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
    }
}
