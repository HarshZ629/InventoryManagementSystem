//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_users
    {
        [Key]
        public int u_id { get; set; }

        [Display(Name ="Name")]
        [Required(ErrorMessage ="Name Required")]
        public string u_name { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User name Required")]
        public string u_username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string u_password { get; set; }

        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Phone Required")]
        public string u_phone { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        public string u_email { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status Required")]
        public byte u_status { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role Required")]
        public byte u_roleid { get; set; }
      
    
        public virtual tbl_roles tbl_roles { get; set; }
    }
}
