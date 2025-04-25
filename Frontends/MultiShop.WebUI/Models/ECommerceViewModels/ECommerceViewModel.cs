namespace MultiShop.WebUI.Models.ECommerceViewModels
{
    public class ECommerceViewModel
    {
        public class Rootobject
        {
            public string status { get; set; }
            public string request_id { get; set; }
            public Parameters parameters { get; set; }
            public Data data { get; set; }
        }

        public class Parameters
        {
            public string query { get; set; }
            public string country { get; set; }
            public string sort_by { get; set; }
            public int page { get; set; }
            public bool is_prime { get; set; }
        }

        public class Data
        {
            public int total_products { get; set; }
            public string country { get; set; }
            public string domain { get; set; }
            public Product[] products { get; set; }
        }

        public class Product
        {
            public string asin { get; set; }
            public string product_title { get; set; }
            public string product_price { get; set; }
            public string product_original_price { get; set; }
            public string currency { get; set; }
            public string product_star_rating { get; set; }
            public int product_num_ratings { get; set; }
            public string product_url { get; set; }
            public string product_photo { get; set; }
            public int product_num_offers { get; set; }
            public string product_minimum_offer_price { get; set; }
            public bool is_best_seller { get; set; }
            public bool is_amazon_choice { get; set; }
            public bool is_prime { get; set; }
            public bool climate_pledge_friendly { get; set; }
            public string sales_volume { get; set; }
            public string delivery { get; set; }
            public bool has_variations { get; set; }
            public string unit_price { get; set; }
            public int unit_count { get; set; }
            public string product_availability { get; set; }
        }
    }
}
