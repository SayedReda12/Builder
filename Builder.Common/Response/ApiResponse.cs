using Builder.Common.ApplicationServices;
using Builder.Common.Helpers.ErrorAndSuccessMessages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builder.Common.Response
{
    public class ApiResponse
    {
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public bool Success { get; set; }
        public string ErrorCode { get; set; }
        public string SuccessCode { get; set; }
        public object Data { get; set; }

        //public ApiResponse(bool success,object data, string messageCode = null)
        //{
        //    if (!success)
        //    {
        //        Data = null;
        //        Success = false;
        //        ErrorCode = messageCode;
        //        ErrorMessage = GetErrorMessage(messageCode ?? "ERR_INT_01");
        //    }
        //    else
        //    {
        //        Data = data;
        //        Success = success;
        //        SuccessCode = messageCode;
        //        SuccessMessage = GetSuccessMessage(messageCode);
        //    }
        //}

        public ApiResponse(ApplicationServiceOutput serviceOutput)
        {
            if (!serviceOutput.Success)
            {
                Data = null;
                Success = false;
                ErrorCode = serviceOutput.MessageCode;
                ErrorMessage = GetErrorMessage(serviceOutput.MessageCode ?? "ERR_INT_01");
            }
            else
            {
                Data = serviceOutput.Result;
                Success = true;
                SuccessCode = serviceOutput.MessageCode;
                SuccessMessage = GetSuccessMessage(serviceOutput.MessageCode);
            }
        }

        private string GetErrorMessage(string errorCode)
        {
            return SystemMessages.GetErrorMessage(errorCode);
        }

        private string GetSuccessMessage(string successCode)
        {
            return SystemMessages.GetSuccessMessage(successCode);
        }
    }
}
