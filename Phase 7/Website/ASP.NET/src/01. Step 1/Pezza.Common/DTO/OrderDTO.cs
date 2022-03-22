﻿namespace Pezza.Common.DTO
{
    using System;
    using System.Collections.Generic;
    using Pezza.Common.Entities;
    using Pezza.Common.Models;

    public class OrderDTO : Entity, Data.ISearchBase
    {
        public CustomerDTO Customer { get; set; }

        public int? CustomerId { get; set; }

        public RestaurantDTO Restaurant { get; set; }

        public int? RestaurantId { get; set; }

        public decimal? Amount { get; set; }

        public bool? Completed { get; set; }

        public virtual ICollection<OrderItemDTO> OrderItems { get; set; }

        public DateTime? DateCreated { get; set; }

        public string OrderBy { get; set; }

        public PagingArgs PagingArgs { get; set; }
    }
}
