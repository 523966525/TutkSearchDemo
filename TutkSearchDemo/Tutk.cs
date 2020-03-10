using System;
using System.Collections.Generic;

using System.Runtime.InteropServices;
using System.Text;


namespace WindowsFormsApp1.juyi
{
    class Tutk
    {
        //
        /// <summary>
        /// 获取 IOTCAPIs.dll 版本号
        /// </summary>
        /// <param name="Version">版本</param>
        /// <returns></returns>
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Get_Version", CallingConvention = CallingConvention.Cdecl)]
        public static extern void IOTC_Get_Version(byte[] Version);
        //初始化
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Initialize2", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IOTC_Initialize2(int UDPPort);
        //获取session
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Get_SessionID", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IOTC_Get_SessionID();
        //注销sid
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Connect_Stop_BySID", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IOTC_Connect_Stop_BySID(int SID);
        //关闭sesiion
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Session_Close", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IOTC_Session_Close(int SID);

        //初始化通道大小
        [DllImport("AVAPIs.dll", EntryPoint = "avInitialize", CallingConvention = CallingConvention.Cdecl)]
        public static extern int avInitialize(int nMaxNumAllowed);
        //关闭session
        [DllImport("AVAPIs.dll", EntryPoint = "avClientStop", CallingConvention = CallingConvention.Cdecl)]
        public static extern int avClientStop(int avIndex);
        //关闭通道
        [DllImport("AVAPIs.dll", EntryPoint = "avClientExit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int avClientExit(int SID, int chID);
        //链接设备
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Connect_ByUID_Parallel", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IOTC_Connect_ByUID_Parallel(String UID, int SID);
        //登录
        [DllImport("AVAPIs.dll", EntryPoint = "avClientStart2", CallingConvention = CallingConvention.Cdecl)]
        public static extern int avClientStart2(int nSID, String viewAcc, String viewPwd, int timeout_sec, int[] pservType, int ChID, int[] bResend);
        //发送指令
        [DllImport("AVAPIs.dll", EntryPoint = "avSendIOCtrl", CallingConvention = CallingConvention.Cdecl)]
        public static extern int avSendIOCtrl(int avIndex, int ioType, byte[] ioCtrlBuf, int ioCtrlBufSize);
        //指令发送返回
        [DllImport("AVAPIs.dll", EntryPoint = "avRecvIOCtrl", CallingConvention = CallingConvention.Cdecl)]
        public   static extern int avRecvIOCtrl(int avIndex, int[] pioType, byte[] ioCtrlBuf, int ioCtrlBufMaxSize, int timeout_ms);

        //读取视频
        [DllImport("AVAPIs.dll", EntryPoint = "avRecvFrameData2", CallingConvention = CallingConvention.Cdecl)]
        public static extern int avRecvFrameData2(int avIndex, byte[] buf, int inBufSize, int[] outBufSize, int[] outFrmSize, ref FRAMEINFO_t pFrmInfoBuf, int inFrmInfoBufSize, int[] outFrmInfoBufSize, int[] pFrmNo);
        //检查BUFF释放已满
        [DllImport("AVAPIs.dll", EntryPoint = "avCheckAudioBuf", CallingConvention = CallingConvention.Cdecl)]
        public static extern int avCheckAudioBuf(int avIndex);
        /// <summary>
        /// 读取音频数据
        /// </summary>
        /// <param name="avIndex">音频nindex</param>
        /// <param name="buf">音频数据buf</param>
        /// <param name="bufMaxSize">音频数据buf大小</param>
        /// <param name="pFrmInfo">pFrmInfo</param>
        /// <param name="FrmInfoMaxSize">pFrmInfo数据大小</param>
        /// <param name="frameNumber">不知道干什么的，照着例子写就行了</param>
        /// <returns></returns>
        [DllImport("AVAPIs.dll", EntryPoint = "avRecvAudioData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int avRecvAudioData(int avIndex, byte[] buf, int bufMaxSize, byte[] pFrmInfo, int FrmInfoMaxSize, int[] pFrmNo);

        //搜索设备开始
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Search_Device_Start", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IOTC_Search_Device_Start(int nWaitTimeMs, int nSendIntervalMs);
        //停止搜索设备
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Search_Device_Stop", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IOTC_Search_Device_Stop();
        //搜索设备的返回
        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Search_Device_Result", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IOTC_Search_Device_Result(ref st_SearchDeviceInfo[] st_SearchDeviceInfos,  int  arrNum, int nGetAll);

        [DllImport("IOTCAPIs.dll", EntryPoint = "IOTC_Lan_Search2", CallingConvention = CallingConvention.Cdecl)]
        public static extern int IOTC_Lan_Search2(ref st_LanSearchInfo2[] st_LanSearchInfo2s, int nArrayLen, int nWaitTimeMs);

        /// <summary>
        /// 视频数据 pFrmInfoBuf 结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FRAMEINFO_t
        {
            /// <summary>
            ///  Media codec type defined in sys_mmdef.h,
            /// </summary>
            public ushort codec_id;
            /// <summary>
            ///   1关键帧 0普通帧,
            /// </summary>
            public Byte flags;
            /// <summary>
            /// 0 - n
            /// </summary>
            public Byte cam_index;
            /// <summary>
            /// 在线观看人数
            /// </summary>
            public Byte onlineNum;
            /// <summary>
            /// 保留字段
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]   //字符串长度要问dll的提供方，约定的长度是多少
            public string reserve1;
            /// <summary>
            /// 视频的高
            /// </summary>
            public ushort videoWidth;
            /// <summary>
            /// 视频的宽度
            /// </summary>
            public ushort videoHeight;

            public uint timestamp;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct st_SearchDeviceInfo
        {
            /// <summary>
            /// 设备UID
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]   //字符串长度要问dll的提供方，约定的长度是多少
            public string uid;

            /// <summary>
            /// 设备Ip
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 46)]   //字符串长度要问dll的提供方，约定的长度是多少
            public string ip;
            /// <summary>
            /// 设备端口
            /// </summary>
            public ushort port;

            /// <summary>
            /// 设备名称
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]   //字符串长度要问dll的提供方，约定的长度是多少
            public string DeviceName;
            /// <summary>
            /// 保留字段
            /// </summary>
            public Byte Reserved;
            /// <summary>
            /// 不知道干嘛的
            /// </summary>
            public uint nNew;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct st_LanSearchInfo2
        {
            /// <summary>
            /// 设备UID
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]   //字符串长度要问dll的提供方，约定的长度是多少
            public string uid;
            /// <summary>
            /// 设备Ip
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]   //字符串长度要问dll的提供方，约定的长度是多少
            public string ip;
            /// <summary>
            /// 设备端口
            /// </summary>
            public ushort port;
            /// <summary>
            /// 设备名称
            /// </summary>
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 132)]   //字符串长度要问dll的提供方，约定的长度是多少
            public string DeviceName;
            /// <summary>
            /// 保留字段
            /// </summary>
            public Byte Reserved;
        }
    }
}
