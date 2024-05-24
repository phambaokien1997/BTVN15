using ThuVien.Data.Models;

namespace LibraryWEB.Models
{
    public class ListAuthorModel
    {
        public List<AuthorModel> Authors { get; set; }
    }
    public class AuthorModel
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Id { get; set; }
    }
}
