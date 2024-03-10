using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;

namespace cf_pad.Forms
{
    public partial class frmDemoRS485 : Form
    {
        /// <summary>
        /// 串行端口资源 端口名称 波特率 奇偶校验位 数据位 停止位
        /// </summary>
        public SerialPort port = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
        public frmDemoRS485()
        {
            InitializeComponent();

            ////串行端口号
            //seriaSettingPlay.PortName = "COM1";
            ////波特率
            //seriaSettingPlay.BaudRate = 115200;
            ////奇偶校验位
            //seriaSettingPlay.Parity = Parity.None;
            ////数据位
            //seriaSettingPlay.DataBits = 8;
            ////停止位
            //seriaSettingPlay.StopBits = StopBits.One;
            //textChanged += new UpdateTextEventHandler(ChangeText);
            //try
            //{
            //    //打开串口
            //    seriaSettingPlay.Open();
            //}
            //catch (Exception ex)
            //{
            //    //捕获的异常信息，没检查到串口或串口设置不正确。
            //    MessageBox.Show("请检查是否已经连接串口！\n" + ex.Message, "提示");
            //}
        }

        //定义委托
        private delegate void GetText(string text);
        //定义事件
        private event GetText textChanged;
        //事件处理方法
        private void ChangeText(string text)
        {
              //这里为处理接收到的值，赋值到控件上。
              //...........
        }
        //定义接收的字节
        private byte[] Data = new byte[8];
        private void frmDemoRS485_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// //设备全开、关
        /// </summary>
        protected void AllOpenOrClose()
        {
            //try
            //{
            //    //打开串口
            //    port.Open();
            //    //判断是否选中开
            //    if (chb_CheckAll.Checked == true)
            //    {
            //        //用字节的形式发送数据  全开 解释：order1 是控制命令，后面是2个byte的校验（高8位与低8位），0x00可以不写，直接写成(byte)((order1)>>8)
            //        byte[] b = { order1, (byte)((order1 + 0x00) >> 8), (byte)(order1 + 0x00) };
            //        //把b数组中的数据以字节的形式写入串行端口
            //        port.Write(b, 0, b.Length);
            //        //提示信息！
            //        lab_Message.Text = "设备已经全部打开!";
            //    }
            //    else
            //    {
            //        //用字节的形式发送数据  全关
            //        byte[] b = { order2, (byte)((order2 + 0x00) >> 8), (byte)(order2 + 0x00) };
            //        v.port.Write(b, 0, b.Length);
            //        lab_Message.Text = "设备已经全部关闭!";
            //    }

            //    //关闭串口  记得开启端口之后一定要关闭，和ADO.NET的Connection对象一样，用过之后必须关闭。
            //    port.Close();
            //}
            //catch (Exception ex)
            //{
            //    //捕获的异常信息
            //    MessageBox.Show(ex.Message, "提示");

            //}
        }

        private void seriaSettingPlay_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ////读取来自监听到的字节
            //seriaSettingPlay.Read(be, 0, be.Length);
            ////把第一个命名赋值到text变量
            //text = be[0].Tostring();
            //seriaSettingPlay.DiscardInBuffer();
            //this.Invoke(textChanged, new string[] { text });
        }
    }
}
