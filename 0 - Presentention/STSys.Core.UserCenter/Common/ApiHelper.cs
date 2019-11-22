using IdentityModel.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace STSys.Core.UserCenter.Common
{
    public class ApiHelper
    {
        public IConfiguration _configuration { get; }
        ///坑爹啊。。。。。。。。。
        private static string _API = "http://localhost:5000";
        public ApiHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static T Get<T>(string url,string token="")
        {
            url = _API+ url;
            T model = default(T);
            var client = new HttpClient();
            client.SetBearerToken(token);
            var task = client.GetAsync(url).ContinueWith((taskwithresponse) =>
            {
                var response = taskwithresponse.Result;
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                try
                {
                    model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString.Result);
                }
                catch (Exception ex)
                {
                    LogHelper.LogWarning("错误", ex.Message);
                    model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>("{'apierrcode':" + jsonString.Result + "}");
                }
            });
            task.Wait();
            if (model == null)
            {
                Type t = typeof(T);
                if(t.IsClass)
                    return (T)Activator.CreateInstance(t, true);
                return default(T);
            }
            return model;
        }
        /// <summary>
        /// Get 异步请求
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string url,string token = null, string contentType = null, Dictionary<string, string> headers = null)
        {
            url = _API + url;
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(token);
                if (contentType != null)
                    client.DefaultRequestHeaders.Add("ContentType", contentType);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                HttpResponseMessage tasl = await client.GetAsync(url);
                if (tasl.StatusCode == HttpStatusCode.OK)
                {
                    var response = tasl.Content.ReadAsAsync<T>().Result;
                    return response;
                }
            }
            return default(T);
        }

        /// <summary>
        /// Post请求 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="paramList">参数</param>
        /// <returns></returns>
        public static T Post<T>(string url, List<KeyValuePair<String, String>> paramList, string token = null)
        {
            url = _API + url;
            T model = default(T);
            var client = new HttpClient();
            client.SetBearerToken(token);
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var http = new HttpClient(handler);
            var content = new FormUrlEncodedContent(paramList);
            var task = client.PostAsync(url, content);
            var response = task.Result;
            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            try
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString.Result);
            }
            catch (Exception ex)
            {
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>("{'apierrcode':" + jsonString.Result + "}");
            }
            return model;
        }
        /// <summary>
        /// Post 请求 var result = await HttpHelper.HttpPostAsync("url", "userid=23456798"); 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="contentType"></param>
        /// <param name="timeOut"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static T Post<T>(string url, string postData = null,string token = null, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            url = _API + url;
            postData = postData ?? "";
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(token);
                client.Timeout = new TimeSpan(0, 0, timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    HttpResponseMessage response = client.PostAsync(url, httpContent).Result;
                    var jsonString = response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString.Result);
                }
            }
        }

        /// <summary>
        /// Post 异步请求 var result = await HttpHelper.HttpPostAsync("url", "userid=23456798"); 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="contentType"></param>
        /// <param name="timeOut"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T>(string url, string postData = null,string token = null, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            url = _API + url;
            postData = postData ?? "";
            using (HttpClient client = new HttpClient())
            {
                client.SetBearerToken(token);
                client.Timeout = new TimeSpan(0, 0, timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    HttpResponseMessage response = await client.PostAsync(url, httpContent);
                    return await response.Content.ReadAsAsync<T>();
                }
            }
        }
        public static T Post<T>(string url, Dictionary<string, string> paramList)
        {
            Encoding encoding = Encoding.UTF8;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.ContentType = "application/json";
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, paramList);
            byte[] buffer = ms.GetBuffer();
            ms.Close();
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
            {
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
                return model;
            }
        }
        /// <summary>
        /// Post 请求（多条数据转换Json同时传输）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T PostByJosn<T>(string url, string json,string token = null)
        {
            try
            {
                T model = default(T);
                HttpClient client = new HttpClient();
                client.SetBearerToken(token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var jObject = JArray.Parse(json);
                var task = client.PostAsJsonAsync(url, jObject);
                var response = task.Result;
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                model = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString.Result);
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #region RestSharp 帮助请求
        //public static T RestGet<T>(string url,params Parameter[] parameters )
        //{
        //    var httpClient = new RestClient(_API);
        //    var httpRequest = new RestRequest(url, Method.GET);
        //    if (parameters.Length > 0)
        //    {
        //        httpRequest.Parameters.AddRange(parameters);
        //    }
        //    IRestResponse response = httpClient.Execute(httpRequest);
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
        //    }
        //    return default(T);
        //}

        public static T RestGet<T>(string url,params Parameter[] parameters)
        {
            var httpClient = new RestClient(_API);
            var httpRequest = new RestRequest(url, Method.GET);
            if (parameters.Length > 0)
            {
                foreach (var item in parameters)
                {
                    httpRequest.AddParameter(item);
                }
            }
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            T t = default(T);
            httpClient.ExecuteAsync(httpRequest, response => {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                t = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
                resetEvent.Set();
            }
            });
            resetEvent.WaitOne();
            return t;
        }

        public static T RestPost<T>(string url, Parameter[] parameters =null, Dictionary<string, string> headers = null)
        {
            var httpClient = new RestClient(_API);
            var httpRequest = new RestRequest(url, Method.POST);
            if (parameters != null && parameters.Length > 0)
            {
                httpRequest.Parameters.AddRange(parameters);
            }
            if (headers != null && headers.Count() > 0)
            {
                foreach (var item in headers)
                {
                    httpRequest.AddHeader(item.Key, item.Value);
                }
            }
            IRestResponse response = httpClient.Execute(httpRequest);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
            }
            return default(T);
        }

        #endregion
    }
}
