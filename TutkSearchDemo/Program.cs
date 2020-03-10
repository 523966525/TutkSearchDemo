using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using WindowsFormsApp1.juyi;
using static WindowsFormsApp1.juyi.Tutk;

namespace TutkSearchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int ret = Tutk.IOTC_Initialize2(0);
            Console.WriteLine("IOTC_Initialize2:" + ret);
            //设置最大数量
            //ret = Tutk.avInitialize(8);
            //Console.WriteLine("avInitialize:" + ret);
            st_LanSearchInfo2[] st_LanSearchInfo2s = new st_LanSearchInfo2[20];

            //ret = Tutk.IOTC_Lan_Search2(ref st_LanSearchInfo2s, st_LanSearchInfo2s.Length, 3000);
           // Console.WriteLine("IOTC_Lan_Search2:" + ret);
            ret = Tutk.IOTC_Search_Device_Start(5000, 100);
            Console.WriteLine("IOTC_Search_Device_Start:" + ret);
            st_SearchDeviceInfo[] ab_LanSearchInfo = new st_SearchDeviceInfo[200];

            ret = Tutk.IOTC_Search_Device_Result(ref ab_LanSearchInfo, ab_LanSearchInfo.Length, 0);
            Console.WriteLine("IOTC_Search_Device_Result:" + ret + " ab_LanSearchInfo:" + ab_LanSearchInfo[0].uid);
            //Tutk.IOTC_Search_Device_Stop();
            Console.ReadKey();//让窗体保存接受外部参数的状态来达到不退出的效果

        }

        }
    }
