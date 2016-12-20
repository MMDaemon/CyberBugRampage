using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{

	public float MaxHp = 100;
	public float MaxEnergy = 250;
	public float EnergyDrainSpeed = 10;
	public float MinEnergyToRecover = 50;
	public float RecoveryWait = 5;
	public float RecoverySpeed = 5;
	public float EnergyOnRecoveryMultiplier = 1;
	public float MinHeight = -5;
	public float RecoveryTimer = 0;
	[Range(0.0f, 1.0f)]
	[SerializeField]
	float BlockAbsorption = 0.7f;

	public float HP { get; private set; }
	public float Energy { get; private set; }

	private Vector3 _spawnPos;
	private Animator _animator;

	public EventHandler DamageDealt;

	private void OnDamageDealt()
	{
		DamageDealt.Invoke(this, new EventArgs());
	}

	// Use this for initialization
	void Start()
	{
		HP = MaxHp;
		Energy = MaxEnergy;
		_spawnPos = transform.position;
		_animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		CheckRecovery();
		Energy -= Time.deltaTime * EnergyDrainSpeed;
		if (Energy < 0)
		{
			Energy = 0;
		}
		if (HP < 0)
		{
			HP = 0;
		}
		if (Energy <= 0 || HP <= 0)
		{
			GameOver();
		}
		if (transform.position.y < MinHeight)
		{
			transform.position = _spawnPos;
		}
	}

	public bool CanCollectOrb(float energyAmount)
	{
		return Energy + energyAmount <= MaxEnergy;
	}

	public bool AddEnergy(float amount)
	{
		if (Energy + amount <= MaxEnergy)
		{
			Energy += amount;
			return true;
		}
		else return false;

	}

	public void ResetRecoveryTimer()
	{
		RecoveryTimer = 0;
	}

	public void DealDamage(float amount)
	{
		if (amount > 0)
		{
			if (!_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.Blocking"))
			{
				HP -= amount;
				ResetRecoveryTimer();
				OnDamageDealt();
			}else
			{
				HP -= (1-BlockAbsorption)*amount;
				OnDamageDealt();
			}
		}
	}

	private void CheckRecovery()
	{
		if (HP < MaxHp)
		{
			RecoveryTimer += Time.deltaTime;
			if (RecoveryTimer >= RecoveryWait && Energy > MinEnergyToRecover)
			{
				float healthGain = Time.deltaTime * RecoverySpeed;
				float healthNeed = MaxHp - HP;
				if (healthGain > healthNeed)
				{
					healthGain = healthNeed;
				}

				HP += healthGain;
				Energy -= healthGain = EnergyOnRecoveryMultiplier;
			}
		}
		else
		{
			RecoveryTimer = 0;
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.tag.Equals("EnemyMeleeCollider"))
		{
			DealDamage(collider.gameObject.GetComponent<EnemyHandCollider>().GetDamage());
		}
	}

	private void GameOver()
	{
		GameObject.FindGameObjectWithTag("SpawnerMaster").GetComponent<SpawnerMaster>().ResetPools();
		GameObject.FindGameObjectWithTag("Score").GetComponent<Score>().Stop();
		SceneManager.LoadScene("GameOver");
	}
}
