using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenBlog.Web.Models
{
    public class RegistViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
    }
}
