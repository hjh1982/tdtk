using UnityEngine;
using System.Collections;

namespace engine
{
	//TODO:没有实现，现在只是简单的new
    public class ObjectPool
    {
        static public GameObject GetEnemy(GameObject parent, GameObject prefab, Vector3 position)
        {
			//position = new Vector3 (0.05f, 0.05f);
            GameObject go = (GameObject)GameObject.Instantiate(prefab);
			setPosition (parent, go, position);

			return go;
        }

		static void setPosition(GameObject parent, GameObject go, Vector3 position)
		{
			if (go != null && parent != null)
			{
				Transform t = go.transform;
				t.parent = parent.transform;
				t.localPosition = position;
				t.localRotation = Quaternion.identity;
				t.localScale = Vector3.one;
				go.layer = parent.layer;
			}
		}
    }
}
