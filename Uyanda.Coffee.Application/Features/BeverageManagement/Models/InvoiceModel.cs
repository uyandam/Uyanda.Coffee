﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Uyanda.Coffee.Application.Features.BeverageManagement.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<LineItemModel> LineItems { get; set; }

        public int UserId { get; set; }

        public UserModel User { get; set; }
    }
}
