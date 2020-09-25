using Refactoring.FraudDetection.Models.Contracts;
using System;

namespace Refactoring.FraudDetection.Models
{
    public class Address : IAddress
    {
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public override bool Equals(object obj)
        {
            if (GetType() != obj?.GetType())
                return false;

            var address = (Address)obj;
            return Street == address.Street
                   && City == address.City
                   && State == address.State
                   && ZipCode == address.ZipCode;
        }

        public override int GetHashCode() => Tuple.Create(Street, City, State, ZipCode).GetHashCode();
    }
}