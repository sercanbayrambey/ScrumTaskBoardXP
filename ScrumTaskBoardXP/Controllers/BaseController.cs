using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrumTaskBoardXP.Web.Controllers
{
    public class BaseController : Controller
    {
        public void Alert(string message)
        {
            string msg = @"<script type='text/javascript'>$.notify({message: '" + message +
                         "'}, {timer: 1000,placement: {from: 'top',align:'center'}});</script>";
            TempData["notification"] = msg;
        }
    }
}
