﻿using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class SoldCreateViewModel
    {
        public List<BookQuantityDTO> Books { get; set; } = new List<BookQuantityDTO>();
        public int CartId { get; set; }
        public string? UserId { get; set; }
    }
}
