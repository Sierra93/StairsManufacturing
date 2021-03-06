﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using StairsManufacturing.Models;
using StairsManufacturing.Models.Context;
using StairsManufacturing.Models.Index;

namespace StairsManufacturing.Controllers {
    public class HomeController : Controller {
        ApplicationContext db;
        string connectionString = "Server=lestnicudom.ru,1433; Database=u0936707_manufacturingdb; Persist Security Info=False; User ID=u0936707_admin; Password=4PbefUvjVAwsfHV; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=true; Connection Timeout=30;";
        public HomeController(ApplicationContext _context) {
            db = _context; 
        }
        /// <summary>
        /// Получение изображений для главной страницы
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() {
            var model = GetImagesFromDB();
            return View(model);
        }
        /// <summary>
        /// Выборка изображений из БД
        /// </summary>
        /// <returns></returns>
        public List<IndexModel> GetImagesFromDB() {
            List<IndexModel> collectionImages = new List<IndexModel>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT ID, NAME_PHOTO, IMAGE_PHOTO, CATEGORY FROM PHOTO_CAGETORY", con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                collectionImages.Add(new IndexModel {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    NAME_PHOTO = reader["NAME_PHOTO"].ToString(),
                                    IMAGE_PHOTO = reader["IMAGE_PHOTO"].ToString(),
                                    CATEGORY = Convert.ToInt32(reader["CATEGORY"].ToString())
                                });
                            }
                        }
                    }
                }
            }
            return collectionImages;
        }
    }
}
