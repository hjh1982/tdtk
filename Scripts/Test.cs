using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {


		void Start()
		{
			StartCoroutine(SaySomeThings());
		}
		
		//Say some messages separated by time
		IEnumerator SaySomeThings()
		{
			Debug.Log("The routine has started");
			yield return StartCoroutine(Wait(1.0f));
			Debug.Log("1 second has passed since the last message");
			yield return StartCoroutine(Wait(2.5f));
			Debug.Log("2.5 seconds have passed since the last message");
		}
		
		//Our wait function
		IEnumerator Wait(float duration)
		{
				for (float timer = 0; timer < duration; timer += RealTime.deltaTime) {
			Debug.Log(RealTime.deltaTime);
						yield return 0;
				}
	}
}
