using API_Testing.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API_Testing
{
    [TestClass]
    public class TestGetEndPoints
    {
        private string GetUrl = "https://reqres.in/api/users/2";

        [TestMethod]
        public void GetAllEndPoints()
        {
            // step 1 create HttpClient
            HttpClient httpClient = new HttpClient();

            //step 2 create a request and exicute it 
            httpClient.GetAsync(GetUrl);

            //close the connection and release the resources 
            httpClient.Dispose();

        }


        [TestMethod]
        public void GetAllEndPointsWithURI()
        {
            // step 1 create HttpClient
            HttpClient httpClient = new HttpClient();

            //uri is a consutruct type it is used to pass the url
            Uri uri = new Uri(GetUrl);

            //and pass the uri to the httpclient get method 
            httpClient.GetAsync(uri);

            //close the connection and release the resources 
            httpClient.Dispose();

        }

        [TestMethod]
        public void GetAllEndPointsWithURIHttpResponseMessage()
        {
            // step 1 create HttpClient
            HttpClient httpClient = new HttpClient();

            //wt format u want the data by dy defolut it will give u xml format 
            HttpRequestHeaders httpRequestHeaders = httpClient.DefaultRequestHeaders;
           // httpRequestHeaders.Add("Accept", "application/json");
           // httpRequestHeaders.Add("Accept", "application/xml");

            //anather way
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");
            httpRequestHeaders.Accept.Add(jsonHeader);
            //MediaTypeWithQualityHeaderValue xmlnHeader = new MediaTypeWithQualityHeaderValue("application/xml");
            //httpRequestHeaders.Accept.Add(xmlnHeader);

            //uri is a consutruct type it is used to pass the url
            Uri uri = new Uri(GetUrl);

            //and pass the uri to the httpclient get method 
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(uri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            //get the status code 
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("satus code -:" + statusCode);
            Console.WriteLine("satus code -:" + (int)statusCode);//type cating ..if u want int value of staus code

            //get the responces 
            HttpContent content = httpResponseMessage.Content;
            Task<string> responseData = content.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine("data  -:" + data);

         
            //close the connection and release the resources 
            httpClient.Dispose();

        }


        [TestMethod]
        public void MyTestMethod()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(GetUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Accept", "application/xml");

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);


            //and pass the uri to the httpclient get method 
            //Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(uri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());


            //get the status code 
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("satus code -:" + statusCode);
            Console.WriteLine("satus code -:" + (int)statusCode);//type cating ..if u want int value of staus code

            //get the responces 
            HttpContent content = httpResponseMessage.Content;
            Task<string> responseData = content.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine("data  -:" + data);


            //close the connection and release the resources 
            httpClient.Dispose();

        }




        [TestMethod]
        public void testMethodusingstatment()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(GetUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/xml");

                    //and pass the uri to the httpclient get method 
                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        //and pass the uri to the httpclient get method 
                        Console.WriteLine(httpResponseMessage.ToString());
                        //get the status code 
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        Console.WriteLine("satus code -:" + statusCode);
                        Console.WriteLine("satus code -:" + (int)statusCode);//type cating ..if u want int value of staus code

                        //get the responces 
                        HttpContent content = httpResponseMessage.Content;
                        Task<string> responseData = content.ReadAsStringAsync();
                        string data = responseData.Result;
                        Console.WriteLine("data  -:" + data);
                    }

                }
            }
        }


        [TestMethod]
        public void testMethodusingstatmentreconstruct()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {
                    httpRequestMessage.RequestUri = new Uri(GetUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("Accept", "application/xml");

                    //and pass the uri to the httpclient get method 
                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {
                        //and pass the uri to the httpclient get method 
                        Console.WriteLine(httpResponseMessage.ToString());
                        //get the status code 
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                       
                        //get the responces 
                        HttpContent content = httpResponseMessage.Content;
                        Task<string> responseData = content.ReadAsStringAsync();
                        string data = responseData.Result;

                        RestResponces restResponces = new RestResponces((int)statusCode, responseData.Result);
                         Console.WriteLine(restResponces.ToString());
                    
                        //whatever u have created passs by using json  
                       // JsonModel JsonModelOBJ = JsonConvert.DeserializeObject<JsonModel>(restResponces.ResponseData);
                       // Console.WriteLine("JsonModelOBJ" + JsonModelOBJ.ToString());
                    }
                    
                }
            }
        }


       




    }
}
