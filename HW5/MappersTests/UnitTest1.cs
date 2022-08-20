using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using DataAcess.Mappers.Customer;
using DataAcess.Mappers.Item;
using HW3.Models.Requests;
using HW3.Models.Responses;
using System;
using HW3.Models.DBTables;

namespace MappersTests
{
    [TestClass]
    public class UnitTest1
    {
        CustomerRequestToDBCustomers customerRequestToDBCustomers;
        DBCustomerToCustomerResponse dBCustomerToCustomerResponse;
        ListDBCustomersToFindCustomersResponse listDBCustomersToFindCustomersResponse;

        CustomerRequest customerRequest;
        FindCustomersResponse findResponseCustomer;
        CustomerResponse customerResponse;
        DBCustomers dBCustomers;

        ItemRequestToDBItems itemRequestToDBItems;
        DBItemToItemResponse dBItemToItemResponse;
        ListDBItemToFindItemResponse listDBItemToFindItemResponse;

        ItemRequest itemRequest;
        FindItemsResponse findResponseItem;
        ItemResponse itemResponse;
        DBItems dBItems;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            customerRequestToDBCustomers = new CustomerRequestToDBCustomers();
            dBCustomerToCustomerResponse = new DBCustomerToCustomerResponse();
            listDBCustomersToFindCustomersResponse = new ListDBCustomersToFindCustomersResponse();

            dBItemToItemResponse = new DBItemToItemResponse();
            listDBItemToFindItemResponse = new ListDBItemToFindItemResponse();
            itemRequestToDBItems = new ItemRequestToDBItems();
        }

        [SetUp]
        public void SetUp()
        {
            customerRequest = new()
            {
                Id = Guid.NewGuid(),
                Name = "Simon",
                Surename = "Dibrov",
                Adress = "evgbhnjmktfgyhujdfes",
                isActive = false
            };

            dBCustomers = new()
            {
                Id = customerRequest.Id,
                Name = "Simon",
                Surename = "Dibrov",
                Adress = "evgbhnjmktfgyhujdfes",
                isActive = false
            };

            customerResponse = new()
            {
                Name = "Simon",
                Surename = "Dibrov",
                Adress = "evgbhnjmktfgyhujdfes",
            };

            findResponseCustomer = new()
            {
                customerResponses = new() { customerResponse, customerResponse }
            };

            itemRequest = new()
            {
                Id = Guid.NewGuid(),
                Id_provider = Guid.NewGuid(),
                Amount = 23,
                Price = 14,
                Expiration_date = DateTime.Now,
                isActive = false
            };

            dBItems = new()
            {
                Id = itemRequest.Id,
                Id_provider = itemRequest.Id_provider,
                Amount = 23,
                Price = 14,
                Expiration_date = itemRequest.Expiration_date,
                isActive = false
            };

            itemResponse = new()
            {
                Amount = 23,
                Price = 14,
                Expiration_date = itemRequest.Expiration_date,
            };

            findResponseItem = new()
            {
                ItemResponses = new() { itemResponse, itemResponse }
            };
        }


        [Test]
        public void TestCustomerRequestToDBCustomer()
        {
            var result = customerRequestToDBCustomers.Map(customerRequest);
            NUnit.Framework.Assert.AreEqual(customerRequest.Id, result.Id);
            NUnit.Framework.Assert.AreEqual(customerRequest.Name, result.Name);
            NUnit.Framework.Assert.AreEqual(customerRequest.Adress, result.Adress);
            NUnit.Framework.Assert.AreEqual(customerRequest.Surename, result.Surename);
            NUnit.Framework.Assert.AreEqual(customerRequest.isActive, result.isActive);
        }

        [Test]
        public void TestDBCustomerToCustomerResponse()
        {
            var result = dBCustomerToCustomerResponse.Map(customerRequest);
            NUnit.Framework.Assert.AreEqual(customerRequest.Name, result.Name);
            NUnit.Framework.Assert.AreEqual(customerRequest.Adress, result.Adress);
            NUnit.Framework.Assert.AreEqual(customerRequest.Surename, result.Surename);
        }
        [Test]
        public void TestListDBCustomersToFindCustomersResponse()
        {
            var result = listDBCustomersToFindCustomersResponse.Map(new() { dBCustomers, dBCustomers });
            foreach(var customerResponse in result.customerResponses)
            {
                NUnit.Framework.Assert.AreEqual(dBCustomers.Name, customerResponse.Name);
                NUnit.Framework.Assert.AreEqual(dBCustomers.Adress, customerResponse.Adress);
                NUnit.Framework.Assert.AreEqual(dBCustomers.Surename, customerResponse.Surename);
            }
        }



        [Test]
        public void TestItemRequestToDBItem()
        {
            var result = itemRequestToDBItems.Map(itemRequest);
            NUnit.Framework.Assert.AreEqual(itemRequest.Id, result.Id);
            NUnit.Framework.Assert.AreEqual(itemRequest.Id_provider, result.Id_provider);
            NUnit.Framework.Assert.AreEqual(itemRequest.Amount, result.Amount);
            NUnit.Framework.Assert.AreEqual(itemRequest.Price, result.Price);
            NUnit.Framework.Assert.AreEqual(itemRequest.Expiration_date, result.Expiration_date);
            NUnit.Framework.Assert.AreEqual(itemRequest.isActive, result.isActive);
        }

        [Test]
        public void TestDBItemToItemResponse()
        {
            var result = dBItemToItemResponse.Map(dBItems);
            NUnit.Framework.Assert.AreEqual(dBItems.Amount, result.Amount);
            NUnit.Framework.Assert.AreEqual(dBItems.Price, result.Price);
            NUnit.Framework.Assert.AreEqual(dBItems.Expiration_date, result.Expiration_date);
        }
        [Test]
        public void TestListDBItemsToFindItemsResponse()
        {
            var result = listDBItemToFindItemResponse.Map(new() { dBItems, dBItems });
            foreach (var itemResponse in result.ItemResponses)
            {
                NUnit.Framework.Assert.AreEqual(dBItems.Amount, itemResponse.Amount);
                NUnit.Framework.Assert.AreEqual(dBItems.Price, itemResponse.Price);
                NUnit.Framework.Assert.AreEqual(dBItems.Expiration_date, itemResponse.Expiration_date);
            }
        }
    }
}
