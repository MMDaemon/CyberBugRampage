using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{

	public int MaxHp;
	public float MaxEnergy;
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
		Energy -= Time.deltaTime;
		UpdateTexts();
	}

	private void UpdateTexts()
	{
		HpText.text = "HP: " + HP;
		EnergyText.text = "Energy: " + (int)Energy;
	}
}
