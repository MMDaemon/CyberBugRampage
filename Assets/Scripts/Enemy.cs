using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{

	public GameObject EnergyOrbPrefab;
	public float Speed = 1;
	public float MaxHealth = 50;
	[Range(0.0f, 1.0f)]
	[SerializeField]
	float Droprate = 0.7f;

	private SpawnerMaster _spawnerMaster;
	float _health;

	// Use this for initialization
	void Start()
	{
		_spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
		_health = MaxHealth;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("MeleeCollider"))
		{
			DealDamage(20);
			if (_health <= 0)
			{
				Die();
			}
		}
	}

	private void DealDamage(float damage)
	{
		_health -= damage;
	}

	private void Die()
	{
		if (Random.Range(0.0f, 1.0f) <= Droprate)
		{
			GameObject energyOrb = _spawnerMaster.PullEnergyOrb();
			energyOrb.transform.position = this.transform.position + Vector3.up;
		}
		_spawnerMaster.PushEnemy(gameObject);
	}
}
