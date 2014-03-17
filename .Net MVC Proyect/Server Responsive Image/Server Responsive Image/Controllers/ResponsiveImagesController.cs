using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Mvc;

namespace Server_Responsive_Image.Controllers
{
    /// <summary>
    /// Controller to work with responsive images
    /// </summary>
    public class ResponsiveImagesController : Controller
    {
        /// <summary>
        /// Provide a URL to get a image of the especifiqued dimensions
        /// </summary>
        /// <param name="src">Path of image in Content folder</param>
        /// <param name="width">Whidth Expected</param>
        /// <param name="height">Height Expected</param>
        /// <returns>The image in proporcional aspect relation</returns>
        public ActionResult GetResponsiveImages(string src, int? width, int? height)
        {
            string path = (string.IsNullOrEmpty(src))
                ? HttpContext.Server.MapPath("~/Content/NotFound.jpg")
                : HttpContext.Server.MapPath("~/Content/" + src);
            
            Image img;
            try
            {
                img = new Bitmap(path);
            }
            catch
            {
                path = HttpContext.Server.MapPath("~/Content/NotFound.jpg");
                img = new Bitmap(path);
            }
            int iwidth = (!width.HasValue || width.Value > img.Width) ? img.Width : width.Value;
            int iheight = (!height.HasValue || height.Value > img.Height) ? img.Height : height.Value;
            Image newimg = ScaleImage(img, iwidth, iheight);
            var ms = new MemoryStream();
            newimg.Save(ms, ImageFormat.Png);
            return File(ms.ToArray(), "image/png");
        }

        /// <summary>
        /// Scale a selected Image
        /// </summary>
        /// <param name="image">Image to Scale</param>
        /// <param name="maxWidth">Width Expected</param>
        /// <param name="maxHeight">Height Expected</param>
        /// <returns></returns>
        private static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }
    }
}