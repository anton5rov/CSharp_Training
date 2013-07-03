namespace CompanyArticles
{
    using System;
    using System.Text;

    public class Article : IComparable<Article>
    {
        public Article(float price, int barCode, string vendor, string title)
        {
            this.Price = price;
            this.BarCode = barCode;
            this.Vendor = vendor;
            this.Title = title;
        }

        public int BarCode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public float Price { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}, vendor: {1}, bar code: {2}, price: ${3:N2}",
                this.Title, this.Vendor, this.BarCode, this.Price);
            return sb.ToString();
        }

        public int CompareTo(Article other)
        {
            if (this.Vendor.CompareTo(other.Vendor) != 0)
            {
                return this.Vendor.CompareTo(other.Vendor);
            }

            // Choose to first select articles by vendor,
            // than by bar code.
            else
            {
                return this.BarCode.CompareTo(other.BarCode);
            }
        }
    }
}
