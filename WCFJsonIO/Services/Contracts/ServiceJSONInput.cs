/// <summary> 
/// It defines your Input complex data
/// </summary> 
namespace WCFJsonIO.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Web;
    using WCFJsonIO.Entities;

    [DataContract]
    public class ServiceJSONInput
    {
        [DataMember]
        public Customer Customer { get; set; }
        [DataMember]
        public Account Account { get; set; }
    }
}