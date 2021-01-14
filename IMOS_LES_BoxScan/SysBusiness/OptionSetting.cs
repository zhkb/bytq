using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Data;

namespace Sys.SysBusiness
{

    public struct StoreBinInfo
    {
        public int StoreBinNo; //货道编号
        public string MaterialCode1;//货道中存储的物料的编码，占5个字
        public string MaterialCode2;//货道中存储的物料的编码，占5个字
        public string MaterialCode3;//货道中存储的物料的编码，占5个字
        public string MaterialCodeStr;//3个物料编码 使用，隔开
        public int MaxQty;  //最大量   
        public int StoreQty;  //存储数量
        public int TransitQty;  //在途量
        public bool UseFlag;  //是否使用
    }


    public class OptionSetting
    {
        public static Color[] ViewBackColor = { Color.LightCyan, Color.White, Color.Lime }; //列表间隔颜色
        public static Color[] StoreMaterColor = { Color.Cyan, Color.Lime, Color.White, Color.White }; //库存物料状态颜色  在库 在途 预出库 空库位

        public static ArrayList OperationInfoList = new ArrayList(); //业务操作信息
        public static ArrayList OperationAlarmList = new ArrayList(); //业务异常信息 如条码扫描异常 不能分配货道等信息
        public static ArrayList OperationTipsList = new ArrayList(); //设备操作信息列表 如条码扫描 计划下传等提示信息 包含正常及异常提示信息

        public static int[] BinArray = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 37108864, 134217728, 268435456, 536870912, 1073741824 }; //判断设备状态使用 
        public static string[] TaskStateName = { "未执行", "执行中", "已完成", "已结束" };

        public static StoreBinInfo[] BoxStoreBinInfo = new StoreBinInfo[8]; //二楼发泡箱体库8个货道的实时PLC数据

        public static int StirStartAddress = 0;
        public static int StirBlockNo = 10;

        public static int DisperseStartAddress = 0;
        public static int DisperseBlockNo = 10;

        public static string CurrentScanBoxBarCode = "等待扫描......";
        public static string CurrentTip = "";
        public static string DownBinNo = "";

        public static bool PLCStatus = false;
        public static bool ScanStatus = false;

        public static DataTable BinDetaildt = null;

        public static string OutProductBarCode = "";

        public static bool Outflag = false;
        public static string OutRow = "";
        public static string OutColumn = "";
        public static string OutTier = "";
        public static string OutSort = "";
        public static string OutMsg = "";
        public static bool OutMsgColor = true;
    }
}
