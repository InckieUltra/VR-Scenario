using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Q5 : BasePanel
{
	public GameObject go;
	Text tex;
	private int N;
	private int cur_id;
	private Button btn;
	
	static readonly string path = "Prefabs/Panel/Q1.1";
	
	private string[] q= new string[] {
"1、遇伤员被挤压、夹嵌在事故车内时：（ ）",
"2、车祸发生时：（ ）",
"3、当交通事故发生后，应迅速向（ ) 求救",
"4、翻车已不可避免，需要跳车时，不应：（ ）",
"5、发生交通事故应该：（ ）",
"6、在车祸现场：（ ）",
"7、车辆意外失火时，应：（ ）",
"8、非机动车如何提高安全性：（ ）",
"9、当车辆迎面碰撞时：（ ）",
"10、车辆落水时：（ ）"};

	private string[] a_content=new string[]{
"A、尽量避免暴力硬拉等方法",
"A、驾乘者应沉着冷静",
"A、消防(119)、交通(122)、急救中心(120）",
"A、用力蹬双脚，增大向外抛出的力量和距离",
"A、立即停车",
"A、保护现场的原始状态",
"A、破窗脱身打滚灭火",
"A、佩戴头盔 ",
"A、两脚踏直身体后倾 ",
"A、先深呼吸再开车门"};

	private string[] b_content=new string[]{
"B、应等待专业救援人员",
"B、保持清醒的头脑",
"B、就近单位、村镇",
"B、顺着翻车的方向跳车",
"B、开启危险报警闪光灯，如夜间还需开示宽灯、尾灯",
"B、不故意破坏、伪造现场",
"B、立即熄火、切断油路和电源",
"B、遇到抢道时，应视情况降低车速",
"B、保持身体平衡",
"B、头部尽量保持在水面上"
};

	private string[] c_content=new string[]{
"C、非专业人士不盲目救援",
"C、及时寻求救援",
"C、可拦截过往车辆",
"C、逆着翻车的方向跳车",
"C、在高速公路上还需在车后按规定设置危险警告标志。",
"C、可用绳索等设置警戒线，保护好现场",
"C、组织车内人员迅速离开车体",
"C、后座尽量不坐人",
"C、驾驶人应迅速躲离方向盘，将两脚抬起",
"C、水较深时，先不急于打开车门"
};

	private string[] d_content=new string[]{
"D、以上都对",
"D、以上都对",
"D、以上都对",
"D、尽量避免跳出后又被车辆重新压上。",
"D、以上都对",
"D、以上都对",
"D、以上都对",
"D、以上都对",
"D、以上都对",
"D、以上都对",
};


	private int now_choose;
	private int[,] TF=new int[,]{
		{-1,0,0,0,0,0,0,0,0,0,0},

		{-1,0,0,0,1,0,0,0,0,0,0},

		{-1,0,0,0,0,0,0,0,0,0,0},

		{-1,1,1,1,0,1,1,1,1,1,1}

	};

	public Q5():base(new UIType(path)){}
	
	public override void OnEnter(){
		go=GameObject.Find("EventSystem");
		N=10;cur_id=0;now_choose=0;
		nextP();
		UITool.GetOrAddComponentInChildren<Button>("A").onClick.AddListener(()=>{
			now_choose=0;
			nextP();
		});
		UITool.GetOrAddComponentInChildren<Button>("B").onClick.AddListener(()=>{
			now_choose=1;
			nextP();
		});
		UITool.GetOrAddComponentInChildren<Button>("C").onClick.AddListener(()=>{
			now_choose=2;
			nextP();
		});
		UITool.GetOrAddComponentInChildren<Button>("D").onClick.AddListener(()=>{
			now_choose=3;
			nextP();
		});
		UITool.GetOrAddComponentInChildren<Button>("Exit").onClick.AddListener(()=>{
			SceneManager.LoadScene("MainMenu");
		});
	}
	void nextP(){
		if(TF[now_choose,cur_id]==1)
			go.GetComponent<Cnt>().T++;
		else if(TF[now_choose,cur_id]==0)
			go.GetComponent<Cnt>().F++;
		if(cur_id==N){
			PanelManager.Push(new CntP());
			return;
		}
		tex=UITool.GetOrAddComponentInChildren<Text>("Q");
		tex.text=q[cur_id];
		tex=GameObject.Find("A/Text").GetComponent<Text>();
		tex.text=a_content[cur_id];
		tex=GameObject.Find("B/Text").GetComponent<Text>();
		tex.text=b_content[cur_id];
		tex=GameObject.Find("C/Text").GetComponent<Text>();
		tex.text=c_content[cur_id];
		tex=GameObject.Find("D/Text").GetComponent<Text>();
		tex.text=d_content[cur_id];
		tex = UITool.GetOrAddComponentInChildren<Text>("Cnt");
		tex.text="正确:"+go.GetComponent<Cnt>().T+"  错误:"+go.GetComponent<Cnt>().F;
		cur_id++;
	}
}