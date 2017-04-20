using Newtonsoft.Json;
using RxOutlet.Business;
using RxOutlet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace RxOutlet.Controllers
{
    public class RxOutletController : ApiController
    {

        [HttpGet]
        public RxOutletMenuListRespone MenuList()
        {
            //var menuDetails = ();
            //return Json(menuDetails, JsonRequestBehavior.AllowGet);

            RxOutletMenuListRespone resp = new RxOutletMenuListRespone();
            IRxOutletService itemService = new RxOutletService();
             resp = itemService.GetMenuList();
            return resp;
        }


        [HttpGet]
        public RxOutletSubMenuListResponse SubMenuList(int objectId)
        {
            RxOutletSubMenuListResponse resp = new RxOutletSubMenuListResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetSubMenuList(objectId);
            return resp;

        }


        [HttpGet]
        public RxOutLetMenuItemListResponse MenuItemList(int objectId, int userid)
        {
            RxOutLetMenuItemListResponse resp = new RxOutLetMenuItemListResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetMenuItemList(objectId, userid);

            return resp;

        }

    }
}
