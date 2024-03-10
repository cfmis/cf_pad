using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Timers;

namespace cf_pad.CLS
{
    public class SynTimer
    {
        public static AutoResetEvent SendTimertimeout = new AutoResetEvent(false);  // sychronize send timer to send task
    }
    public class RS485 : SynTimer
    {
//        enum eCMDType
//        {
//        };

//        enum eFrameType
//        {

//        };
//        enum eFrameOffset
//        {

//        };

//        enum eRecvErrorCode
//        {

//        };

//        private struct SFrameContent
//        {
//            public byte frame_head1;
//            public byte frame_head2;
//            public byte frame_des;
//            public byte frame_tail1;
//            public byte frame_tail2;
//        };

//        private struct SReceivedErrMsg
//        {

//        };
//        private struct SIoTMsg
//        {

//        };

//        SerialPortStream uart;
//        SFrameContent SFramecontent;
//        SReceivedErrMsg errMsg;
//        SIoTMsg IoTMsgs;

//        private static byte CMD0ResendCount;
//        private static byte CMD3ResendCount;
//        private static bool isGetHeartbeat = false;
//        private static bool BusOff_485 = false;
//        private byte isGetRes = 0x00;

//        // 计时器
//        private System.Timers.Timer HeartbeatTimer;
//        private System.Timers.Timer CMD3Timer;
//        private System.Timers.Timer CMD0Timer;
//        private System.Timers.Timer SendTimer;

//        // for debug
//        private void showRcevInfo(byte[] recvBuf)
//        {
//            Console.Write("DATA RECEIVED: Length = {0}; ", recvBuf.Length);
//            for (int i = 0; i < recvBuf.Length; i++)
//            {
//                Console.Write("buf[{0}]: {1:x} ", i, recvBuf[i]);
//            }
//            Console.WriteLine(" -->receive buf end.");
//        }

//        public RS485()
//        {
//            uartInit();
//            SFramecontent = new SFrameContent();
//            SFramecontent.frame_head1 = 0xaa;
//            SFramecontent.frame_head2 = 0x55;
//            SFramecontent.frame_des = 0x00;
//            SFramecontent.frame_tail1 = 0x0a;
//            SFramecontent.frame_tail2 = 0x0d;
//        }

//        private void uartDataReceived(object sender, SerialDataReceivedEventArgs e)
//        {
//            SerialPortStream serialPort = (SerialPortStream)sender;
//            byte[] recvBuf = new byte[serialPort.BytesToRead];
//            byte recvErrorCode = 0;

//            if (recvBuf.Length < (int)eFrameOffset.FRAME_LENBASE)
//            {
//                #region DEBUG_MSG
//#if true
//                serialPort.Read(recvBuf, 0, recvBuf.Length);
//                showRcevInfo(recvBuf);
//#endif
//                #endregion
//                Console.WriteLine(" invalid lenth.lenth = {0}\n", recvBuf.Length);
//                return;
//            }
//            //接收到数据包
//            serialPort.Read(recvBuf, 0, recvBuf.Length);
//            #region DEBUG_MSG
//#if true
//            showRcevInfo(recvBuf);
//#endif
//            #endregion
//            //检查帧头
//            if (recvBuf[(int)eFrameOffset.FRAME_HEAD1].Equals(SFramecontent.frame_head1) &&
//                recvBuf[(int)eFrameOffset.FRAME_HEAD2].Equals(SFramecontent.frame_head2))
//            {
//                //检查帧尾
//                if (recvBuf[recvBuf.Length - (int)eFrameOffset.FRAME_TAIL1].Equals(SFramecontent.frame_tail1) &&
//                    recvBuf[recvBuf.Length - (int)eFrameOffset.FRAME_TAIL2].Equals(SFramecontent.frame_tail2))
//                {
//                    //检查目的地址
//                    if (recvBuf[(int)eFrameOffset.FRAME_DES].Equals(SFramecontent.frame_des))
//                    {
//                        //检查帧长度
//                        if (!recvBuf[(int)eFrameOffset.FRAME_LEN].Equals(recvBuf.Length))
//                        {
//                            //校验
//                            if (CheckSum(recvBuf))
//                            {
//                                ParseCMD(recvBuf);
//                            }
//                            else
//                            {
//                                Console.WriteLine("check sum failed.\n");
//                                recvErrorCode = (byte)eRecvErrorCode.Checksum_Error;
//                            }
//                        }
//                        else
//                        {
//                            Console.WriteLine("check len failed. len = {0:x}, recv_len = {1:x}\n", recvBuf[(int)eFrameOffset.FRAME_LEN], recvBuf.Length);
//                            recvErrorCode = (byte)eRecvErrorCode.Len_Error;
//                        }
//                    }
//                    else
//                    {
//                        Console.WriteLine("check des failed.\n");
//                        recvErrorCode = (byte)eRecvErrorCode.Des_Error;
//                    }
//                }
//                else
//                {
//                    Console.WriteLine("check tail failed.\n");
//                    recvErrorCode = (byte)eRecvErrorCode.Tail_Error;
//                }
//            }
//            else
//            {
//                Console.WriteLine("check head failed.\n");
//                recvErrorCode = (byte)eRecvErrorCode.Head_Error;
//            }

//            //发送故障码
//            if (!recvErrorCode.Equals(0))
//            {
//                SendErrorCode(recvErrorCode);
//            }
//        }

//        private byte CalSum(byte[] checkBuf)
//        {
//            int sum = 0;
//            byte checksum = 0;

//            for (int i = (int)eFrameOffset.FRAME_DES; i < checkBuf.Length - (int)eFrameOffset.FRAME_CHECKSUM; i++)
//            {
//                sum += checkBuf[i];
//            }
//            checksum = (byte)(sum & 0xff);
//            checksum = (byte)(~checksum + 1);

//            return checksum;
//        }

//        private bool CheckSum(byte[] checkBuf)
//        {
//            byte recv_checksum = checkBuf[checkBuf.Length - (int)eFrameOffset.FRAME_CHECKSUM];
//            byte checksum = 0;

//            checksum = CalSum(checkBuf);

//            //    Console.WriteLine("CheckSum :recv_checksum = {0:x}, checksum = {1:x}.\n", recv_checksum, checksum);

//            if (checksum.Equals(recv_checksum))
//                return true;
//            else
//                return false;
//        }

//        private void ParseCMD(byte[] parseBuf)
//        {
//            byte cmd = parseBuf[(int)eFrameOffset.FRAME_CMD];

//            // ack
//            SendResponse(cmd);

//            //处理命令
//            switch (cmd)
//            {
//                case (byte)eCMDType.cmd_ElevatorReq:
//                    ParseCMD0(parseBuf);
//                    break;
//                case (byte)eCMDType.cmd_LiTOElErrorUpload:
//                    ParseCMD1(parseBuf);
//                    break;
//                case (byte)eCMDType.cmd_LiTOElIOTUpload:
//                    ParseCMD2(parseBuf);
//                    break;
//                case (byte)eCMDType.cmd_ElTOLiSendFloor:
//                    ParseCMD3(parseBuf);
//                    break;
//                case (byte)eCMDType.cmd_LiTOElUploadFloor:
//                    ParseCMD4(parseBuf);
//                    break;
//                case (byte)eCMDType.cmd_Heartbeat:
//                    ParseHeartbeat();
//                    break;
//                case (byte)eCMDType.cmd_PackageError:
//                    ParsePackageError();
//                    break;
//                default:
//                    Console.WriteLine("invalid cmd:{0}\n", cmd);
//                    break;

//            }

//        }

//        private void ParseCMD0(byte[] parseBuf)
//        {
//            Console.WriteLine("ParseCMD0.\n");
//            // 正确接收到ack， 停止timer
//            CMD0Timer.Enabled = false;
//            CMD0Timer.Stop();
//        }

//        private void ParseCMD1(byte[] parseBuf)
//        {

//            Console.WriteLine("ParseCMD1.\n");
//        }

//        private void ParseCMD2(byte[] parseBuf)
//        {
//            Console.WriteLine("ParseCMD2.\n");
//        }

//        private bool ParseCMD3(byte[] parseBuf)
//        {
//            Console.WriteLine("ParseCMD3.\n");
//            if (parseBuf[(int)eFrameOffset.FRAME_DATA].Equals(0))
//            {
//                // 正确接收到ack， 停止timer
//                CMD3Timer.Enabled = false;
//                CMD3Timer.Stop();

//                return true;
//            }
//            else     // 对方接收到的报文不对， 重发
//            {
//                Console.WriteLine("parse cmd3:{0}", DateTime.Now);
//                if (!BusoffHandler((byte)eCMDType.cmd_ElTOLiSendFloor))
//                {
//                    Console.WriteLine("cmd3 error:{0}", parseBuf[(int)eFrameOffset.FRAME_DATA]);
//                    // 重发
//                    CMD3ResendCount++;
//                    SendCMD3();
//                }
//                else
//                {
//                    Console.WriteLine("cmd3 timeout:{0}", DateTime.Now);
//                }
//            }

//            return false;
//        }

//        private void ParseCMD4(byte[] parseBuf)
//        {
//            Console.WriteLine("ParseCMD4: floor num from light curtain:{0}", recvdFloorNum);
//        }

//        private void ParseHeartbeat()
//        {
//            byte[] buf = new byte[1];
//            buf[0] = 0;

//            isGetHeartbeat = true;
//            SendCMD(buf, (byte)eCMDType.cmd_Heartbeat, 0x01, (byte)eFrameType.Ack);

//            Console.WriteLine("res heartbeat. res time = {0}", DateTime.Now);
//        }

//        private void ParsePackageError()
//        {
//            Console.WriteLine("ParsePackageError \n");
//        }

//        private void SendResponse(byte cmd)
//        {
//            byte[] resbuf = new byte[1];
//            resbuf[0] = (byte)eRecvErrorCode.No_Error;

//            if (cmd != (byte)eCMDType.cmd_ElevatorReq && cmd != (byte)eCMDType.cmd_ElTOLiSendFloor && cmd != (byte)eCMDType.cmd_Heartbeat)
//                SendCMD(resbuf, cmd, 0x01, (byte)eFrameType.Ack);
//        }
//        private void SendErrorCode(byte errorCode)
//        {
//            // TODO: 
//            //    byte[] errcode = new byte[1];
//            //    errcode[0] = errorCode;
//            //    SendCMD(errcode, (byte)eCMDType.cmd_PackageError, 0x01, (byte)eFrameType.Error);

//            Console.WriteLine("SendErrorCode errorCode:{0} \n", errorCode);
//        }

//        private void SendCMD(byte[] buf, byte cmd, byte len, byte type)
//        {
//            byte sendlen = (byte)(eFrameOffset.FRAME_LENBASE + len);
//            byte[] sendbuf = new byte[sendlen];

//            SendTimer.Start();
//            Console.WriteLine("Send timer start, time = {0}", DateTime.Now.TimeOfDay);

//            sendbuf[(int)eFrameOffset.FRAME_HEAD1] = SFramecontent.frame_head1;
//            sendbuf[(int)eFrameOffset.FRAME_HEAD2] = SFramecontent.frame_head2;
//            sendbuf[(int)eFrameOffset.FRAME_DES] = 0x01;
//            sendbuf[(int)eFrameOffset.FRAME_CMD] = cmd;
//            sendbuf[(int)eFrameOffset.FRAME_TYPE] = type;
//            sendbuf[(int)eFrameOffset.FRAME_LEN] = sendlen;
//            //数据域赋值
//            for (int i = 0; i < len; i++)
//            {
//                sendbuf[(int)(eFrameOffset.FRAME_DATA + i)] = buf[i];
//            }
//            //校验
//            sendbuf[(int)(sendlen - eFrameOffset.FRAME_CHECKSUM)] = CalSum(sendbuf); ;
//            sendbuf[(int)(sendlen - eFrameOffset.FRAME_TAIL1)] = SFramecontent.frame_tail1;
//            sendbuf[(int)(sendlen - eFrameOffset.FRAME_TAIL2)] = SFramecontent.frame_tail2;

//            #region DEBUG_MSG   
//#if true            // todo: remove in publish
//            Console.Write("send buf: ");
//            for (int j = 0; j < sendlen; j++)
//            {
//                Console.Write(" {0:x} ", sendbuf[j]);
//            }
//            Console.WriteLine("\n");
//#endif
//            #endregion
//            if (uart.IsOpen)
//            {
//                try
//                {
//                    SendTimertimeout.WaitOne();
//                    Console.WriteLine("send package: {0}", DateTime.Now.TimeOfDay);
//                    uart.Write(sendbuf, 0, sendlen);
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine("send error: {0}", e);
//                }
//            }
//            else
//            {
//                Console.WriteLine("uart {0} is closed!", uart.PortName);
//            }

//        }

//        public void SendCMD0()
//        {
//            SynSign.mUpdateEventForRS485.WaitOne();
//            Console.WriteLine("ElevatorSendCMD0.\n");

//            byte[] buf = new byte[6];
//            buf[0] = 0x01;
//            SendCMD(buf, (byte)eCMDType.cmd_ElevatorReq, 0x06, (byte)eFrameType.Request);

//            CMD0Timer.Enabled = true;
//            CMD0Timer.Start();
//        }

//        public void SendCMD3()
//        {
//            byte[] sendbuf = new byte[7];

//            sendbuf[0] = 0;

//            Console.WriteLine("ElevatorSendCMD3.\n");

//            SendCMD(sendbuf, (byte)eCMDType.cmd_ElTOLiSendFloor, 0x07, (byte)eFrameType.Download);

//            CMD3Timer.Enabled = true;
//            CMD3Timer.Start();
//        }

//        private bool BusoffHandler(byte cmd)
//        {
//            byte ResendCount = 0;

//            if (cmd == (byte)eCMDType.cmd_ElevatorReq)
//            {
//                ResendCount = CMD0ResendCount;
//            }
//            else if (cmd == (byte)eCMDType.cmd_ElTOLiSendFloor)
//            {
//                ResendCount = CMD3ResendCount;
//            }

//            if (ResendCount > 3 || cmd == (byte)eCMDType.cmd_Heartbeat)
//            {
//#if true   //TODO: in publish version
//                // TODO: 心跳超时， 485网络故障， 关闭485
//                BusOff_485 = true;
//                uart.Close();
//                // 关闭定时器
//                HeartbeatTimer.Dispose();
//                CMD3Timer.Dispose();
//                CMD0Timer.Dispose();
//                // TODO: 上报到com stack
//#endif
//                return true;
//            }
//            return false;
//        }

//        private void HeartbeatTimeoutExecute(object source, System.Timers.ElapsedEventArgs e)
//        {
//            HeartbeatTimer.Stop();

//            if (isGetHeartbeat)
//            {
//                isGetHeartbeat = false;
//                Console.WriteLine("HeartbeatTimeoutExecute: get heartbeat time = {0}", DateTime.Now);
//            }
//            else
//            {
//                Console.WriteLine("HeartbeatTimeoutExecute:{0}", DateTime.Now);
//                if (BusoffHandler((byte)eCMDType.cmd_Heartbeat))
//                {
//                    Console.WriteLine("heartbeat timeout:{0}", DateTime.Now);
//                    return;
//                }
//            }
//            HeartbeatTimer.Interval = 3000;     // 第一次检测心跳为上电10s后， 此后每3s检测一次
//            HeartbeatTimer.Start();
//        }

//        private void CMD0TimeoutExecute(object source, System.Timers.ElapsedEventArgs e)
//        {
//            CMD0Timer.Stop();
//            // 没有接收到对方回复
//            {
//                Console.WriteLine("cmd0 TimeoutExecute:{0}", DateTime.Now);
//                if (!BusoffHandler((byte)eCMDType.cmd_ElevatorReq))
//                {
//                    // 超时未收到 res， 重发
//                    CMD0ResendCount++;
//                    SendCMD0();
//                }
//                Console.WriteLine("CMD0 get res timeout, resend.CMD0ResendCount = {0}", CMD0ResendCount);
//            }
//        }

//        private void CMD3TimeoutExecute(object source, System.Timers.ElapsedEventArgs e)
//        {
//            CMD3Timer.Stop();
//            // 没有接收到对方回复， 重发
//            {
//                Console.WriteLine("cmd3 TimeoutExecute:{0}", DateTime.Now);
//                if (!BusoffHandler((byte)eCMDType.cmd_ElTOLiSendFloor))
//                {
//                    // 超时未收到res， 重发
//                    CMD3ResendCount++;
//                    SendCMD3();
//                }
//                Console.WriteLine("CMD3 get res timeout, resend.ResendCount = {0}", CMD3ResendCount);
//            }
//        }

//        // delay 10ms before send cmd package
//        private void SendtimerTimeoutExecute(object source, System.Timers.ElapsedEventArgs e)
//        {
//            SendTimer.Stop();
//            SendTimertimeout.Set();
//            Console.WriteLine("Send timer timeout, time = {0}", DateTime.Now.TimeOfDay);
//        }

//        public void uartInit()
//        {
//            uart = new SerialPortStream();
//            uart.BaudRate = 115200;
//            uart.PortName = "/dev/ttymxc2";
//            //    uart.PortName = "COM8";
//            uart.Parity = Parity.None;
//            uart.StopBits = StopBits.One;
//            uart.DataReceived += uartDataReceived;

//            // 初始化心跳定时器
//            HeartbeatTimer = new System.Timers.Timer(10000);         // 心跳超时时间 第一次进中断为10s以后
//            HeartbeatTimer.Elapsed += new System.Timers.ElapsedEventHandler(HeartbeatTimeoutExecute);
//            HeartbeatTimer.AutoReset = true;

//            // 初始化cmd0 定时器
//            CMD0Timer = new System.Timers.Timer(500);
//            CMD0Timer.Elapsed += new System.Timers.ElapsedEventHandler(CMD0TimeoutExecute);
//            CMD0Timer.AutoReset = false;

//            // 初始化cmd3 定时器
//            CMD3Timer = new System.Timers.Timer(500);
//            CMD3Timer.Elapsed += new System.Timers.ElapsedEventHandler(CMD3TimeoutExecute);
//            CMD3Timer.AutoReset = false;

//            // 初始化 send cmd 定时器
//            SendTimer = new System.Timers.Timer(10);
//            SendTimer.Elapsed += new System.Timers.ElapsedEventHandler(SendtimerTimeoutExecute);
//            SendTimer.AutoReset = false;

//            try
//            {
//                uart.Open();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("uart open error:{0}", e);
//            }
//            Console.WriteLine("init uart.!");
//        }

//        public void Task()
//        {
//            Console.WriteLine(" uart task.!");
//            string cmd = "";

//            if (uart.IsOpen)
//            {
//                Console.WriteLine(" open heartbeat timer.!");
//                HeartbeatTimer.Enabled = true;
//                HeartbeatTimer.Start();
//            }

//            while (true)
//            {
//                Console.WriteLine("pls input cmd(end with enter_ksy): ");
//                cmd = Console.ReadLine();

//                switch (cmd)
//                {
//                    case "cmd0":
//                        SynSign.mUpdateEventForRS485.Set();
//                        break;
//                    case "cmd3":
//                        ElevatorSendCMD3();
//                        break;
//                    case "open heart":
//                        HeartbeatTimer.Enabled = true;
//                        HeartbeatTimer.Start();
//                        break;
//                    case "close heart":
//                        HeartbeatTimer.Stop();
//                        break;
//                    default:
//                        Console.WriteLine("invalid cmd: {0}", cmd);
//                        break;
//                }
//                ElevatorSendCMD0();
//            }

//        }

//        static void Main()
//        {
//            //     RS485 uart485 = new RS485();
//            Task Task = new TaskFactory().StartNew(() =>
//            {
//                new Task(() =>
//                {
//                    Console.WriteLine("Create rs485 task");
//                    new RS485().Task();
//                }).Start();
//            });

//            Thread.CurrentThread.Join();
//        }


    }
}
