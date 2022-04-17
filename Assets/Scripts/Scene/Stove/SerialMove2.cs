// 串口通信+物体移动(旋转)
//--------------------环境配置--------------------------
// Edit->Projrct Settings->Player->Api COmpatibility level设置为".NET 4.x"
// 将脚本与手的prefab绑定
// portName根据实际情况进行设置
//--------------------模块介绍--------------------------
// 通过isMode1设置模式。
// mode1, 离散型运动，选择encoding_1,move_1,speed=7.0f;
// mode2, 连续型运动，选择encoing_2,move_2,speed=0。001f;
//-----------------------------------------------------
using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

public class SerialMove2 : MonoBehaviour
{
	/*物体运动*/
	public bool isMode1 = true;//true代表mode1，false代表，mode2
	private float movespeed_1 = 10.0f;
	private float movespeed_2 = 1f;
	private int x=0;//Right，对应pitch,mpu6050 y，手腕向上
	private int y=0;//Up，对应roll, mpu6050 x, 手腕向右
	private int z=0;//Forward，对应-yaw, mpu6050 -z，顺时针拧瓶盖
	private int f=0;//Flex，手指弯曲，值为1;相当于Click信号，后续可被使用！！！！！！
    private bool isFlex = false;//辅助f运算
	private int ticks=0;//move_2计数使用
    private int count =0 ;//collision使用

	/*串口通信*/
	private SerialPort sp; //串口名字
	private Thread recvThread; //接收线程
    public string portName = "/dev/cu.usbserial-14410";//串口号
    public int baudRate = 19200;//波特率
    //public Parity parity = Parity.None;//效验位
    //public int dataBits = 8;//数据位
    //public StopBits stopBits = StopBits.One;//停止位

    /*数据传递*/
    private Queue<char> dataQueue = new Queue<char>();//队列数据池
    private String str; //串口readline（）数据
    private char data;  //实际接受数据
  
   
    void Start()
    {
        OpenPort();
        recvThread = new Thread(new ThreadStart(DataReceiveFunction));
        recvThread.Start();
    }

    void Update()
    {
        if(dataQueue.Count!=0){
        	char data = dataQueue.Dequeue();
        	// Debug.Log("main: "+data);
        	// Debug.Log("main: "+"x: " + (data>>4) + " y: "+ ((data>>2)&3) + " z: " + (data&3));
        	if(isMode1){
        		encoding_1(data);
        	}
        	else{
        		encoding_2(data);
        	}
        }
        if(isFlex && f==0){
            Debug.Log("000000000");
            int count = 0;
            foreach (Transform child in this.transform)
            {
                count++;
                if(count>3){
                    Debug.Log ("Trigger Up");
 
                    child.GetComponent<Rigidbody>().isKinematic = false;
 
                    child.GetComponent<Rigidbody>().useGravity = true;
 
                    child.SetParent(null);
                }
            }
            isFlex = false;
        }
        if(isMode1){
            move_1();
        }
        else{
            move_2();
        }
    }

    
    void OnCollisionStay(Collision collision){
        count++;
        Debug.Log("111111");
        if (f==1){
            Debug.Log("2222222");
            collision.collider.attachedRigidbody.isKinematic = true;
            collision.collider.attachedRigidbody.useGravity = false;
            collision.collider.gameObject.transform.SetParent(this.transform);
        }
 
    }

    //离散型运动
    void encoding_1(char data){
    	//decoding
    	int s_f = (data>>6)&1;
    	int s_x = data>>4;
    	int s_y = (data>>2)&3;
    	int s_z = data&3;
    	Debug.Log("Main: s_f: "+s_f+" s_x: "+x+" s_y: "+y+" s_z: "+z);
		f = s_f;
        if(f==1){
            isFlex = true;
        }
		if(s_y==1){
			x=1;
		}else if(s_y==2){
			x=-1;
		}
		if(s_x==1){
			y=1;
		}else if(s_x==2){
			y=-1;
		}
		if(s_z==1){
			z=-1;
		}else if (s_z==2){
			z=1;
		}	
		Debug.Log("Main: v_f: "+f+" v_x: "+x+" v_y: "+y+" v_z: "+z);
    }

    void move_1(){
    	// this.transform.Translate(new Vector3(x,y,z)*movespeed_1*Time.deltaTime,Space.World);//绝对位移
    	this.transform.Translate(new Vector3(z,y,-x)*movespeed_1*Time.deltaTime);//相对位移
		x=0;
		y=0;
		z=0;
    }

    //连续型运动
    void encoding_2(char data){
    	//decoding
    	int s_f = (data>>6)&1;
    	int s_x = data>>4;
    	int s_y = (data>>2)&3;
    	int s_z = data&3;
    	Debug.Log("Main: s_f: "+s_f+" s_x: "+x+" s_y: "+y+" s_z: "+z);
		f = s_f;
        if(f==1){
            isFlex = true;
        }
		if(s_y==1){
			if(x!=1)
				x+=1;
		}else if(s_y==2){
			if(x!=-1)
				x-=1;
		}
		if(s_x==1){
			if(y!=1)
				y+=1;
		}else if(s_x==2){
			if(y!=-1)
				y-=1;
		}
		if(s_z==1){
			if(z!=-1)
				z-=1;
		}else if (s_z==2){
			if(z!=1)
				z+=1;
		}
		Debug.Log("Main: v_f: "+f+" v_x: "+x+" v_y: "+y+" v_z: "+z);
    }

    //速度太快，定期停止
    void move_2(){
    	// this.transform.Translate(new Vector3(x,y,z)*movespeed_2*Time.deltaTime,Space.World);
    	this.transform.Translate(new Vector3(z,y,-x)*movespeed_2*Time.deltaTime);//相对位移

    	// ticks++;
    	// if(ticks==100){
    	// 	ticks=0;
    	// 	x=0;
    	// 	y=0;
    	// 	z=0;
    	// 	f=0;
    	// }
    }

    void OnApplicationQuit()
    {
        ClosePort();
    }

    //打开串口
    public void OpenPort()
    {
        //创建串口
        sp = new SerialPort(portName, baudRate);
        sp.ReadTimeout = 400;
        try
        {
            sp.Open();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    //关闭串口
    public void ClosePort()
    {
        try
        {
            sp.Close();
            recvThread.Abort();
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
    }

    //接收数据
    void DataReceiveFunction()
    {
        while (true)
        {
            if (sp != null && sp.IsOpen)
            {
                try
                {
                	str = sp.ReadLine();            
	                sp.DiscardInBuffer();//清除缓存

	                if(str.Length!=0){
	                	data = str[0];
	                	dataQueue.Enqueue(data);

	                	// Debug.Log("Signal_len: " + strRec.Length);
				    	Debug.Log("Thread: Signal: "+data);
				    	Debug.Log("Thread: s_f: "+((data>>6)&1)+"s_x: " + (data>>4) + " s_y: "+ ((data>>2)&3) + " s_z: " + (data&3));
	                }
                }
                catch (Exception ex)
                {
                    if (ex.GetType() != typeof(ThreadAbortException))
                    {
                    	// Debug.Log(ex.Message);
                    }
                }
            }
            // Thread.Sleep(10);
        }
    }
}