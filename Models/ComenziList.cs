using System;

namespace API_Restaurant.Models
{
    public class ComenziList
    {
        public int ID { get; set; }

        public DateTime DataComenzii { get; set; }

        public int? ClientID { get; set; }
        public int? ProdusID { get; set; }

    }
}