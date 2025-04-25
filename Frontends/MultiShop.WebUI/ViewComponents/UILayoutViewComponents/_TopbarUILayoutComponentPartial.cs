using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Models.RapidApiViewModels.CurrenciesViewModels_;
using Newtonsoft.Json;
namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _TopbarUILayoutComponentPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ExchangeRateViewModel? model = new ExchangeRateViewModel();
            var client = new HttpClient();
            var client2 = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&language=TR&to_symbol=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", "abedb3b754msh1231493457e791dp16ec12jsndbe4630f6b52" },
                    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                },
            };
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&language=TR&to_symbol=TRY"),
                Headers =
                {
                    { "x-rapidapi-key", "abedb3b754msh1231493457e791dp16ec12jsndbe4630f6b52" },
                    { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var usd = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body);
                    model.Usd = decimal.Parse(usd.data.exchange_rate.ToString());
                    model.UsdSymbol = usd.data.to_symbol;
                }
                else
                {
                    model.Usd = 34;
                    model.UsdSymbol = "veri yok";
                }

            }
            using (var response2 = await client2.SendAsync(request2))
            {
                if (response2.IsSuccessStatusCode)
                {
                    response2.EnsureSuccessStatusCode();
                    var body2 = await response2.Content.ReadAsStringAsync();
                    var eur = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(body2);
                    model.Eur = decimal.Parse(eur.data.exchange_rate.ToString());
                    model.EurSymbol = eur.data.to_symbol;
                }
                else
                {
                    model.Eur = 37;
                    model.EurSymbol = "veri yok";
                }
            }
            return View(model);
        }
    }
}
