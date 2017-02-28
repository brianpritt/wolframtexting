using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WolframAlpha.Api.v2;

namespace Texter.Models
{
    public class Message
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Status { get; set; }
        public List<Message> Messages { get; set; }

        public static List<Message> GetMessages()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/"+EnvironmentVariables.AccountSid+"/Messages.json", Method.GET);
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse["messages"].ToString());

            Console.WriteLine(jsonResponse);

            //bool newMessages = Message.NewMessageCheck(messageList);
            //if(newMessages == true)
            //{
            //    //read newest 
            //}
            //else
            //{
            //    //getmessages()
            //}

            //wolfram id: 2ERJG7-XRUKW977J9

            return messageList;
        }
        //public static bool NewMessageCheck()
        //{
        //    return true;
        //}
        public void Send()
        {
            var client = new RestClient("https://api.twilio.com/2010-04-01");
            var request = new RestRequest("Accounts/"+EnvironmentVariables.AccountSid+"/Messages", Method.POST);
            request.AddParameter("To", "+1" + To);
            request.AddParameter("From", "+1" + From);
            request.AddParameter("Body", Body);
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);
            client.ExecuteAsync(request, response =>
            {
                Console.WriteLine(response.Content);
            });
        }
        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
             {
                 tcs.SetResult(response);
             });
            return tcs.Task;
        }

        


    }
}
