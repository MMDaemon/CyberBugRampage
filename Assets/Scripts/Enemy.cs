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

	private Animator _animator;
	private Rigidbody _rigidbody;
	private SpawnerMaster _spawnerMaster;
	float _health;
	public Melee _playerMelee;
	public Transform _playerTransform;
	bool _hitLeft = true;

	// Use this for initialization
	void Start()
	{
		_animator = GetComponent<Animator>();
		_rigidbody = GetComponent<Rigidbody>();
		_spawnerMaster = GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>();
		_playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		_playerMelee = GameObject.FindGameObjectWithTag("Player").GetComponent<Melee>();
		_health = MaxHealth;
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("MeleeCollider")&&_hitLeft)
		{
			_hitLeft = false;
			_animator.SetTrigger("Damaged");
			DealDamage(_playerMelee.AttackDamage);
			if (_health <= 0)
			{
				Die();
			}
		}

		if (collider.tag.Equals("PulseSphere"))
		{
			_animator.SetTrigger("Stunned");
			_rigidbody.AddForce(Vector3.Normalize(_playerTransform.position - transform.position)*1000);
		}
	}

	void FixedUpdate()
	{
		if (!_playerMelee.Hitting)
		{
			_hitLeft = true;
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
