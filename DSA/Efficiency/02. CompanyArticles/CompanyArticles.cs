// -----------------------------------------------------------------------
// <copyright file="CompanyArticles.cs" company="Telerik">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace CompanyArticles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CompanyArticles
    {
        public CompanyArticles()
        {
            this.Articles = new OrderedMultiDictionary<float, Article>(true);
        }

        public CompanyArticles(Article article)
            : this()
        {
            this.AddArticle(article);
        }

        public OrderedMultiDictionary<float, Article> Articles { get; set; }

        public void AddArticle(Article article)
        {
            this.Articles.Add(article.Price, article);
        }

        public OrderedMultiDictionary<float, Article>.View GetArticlesInRange(float minPrise, float maxPrise)
        {
            return this.Articles.Range(minPrise, true, maxPrise, true);
        }
    }
}
