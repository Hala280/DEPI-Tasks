public class Book
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string[] Authors { get; set; }
    public DateTime PublicationDate { get; set; }
    public decimal Price { get; set; }

    public Book(string title, string isbn, string[] authors, DateTime publicationDate, decimal price)
    {
        Title = title;
        ISBN = isbn;
        Authors = authors;
        PublicationDate = publicationDate;
        Price = price;
    }

    public override string ToString()
    {
        return $"Title: {Title}\nISBN: {ISBN}\nAuthors: {string.Join(", ", Authors)}\nPublication Date: {PublicationDate.ToShortDateString()}\nPrice: ${Price:C}";
    }

}

public class  BookFunctions
{
    public static string GetTitle(Book book) => book?.Title ?? "Unknown Title";
    public static string GetAuthors(Book book)=> string.Join(", ", book?.Authors ?? Array.Empty<string>());

    public static string GetPrice(Book book )=> book.Price.ToString("C");


}


public class LibraryEngine
{
    public delegate string CustomDelegate(Book book);

    public static void ProcessBooks(List<Book> bList, Func<Book, string> fPtr)
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(fPtr(B));
        }
    }

    public static void ProcessBooks(List<Book> bList, CustomDelegate fPtr)
    {
        foreach (Book B in bList)
        {
            Console.WriteLine(fPtr(B));
        }
    }
}

public class Program
{
    public static void Main()
    {
        List<Book> myBooks = new List<Book>
    {

            // adding books to the list
        new Book("The Hobbit", "123456789", new string[] { "J.R.R. Tolkien" }, new DateTime(1937, 9, 21), 15.99m),
        new Book("1984", "987654321", new string[] { "George Orwell" }, new DateTime(1949, 6, 8), 12.50m)
    };

        Console.WriteLine("--- Testing Anonymous Method (ISBN) ---");
        LibraryEngine.ProcessBooks(myBooks, (Func<Book, string>)(delegate (Book b) { return b.ISBN; }));

        Console.WriteLine("\n--- Testing Lambda Expression (Date) ---");
        LibraryEngine.ProcessBooks(myBooks, (Func<Book, string>)(b => b.PublicationDate.ToShortDateString()));
    }
}