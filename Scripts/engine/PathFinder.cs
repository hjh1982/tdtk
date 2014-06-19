using UnityEngine;
using System.Collections;

namespace engine
{
	/// <summary>
	/// 执行真正的寻路
	/// </summary>
	public class PathFinder : MonoBehaviour
	{
		public Path path;

		int pointIndex = 0;
		int maxIndex = 0;
		bool bFinishFind = false;

		// Use this for initialization
		void Start ()
		{
			maxIndex = path.waypoints.Count - 1;
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (!bFinishFind)
			{
				Vector3 point = path.waypoints[pointIndex];
				if (MoveToPoint(point))
				{
					if (pointIndex == maxIndex)
					{
						FinishFind();
					}
					else
					{
						pointIndex = Mathf.Min(path.waypoints.Count - 1, pointIndex + 1);
					}
				}
			}
		}

		bool MoveToPoint(Vector3 point)
		{
			Vector3 dir = (point - transform.localPosition).normalized;
			float dist = Vector3.Distance(point, transform.localPosition);
			if (dist < 1f) return true;
			transform.Translate(dir * Mathf.Min(dist, path.speed * RealTime.deltaTime), Space.Self);
			return false;
		}
		
		void FinishFind()
		{
			bFinishFind = true;
		}
	}
}
