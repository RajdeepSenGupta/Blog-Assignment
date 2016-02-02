using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace Blogging.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Display(Name = "Title")]
        public string BlogTitle { get; set; }

        [Display(Name = "Blog")]
        [DataType(DataType.MultilineText)]
        public string BlogContent { get; set; }

        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        public DateTime? OnCreated { get; set; }

        
        [ForeignKey("UserId")]
        public virtual ApplicationUser User{get;set;}
        public string UserId { get; set; }

    }

    
}