using System.Net.Http.Headers;

namespace P3.Services
{
    public class DataRetrieval
    {
        // Build A Method To Get Data From A API Endpoint
        // We are going to send in the endpoint of the url ("about/" or "people/")
        public async Task<string> GetData(string endpoint)
        {
            // Task vs Thread - 
            // Task Has async/await & A return value, Can Cancel Task
            // Thread - No Direct Way To Return From A Thread, Thread Can Do Multiple Things At Once

            // using Statement - At End Of It, It Is Automagically Disposed
            using (var client = new HttpClient())
            {
                // We Need To Setup Our Http Client
                // Request/Response
                client.BaseAddress = new Uri("https://ischool.gccis.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                // Tells The Server The Type Of File I'm Expecting
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                try
                {
                    HttpResponseMessage response = await client.GetAsync(endpoint);
                    response.EnsureSuccessStatusCode();
                    // Go Get It
                    var data = await response.Content.ReadAsStringAsync();
                    // Data Is A String
                    return data;
                } 
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    return "httpRequest" + msg;
                } 
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    return "Exception" + msg;
                }
            }
        }
    }
}