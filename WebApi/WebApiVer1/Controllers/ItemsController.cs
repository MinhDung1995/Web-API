using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiVer1.Controllers
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ItemsController : ApiController
    {
        private static List<Item> items = new List<Item>(new Item[] {
            new Item { Id = 1, Name = "Demon  & Angel", LibraryId = 1, ContributorId = 1, IsActive = true, Description = "Mystery Adventure", ManufactoryId = 2  },
            new Item { Id = 2, Name = "Da Vinci Code", LibraryId = 1, ContributorId = 1, IsActive = true, Description = "Another Mystery Adventure" , ManufactoryId = 2},
            new Item { Id = 3, Name = "Infernal", LibraryId = 1, ContributorId = 1, IsActive = true, Description = "New Mystery Adventure", ManufactoryId = 2},
            new Item { Id = 4, Name = "Infernal", AdditionalName="Infernal#2", LibraryId = 2, ContributorId = 1, IsActive = true, Description = "New Mystery Adventure", ManufactoryId = 2},
            new Item { Id = 5, Name = "Infernal", AdditionalName="Infernal#3", LibraryId = 3, ContributorId = 1, IsActive = true, Description = "Brand New Mystery Adventure", ManufactoryId = 2},
            new Item { Id = 6, Name = "Infernal", AdditionalName="Infernal#4", LibraryId = 4, ContributorId = 1, IsActive = true, Description = "Super New Mystery Adventure", ManufactoryId = 2},
            new Item { Id = 7, Name = "Infernal", AdditionalName="Infernal#5", LibraryId = 5, ContributorId = 1, IsActive = true, Description = "Somehow New Mystery Adventure", ManufactoryId = 2},
            new Item { Id = 8, Name = "Infernal", AdditionalName="Infernal#6", LibraryId = 6, ContributorId = 1, IsActive = true, Description = "Forever Mystery Adventure", ManufactoryId = 2},

            new Item { Id = 9, Name = "One Piece 1", LibraryId = 1, ContributorId = 8, IsActive = true, Description = "Forever Mystery Adventure", ManufactoryId = 1},
            new Item { Id = 10, Name = "One Piece 2", LibraryId = 1, ContributorId = 8, IsActive = true, Description = "Forever Mystery Adventure", ManufactoryId = 1},
            new Item { Id = 11, Name = "One Piece 3", LibraryId = 1, ContributorId = 8, IsActive = true, Description = "Forever Mystery Adventure", ManufactoryId = 1},
            new Item { Id = 12, Name = "One Piece 4", LibraryId = 1, ContributorId = 8, IsActive = true, Description = "Forever Mystery Adventure", ManufactoryId = 1},
            new Item { Id = 13, Name = "One Piece 5", LibraryId = 1, ContributorId = 8, IsActive = true, Description = "Forever Mystery Adventure", ManufactoryId = 1},
            new Item { Id = 14, Name = "One Piece 6", LibraryId = 1, ContributorId = 8, IsActive = true, Description = "Forever Mystery Adventure", ManufactoryId = 1},
            new Item { Id = 15, Name = "One Piece 7", LibraryId = 1, ContributorId = 8, IsActive = true, Description = "Forever Mystery Adventure", ManufactoryId = 1},
            new Item { Id = 16, Name = "One Piece 8", LibraryId = 1, ContributorId = 8, IsActive = true, Description = "Forever Mystery Adventure", ManufactoryId = 1}
        });

        private static List<Category> categories = new List<Category>(new Category[]
        {
            new Category {Id = 1, ParrentCategoryId = null, Name = "Book", LibraryId = 1, IsActive = true },
            new Category {Id = 2, ParrentCategoryId = 1, Name = "Novel", LibraryId = 1, IsActive = true },
            new Category {Id = 3, ParrentCategoryId = 1, Name = "Manga", LibraryId = 1, IsActive = true },
            new Category {Id = 4, ParrentCategoryId = 1, Name = "Schoolbook", LibraryId = 1, IsActive = true },
            new Category {Id = 5, ParrentCategoryId = null, Name = "Household", LibraryId = 1, IsActive = true },
            new Category {Id = 6, ParrentCategoryId = 5, Name = "Iron", LibraryId = 1, IsActive = true },
            new Category {Id = 7, ParrentCategoryId = 5, Name = "Fan", LibraryId = 1, IsActive = true },
            new Category {Id = 8, ParrentCategoryId = 5, Name = "Lamp", LibraryId = 1, IsActive = true },
            new Category {Id = 9, ParrentCategoryId = 5, Name = "Folding Table", LibraryId = 1, IsActive = true },
            new Category {Id = 10, ParrentCategoryId = 5, Name = "Washing Machine", LibraryId = 1, IsActive = true },
            new Category {Id = 11, ParrentCategoryId = null, Name = "Electronic", LibraryId = 1, IsActive = true },
            new Category {Id = 12, ParrentCategoryId = 11, Name = "USB" , LibraryId = 1, IsActive = true },
            new Category {Id = 13, ParrentCategoryId = 11, Name = "Mouse", LibraryId = 1, IsActive = true },
            new Category {Id = 14, ParrentCategoryId = 11, Name = "Hard Disk", LibraryId = 1, IsActive = true },
            new Category {Id = 15, ParrentCategoryId = 11, Name = "DVD-CD", LibraryId = 1, IsActive = true },
            new Category {Id = 16, ParrentCategoryId = 11, Name = "Memory Card", LibraryId = 1, IsActive = true },
            new Category {Id = 17, ParrentCategoryId = 11, Name = "Camera", LibraryId = 1, IsActive = true },
            new Category {Id = 18, ParrentCategoryId = null, Name = "Smart Equipment", LibraryId = 1, IsActive = true },
            new Category {Id = 19, ParrentCategoryId = 18, Name = "Apple", LibraryId = 1, IsActive = true },
            new Category {Id = 20, ParrentCategoryId = 19, Name = "IPad", LibraryId = 1, IsActive = true },
            new Category {Id = 21, ParrentCategoryId = 19, Name = "IPhone", LibraryId = 1, IsActive = true },
            new Category {Id = 22, ParrentCategoryId = 19, Name = "IPod", LibraryId = 1, IsActive = true },
            new Category {Id = 23, ParrentCategoryId = 18, Name = "Samsung", LibraryId = 1, IsActive = true }
        });

        private static List<ItemCategory> itemCategories = new List<ItemCategory>(new ItemCategory[]
        {
            new ItemCategory { Id = 1, CategoryId = 1, ItemId = 1 },
            new ItemCategory { Id = 2, CategoryId = 1, ItemId = 2 },
            new ItemCategory { Id = 3, CategoryId = 1, ItemId = 3 },
            new ItemCategory { Id = 4, CategoryId = 1, ItemId = 4 },
            new ItemCategory { Id = 5, CategoryId = 1, ItemId = 5 },
            new ItemCategory { Id = 6, CategoryId = 1, ItemId = 6 },
            new ItemCategory { Id = 7, CategoryId = 1, ItemId = 7 },
            new ItemCategory { Id = 8, CategoryId = 1, ItemId = 8 },
            new ItemCategory { Id = 9, CategoryId = 1, ItemId = 9 },
            new ItemCategory { Id = 10, CategoryId = 1, ItemId = 10 },
            new ItemCategory { Id = 11, CategoryId = 1, ItemId = 11 },
            new ItemCategory { Id = 12, CategoryId = 1, ItemId = 12 },
            new ItemCategory { Id = 13, CategoryId = 1, ItemId = 13 },
            new ItemCategory { Id = 14, CategoryId = 1, ItemId = 14 },
            new ItemCategory { Id = 15, CategoryId = 1, ItemId = 15 },
            new ItemCategory { Id = 16, CategoryId = 1, ItemId = 16 },

            new ItemCategory { Id = 17, CategoryId = 2, ItemId = 1 },
            new ItemCategory { Id = 18, CategoryId = 2, ItemId = 2 },
            new ItemCategory { Id = 19, CategoryId = 2, ItemId = 3 },
            new ItemCategory { Id = 20, CategoryId = 2, ItemId = 4 },
            new ItemCategory { Id = 21, CategoryId = 2, ItemId = 5 },
            new ItemCategory { Id = 22, CategoryId = 2, ItemId = 6 },
            new ItemCategory { Id = 23, CategoryId = 2, ItemId = 7 },
            new ItemCategory { Id = 24, CategoryId = 2, ItemId = 8 },

            new ItemCategory { Id = 25, CategoryId = 3, ItemId = 9 },
            new ItemCategory { Id = 26, CategoryId = 3, ItemId = 10 },
            new ItemCategory { Id = 27, CategoryId = 3, ItemId = 11 },
            new ItemCategory { Id = 28, CategoryId = 3, ItemId = 12 },
            new ItemCategory { Id = 29, CategoryId = 3, ItemId = 13 },
            new ItemCategory { Id = 30, CategoryId = 3, ItemId = 14 },
            new ItemCategory { Id = 31, CategoryId = 3, ItemId = 15 },
            new ItemCategory { Id = 32, CategoryId = 3, ItemId = 16 }
        });

        private static List<User> users = new List<User>(new User[]
        {
            new User { Id = 1, Name = "Nguyễn Văn Tín" },
            new User { Id = 2, Name = "Nguyễn Tiến Dũng" },
            new User { Id = 3, Name = "Nguyễn Minh Thiện" },
            new User { Id = 4, Name = "Đặng Thành Luân" },
            new User { Id = 5, Name = "Nguyễn Thanh Phi" },
            new User { Id = 6, Name = "Lê Viết Toàn" },
            new User { Id = 7, Name = "Đinh Quang Trung" },
            new User { Id = 8, Name = "Nguyễn Minh Dũng" },
            new User { Id = 9, Name = "Vũ Đình Thăng" }
        });

        private static List<Manuafactory> manufactories = new List<Manuafactory>(new Manuafactory[]
        {
            new Manuafactory { Id = 1, Name = "NXB Kim Đồng" },
            new Manuafactory { Id = 2, Name = "NXB Trẻ" },
            new Manuafactory { Id = 3, Name = "Apple" },
            new Manuafactory { Id = 4, Name = "Samsung" },
            new Manuafactory { Id = 5, Name = "NXB Văn Hóa - Văn Nghệ HCM" },
            new Manuafactory { Id = 6, Name = "NXB Giáo Dục" },
            new Manuafactory { Id = 7, Name = "Hitachi" },
            new Manuafactory { Id = 8, Name = "Sanyo" },
            new Manuafactory { Id = 9, Name = "Daichi" },
            new Manuafactory { Id = 10, Name = "Vaio" },
        });

        private static List<Notification> notifications = new List<Notification>(new Notification[]
        {
            new Notification { Id = 1, ToUserId = 1, NotificationType = "Cancel", Message = "User A cancel his registration on Demon & Angel", StatusId = 1 },
            new Notification { Id = 2, ToUserId = 2, NotificationType = "Aprroved", Message = "Library ABC approved your registration of Demon & Angel", StatusId = 1 },
            new Notification { Id = 3, ToUserId = 2, NotificationType = "Aprroved", Message = "Library ABC approved your extention of Infernal", StatusId = 1 },
            new Notification { Id = 3, ToUserId = 2, NotificationType = "Aprroved", Message = "Library ABC approved your jouning request", StatusId = 1 }
        });

        [HttpGet]
        [Route("api/libraries/{libraryId}/items")]
        public IEnumerable<Item> GetAllItems(int libraryId)
        {
            return items.Where(i => i.LibraryId == libraryId && i.IsActive == true);
        }

        [HttpGet]
        [Route("api/users/{userId}/contributedItems")]
        public IEnumerable<Item> GetAllContributedItems(int userId)
        {
            return items.Where(i => i.ContributorId == userId && i.IsActive == true);
        }

        [HttpGet]
        [Route("api/libraries/{libraryId}/categories")]
        public IEnumerable<Category> GetAllLibraryCategories(int libraryId)
        {
            return categories.Where(c => c.LibraryId == libraryId && c.IsActive == true);
        }

        [HttpGet]
        [Route("api/libraries/{libraryId}/{categoryId}/items")]
        public IEnumerable<Item> GetAllCategoryItems(int libraryId, int categoryID)
        {
            return items.Where(i => i.LibraryId == libraryId && i.IsActive == true 
                        && itemCategories.Where(iC => iC.CategoryId == categoryID)
                            .Select(iC1 => iC1.ItemId).Contains(i.Id));
        }

        [HttpGet]
        [Route("api/manufactories")]
        public IEnumerable<Manuafactory> GetAllManufactory()
        {
            return manufactories;
        }

        [HttpGet]
        [Route("api/contributors")]
        public IEnumerable<User> GetAllContributors()
        {
            return users.Where(u => items.Select(i => i.ContributorId).Contains(u.Id));
        }

        [HttpGet]
        [Route("api/libraries/{libraryId}/search?name={name}&category={categoryId}&manufactory={manufactoryId}&contributor={userId}")]
        public IEnumerable<Item> FindItems(int libraryId, string name, int categoryId, 
                                                            int manufactoryId, int contributorId)
        {
            return items.Where(i => i.LibraryId == libraryId && i.IsActive == true
                            && i.ManufactoryId == manufactoryId && i.ContributorId == contributorId
                            && itemCategories.Where(iC => iC.CategoryId == categoryId)
                            .Select(iC1 => iC1.ItemId).Contains(i.Id));
        }

        [HttpGet]
        [Route("api/users/{userId}/notifications")]
        public IEnumerable<Notification> GetAllNotification(int userId)
        {
            return notifications.Where(n => n.ToUserId == userId);
        }
    }
}
