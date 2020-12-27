using System;
using System.Collections.Generic;
using System.Text;

namespace ScrumTaskBoardXP.Business.Results
{
    public interface IResult
    {
        string Message { get; }
        bool Success { get; }
    }
}
