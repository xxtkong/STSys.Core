using ImageProcessor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace STSys.Core.Files
{
    public class PTImage
    {
        /// <summary>
        /// 切片
        /// </summary>
        /// <param name="imagePath">图片路径</param>
        /// <param name="silceUpWidth">切片宽</param>
        /// <param name="silceUpHeight">切片高</param>
        public static void SliceUp(string imagePath, string fileSaveUrl,int silceUpWidth, int silceUpHeight)
        {
            string dir = Path.GetDirectoryName(fileSaveUrl);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            Image orginalImage = Image.FromFile(imagePath);
            //计算x方向上的切片份数，如果原图宽度100 ，切片宽度30，则切片在x方向上的份数为4
            int widthCount = (int)Math.Ceiling((orginalImage.Width * 1.0) / (silceUpWidth * 1.0));
            //计算y方向上的切片份数，如果原图宽度100 ，切片宽度30，则切片在x方向上的份数为4
            int heightCount = (int)Math.Ceiling((orginalImage.Height * 1.0) / (silceUpHeight * 1.0));
            for (int i = 0; i < heightCount; i++)
            {
                //设置最终切割的高度
                int recHeight = 0;
                //判断图片高度是否满足本次切片的高度
                if (orginalImage.Height - silceUpHeight * i > silceUpHeight)
                {
                    recHeight = silceUpHeight;
                }
                else
                {
                    recHeight = orginalImage.Height - silceUpHeight * i;
                }
                for (int j = 0; j < widthCount; j++)
                {
                    //设置最终切割的宽度
                    int recWidth = 0;
                    //判断图片高度是否满足本次切片的宽度
                    if (orginalImage.Width - silceUpWidth * i > silceUpWidth)
                    {
                        recWidth = silceUpWidth;
                    }
                    else
                    {
                        recWidth = orginalImage.Width - silceUpWidth * i;
                    }
                    //保留exif元数据，初始化ImageFactory
                    using (ImageFactory imageFactory = new ImageFactory(true))
                    {
                        //创建截取图片的大小
                        Rectangle rectangle = new Rectangle
                            (j * silceUpWidth
                            , i * silceUpHeight
                            , recWidth, recHeight
                            );
                        //切割图片
                        imageFactory.Load(orginalImage)
                            .Crop(rectangle)
                            .Save(fileSaveUrl);
                    }
                }
            }
        }
    }
}
