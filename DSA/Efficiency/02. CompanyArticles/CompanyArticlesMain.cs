namespace CompanyArticles
{
    using System;
    using Wintellect.PowerCollections;

    public class CompanyArticlesMain
    {
        public static void Main()
        {
            CompanyArticles myShop = new CompanyArticles();
            myShop.AddArticle(new Article(1.5f, 123, "Bakery", "White bread"));
            myShop.AddArticle(new Article(1, 124, "Fine sausages", "Salami"));
            myShop.AddArticle(new Article(1.5f, 125, "A. Madjarski", "Cheese"));
            myShop.AddArticle(new Article(2, 126, "A. Madjarski", "Yogurt"));
            myShop.AddArticle(new Article(3.2f, 127, "Madjarski", "Yellow Cheese"));

            OrderedMultiDictionary<float, Article>.View select = myShop.GetArticlesInRange(1, 2);

            Console.WriteLine("Sorted by price, then by vendor, then by bar code:");
            foreach (var item in select.Values)
            {
                Console.WriteLine(item);
            }
        }
    }
}
