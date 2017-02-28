using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//the following is for parsing xml // 
using System.Xml;
using System.IO;
using System.Text;
using System.Net.Http;

namespace Texter.Models
{
    public class WA
    {
        //private static RestResponse response;

        public string Question { get; set; }

        public async static Task<string> AskWolfram(string question)
        {
            StringBuilder output = new StringBuilder();
            using (var client = new HttpClient())
            {
                // Define your URL to call here
                var uri = new Uri($"http://api.wolframalpha.com/v2/query?input={question}&appid={EnvironmentVariables.WolframAppId}");
                // Get and output your response
                var response = await client.GetAsync(uri);
                string wolframResultString = await response.Content.ReadAsStringAsync();

                //using (XmlReader reader = XmlReader.Create(new StringReader(wolframResultString)))
                //{
                //    XmlWriterSettings ws = new XmlWriterSettings();
                //    ws.Indent = true;
                //    using (XmlWriter writer = XmlWriter.Create(output, ws))
                //    {
                //        // Parse the file and display each of the nodes.
                //        while (reader.Read())
                //        {
                //            switch (reader.NodeType)
                //            {
                //                case XmlNodeType.Element:
                //                    writer.WriteStartElement(reader.Name);
                //                    break;
                //                case XmlNodeType.Text:
                //                    writer.WriteString(reader.Value);
                //                    break;
                //                case XmlNodeType.XmlDeclaration:
                //                case XmlNodeType.ProcessingInstruction:
                //                    writer.WriteProcessingInstruction(reader.Name, reader.Value);
                //                    break;
                //                case XmlNodeType.Comment:
                //                    writer.WriteComment(reader.Value);
                //                    break;
                //                case XmlNodeType.EndElement:
                //                    writer.WriteFullEndElement();
                //                    break;
                //            }
                //        }
                //    }
                //}











                //string stringer = output.ToString();
                Console.WriteLine("wolfram response:" + wolframResultString);
                return (wolframResultString);
            }
        }

        private static Task<RestResponse> GetResponseContentAsync(RestClient client)
        {
            throw new NotImplementedException();
        }
    }
}
