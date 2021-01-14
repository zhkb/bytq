
using System.Drawing;
using System.Collections;

namespace Sys.SysBusiness
{
    using Sys.DbUtilities;
    using System;
    using System.Collections.Generic;

    public class OptionSetting
    {
        //称重界面
        public static string MenuTitle = "";
        public static string ProBarCodeA = "";//一号工位产品码
        public static string ProBarCodeB = "";//二号工位产品码
        public static string ProductModeA = "";//一号工位产品型号
        public static string ProductModeB = "";//二号工位产品型号
        public static string MsgInfoA = "";//一号工位提示信息
        public static string MsgInfoB = "";//二号工位提示信息
        public static int CycleTimeA = 0;//一号工位生产节拍
        public static int CycleTimeB = 0;//二号工位生产节拍
        public static string CurrentWeight1 = "";//一号工位当前重量
        public static string CurrentWeight2 = "";//二号工位当前重量
        public static decimal CurrentWeightA = 0;//一号工位当前重量
        public static decimal CurrentWeightB = 0;//二号工位当前重量
        public static decimal TempStandWeightA = 0;//一号工位标准重量
        public static decimal TempStandWeightB = 0;//二号工位标准重量
        public static decimal TempToleranceA = 0;//一号工位标准误差
        public static decimal TempToleranceB = 0;//二号工位标准误差
        public static bool ScanFlagA = false;
        public static bool ScanFlagB = false;

        //称重监控看板
        public static string ProBarCode1 = "";//一号工位产品码
        public static string ProBarCode2 = "";//二号工位产品码
        public static string ProBarCode3 = "";//三号工位产品码
        public static string ProBarCode4 = "";//四号工位产品码
        public static string Perfusion1 = "0";//一号工位灌注量
        public static string Perfusion2 = "0";//二号工位灌注量
        public static string Perfusion3 = "0";//三号工位灌注量
        public static string Perfusion4 = "0";//四号工位灌注量
        public static bool MonitorRefreshFlag1 = false;
        public static bool MonitorRefreshFlag2 = false;
        public static bool MonitorRefreshFlag3 = false;
        public static bool MonitorRefreshFlag4 = false;


        //质检
        public static string QCProBarCode = "";//产品码
        public static string QCMsgInfo = "";//提示信息
        public static string QCProductMode = "";//产品型号
        public static bool QCScanFlag = false;
        public static string QCActualCount = "";
        public static string QCFinishCount = "";
        public static string QCRepairCount = "";

        //质检缺陷信息
        public static List<CheckDetailData> CheckDetailList = new List<CheckDetailData>();
        public static bool CheckResult = true;//产品质量标志
        public static string nGUID = "";
        public static string DetailCode = "";
        public static bool ReDeFlag = false; //质检缺陷刷新标志
        public static string itemcode = "";
        //上线、焊接、下线
        public static int Check_Result = 0;
        public static string BarCode = "";
        public static string MCode = "";//物料编码
        public static string MName = "";//物料名称
        public static string Msg = "";
        public static bool TaktTimeFlag = false;
        public static string ScanTime = "";

        //程序关闭标志
        public static int ExitFlag = 0;

        public static string PWeigh = "0.000";
    }
}
