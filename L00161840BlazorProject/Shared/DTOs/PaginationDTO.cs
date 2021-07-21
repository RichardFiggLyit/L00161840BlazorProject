﻿using System;
using System.Collections.Generic;
using System.Text;

namespace L00161840BlazorProject.Shared.DTOs
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get; set; } = 50;
    }
}
