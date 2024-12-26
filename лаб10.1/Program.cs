using System;

class Book
{
    protected string title;
    protected int pageCount;
    protected double price;
    public Book(string title, int pageCount, double price)
    {
        this.title = title;
        this.pageCount = pageCount;
        this.price = price;
    }
    public virtual string GetInfo()
    {
        return $"Title: {title}, Pages: {pageCount}, Price: {price:C}";
    }
}

class LibraryBook : Book
{
    private double discountPercentage;
    public LibraryBook(string title, int pageCount, double price, double discountPercentage)
        : base(title, pageCount, price)
    {
        this.discountPercentage = discountPercentage;
    }
    public double CalculateDiscountedPrice()
    {
        return price - (price * discountPercentage / 100);
    }
    public override string GetInfo()
    {
        return $"{base.GetInfo()}, Discount: {discountPercentage}%, Discounted Price: {CalculateDiscountedPrice():C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        LibraryBook libraryBook = new LibraryBook("C# Programming", 300, 29.99, 10);
        Console.WriteLine(libraryBook.GetInfo());
        double discountedPrice = libraryBook.CalculateDiscountedPrice();
        Console.WriteLine($"Discounted Price: {discountedPrice:C}");
    }
}
