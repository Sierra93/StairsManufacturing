using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StairsManufacturing.Models;
using StairsManufacturing.Models.Index;
using Microsoft.Data.SqlClient;
using StairsManufacturing.Models.Context;

namespace StairsManufacturing.Controllers {
    /// <summary>
    /// Выборка детальных изображений по ID с главной страницы
    /// </summary>
    public class GetDetailsImagesController : Controller {
        ApplicationContext db;
        string connectionString = "Server=lestnicudom.ru,1433; Database=u0936707_manufacturingdb; Persist Security Info=False; User ID=u0936707_admin; Password=4PbefUvjVAwsfHV; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=true; Connection Timeout=30;";
        public GetDetailsImagesController(ApplicationContext _context) {
            db = _context;
        }
        public IActionResult GetDetails(int id) {
            var result = GetImages(id);
            return View(result);
        }
        /// <summary>
        /// Выборка изображений
        /// </summary>
        /// <param name="model">Модель изображений</param>
        /// <returns></returns>
        public List<IndexModel>GetImages(int id) {
            List<IndexModel> collectionImages = new List<IndexModel>();
            using (var con = new SqlConnection(connectionString)) {
                con.Open();
                using (var com = new SqlCommand("SELECT * FROM DETAILS_PHOTO_CATEGORY " +
                    " WHERE CATEGORY = " + id, con)) {
                    using (var reader = com.ExecuteReader()) {
                        if (reader.HasRows) {
                            while (reader.Read()) {
                                collectionImages.Add(new IndexModel {
                                    ID = Convert.ToInt32(reader["ID"]),
                                    NAME_PHOTO = reader["NAME_PHOTO"].ToString(),
                                    IMAGE_PHOTO = reader["IMAGE_PHOTO"].ToString(),
                                    CATEGORY = Convert.ToInt32(reader["CATEGORY"].ToString()),
                                    PRICE = reader["PRICE"].ToString()
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