using System;

namespace BackendBlogServicesApi.Entries
{
    public class Categories
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Code { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public bool Estado { get; set; } = true;
    }
}
