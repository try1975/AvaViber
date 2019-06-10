//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Web;
//using System.Web.Http;

//namespace AvaViber.WebApi.Controllers
//{
//    [RoutePrefix("api/content")]
//    public class ContentController : ApiController
//    {
//        [HttpGet, Route("")]
//        public HttpResponseMessage GetFile(string docPath)
//        {
//            var response = new HttpResponseMessage(HttpStatusCode.OK);
//            if (string.IsNullOrWhiteSpace(docPath)) return response;

//            docPath = HttpUtility.UrlDecode(docPath, System.Text.Encoding.UTF8);
//            var path = Path.Combine(@"\\Server\users$\vorobyev\My Documents\ViberDownloads\PublicAccountMedia", docPath);
//            if (!File.Exists(path)) return response;
//            var stream = new FileStream(path, FileMode.Open);
//            response.Content = new StreamContent(stream);
//            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
//            response.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
//            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
//            response.Content.Headers.ContentLength = stream.Length;
//            return response;
//        }
//    }
//}
