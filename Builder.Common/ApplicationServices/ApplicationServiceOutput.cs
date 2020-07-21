using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Common.ApplicationServices
{
    public class ApplicationServiceOutput
    {
        public object Result { get; private set; }

        public bool Success { get; private set; }

        public string MessageCode { get; private set; }


        public ApplicationServiceOutput SuccessServiceOutput( object result, string messageCode=null)
        {
            return new ApplicationServiceOutput
            {
                Result = result,
                Success = true,
                MessageCode = messageCode
            };
        }


        public ApplicationServiceOutput ErrorServiceOutput(string messageCode)
        {
            return new ApplicationServiceOutput
            {
                Result = null,
                Success = false,
                MessageCode = messageCode
            };
        }
    }


}
