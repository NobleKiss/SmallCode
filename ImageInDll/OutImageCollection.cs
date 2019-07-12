using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static ImageInDll.ImageSourceFile;

namespace ImageInDll
{
    /// <summary>
    /// 所有外部图像的集合
    /// </summary>
    public static class OutImageCollection
    {
        /// <summary>
        /// 所有图像的初始化
        /// </summary>
        public static Dictionary<string, Image> SourceImgList { get; } = new Dictionary<string, Image> { { "第一张图片", _1 }, { "这是123", _123 }, { "第3张", _3 }, { "虽然是31但是顺序不是", _31 }, { "Four", _4 }, { "顺序不是45", _45 } };
        /// <summary>
        /// 返回当前集合中的图像个数
        /// </summary>
        /// <returns></returns>
        public static int GetImgCount()
        {
            return SourceImgList.Count;
        }
        /// <summary>
        /// 获取所有的图像的名字
        /// </summary>
        /// <returns>返回所有图像的名字</returns>
        public static List<string> GetAllImagesName()
        {
            return SourceImgList.Keys.ToList();
        }
        /// <summary>
        /// 根据名字判断是否存在该项
        /// </summary>
        /// <param name="VName">需要判断是名字</param>
        /// <returns>是否存在</returns>
        public static bool ValidationContainImgByName(string VName)
        {
            return SourceImgList.Keys.Contains(VName);
        }
        /// <summary>
        /// 根据枚举名字返回图像，如果么有找到则返回空
        /// </summary>
        /// <param name="EImgName"></param>
        /// <returns></returns>
        public static Image GetImageByEnum(OutImageName EImgName)
        {
            return GetImageByName(EImgName.ToString());
        }
        /// <summary>
        /// 根据图像索引返回图像
        /// </summary>
        /// <param name="ImgName"></param>
        /// <returns></returns>
        public static Image GetImageByName(string ImgName)
        {
            return SourceImgList.FirstOrDefault(f => f.Key.Equals(ImgName)).Value;
        }
    }
}
