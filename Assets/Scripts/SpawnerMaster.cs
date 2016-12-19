using UnityEngine;
using System.Linq;

public class SpawnerMaster : MonoBehaviour
{

	public GameObject EnemyPrefab;
	public int EnemyInitialAmount = 500;
	public GameObject EnergyOrbPrefab;
	public int EnergyOrbInitialAmount = 200;
	public bool CreateOnEmptyList = true;

	private ObjectPool _enemyPool;
	private ObjectPool _energyOrbPool;

	private static SpawnerMaster _instance;

	// Use this for initialization
	void Start()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
			AddObectPool(EnemyPrefab, EnemyInitialAmount);
			AddObectPool(EnergyOrbPrefab, EnergyOrbInitialAmount);
			ObjectPool[] objectPools = GetComponents<ObjectPool>();
			_enemyPool = (from objectPool in objectPools
				where objectPool.ObjectPrefab.Equals(EnemyPrefab)
				select objectPool).First();
			_energyOrbPool = (from objectPool in objectPools
				where objectPool.ObjectPrefab.Equals(EnergyOrbPrefab)
				select objectPool).First();
		}
		else
		{
			if (_instance != this)
			{
				Destroy(gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void AddObectPool(GameObject prefab, int initialAmount)
	{
		ObjectPool pool = gameObject.AddComponent<ObjectPool>();
		pool.Init(prefab, initialAmount, CreateOnEmptyList);
	}

	public GameObject PullEnemy()
	{
		return _enemyPool.PullFromPool();
	}

	public void PushEnemy(GameObject enemy)
	{
		_enemyPool.PushToPool(enemy);
	}

	public GameObject PullEnergyOrb()
	{
		return _energyOrbPool.PullFromPool();
	}

	public void PushEnergyOrb(GameObject energyOrb)
	{
		_energyOrbPool.PushToPool(energyOrb);
	}

	public void ResetPools()
	{
		_enemyPool.Reset();
		_energyOrbPool.Reset();
	}
}
