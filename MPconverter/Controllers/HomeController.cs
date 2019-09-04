using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using YoutubeExtractor;

namespace MPconverter.Controllers
{
    using System.Runtime.Serialization.Json;
    using System.Web.Script.Serialization;

    using Newtonsoft.Json.Linq;

    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult ConverttoMp3(string FileName)
        {
            try
            {
                string sendRequest = "function=validate&args[dummy]=1&args[urlEntryUser]=" + FileName + "&args[fromConvert]=urlconverter&args[requestExt]=mp3&args[nbRetry]=0&args[videoResolution]=-1&args[audioBitrate]=0&args[audioFrequency]=0&args[channel]=stereo&args[volume]=0&args[startFrom]=-1&args[endTo]=-1&args[custom_resx]=-1&args[custom_resy]=-1&args[advSettings]=false&args[aspectRatio]=-1";
                string responseRead = sendWebRequest("https://www2.onlinevideoconverter.com/webservice", "https://www.onlinevideoconverter.com/tr/video-converter", sendRequest, "www2.onlinevideoconverter.com");
                string stringId = responseRead.Substring(responseRead.IndexOf("dPageId"), responseRead.IndexOf("jobpc") - responseRead.IndexOf("dPageId")).Replace("dPageId", "").Replace("\"", "").Replace(":", "").Replace(",", "");
                string cevap = sendWebRequest("https://www.onlinevideoconverter.com/tr/success", "https://www.onlinevideoconverter.com/tr/video-converter", "id=" + stringId, "www.onlinevideoconverter.com");
                string linkAlani = cevap.Substring(cevap.IndexOf("onlinevideoconverter.com/download?file") - 30, 100);
                string linkTum = linkAlani.Substring(0, linkAlani.IndexOf("replace") - 1);
                string linkSade = linkTum.Replace(" ", "").Replace("{", "").Replace("url", "").Replace("'", "");
                JObject o = JObject.Parse(responseRead);
                linkSade = linkSade.Substring(1, linkSade.Length-1);
                var jo = JObject.Parse(responseRead);
                var title = jo["result"]["title"].ToString();
                //return Json("Başarılı" + linkSade + "", JsonRequestBehavior.AllowGet);
                return Json(new { snc=true,linkSade = linkSade, title = title }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { snc = false}, JsonRequestBehavior.AllowGet);
            }
  

        }
        string sendWebRequest(string url, string referer, string query,string host)
        {
            string responseRead = "";
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Accept = "Accept";
                webRequest.Host = host;
                webRequest.Method = "POST";
                byte[] request = Encoding.UTF8.GetBytes(query);
                webRequest.ContentLength = request.Length;
                webRequest.Timeout = 300000;
                webRequest.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                webRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
                webRequest.Referer = referer;
                using (Stream stream = webRequest.GetRequestStream())
                {
                    stream.Write(request, 0, request.Length);
                    stream.Close();
                }
                try
                {
                    using (Stream responseStream = webRequest.GetResponse().GetResponseStream())
                    {
                        using (StreamReader streamReader = new StreamReader(responseStream))
                        {
                            responseRead = streamReader.ReadToEnd();
                            streamReader.Close();
                        }
                        responseStream.Close();
                    }
                }
                catch (Exception)
                {
                }

            }
            catch (Exception)
            {

            }
            return responseRead;
        }

        public ActionResult Test()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            return this.View();
        }
        public ActionResult CopyrightNotice()
        {
            return this.View();
        }

        public ActionResult TermsOfUse()
        {
            return this.View();
        }


    }
}