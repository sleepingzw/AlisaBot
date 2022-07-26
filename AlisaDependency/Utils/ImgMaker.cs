using System.Globalization;
using AlisaDependency.Datas;
using SkiaSharp;
using SkiaSharp.Internals;


namespace AlisaDependency.Utils;

public static class ImgMaker
{
    
    public static string MakeSvRoomImg()
    {
        try
        {
            var info = new SKImageInfo(600, 5 + (GlobalVariables.svRoomInfos.Count + 1) * 30);
            string ret = "";
            using (var surface = SKSurface.Create(info))
            {
                using var glCanvas = surface.Canvas;
                using var skTypeface = SKTypeface.FromFile("C:\\AlisaBot\\Fonts\\华康少女文字W5.ttf", 0);
                using var skFont = new SKFont(skTypeface, 30);
                using var titleSkPaint = new SKPaint
                {
                    Color = SKColors.Aqua,
                    TextEncoding = SKTextEncoding.Utf8,
                    Typeface = skTypeface,
                    TextSize = 30,
                    IsAntialias = true
                };
                using var skPaint = new SKPaint
                {
                    Color = SKColors.Black,
                    TextEncoding = SKTextEncoding.Utf8,
                    Typeface = skTypeface,
                    TextSize = 30,
                    IsAntialias = true
                };
                using var skTextBlob = SKTextBlob.Create(
                    "服务器".PadLeft(5, ' ') +
                    "||房间号".PadRight(8, ' ') +
                    "||创建时间", skFont);
                /*
                using var temp = SKTextBlob.Create(
                    "国服".PadLeft(7,' ')+
                    "||11451".PadRight(8,' ')+
                    "||2022-07-25 23:40", skFont);
                */
                glCanvas.DrawColor(SKColors.White);
                glCanvas.DrawText(skTextBlob, 0f, 30f, titleSkPaint);
                var i = 1;
                foreach (var pair in GlobalVariables.svRoomInfos)
                {
                    var tt = "";
                    if (pair.Value.whatServer == 0)
                    {
                        tt += "国际服".PadLeft(5, ' ');
                    }
                    else
                    {
                        tt += "国服".PadLeft(7, ' ');
                    }

                    tt = tt + pair.Value.roomNum.ToString().PadRight(8, ' ') +
                         pair.Value.createTime.ToString(CultureInfo.InvariantCulture);
                    glCanvas.DrawText(tt, 0f, i * 30, skPaint);
                    i++;
                }

                glCanvas.Flush();
                // 输出到文件
                ret = $"C:\\AlisaBot\\Img\\SvRoomTempImg\\{DateTime.Now:yyyy-M-dd--HH-mm-ss}.png";
                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = File.OpenWrite(ret))
                {
                    data.SaveTo(stream);
                }
            }
            return ret;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}