namespace KnapsackProblem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class KnapsackProblemMain
    {
        static void Main(string[] args)
        {   
            Dictionary<int, SetOfArticles> Knapsack = new Dictionary<int, SetOfArticles>();

            SetOfArticles articles = new SetOfArticles();

            Article beer = new Article("beer", 3, 2);
            Article vodka = new Article("vodka", 8, 12);
            Article cheese = new Article("cheese", 4, 5);
            Article nuts = new Article("nuts", 1, 4);
            Article ham = new Article("ham", 2, 3);
            Article whiskey = new Article("whiskey", 8, 13);

            articles.AddArticle(beer);
            articles.AddArticle(vodka);
            articles.AddArticle(cheese);
            articles.AddArticle(ham);
            articles.AddArticle(nuts);
            articles.AddArticle(whiskey);

            Console.WriteLine(articles);

            int maxWeight = 10;

            InitKnapsack(Knapsack, maxWeight);

            SetOfArticles result = new SetOfArticles();

            ResolveKnapsack(Knapsack, articles, maxWeight);

            for (int i = 0; i <= maxWeight; i++)
            {
                Console.WriteLine("Max weight: {0}", i);
                Console.WriteLine(Knapsack[i]);
            }
        }

        private static void InitKnapsack(Dictionary<int, SetOfArticles> Knapsack, int maxWeight)
        {
            for (int i = 0; i <= maxWeight; i++)
            {
                Knapsack.Add(i, new SetOfArticles());
            }
        }

        private static void ResolveKnapsack(
            Dictionary<int, SetOfArticles> Knapsack, 
            SetOfArticles articles, 
            int maxWeight)
        {
            if (maxWeight > 0)
            {
                ResolveKnapsack(Knapsack, articles, maxWeight -1);

                int maxCost = 0;

                foreach (var article in articles.Set)
                {
                    int previousWeight = maxWeight - article.Weight;
                    if (previousWeight >= 0) // Adding this article is possible.
                    {
                        if (!Knapsack[previousWeight].Set.Contains(article)) // This article is NOT used yet.
                        {
                            int maxCostAddingThisArticle = article.Value + Knapsack[previousWeight].SumOfValues();
                            if (maxCostAddingThisArticle > maxCost)
                            {
                                SetOfArticles newSet = new SetOfArticles(Knapsack[previousWeight].Set);
                                newSet.Set.Add(article);
                                Knapsack[maxWeight] = newSet;
                                maxCost = newSet.SumOfValues();
                            }
                        }
                    }
                }

                if (maxCost <= Knapsack[maxWeight - 1].SumOfValues())
                {
                    Knapsack[maxWeight] = Knapsack[maxWeight - 1];
                }
            }
        }
    }
}