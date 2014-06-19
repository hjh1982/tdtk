using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace engine
{
	/// <summary>
	/// 负责设置路径点这些寻路需要使用的变量
	/// zhexie
	/// </summary>
	[System.Serializable]
    public class Path : MonoBehaviour
    {
        //速度单位是像素
        public float speed = 5f;
        //路点集合，路点的坐标也是像素
        public List<Vector3> waypoints;
    }
}