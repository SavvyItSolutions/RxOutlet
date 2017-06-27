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
        public GetDrugNameResponse GetSupplierName()
        {

            GetDrugNameResponse resp = new GetDrugNameResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetSupplierName();
            return resp;
        }


        [HttpGet]
        public GetDrugNameResponse DrugList()
        {

            GetDrugNameResponse resp = new GetDrugNameResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetDrugList();
            return resp;
        }

        [HttpGet]
        public GetDrugNameResponse DrugListNew(SearchCreiteria sc)
        {

            GetDrugNameResponse resp = new GetDrugNameResponse();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetDrugList();
            return resp;
        }

        public class SearchCreiteria
        {
            public string SearchText { get; set; }
            List<int> Type;
            int PageStart;
            int PageSize;
            public SearchCreiteria()
            {
                Type = new List<int>();
            }
        }
        //[HttpGet]
        //public RxOutletMenuListRespone MenuList()
        //{

        //    RxOutletMenuListRespone resp = new RxOutletMenuListRespone();
        //    IRxOutletService itemService = new RxOutletService();
        //     resp = itemService.GetMenuList();
        //    return resp;
        //}


        //[HttpGet]
        //public RxOutletSubMenuListResponse SubMenuList(int objectId)
        //{
        //    RxOutletSubMenuListResponse resp = new RxOutletSubMenuListResponse();
        //    IRxOutletService itemService = new RxOutletService();
        //    resp = itemService.GetSubMenuList(objectId);
        //    return resp;

        //}


        //[HttpGet]
        //public RxOutLetMenuItemListResponse MenuItemList(int objectId, int userid)
        //{
        //    RxOutLetMenuItemListResponse resp = new RxOutLetMenuItemListResponse();
        //    IRxOutletService itemService = new RxOutletService();
        //    resp = itemService.GetMenuItemList(objectId, userid);

        //    return resp;

        //}





        //[HttpGet]
        //public List<CompleteMenu> GetCompleteMenu()
        //{
        //    List<CompleteMenu> resp = new List<CompleteMenu>();
        //    IRxOutletService itemService = new RxOutletService();
        //    resp = itemService.GetCompleteMenu();

        //    return resp;
        //}


        [HttpGet]
        public List<DrugSearch> GetDrugNamesSearch()
        {
            List<DrugSearch> resp = new List<DrugSearch>();
            IRxOutletService itemService = new RxOutletService();
            resp = itemService.GetDrugNamesSearchService();

            return resp;
        }



    }
}
