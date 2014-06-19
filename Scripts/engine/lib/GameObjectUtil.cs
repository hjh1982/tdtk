using UnityEngine;

namespace engine.lib
{
    /// <summary>
    /// GameObject工具类
    /// </summary>
    static public class GameObjectUtil
    {
        /// <summary>
        /// MonoBehaviour是否激活
        /// </summary>
        /// <param name="mb"></param>
        /// <returns></returns>
        static public bool GetActive(Behaviour mb)
        {
            return mb && mb.enabled && mb.gameObject.activeInHierarchy;
        }

        static public bool GetActive(GameObject go)
        {
            return go && go.activeInHierarchy;
        }
    }
}
