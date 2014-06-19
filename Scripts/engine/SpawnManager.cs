using UnityEngine;
using System.Collections;

namespace engine
{
    /// <summary>
    /// 现在只支持有限模式
    /// </summary>
    public class SpawnManager : MonoBehaviour
    {
        static public SpawnManager spawnManager;
        public Wave[] waves;

        int currentWave = 0;
	
		/// <summary>
		/// 返回是否可以产卵
		/// </summary>
        public bool Spawn()
        {
            if (GameControl.gameState != GameState.Ended)
            {
                if ((currentWave != 0) && (currentWave >= waves.Length - 1))
                {
                    GameControl.ShowDebugMessage("All waves has been spawned");
                    return false;
                }
                else
                {
                    if (currentWave == 0)
                    {
                        GameControl.gameState = GameState.Started;
                        GameControl.ShowDebugMessage("Game Started");
                    }

                    StartCoroutine(CoroutineSpawnWave());
                    return true;
                }
            }

            return false;
        }

        IEnumerator CoroutineSpawnWave()
        {
			Wave wave;

            while ((currentWave < waves.Length) && (GameControl.gameState != GameState.Ended))
            {
				wave = waves[currentWave];

				yield return StartCoroutine(TimeUtil.Wait(wave.interval));
				StartCoroutine(CoroutineSpawnCreep(wave));
				currentWave++;
            }
        }

		IEnumerator CoroutineSpawnCreep(Wave wave)
		{
			GameControl.ShowDebugMessage("wave:" + wave.id);
			foreach (UnitCreep creep in wave.creeps) 
			{
				yield return StartCoroutine(TimeUtil.Wait(creep.interval));
				GameControl.ShowDebugMessage(wave.id + ":" + creep.id);
				SpawnUnitCreep(wave.id, creep);
			}
        }

		void SpawnUnitCreep(int waveId, UnitCreep creep)
		{
            Vector3 position = creep.path.waypoints[0];
			GameObject go = ObjectPool.GetEnemy(transform.parent.gameObject, creep.prefab, position);
			go.name = creep.prefab.name + "_" + waveId + "_" + creep.id;

			PathFinder finder = go.GetComponent<PathFinder> ();
			if (finder != null) {
				finder.path = creep.path;
			}
		}

        // Use this for initialization
        void Awake()
        {
            spawnManager = this;
        }

		void Start()
		{
			Spawn ();
		}

        // Update is called once per frame
        void Update()
        {

        }
    }
}
