using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Results
{
    public class Result : IResult
    {
        public Result(string message, bool success)
        {
            Message = message;
            Success = success;
        }

        public Result()
        {
            Success = true;
        }

        public Result(bool success)
        {
            Success = success;   
        }

        public Result(string message)
        {
            Success = true;
            Message = message;
        }

        public string Message { get; }

        public bool Success { get; set; }
    }
}
