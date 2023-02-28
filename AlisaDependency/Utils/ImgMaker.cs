using System.ComponentModel.Design;
using System.Globalization;
using AlisaDependency.Datas;
using AlisaDependency.DataTypes.Infos;
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
                var i = 2;
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

                    tt = tt + " "+pair.Value.roomNum.ToString().PadRight(7, ' ') +
                         pair.Value.createTime.ToString("yyyy-M-d HH:mm:ss");
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
            Logger.Log($"Img {ret} 生成成功", 1);
            return ret;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public static string MakeSvInfoImg(SVCardInfo card)
    {
        try
        {
            var skInfo = new SKImageInfo(950, 698);
            var ret = "";
            using (var surface = SKSurface.Create(skInfo))
            {
                using var glCanvas = surface.Canvas;
                var index = SKFontManager.Default.FontFamilies.ToList().IndexOf("宋体"); // 创建宋体字形
                var skTypeface = SKFontManager.Default.GetFontStyles(index).CreateTypeface(0);
                // using var skTypeface = SKTypeface.FromFile("C:\\AlisaBot\\Fonts\\华康少女文字W5.ttf", 0);
                using var skFont = new SKFont(skTypeface, 30);
                using var skBitMap = SKBitmap.Decode($"C:\\AlisaBot\\StaticData\\SVCardPics\\{card.Id}\\pic.png").Resize(new SKImageInfo(536,698),SKFilterQuality.High);
                using var skTextPaint = new SKPaint
                {
                    Color = SKColors.Black,
                    TextEncoding = SKTextEncoding.Utf8,
                    Typeface = skTypeface,
                    TextSize = 30,
                    IsAntialias = true
                };
                using var skPaint = new SKPaint
                {
                    BlendMode = SKBlendMode.SrcATop,
                    FilterQuality = SKFilterQuality.High,
                    IsAntialias = true
                };
                glCanvas.Clear();
                glCanvas.DrawColor(SKColors.White, SKBlendMode.Src); //绘制底色
                glCanvas.DrawBitmap(skBitMap, 0, 0, skPaint);
                
                var texts = new List<string>();
                texts.Add($"{card.ChineseName}");
                texts.Add($"{card.JapaneseName}");
                texts.Add($"{card.EnglishName}");
                texts.Add("");
                var typeText = $"种类:{card.CardType}";
                if (card.SubType != "")
                {
                    typeText += $" 词条:{card.SubType}";
                }
                texts.Add(typeText);
                texts.Add("");
                if (card.Effects != "")
                {
                    var effectText = $"效果:{card.Effects}";
                    foreach (var t in effectText.Split('\n'))
                    {
                        var effectTexts = SplitByLen(t, 13);
                        texts.AddRange(effectTexts);
                    }
                }
                var desText = $"{card.ChineseDescription}";
                texts.Add("");
                foreach (var t in desText.Split('\n'))
                {
                    var desTexts = SplitByLen(t, 13);
                    texts.AddRange(desTexts);
                }

                for(int i=0;i<texts.Count;i++)
                {
                    glCanvas.DrawText(texts[i], 540f, (i + 2) * 30, skTextPaint);
                }
                glCanvas.Flush();
                // 输出到文件
                ret = $"C:\\AlisaBot\\Img\\SvInfoTempImg\\{DateTime.Now:yyyy-M-dd--HH-mm-ss}.png";
                using (var image = surface.Snapshot())
                using (var data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (var stream = File.OpenWrite(ret))
                {
                    data.SaveTo(stream);
                }
            }
            Logger.Log($"Img {ret} 生成成功", 1);
            return ret;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    private static string[] SplitByLen(string str, int separatorCharNum)  
    {  
        if (string.IsNullOrEmpty(str) || str.Length <= separatorCharNum)   
        {  
            return new string[] { str };  
        }  
        string tempStr = str;  
        List<string> strList = new List<string>();  
        int iMax = Convert.ToInt32(Math.Ceiling(str.Length / (separatorCharNum * 1.0)));//获取循环次数  
        for (int i = 1; i <= iMax; i++)  
        {  
            string currMsg = tempStr.Substring(0, tempStr.Length > separatorCharNum ? separatorCharNum : tempStr.Length);  
            strList.Add(currMsg);  
            if (tempStr.Length > separatorCharNum)  
            {  
                tempStr = tempStr.Substring(separatorCharNum, tempStr.Length - separatorCharNum);  
            }  
        }  
        return strList.ToArray();  
    }
}