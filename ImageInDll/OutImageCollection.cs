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
        public static Dictionary<string, Image> SourceImgList { get; } = new Dictionary<string, Image> { { "第一张图片", _1 }, { "这是10", _10 }, { "第2张", _2 }, { "虽然是31但是顺序不是", _31 }, { "FourOne", _41 }, { "顺序不是45", _45 }, { "名称是12", _12 }, { "名称是14", _14 }, { "名称是16", _16 }, { "名称是18", _18 }, { "名称是20", _20 }, { "名称是22", _22 }, { "名称是24", _24 }, { "名称是26", _26 }, { "名称是6", _6 }, { "名称是8", _8 } };
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
