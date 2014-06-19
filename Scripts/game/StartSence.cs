using UnityEngine;
using System.Collections;

namespace com.sences
{
    public class StartSence : MonoBehaviour
    {
        void Awake()
        {
            //定义按钮事件
            GameObject startBtn = GameObject.Find("StartButton");
            UIEventListener.Get(startBtn).onClick = OnButtonClick;
        }
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnButtonClick(GameObject button)
        {
            Application.LoadLevel("Map");
        }
    }
}
