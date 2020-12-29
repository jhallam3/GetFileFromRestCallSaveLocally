using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestCallSaveFileClass
{
    public class RestCallSaveFileLocally
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<bool> RunRestCallSaveFileFlocallyAsync(string WebhookURL, string fileNameToSaveAs, string path, string fileID)
        {
            var webhookcontents = await GetContentFromRestCallAsync(WebhookURL+ "&FileID="+fileID);
            var Deserialse = JsonConvert.DeserializeObject<JsonToFileData>(webhookcontents);
            //string to byte
            byte[] bytes = Convert.FromBase64String(Deserialse.Done.File.Contents);
            SaveFile(bytes, fileNameToSaveAs, path);
            return true;
        }
        public void SaveFile(byte[] contents, string fileNameToSaveAs, string path)
        {
            System.IO.File.WriteAllBytes(path + "\\" + fileNameToSaveAs + ".xml", contents);
        }

        public async Task<String> GetContentFromRestCallAsync(string WebhookURL)
        {

            try
            {
                HttpResponseMessage response = await client.GetAsync(WebhookURL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return null;
        }
    }
}

