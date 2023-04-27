using RestSharp;

namespace TodoApi.Services
{
    public static class NewService
    {
        public static async Task<String> GetNewAsync(string? Cookie)
        {
            var options = new RestClientOptions("https://skhcn.thuathienhue.gov.vn")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/Service/TinTuc.asmx/DanhSachTin", Method.Post);

            if (Cookie != null)
            {
                request.AddHeader("Cookie", $"D1N={Cookie}; path=/");
            }
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("token", "41-F6-15-15-24-E7-3D-A5-52-55-74-47-64-0A-15-12-E1-AE-80-73");
            request.AddParameter("tukhoa", "");
            request.AddParameter("perpage", "20");
            request.AddParameter("page", "1");
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
            return response.Content!;
        }


    }

}