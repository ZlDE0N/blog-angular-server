namespace BackendBlogServicesApi.DTOs
{
    public class CreateEntriesBlogCategoryDto
    {
        public int IdEntriesBlog { get; set; }
        public int IdCategories { get; set; }
        public bool Estado { get; set; } = true;
    }

    public class EntriesBlogCategoryDto
    {
            public int IdEntriesBlog { get; set; }
            public int IdCategories { get; set; }
            public string CategoriaName { get; set; } // Nombre de la categoría
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }
            public DateTime PublicationDate { get; set; }
        }
}
