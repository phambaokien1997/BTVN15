using ThuVien.Data.Models;

namespace LibraryWEB.Models
{
    public class ListBookModel : Books
	{
		public List<Books> Books { get; set; }
		
		
	}
	//{
 //       public List<BookModel> Books { get; set; }
 //       public string BookStoreOwner { get; set; }
 //       public string Director { get; set;}
 //   }
 //   public class BookModel()
 //   {

 //       public string Title { get; set; }
 //       public string Author { get; set; }
 //       public int BookID { get; set; }
	//	public override string ToString()
	//	{
	//		return $"Title {Title}, Author {Author}, BookID {BookID}";
	//	}
	//}
}
