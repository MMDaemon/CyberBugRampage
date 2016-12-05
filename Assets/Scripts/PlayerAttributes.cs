using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{

	public float MaxHp = 100;
	public float MaxEnergy = 250;
	public float EnergyDrainSpeed = 10;
	public float RecoveryWait = 5;
	public float RecoverySpeed = 5;

	public float HP { get; private set; }
	public float Energy { get; private set; }

	private float _recoveryTimer = 0;

	// Use this for initialization
	void Start()
	{
		HP = MaxHp;
		Energy = MaxEnergy;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		CheckRecovery();
		Energy -= Time.deltaTime * EnergyDrainSpeed;
		if (Energy <= 0 || HP <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
		}
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
		_recoveryTimer = 0;
	}

	public void DealDamage(float amount)
	{
		HP -= amount;
		ResetRecoveryTimer();
	}

	private void CheckRecovery()
	{
		_recoveryTimer += Time.deltaTime;
		if (_recoveryTimer >= RecoveryWait && HP < MaxHp)
		{
			float healthGain = Time.deltaTime * RecoverySpeed;
			float healthNeed = MaxHp - HP;
			if (healthGain > healthNeed)
			{
				healthGain = healthNeed;
			}

			HP += healthGain;
			Energy -= healthGain;
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag.Equals("EnemyMeleeCollider"))
		{
			DealDamage(10);
		}
	}


}
