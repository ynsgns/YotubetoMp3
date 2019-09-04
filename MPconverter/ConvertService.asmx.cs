
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using YoutubeExtractor;

namespace MPconverter
{
    /// <summary>
    /// Summary description for ConvertService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    [ScriptService]
    public class ConvertService : System.Web.Services.WebService
    {
      
        [WebMethod]
        [ScriptMethod]
        //public string ConvertToLinkToMp3(string FileName)
        //{
        //    bool ciksinmi = false;
        //    VideoDownloader downloader=null;
        //    while (!ciksinmi)
        //    {
        //        try
        //        {
        //            IEnumerable<VideoInfo> videos = DownloadUrlResolver.GetDownloadUrls(FileName);
        //            VideoInfo videoInfo = videos.First(p => p.VideoType == VideoType.Mp4 && p.Resolution == 360);
        //            if (videoInfo.RequiresDecryption)
        //                DownloadUrlResolver.DecryptDownloadUrl(videoInfo);

                   

        //            string path = Path.Combine(Server.MapPath("~/Contents"), videoInfo.Title + videoInfo.VideoExtension);
        //            downloader = new VideoDownloader(videoInfo, path);
        //            downloader.DownloadProgressChanged += processChange;
        //            ciksinmi = !ciksinmi;
        //        }
        //        catch (Exception ex)
        //        {

        //            Thread.Sleep(5000);
        //        }

        //    }
        //    try
        //    {
        //        downloader.Execute();
        //        VideoInfo videoInfo = downloader.Video;
        //        FFMpegConverter convert = new FFMpegConverter();
                
        //        convert.ConvertMedia(@"C:\Users\user\Desktop\" + videoInfo.Title + videoInfo.VideoExtension, @"C:\Users\user\Desktop\" + videoInfo.Title + ".mp3", "mp3");
        //        return "Başarılı";
        //    }
        //    catch (Exception ex)
        //    {

        //        return "Hata:" + ex.Message;
        //    }
        //}

        private void processChange(object sender, ProgressEventArgs e)
        {
         
        }
    }
}
