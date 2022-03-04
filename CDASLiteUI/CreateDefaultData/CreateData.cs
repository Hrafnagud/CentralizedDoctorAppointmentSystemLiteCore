using CDASLiteBusinessLogicLayer.Contracts;
using CDASLiteEntityLayer.Enums;
using CDASLiteEntityLayer.IdentityModels;
using CDASLiteEntityLayer.Models;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CDASLiteUI.CreateDefaultData
{
    public static class CreateData
    {
        public static void Create(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IUnitOfWork unitOfWork, IConfiguration configuration, IWebHostEnvironment environment)
        {
            //Method calls to add data.
            CheckRoles(roleManager);
            CreateCities(environment, unitOfWork);
        }

        private static void CheckRoles(RoleManager<AppRole> roleManager)
        {
            var allRoles = Enum.GetNames(typeof(RoleNames));
            foreach (var item in allRoles)
            {
                if (!roleManager.RoleExistsAsync(item).Result)
                {
                    var result = roleManager.CreateAsync(new AppRole()
                    {
                        Name = item,
                        Description = item
                    }).Result;  //In methods which is not async type, we can use async object methods by using Result property. 
                }
            }
        }

        private static void CreateCities(IWebHostEnvironment environment, IUnitOfWork unitOfWork)
        {
            try
            {
                //Provide a path for excel file. Obtain where the xlsx file, which you're looking for, located.
                string path = Path.Combine(environment.WebRootPath,"Excels");
                string fileName = Path.GetFileName("Cities.xlsx");
                string filePath = Path.Combine(path, fileName);
                using (var excelBook = new XLWorkbook(filePath))
                {
                    var rows = excelBook.Worksheet(1).RowsUsed();
                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1 && item.RowNumber() <= rows.Count())
                        {
                            var cell = item.Cell(2).Value;  // Istanbul
                            City city = new City()
                            {
                                CreatedDate = DateTime.Now,
                                CityName = cell.ToString(),
                                PlateCode = Convert.ToByte(item.Cell(3).Value)
                            };
                            unitOfWork.CityRepository.Add(city);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
