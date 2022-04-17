using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Q4 : BasePanel
{
	public GameObject go;
	Text tex;
	private int N;
	private int cur_id;
	private Button btn;
	
	static readonly string path = "Prefabs/Panel/Q1.1";
	
	private string[] q= new string[] {
"1、洪水来临时，危险地带有（ ）",
"2、洪涝灾害期间，以下不可饮用的是（ ）",
"3、防止洪水涌入室内，以下做法正确的是（ ）",
"4、暴雨时，不能在马路两侧行走的原因有（ ）",
"5、洪水来袭，已经来不及转移时，不应该（ ）",
"6、驾车遭遇洪水时，以下错误的做法是（ ）",
"7、泥石流发生的征兆有( )",
"8、在遇到泥石流的时候，应如何自救（ ）",
"9、在遇到泥石流的时候，应如何自救（ ）",
"10、以下防泥石流安全知识正确的是（ ）",
"41、遇伤员被挤压、夹嵌在事故车内时：（ ）",
"42、车祸发生时：（ ）",
"43、当交通事故发生后，应迅速向（ ) 求救",
"44、翻车已不可避免，需要跳车时，不应：（ ）",
"45、发生交通事故应该：（ ）",
"46、在车祸现场：（ ）",
"47、车辆意外失火时，应：（ ）",
"48、非机动车如何提高安全性：（ ）",
"49、当车辆迎面碰撞时：（ ）",
"50、车辆落水时：（ ）"};

	private string[] a_content=new string[]{
"A、马路两侧",
"A、瓶装水",
"A、用沙袋、土袋在门槛和窗户处筑起防线",
"A、因低洼的地形，马路两侧是最易存水的地方，在积水中不易辨别情况",
"A、立即爬上高处暂时避险。",
"A、立刻冲出车门，弃车逃至地势较高的地方。",
"A、山体出现很多白色水流，山坡变形、鼓包、裂缝，甚至坡上物体出现倾斜。",
"A、往地势空旷、树木生长稀疏的地方逃生。",
"A、朝与泥石流方向垂直的两边撤离。",
"A、泥石流发生时，在坡度大，土层厚的凹处躲避。",
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
"B、地下通道",
"B、烧开的自来水 ",
"B、用胶带纸密封所有门窗的缝隙，多封几层",
"B、两侧埋有下水管线及其他管道，当窖井的盖子丢失时，贸然踏入会伤及自身",
"B、抓住身边存在的漂浮物。",
"B、继续在已被洪水淹没的公路上行驶。",
"B、 河（沟）床中正常流水突然断流或洪水突然增大，并夹有较多的柴草、树木。",
"B、就近选择树木生长密集可阻挡泥石流流速的地带逃生。",
"B、朝泥石流下游方向撤离。",
"B、在山区沟谷中游玩时，在沟道处或沟内的低平处搭建宿营棚。",
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
"C、高架桥下面的通道",
"C、救灾指挥部认可的饮用水",
"C、堵死老鼠洞、排水洞等一切可能进水的地方",
"C、马路中央积水中可能存在其他危险，如遇漩涡应绕行",
"C、单身游水转移。",
"C、如不小心进入被洪水淹没的地区，应爬上车顶，大声呼救。",
"C、 山沟或深谷发出轰鸣声音或有轻微的震动感。",
"C、停留在陡峻的山坡或者爬树躲避。",
"C、朝泥石流上游方向撤离。",
"C、长时间降雨或暴雨渐小之后或雨刚停不能马上返回危险区。",
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
"D、以上都是",
"D、未经处理的地表水",
"D、以上都对",
"D、以上全是",
"D、利用船只、木排、门板、木床等水上转移。",
"D、当汽车沉默在水中时，摇起车窗，打开所有车灯，进行求救。",
"D、以上都是。",
"D、往开阔的低地逃生。",
"D、停在原地等待救援。",
"D、在凹形陡坡危岩突出的地方避雨、休息和穿行。",
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
		{-1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0},

		{-1,0,0,0,0,0,1,0,1,0,0,0,0,0,1,0,0,0,0,0,0},

		{-1,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0},

		{-1,1,1,1,1,0,0,1,0,0,0,1,1,1,0,1,1,1,1,1,1}

	};

	public Q4():base(new UIType(path)){}
	
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