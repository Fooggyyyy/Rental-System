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
    public enum TypePayment
    {
        None,
        Done,
        InTime
    }
    public class Payment 
    { 
        private int Id;
        private int Cost;
        private DateTime DatePayment;
        private TypePayment TypePayment;
        private int LeaseAgreement_Id; 
        public int IdGET { get => Id; set => Id = value; }
        public int CostGET { get => Cost; set => Cost = value; }
        public DateTime DatePaymentGET { get => DatePayment; set => DatePayment = value; }
        public TypePayment TypePaymentGET { get => TypePayment; set => TypePayment = value; }
        public int LeaseAgreement_IdGET { get => LeaseAgreement_Id; set => LeaseAgreement_Id = value; }
    }
}