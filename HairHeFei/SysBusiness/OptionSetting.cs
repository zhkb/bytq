
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace Sys.SysBusiness
{
    using Sys.DbUtilities;
    using System.Data;

    public class OptionSetting
    {
        public static Color[] ViewBackColor = { Color.LightCyan, Color.White, Color.Lime }; //列表间隔颜色
        public static Color[] StoreMaterColor = { Color.Cyan, Color.Lime, Color.White, Color.White }; //库存物料状态颜色  在库 在途 预出库 空库位

        public static Color[] FlagColor = { Color.Red, Color.Lime };

        public static Image[] ConnImage = { Properties.Resources.Status_Red, Properties.Resources.Status_Green }; //连接状态显示颜色 


        public static ArrayList OperationInfoList = new ArrayList(); //业务操作信息
        public static ArrayList OperationAlarmList = new ArrayList(); //业务异常信息 如条码扫描异常 不能分配货道等信息
        public static ArrayList OperationTipsList = new ArrayList(); //设备操作信息列表 如条码扫描 计划下传等提示信息 包含正常及异常提示信息

        public static ArrayList StirAlarmInfo = new ArrayList(); //搅拌罐报警信息



        public static string MenuTitle = "";

        public static int[] BinArray = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 37108864, 134217728, 268435456, 536870912, 1073741824 }; //判断设备状态使用 按照位 
        public static string[] PlanStatusName = { "未执行", "执行中", "已完成", "已结束" };

        public static decimal[] ZLTime = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        //动作类别
        public enum ActionType
        {
            StirType = 1, //搅拌动作
            RubberType = 2, //制胶动作
            TerrineType = 3 //制陶动作
        };
        //配方类别
        public enum RecipeType
        {
            StirType = 1, //搅拌配方
            RubberType = 2, //制胶配方
            TerrineType = 3 //制陶配方
        };


        //计划类别
        public enum PlanType
        {
            StirPlan = 1, //搅拌计划
            RubberPlan = 2, //制胶计划
            TerrinePlan = 3   //制陶计划
        };

        //计划状态
        public enum PlanStatus
        {
            NoExecute = 0,
            Execute = 1, //计划执行
            Finish = 2, //计划完成
            Force = 3   //强制结束
        };




        //门壳物料信息标识
        public static string BasketCode = "";//吊笼编号
        public static string MaterialBarCode = "";//物料条码
        public static string MaterialCode = "";//物料编号
        public static string MaterialName = "";//物料型号

        public static string ScanTime = "";//扫描时间
        public static string MsgInfo = "";//提示信息
        public static bool MsgColorRed = false;//提示信息颜色变化
        public static bool UseMsg = false;//使用信息提示

        //吊笼绑定物料小车
        public static string PalletCode = "";//吊笼编号
        public static string SpreaderCode = "";//物料小车编号
        public static string PalletScanTime = "";//扫描时间
        public static string PalletMsgInfo = "";//提示信息
        public static bool PalletMsgColorRed = false;//提示信息颜色变化
        public static int PalletQty = 0;//小车中物料数量

        public struct StoreBinData
        {
            public string ID;//ID
            public string Material_Name;//物料名称
            public string RFID_BarCode;//RFID编号
            public string Bar_Code;//条码
            public string Task_From;//起始地
            public string Task_To;//目的地
            public string Task_State;//状态
            public string Start_Time;//开始时间
            public string Task_Type;//'1'=入库，'2'=出库
            public string Store_Code;//区分库位
        }
        public static List<StoreBinData> StoreShowDataList = new List<StoreBinData>(); //库存信息
        public static List<StoreBinData> StoreShowDataList2 = new List<StoreBinData>(); //库存信息

        //货道物料绑定
        public static int BinNo = 0;
        public static string BinMaterialCode = "";
        public static string BinMaterialName = "";
        public static string BinMaterialTypeCode = "";
        public static string AreaCode = "";

        public static List<string> SelectMaterialList = new List<string>();

        public static List<TaskInfo> InTaskList = new List<TaskInfo>();

        public static object[] StoreBuff = new object[80];

        public static DataSet BinDetailds = null;
        public static StoreMaterialInfo smi = new StoreMaterialInfo();

        public static object[] CKStoreBuff = null;
        public static object[] RKStoreBuff = null;

        public static bool Check = true;

        public static int RKTypeFlag = 1;

        public static string SDRKCode = "";

        public static bool Bindingflag = true;

        public static string OldBasketCode = "";

        public static string KBMaterialCode = "AAAA";
        public static string KBMaterialBarCode = "";
        public static string KBSort = "99";
        public static string KBMaterialName = "空板";

        public static int PlanCount = 1;

        public static bool JLFlag = false;

        public static bool SFlag = false;
    }
}
