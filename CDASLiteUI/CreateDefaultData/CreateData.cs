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
            //CreateCities(environment, unitOfWork);
            //This method is suitable to implement CheckRoles or Cities only. Other tables such as hospitals, clinics (has loads of data) would be not so cost efficient.
            //CreateClinics(environment, unitOfWork);
            //These guys will be added via scripts. Too Expensive for server side.
            #if DEBUG
                //CreateDistricts(environment, unitOfWork);
                //CreateHospitals(environment, unitOfWork);
            #endif
        }

        private static void CreateHospitals(IWebHostEnvironment environment, IUnitOfWork unitOfWork)
        {
            try
            {
                var hospitalList = unitOfWork.HospitalRepository.GetAll().ToList();

                //Provide a path for excel file
                // Excel dosyasının bulunduğu yolu aldık
                string path = Path.Combine(environment.WebRootPath, "Excels");
                string fileName = Path.GetFileName("Hospitals.xlsx");
                string filePath = Path.Combine(path, fileName);
                using (var excelBook = new XLWorkbook(filePath))
                {
                    var rows = excelBook.Worksheet(1).RowsUsed();
                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1
                            && item.RowNumber() <= rows.Count())
                        {
                            var cell = item.Cell(1).Value; //Hospital Name
                            var districtId = Convert.ToInt32(item.Cell(2).Value); //DistrictId
                            var district = unitOfWork.DistrictRepository.GetFirstOrDefault(x => x.Id == districtId);
                            var address = item.Cell(3).Value;   //Address
                            var email = item.Cell(4).Value;   //email
                            var latitude = item.Cell(5).Value;   
                            var longitude = item.Cell(6).Value;
                            var phoneNumber = item.Cell(7).Value;
                            Hospital hospital= new Hospital()
                            {
                                HospitalName= cell.ToString(),
                                DistrictId= districtId,
                                CreatedDate = DateTime.Now,
                                Address = address.ToString(),
                                Email = email.ToString(),
                                Latitude = latitude.ToString(),
                                Longitude = longitude.ToString(),
                                PhoneNumber = phoneNumber.ToString()
                            };

                            if (hospitalList.Count(x => x.HospitalName.ToLower() == cell.ToString().ToLower() && x.DistrictId == districtId) == 0)
                            {
                                unitOfWork.HospitalRepository.Add(hospital);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private static void CreateDistricts(IWebHostEnvironment environment, IUnitOfWork unitOfWork)
        {
            try
            {
                var districtList = unitOfWork.DistrictRepository.GetAll().ToList();

                //Provide a path for excel file
                // Excel dosyasının bulunduğu yolu aldık
                string path = Path.Combine(environment.WebRootPath, "Excels");
                string fileName = Path.GetFileName("Districts.xlsx");
                string filePath = Path.Combine(path, fileName);
                using (var excelBook = new XLWorkbook(filePath))
                {
                    var rows = excelBook.Worksheet(1).RowsUsed();
                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1
                            && item.RowNumber() <= rows.Count())
                        {
                            var cell = item.Cell(1).Value; //ilçe adı
                            var cityId = Convert.ToByte(item.Cell(2).Value);//1
                            var city = unitOfWork.CityRepository.GetFirstOrDefault(x => x.Id == cityId);
                            District district = new District()
                            {
                                DistrictName = cell.ToString(),
                                CityId = cityId,
                                CreatedDate = DateTime.Now
                            };

                            if (districtList.Count(x => x.DistrictName.ToLower() == cell.ToString().ToLower() && x.CityId == cityId) == 0)
                            {
                                unitOfWork.DistrictRepository.Add(district);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
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
                            var cell = item.Cell(1).Value;  // Istanbul
                            var plateCode = item.Cell(2).Value;
                            City city = new City()
                            {
                                CreatedDate = DateTime.Now,
                                CityName = cell.ToString(),
                                PlateCode = Convert.ToByte(plateCode)
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

        private static void CreateClinics(IWebHostEnvironment environment, IUnitOfWork unitOfWork)
        {
            try
            {
                var clinicList = unitOfWork.ClinicRepository.GetAll().ToList();
                string path = Path.Combine(environment.WebRootPath, "Excels");
                string fileName = Path.GetFileName("Clinics.xlsx");
                string filePath = Path.Combine(path, fileName);
                using (var excelBook = new XLWorkbook(filePath))
                {
                    var rows = excelBook.Worksheet(1).RowsUsed();
                    foreach (var item in rows)
                    {
                        if (item.RowNumber() > 1 && item.RowNumber() <= rows.Count())
                        {
                            var cell = item.Cell(1).Value;
                            Clinic clinic = new Clinic()
                            {
                                CreatedDate = DateTime.Now,
                                ClinicName = cell.ToString()
                            };
                            if (clinicList.Count(x => x.ClinicName.ToLower() == cell.ToString().ToLower()) == 0)
                            {
                                unitOfWork.ClinicRepository.Add(clinic);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
