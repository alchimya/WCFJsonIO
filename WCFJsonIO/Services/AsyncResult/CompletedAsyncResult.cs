/// <summary> 
/// It allows to Implement an Asynchronous Service Operation
/// </summary> 
namespace WCFJsonIO.Services.AsyncResult
{
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Threading;
    class CompletedAsyncResult<T> : IAsyncResult {
        T data;

        public CompletedAsyncResult(T data)
        { this.data = data; }

        public T Data
        { get { return data; } }

        #region IAsyncResult Members
        public object AsyncState
        { get { return (object)data; } }

        public WaitHandle AsyncWaitHandle
        { get { throw new Exception("The method or operation is not implemented."); } }

        public bool CompletedSynchronously
        { get { return true; } }

        public bool IsCompleted
        { get { return true; } }
        #endregion
    }
}