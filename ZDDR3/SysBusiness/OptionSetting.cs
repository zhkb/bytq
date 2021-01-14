
using System.Drawing;
using System.Collections;

namespace Sys.SysBusiness
{
    using Sys.DbUtilities;
    public class OptionSetting
    {
        public static Color[] ViewBackColor = { Color.LightCyan, Color.White, Color.Lime }; //列表间隔颜色
        public static Color[] StoreMaterColor = { Color.Cyan, Color.Lime, Color.White, Color.White }; //库存物料状态颜色  在库 在途 预出库 空库位

        public static ArrayList OperationInfoList = new ArrayList(); //业务操作信息
        public static ArrayList OperationAlarmList = new ArrayList(); //业务异常信息 如条码扫描异常 不能分配货道等信息
        public static ArrayList OperationTipsList = new ArrayList(); //设备操作信息列表 如条码扫描 计划下传等提示信息 包含正常及异常提示信息

        public static string HisBarcode = ""; // 历史条码
        public static string CurrentBarcode = ""; // 当前扫描条码
        public static string CurrentMatercode = ""; //当前物料编码
        public static string CurrentMaterName = "";//当前物料名称
        public static string CurrentLevel = "";//当前物料能耗等级
        public static string CurrentMaterImage = "";//当前物料能效图片
        public static string MenuTitle = ""; // 菜单 

        public static string CurrentBackBarcode = ""; // 当前返修扫描条码
        public static string CurrentBackMatercode = ""; //当前返修物料编码
        public static string CurrentBackMaterName = "";//当前返修物料名称
        public static string CurrentBackLevel = "";//当前返修物料能耗等级

        public static string CurrentBeforeBarcode = ""; // 当前发泡前扫描条码
        public static string CurrentAfterBarcode = ""; // 当前发泡后扫描条码

        public static string portBarCode = "";
        public static string strClassName = "";

        public static string strMaterialCode = "";
        public static string strMaterialName = "";
        public static string strMaterialDesc = "";
        public static string strMaterialSpec = "";


        public static string G_productCodeA = "";//扫描产品码
        public static string G_productCodeB = "";//扫描产品码

        public static string G_ProductNameA = "";
        public static string G_ProductNameB = "";
        public static string G_productCodeMSG = "";//扫描产品码 信息
        public static string G_productCodeIsSuccessFlag = "";//扫描成功标识 -1 初始化 0失败 1 成功 

        public static string G_CurrentStoreCode1 = "ABCD";  //记录当前的库位信息
        public static string G_PreviousStoreCode1 = "";  //记录前一个库位信息

        public static string G_CurrentStoreCode2 = "ABCD";  //记录当前的库位信息
        public static string G_PreviousStoreCode2 = "";  //记录前一个库位信息

        public static string G_CurrentStoreCode3= "ABCD";  //记录当前的库位信息
        public static string G_PreviousStoreCode3 = "";  //记录前一个库位信息

        public static string G_CurrentStoreCode4= "ABCD";  //记录当前的库位信息
        public static string G_PreviousStoreCode4 = "";  //记录前一个库位信息

   
    }
}
