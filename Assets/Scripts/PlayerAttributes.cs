using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{

	public int MaxHp = 100;
	public float MaxEnergy = 250;
	public float EnergyDrainSpeed = 10;
	public Text HpText;
	public Text EnergyText;

	public int HP { get; private set; }
	public float Energy { get; private set; }

	// Use this for initialization
	void Start()
	{
		HP = MaxHp;
		Energy = MaxEnergy;
		UpdateTexts();
	}

	// Update is called once per frame
	void Update()
	{
		Energy -= Time.deltaTime * EnergyDrainSpeed;
		if (Energy <= 0 || HP <=0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
		}
		UpdateTexts();
	}

	public bool AddEnergy(float amount)
	{
		if (Energy+amount <= MaxEnergy)
		{
			Energy += amount;
			return true;
		}
		else return false;

	}

	public void DealDamage(int amount)
	{
		HP += amount;
	}

	private void UpdateTexts()
	{
		HpText.text = "HP: " + HP;
		EnergyText.text = "Energy: " + (int)Energy;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag.Equals("Enemy"))
		{
			HP -= 10;
		}
	}
}
