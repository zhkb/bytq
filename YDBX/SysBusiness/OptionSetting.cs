
using System.Drawing;
using System.Collections;

namespace Sys.SysBusiness
{
    using Sys.DbUtilities;
    using System.Collections.Generic;

    public class OptionSetting
    {
        public static Color[] ViewBackColor = { Color.LightCyan, Color.White, Color.Lime }; //列表间隔颜色
        public static Color[] StoreMaterColor = { Color.Cyan, Color.Lime, Color.White, Color.White }; //库存物料状态颜色  在库 在途 预出库 空库位

        public static ArrayList OperationInfoList = new ArrayList(); //业务操作信息
        public static ArrayList OperationAlarmList = new ArrayList(); //业务异常信息 如条码扫描异常 不能分配货道等信息
        public static ArrayList OperationTipsList = new ArrayList(); //设备操作信息列表 如条码扫描 计划下传等提示信息 包含正常及异常提示信息

        public static ArrayList StirAlarmInfo = new ArrayList(); //搅拌罐报警信息

        public static List<StoreBinData> StoreBinDataList = new List<StoreBinData>(); //库存信息

   

        public static int StirPlanType = 1;//搅拌计划类型
        public static int RubPlanType = 2;//制胶计划类型
        public static int TGPlanType = 3;//陶罐计划类型

        public static int StirEquipmentCount = 4;//搅拌罐数量
        public static int RubEquipmentCount = 2;//制胶罐数量
        public static int CJGEquipmentCount = 2;//储胶罐数量
        public static int TGEquipmentCount = 2;//陶罐数量
        public static int TGHCEquipmentCount = 1;//陶瓷缓存罐数量
        public static int CNTEquipmentCount = 1;//CNT缓存罐数量

        public static int StirStoreEquipmentCount = 5;//5个中转罐
        public static int TBJTEquipmentCount = 3;//涂布机头数量
        public static int TBJWEquipmentCount = 3;//涂布机尾数量

        public static int NMPEquipmentCount = 3;//室外NMP中转罐数量

        public static int FSEquipmentCount = 2;//分散设备数量

        public static string MenuTitle = "";
        public static string CNTitle = "";
        public static string ENTitle = "";

        public static int MaxStepCount = 30;// 配方步骤最大数量份

        public static int[] BinArray = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 37108864, 134217728, 268435456, 536870912, 1073741824 }; //判断设备状态使用 按照位 
        public static string[] PlanStatusName = { "未执行", "执行中", "已完成", "已结束" };

        public static string[] DownBackMsg = { "无计划数据", "无配方数据", "无搅拌步骤数据", "PLC反馈超时", "计划数据下传异常", "请检查PLC连接." };

        public static string[] StirAlarmDesc = { "测试报警1", "测试报警2", "测试报警3", "测试报警4", "测试报警5", "测试报警6", "测试报警7", "测试报警8", "测试报警9", "测试报警10", "测试报警11", "测试报警12", "测试报警13", "测试报警14", "测试报警15", "测试报警16", "测试报警17", "测试报警18", "测试报警19", "测试报警20" };

        public static int[] ValueType = { 1, -1 };

        public static string[] ZJBatchMaterialName = { "正极主料", "PVDF", "SP", "碳酸锂", "胶料", "溶剂" ,"CNT","NMP"};
        public static string[] FJBatchMaterialName = { "负极主料", "CMC", "SP", "", "胶料", "溶剂", "SBR" ,"去离子水"};
 
        //门体匹配
        public static string MsgInfo = "";        
        public static string BoxBarCodeA = "";
        public static string BoxCodeA = "";
        public static string BoxNameA = "";
        public static string DoorCodeA = "";
        public static string DoorNameA = "";

        //能耗贴数量放置界面
        public static string EnergyBarcode = "";//能好帖条码
        public static bool ShowFlag;
        public static string BNum = "-1";
        public static string EEnergyCode = "";//能耗贴编号
        public static string EEnergyName = "";//能耗贴名称
        public static string EProBarCode = "";//产品条码
        public static string EProCode = "";//产品编号
        public static string EProName = "";//产品名称
        public static string EMsg = "";//反馈信息
        public static bool EResultFlag = true;//结果
        public static string ProImage = "";//产品图片
        public static string EnergyImage = "";//能耗贴图片

        //能耗贴放料界面
        public static string Ebinno = "";//网格编号
        public static string Ename = "";//物料名称
        public static string Ecode = "";//物料编号
        public static string Eqty = "-1";//能效贴实际数量
        public static string strMsg = "";

        //压缩机防差错监控界面

        public static string ProductBarCode = "";//压缩机防差错 产品条码
        public static string CompressorBarCode = "";//压缩机放差错 压缩机条码
        public static string ProductCode = "";//压缩机防差错 编号
        public static string CompressorCode = "";//压缩机放差错 编号
        public static string ProductName = "";//压缩机防差错型号
        public static string CompressorName = "";//压缩机放差错型号

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

        //前排缓存库
		
        public static string ProBarCodeA = "";//一号工位产品码
        public static string ProBarCodeB = "";//二号工位产品码
        public static string ProductModeA = "";//一号工位产品型号
        public static string ProductModeB = "";//二号工位产品型号
        public static string MsgInfoA = "";//一号工位提示信息
        public static string MsgInfoB = "";//二号工位提示信息
        public static string BinNoA = "";//一号工位产品所在货道
        public static string BinNoB = "";//二号工位产品所在货道
        public static bool ScanFlagA = false;
        public static bool ScanFlagB = false;
        public static bool ModifyBinA = false;//是否启用手工改道A
        public static bool ModifyBinB = false;//是否启用手工改道B

        //箱体寄存库

        public static string XTBarCodeA = "";
        public static string XTBinNoA = "";
        public static string XTMsgA = "";
        public static string XTMaterialCodeA = "";
        public static string XTMaterialCodeB = "";
        public static string XTBarCodeB = "";
        public static string XTBinNoB = "";
        public static string XTMsgB = "";

        public static bool PutFlag = false;


        //U壳寄存库
        //内胆串口
        public static string IsInitCodeLiner = "";//是否启用内胆串口
        public static string LinerCode = "";//内胆条码
        public static string MaterialCode = "";//内胆编码
        public static string MaterialName = "";//内胆名称
        public static string ToolingBoardRFID = "";//工装板RFID
        public static string CodeMsg = "";//条码扫描信息
        public static string isSuccessFlag = "-1";//扫描成功标识 -1 初始化 0失败 1 成功 
        public static string RFIDCode = "";//固定RFID读取
        public static string RFIDCodeMsg = "";//RFID设备读取信息
        public static string IsSuccessFlagRFID = "-1";//RFID扫描成功标识 -1 初始化 0失败 1 成功 
      
    }
}
