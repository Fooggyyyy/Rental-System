using System;
using Rental;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Proxies;

namespace Rental
{
    public abstract class User
    {
        protected int Id;
        protected string? Name;
        protected string? Email;
        protected string? PhoneNumber;

        public int IdGET
        {
            get => Id;
            set => Id = value;
        }
        public string? NameGET
        {
            get => Name;
            set => Name = value;
        }
        public string? EmailGET
        {
            get => Email;
            set => Email = value;
        }
        public string? PhoneNumberGET
        {
            get => PhoneNumber;
            set => PhoneNumber = value;
        }
    }


    public class Owner : User
    {
        private List<Property>? PaymentList;
        public List<Property>? PaymentListGET { get => PaymentList; set => PaymentList = value; }
    }
    public class Tenant : User
    {
        private List<LeaseAgreement>? LeaseAgreementsList;
        public List<LeaseAgreement>? LeaseAgreementsListGET { get => LeaseAgreementsList; set => LeaseAgreementsList = value; }
    }
}