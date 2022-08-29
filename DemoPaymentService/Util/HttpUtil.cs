using RestSharp;

namespace DemoPaymentService.Util
{
    public class HttpUtil
    {
        public async Task<RestResponse> GetRequest(string url, Dictionary<string, string> header, string parameter)
        {
            try
            {
                var options = new RestClientOptions(parameter == null ? url : $"{url}?{parameter}")
                {
                    ThrowOnAnyError = true,
                    MaxTimeout = 8000
                };

                var client = new RestClient(options);

                var request = new RestRequest();
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "*/*");

                if (header != null)
                    foreach (var head in header)
                    {
                        request.AddHeader(head.Key, head.Value);
                    }

                var response = await Task.FromResult(client.Execute(request));

                return response;
            }
            catch (Exception) { throw; }
        }

        public async Task<RestResponse> PostResquest(string url, Dictionary<string, string> header, string parameter, string body)
        {
            try
            {
                var options = new RestClientOptions(parameter == null ? url : $"{url}?{parameter}")
                {
                    ThrowOnAnyError = true,
                    MaxTimeout = 8000
                };

                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Accept", "*/*");

                if (header != null)
                    foreach (var head in header)
                    {
                        request.AddHeader(head.Key, head.Value);
                    }

                request.AddParameter("application/json", body, ParameterType.RequestBody);
                var response = await Task.FromResult(client.Execute(request));

                return response;
            }
            catch (Exception)
            { throw; }
        }

        public async Task<RestResponse> PostMonoResquest(string url, Dictionary<string, string> header, string parameter, string body)
        {
            try
            {
                var options = new RestClientOptions(parameter == null ? url : $"{url}?{parameter}")
                {
                    ThrowOnAnyError = true,
                    MaxTimeout = 8000
                };

                var client = new RestClient(options);
                var request = new RestRequest();
                request.Method = Method.Post;
                request.AddHeader("Accept", "application/json");
                request.AddHeader("Content-Type", "application/json");

                if (header != null)
                    foreach (var head in header)
                    {
                        request.AddHeader(head.Key, head.Value);
                    }

                request.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = await Task.FromResult(client.Execute(request));

                return response;
            }
            catch (Exception)
            { throw; }
        }
    }
}