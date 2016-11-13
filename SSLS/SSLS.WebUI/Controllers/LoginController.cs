using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSLS.WebUI.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public FileResult CreateValidateGraphic(int length)
        {
            string validateCode = EmptyResultDemo(length);
            Session["ValidateCode"] = validateCode;
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 14.0), 22);
            Graphics g = Graphics.FromImage(image);

            //生成随机生成器    
            Random random = new Random();
            //清空图片背景色    
            g.Clear(Color.White);
            //画图片的干扰线    
            for (int i = 0; i < 25; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }
            Font font = new Font("Arial", 12, (FontStyle.Bold | FontStyle.Italic));
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height),
             Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(validateCode, font, brush, 3, 2);
            //画图片的前景干扰点    
            for (int i = 0; i < 100; i++)
            {
                int x = random.Next(image.Width);
                int y = random.Next(image.Height);
                image.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
            //画图片的边框线    
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

            byte[] imageBuffer;
            //保存图片数据    
            using (MemoryStream stream = new MemoryStream())
            {
                //保存的二进制写入到stream对象中  
                image.Save(stream, ImageFormat.Jpeg);

                //ms对象中的二进制数据转换成byte数组  
                imageBuffer = stream.ToArray();
            }
            return File(imageBuffer, "image/jpeg");
        }

        public string EmptyResultDemo(int length)
        {

            char[] chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            int[] randMembers = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列值    
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int charLen = chars.Length;
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += chars[seekRand.Next(charLen)];


            }
            return validateNumberStr;

        }

        public RedirectToRouteResult Logout()
        {

            Session["Reader"] = null;
            return RedirectToAction("List","Book");
        }
    }
}