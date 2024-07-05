using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AchareLite.UI2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IMainCategoryAppService _mainCategoryAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly IServiceAppService _serviceAppService;

        public HomeController(IMainCategoryAppService mainCategoryAppService, ISubCategoryAppService subCategoryAppService, IServiceAppService serviceAppService)
        {
            _mainCategoryAppService = mainCategoryAppService;
            _subCategoryAppService = subCategoryAppService;
            _serviceAppService = serviceAppService;
        }
        public async Task<IActionResult> ShowMainPage(CancellationToken cancellationToken)
        {
            if (User.IsInRole("Admin") || User.IsInRole("Expert"))
            {
                return RedirectToAction("LogoutConfirm", "Logout");
            }
            else
            {
                List<MainCategoryDto> mainCategories = await _mainCategoryAppService.GetAll(cancellationToken);
                ViewData["mainCategories"] = mainCategories;
                ViewData["canellationToken"] = cancellationToken;
                return View();
            }
        }
        public async Task<IActionResult> ShowSubCategories(CancellationToken cancellationToken, int id = 0)
        {
            if (id > 0)
            {
                List<SubCategoryDto> subDtos = await _subCategoryAppService.ShowListOfSubCategoriesWhitMianCategoryId(id, cancellationToken);
                ViewData["subCategoryEntities"] = subDtos;
                TempData["mainCategoryId"] = id;
            }
            return View();
        }
        public async Task<IActionResult> showServices(CancellationToken cancellationToken, int id = 0)
        {
            List<ServiceDto> serviceDtos = await _serviceAppService.ShowListOfServicesWithSubCategoryId(id, cancellationToken);
            ViewData["serviceEntities"] = serviceDtos;
            return View();
        }
        public async Task<IActionResult> CheckRole(CancellationToken cancellationToken)
        {
            switch (User.IsInRole("Customer"))
            {
                case true:
                    return RedirectToAction("ShowMainPage", "Home");
                case false when User.IsInRole("Expert"):
                    return RedirectToAction("ShowExpertPanel", "Expert");
                case false when User.IsInRole("Admin"):
                    return RedirectToAction("ShowPendingOrders", "Admin");
                default:
                    return View();
            }
        }
    }
}


/////////////////////////////////////
//@model YourProjectName.Models.CustomerDto

//<h1>Customer Panel</h1>

//<div class= "row" >
//  < div class= "col-md-4" >

//     < h2 > Personal Information </ h2 >

//        < form asp - action = "EditCustomer" asp - route - id = "@Model.Id" method = "post" >

//                     < div class= "form-group" >

//                        < label asp -for= "Name" > Name:</ label >

//                          < input asp -for= "Name" class= "form-control" />

//                             < span asp - validation -for= "Name" class= "text-danger" ></ span >

//                                </ div >

//                                < div class= "form-group" >

//                                   < label asp -for= "Email" > Email:</ label >

//                                     < input asp -for= "Email" class= "form-control" />

//                                        < span asp - validation -for= "Email" class= "text-danger" ></ span >

//                                           </ div >

//                                           < button type = "submit" class= "btn btn-primary" > Save Changes </ button >

//                                               </ form >

//                                             </ div >

//                                             < div class= "col-md-8" >

//                                                < h2 > Actions </ h2 >

//                                                < ul class= "list-group" >

//                                                   < li class= "list-group-item" >

//                                                      < a asp - action = "ShowAllServices" > View Available Services</a>
//                                                           </li>
//      <li class= "list-group-item" >
//        < a asp - action = "ShowMyOrders" > View My Orders</a>
//             </li>
//      <li class= "list-group-item" >
//        < a asp - action = "ShowCustomerBids" > View My Bids on Orders</a>
//      </li>
//      </ul>
//  </div>
//</div>

