namespace WCFJsonIO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    using WCFJsonIO.Services.AsyncResult;
    using WCFJsonIO.Services.Contracts;
    using WCFJsonIO.Services.Interfaces;

    public class ServiceJSON : IServiceJSON{


        public IAsyncResult BeginMyMethod(ServiceJSONInput input, AsyncCallback callback, object asyncState){
           return new CompletedAsyncResult<ServiceJSONResult>((MyMethod(input)));
        }

        public ServiceJSONResult EndMyMethod(IAsyncResult result){
             return (ServiceJSONResult)result;
        }

        public ServiceJSONResult MyMethod(ServiceJSONInput input){

            //controls if input data is not null, otherwise it returns
            if (input == null){
                return new ServiceJSONResult { Customer = null, Exception = new Exception("Invalid input data") , Message="Sevice Cannnot perform your request" };
            }

            //defines a ret var
            ServiceJSONResult ret = new ServiceJSONResult { Customer = input.Customer, Exception = null };

            try{
                //do something with input data
                ret.Message = "Your request has been performed";

            }
            catch (Exception ex){
                while (ex.InnerException != null) ex = ex.InnerException;
                ret.Exception = new Exception(ex.Message);
                ret.Message = "Sevice Cannnot perform your request";
            }

            return ret;
        }
    }
}



