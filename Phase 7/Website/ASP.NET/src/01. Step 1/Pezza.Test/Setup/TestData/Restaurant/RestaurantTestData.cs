﻿namespace Pezza.Test
{
    using System;
    using Bogus;
    using Pezza.Common.DTO;
    using Pezza.Common.Entities;

    public static class RestaurantTestData
    {
        public static Faker faker = new Faker();

        public static RestaurantDTO RestaurantDTO = new RestaurantDTO()
        {
            Name = faker.Company.CompanyName(),
            Description = string.Empty,
            PictureUrl = string.Empty,
            Address = new AddressBase
            {
                Address = faker.Address.FullAddress(),
                City = faker.Address.City(),
                PostalCode = faker.Address.PostalCode(),
                Province = faker.Address.State(),
            },
            DateCreated = DateTime.Now,
            IsActive = true
        };
    }

}
