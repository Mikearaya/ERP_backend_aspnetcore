using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BionicERP.Domain.CRM;

namespace BionicERP.Application.Crm.Customers.Models {
    public class CustomerDetailViewModel {
        public CustomerDetailViewModel () {
            SocialMedia = new List<CustomerSocialMediaViewModel> ();
            PhoneNumber = new List<CustomerPhoneNumberViewModel> ();
            Address = new List<CustomerAddressViewModel> ();
        }

        public uint Id { get; set; }
        public string FullName { set; get; }

        public string Tin { set; get; }
        public string Email { set; get; }

        public int? PaymentPeriod { get; set; }
        public double? CreditLimit { get; set; }
        public string PoBox { get; set; }

        public string Type { set; get; }

        public IEnumerable<CustomerSocialMediaViewModel> SocialMedia { get; set; }
        public IEnumerable<CustomerAddressViewModel> Address { get; set; }
        public IEnumerable<CustomerPhoneNumberViewModel> PhoneNumber { get; set; }

        public static Expression<Func<Customer, CustomerDetailViewModel>> Projection {
            get {
                return c => new CustomerDetailViewModel () {
                    Id = c.Id,
                    FullName = c.FullName,
                    Tin = c.Tin,
                    Email = c.Email,
                    PaymentPeriod = c.PaymentPeriod,
                    CreditLimit = c.CreditLimit,
                    PoBox = c.PoBox,
                    Type = c.Type,
                    SocialMedia = c.SocialMedia.AsQueryable ().Select (CustomerSocialMediaViewModel.Projection),
                    PhoneNumber = c.PhoneNumber.AsQueryable ().Select (CustomerPhoneNumberViewModel.Projection),
                    Address = c.Address.AsQueryable ().Select (CustomerAddressViewModel.Projection),
                };
            }
        }

    }
}