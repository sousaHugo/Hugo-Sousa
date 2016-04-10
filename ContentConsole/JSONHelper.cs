using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ContentConsole
{
    public class JSONHelper
    {
        public static SentenceConfiguration ReadJson()
        {
            SentenceConfiguration config = new SentenceConfiguration();

            try
            {
                StreamReader file =
                    File.OpenText(
                        @"D:\NB21467\Desktop\Euromoney.RecruitmentTest-master\ContentConsole\Content\Data.json");


                JsonSerializer serializer = new JsonSerializer();
                config = (SentenceConfiguration)serializer.Deserialize(file, typeof(SentenceConfiguration));

            }
            catch (Exception ex)
            {
                return null;
            }


            return config;
        }

        public static SentenceConfiguration CreateJson(SentenceConfiguration _data)
        {
            string json = JsonConvert.SerializeObject(_data);

            try
            {
                //write string to file
                System.IO.File.WriteAllText(
                    @"D:\NB21467\Desktop\Euromoney.RecruitmentTest-master\ContentConsole\Content\Data.json", json);


            }
            catch (Exception ex)
            {
                return null;
            }
            return _data;
        }
    }

    public class SentenceConfiguration
    {
        public string Sentence { get; set; }
        public List<string> Word { get; set; }
    }
}
