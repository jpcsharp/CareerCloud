using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph.Models;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
     class Program
    {
        private static IConfigurationRoot _configurationRoot;
        static void Main(string[] args)
        {
            var connectionstring = _configurationRoot.GetConnectionString("DataConnection");
            var options = new DbContextOptionsBuilder<CareerCloudContext>().UseSqlServer(connectionstring).Options;

        }
    }
}
