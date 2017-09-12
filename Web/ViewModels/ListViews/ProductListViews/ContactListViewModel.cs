﻿using System.ComponentModel;
using Core.Dtos;

namespace Web.ViewModels.ListViews.ProductListViews
{
    public class ContactListViewModel
    {
        [DisplayName("Contact Name")]
        public string Name { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Contact Partner")]
        public virtual PartnerDto Partner { get; set; }

        [DisplayName("Partner Id")]
        public int PartnerId { get; set; }
    }
}