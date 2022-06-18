using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebServiceBooking.Backend.Data;

namespace ServiceBooking.WebBackend.UnitTest
{
    public class InMemoryDbContextFactory
    {
        public WebDBContext GetApplicationDbContext(string databaseName = "InMemoryApplicationDatabase")
        {
            var options = new DbContextOptionsBuilder<WebDBContext>()
                       .UseInMemoryDatabase(databaseName: databaseName)
                       .Options;
            var dbContext = new WebDBContext(options);
 
            return dbContext;
        }
    }
}
    