﻿using Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Abstractions.Interfaces.IRepositories;
using Shared.DTOs;

namespace BookApp.Controllers
{
    public class RentedsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RentedsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: /Cart
        public async Task<IActionResult> Index()
        {
            var carts = await _unitOfWork.Renteds.FindAll(c => c.Id > 0, include: q => q.Include(c => c.Book).Include(c=>c.User));
            return View(carts);
        }
        [HttpGet]
        public async Task<IActionResult> Create(string userId, int cartId)
        {
            ViewBag.User = userId;
            ViewBag.Cart = cartId;
            ViewBag.Books = await _unitOfWork.Books.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RentedCreateDTO dto)
        {
            if (ModelState.IsValid)
            {
                var rent = new Rented
                {
                    
                    StartDate= dto.StartDate,
                    EndDate= dto.EndDate,
                    BookId = dto.BookId,
                    CartId = dto.CartId,
                    UserId = dto.UserId
                };
                await _unitOfWork.Renteds.Add(rent);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }

            ViewBag.Books = await _unitOfWork.Books.GetAll();
            return View(dto);
        }


    }
}
