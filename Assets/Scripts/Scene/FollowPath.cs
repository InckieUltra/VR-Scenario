using UnityEngine;
using System.Collections;

public class FollowPath : MonoBehaviour {

    public bool StartFollow = false;
    public EditorPathScript PathToFollow;
    public int CurrentWayPointID = 0;
    private float Speed;//移动速度
	public float normalSpeed;
    public float reachDistance = 0f;//里路径点的最大范围
    public string PathName;//跟随路径的名字
    private string LastName;
    private bool ChangePath = true;
	double lastTime;



    void Start () {
		Speed = normalSpeed;
    }

    void Update () {
        if (!StartFollow)
            return;
        if (ChangePath)
        {
            PathToFollow = GameObject.Find(PathName).GetComponent<EditorPathScript>();
            ChangePath = false;
        }
        if (LastName != PathName)
        {
            ChangePath = true;
        }
        LastName = PathName;

		


        float distance = Vector3.Distance(PathToFollow.path_objs[CurrentWayPointID].position, transform.position);
        //transform.Translate(PathToFollow.path_objs[CurrentWayPointID].position * Time.deltaTime * Speed, Space.Self);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.path_objs[CurrentWayPointID].position, Time.deltaTime * Speed);
        if (distance <= reachDistance)
        {
            CurrentWayPointID++;
        }
        if (CurrentWayPointID >= PathToFollow.path_objs.Count)
        {
            CurrentWayPointID = 0;
			Speed = 9999;
        }
		else
			Speed = normalSpeed;
    }
}