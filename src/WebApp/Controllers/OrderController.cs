using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApp.Models;
using WebApp.Services;
using System.Security.Claims;

namespace WebApp.Controllers
{
    public class OrderController : Controller
    {
        IAuthorizationService _authorizationService;

        public OrderController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        public async Task<IActionResult> View(int id)
        {
            var order = GetOrder(id);

            if(await _authorizationService.AuthorizeAsync(User, order, "ShowOrder"))
            {
                return View(order);
            }
            return new ChallengeResult();
        }

        OrderModel GetOrder(int orderId)
        {
            return new OrderModel(orderId, User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}