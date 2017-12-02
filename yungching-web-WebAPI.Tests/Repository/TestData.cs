﻿using System;
using yungching_web_WebAPI.Models;

namespace yungching_web_WebAPI.Tests.Repository
{
    struct TestData1
    {
        public static String Id { get; } = "EDCBA";

        public static Customer Customer { get; } = new Customer()
        {
            CustomerID = Id,
            CompanyName = "Yungching",
            ContactName = "Kevin",
            ContactTitle = "Software Engineer",
            Address = "HOME",
            City = "Taoyuan",
            Region = "",
            PostalCode = "12345",
            Country = "Taiwan",
            Phone = "0912345678",
            Fax = ""
        };
    }

    struct TestData2
    {
        public static String Id { get; } = "ABCDE";

        public static Customer Customer { get; } = new Customer()
        {
            CustomerID = Id,
            CompanyName = "yungching",
            ContactName = "kevin",
            ContactTitle = "software engineer",
            Address = "home",
            City = "taoyuan",
            Region = "",
            PostalCode = "12345",
            Country = "taiwan",
            Phone = "0912345678",
            Fax = ""
        };
    }
}
