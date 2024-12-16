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
    public enum TypeProperty
    {
        House,
        Garage,
        Flat,
        Mall,
        Shop
    }

    public class Property
    {
        private int Id; 
        private string? Addres;
        private TypeProperty? Type; 
        private int Cost; private int Area; 
        private PropertyDetails? Details;
        private int Owner_Id;
        private List<LeaseAgreement>? LeaseAgreementList; 

        public int IdGET { get => Id; set => Id = value; }
        public string? AddresGET { get => Addres; set => Addres = value; }
        public TypeProperty? TypeGET { get => Type; set => Type = value; }
        public int CostGET { get => Cost; set => Cost = value; }
        public int AreaGET { get => Area; set => Area = value; }
        public PropertyDetails? DetailsGET { get => Details; set => Details = value; }
        public int Owner_IdGET { get => Owner_Id; set => Owner_Id = value; }
        public List<LeaseAgreement>? LeaseAgreementListGET
        {
            get => LeaseAgreementList; set => LeaseAgreementList = value;
        }
    }
    public class PropertyDetails
    {
        private int Id;
        private int Rooms;
        private int Flat;
        private int BuildYears; 
        private int Property_Id;
        public int IdGET { get => Id; set => Id = value; }
        public int RoomsGET { get => Rooms; set => Rooms = value; }
        public int FlatGET { get => Flat; set => Flat = value; }
        public int BuildYearsGET { get => BuildYears; set => BuildYears = value; }
        public int Property_IdGET { get => Property_Id; set => Property_Id = value; }
    }
}