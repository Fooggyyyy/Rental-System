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
    public class LeaseAgreement
    {
        private int Id;
        private DateTime? DateStart;
        private DateTime? DateEnd;
        private int Cost;
        private int Tenant_Id;
        private int Property_Id;
        private Payment? Payment;
        public int IdGET { get => Id; set => Id = value; }
        public DateTime? DateStartGET { get => DateStart; set => DateStart = value; }
        public DateTime? DateEndGET { get => DateEnd; set => DateEnd = value; }
        public int CostGET { get => Cost; set => Cost = value; }
        public int TenantGET { get => Tenant_Id; set => Tenant_Id = value; }
        public int PropertyGET { get => Property_Id; set => Property_Id = value; }
        public Payment? PaymentGET
        {
            get => Payment; set => Payment = value;
        }
    }
}