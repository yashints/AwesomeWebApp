using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AwesomeWebApp.Models
{
    public class Todo
    {
        public int Id { get; internal set; }
        [Required]
        public string Owner { get; set; }
        [Required]
        public string AssignedTo { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}