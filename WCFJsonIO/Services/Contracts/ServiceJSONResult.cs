/// <summary> 
/// It defines your Output complex data
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
    public class ServiceJSONResult
    {
        [DataMember]
        public Customer Customer { get; internal set; }
        [DataMember]
        public Exception Exception { get; internal set; }
        [DataMember]
        public string Message { get; internal set; }

    }
}