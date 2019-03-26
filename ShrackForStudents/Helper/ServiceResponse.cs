using System;
using System.Net;

namespace ShrackForStudents.Helper
{
    public class ServiceResponse<T>
    {
        #region Properties
        public Exception Exception { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode ResponseCode { get; set; }
        public T Result { get; set; }
        #endregion
    }
}
