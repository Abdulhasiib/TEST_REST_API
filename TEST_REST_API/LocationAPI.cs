using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using RestSharp.Authenticators;

namespace TEST_REST_API
{
    [TestClass]
    public class LocationAPI
    {
        [TestMethod, TestCategory("Sanity")]
        public void GetLocationInfo()
        {
            //Client Initialisation
            const string baseURL = "http://api.zippopotam.us/IN/";
            RestClient restClient = new RestClient();
            restClient.BaseUrl = new Uri(baseURL);

            //Request Data from Server
            RestRequest resRequest = new RestRequest("500032", Method.GET);

            //Execute Request and check server response
            IRestResponse restResponse = restClient.Execute(resRequest);

            //Extracting data from responce
            string location = restResponse.Content;

            //Evaluating Response
            if (location.Contains("Gachibowli"))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("Location Information not correct");
            }
            
        }
    }
}
