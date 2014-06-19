using UnityEngine;
using System.Collections;

namespace engine
{
	public class TimeUtil 
	{
		static public IEnumerator Wait(float interval)
		{
			for (float timer = 0; timer < interval; timer += RealTime.deltaTime) 
			{
				yield return 0;
			}
		}
	}
}