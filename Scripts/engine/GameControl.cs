using UnityEngine;
using System.Collections;

namespace engine
{
    public class GameControl : MonoBehaviour
    {
        static public GameState gameState;
        static public bool bShowDebug = true;

        static public void ShowDebugMessage(string message)
        {
            if (bShowDebug)
            {
				Debug.Log(message);
            }
        }

        // Use this for initialization
        void Awake()
        {
            gameState = GameState.Idle;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
