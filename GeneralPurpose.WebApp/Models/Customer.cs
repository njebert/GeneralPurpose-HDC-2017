using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GeneralPurpose.WebApp.Models
{
    [DataContract]
    public class Customer
    {
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerName { get; set; }
    }
}
