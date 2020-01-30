using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StairsManufacturing.Models;
using StairsManufacturing.Models.Index;

namespace StairsManufacturing.Models.Context {
    public class ApplicationContext : DbContext {
        // Кэш данных для главной таблицы с фото
        public DbSet<IndexModel> PHOTO_CATEGORY { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) {
            Database.EnsureCreated();   // Создает базу данных при первом обращении
        }
    }
}
