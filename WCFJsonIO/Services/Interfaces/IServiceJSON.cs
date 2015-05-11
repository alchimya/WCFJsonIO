/// <summary> 
/// It defines an interface with service methods
/// </summary> 
namespace WCFJsonIO.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    using System.Threading.Tasks;
    using WCFJsonIO.Services.Contracts;


    [ServiceContract]
    interface IServiceJSON
    {
        ////////////////////////////////////////////////////////////////////////////////////////
        //MyMethod

        [OperationContract(AsyncPattern = true)]
        IAsyncResult BeginMyMethod(ServiceJSONInput input, AsyncCallback callback, object asyncState);
        ServiceJSONResult EndMyMethod(IAsyncResult result);

        [OperationContract]
        [WebInvoke(Method = "*", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ServiceJSONResult MyMethod(ServiceJSONInput input);
        ////////////////////////////////////////////////////////////////////////////////////////

    }
}