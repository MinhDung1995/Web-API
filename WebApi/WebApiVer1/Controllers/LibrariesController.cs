using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApiVer1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LibrariesController : ApiController
    {
        private static List<Library> libraries = new List<Library>(new Library[] {
            new Library{ Id = 1, Name = "Library ABC", Address = "Quan 10, HCM",
                                    Description = "For cooking book", LibraryAdminId = 1 },
            new Library{ Id = 2, Name = "University Library", Address = "Quan 10, HCM",
                                    Description = "For book", LibraryAdminId = 1 },
            new Library{ Id = 3, Name = "GST Library", Address = "Quan 10, HCM",
                                    Description = "For khtn student", LibraryAdminId = 1 }
        });

        [HttpGet]
        [Route("api/libraries/name")]
        public IEnumerable<string> GetAllLibraryNames()
        {
            return new string[] { "Library ABC", "University Library", "GST Library" };
        }

        [HttpGet]
        [Route("api/libraries/{libraryId}")]
        public Library GetLibrary(int libraryId)
        {
            return libraries.First(l => l.Id == libraryId);
        }

        [HttpGet]
        [Route("api/libraries")]
        public IEnumerable<Library> GetAllLibraries()
        {
            return libraries;
        }
    }
}
