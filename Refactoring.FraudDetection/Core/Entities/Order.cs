using System;

namespace Refactoring.FraudDetection.Core.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int DealId { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string CreditCard { get; set; }

        public Order(string line)
        {
            var items = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            OrderId = int.Parse(items[0]);
            DealId = int.Parse(items[1]);
            Email = items[2].ToLower();
            Street = items[3].ToLower();
            City = items[4].ToLower();
            State = items[5].ToLower();
            ZipCode = items[6];
            CreditCard = items[7];
        }
    }
}
