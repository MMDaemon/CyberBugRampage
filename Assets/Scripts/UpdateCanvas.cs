using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateCanvas : MonoBehaviour
{
	private PlayerAttributes _playerAttributes;
	private float _maxHp;
	private float _maxEnergy;
	private float _recoveryWait;
	private float _energyTimer;

	public Slider HpSlider;                                 // Reference to the UI's health bar.
	public Slider EnergySlider;                                 // Reference to the UI's energy bar.
	public Slider HpRegenSlider;                                // Referene to the UI's health regen bar.

	public Image DamageImage;                                   // Reference to an image to flash on the screen on being hurt.

	private readonly float _flashSpeed = 1f;                               // The speed the damageImage will fade at.
	private readonly Color _hpColour = new Color(1f, 0f, 0f, 0.3f);     // The colour the damageImage is set to, to red.
	private readonly Color _energyColour = new Color(0f, 0f, 1f, 0.3f);     // The colour the damageImage is set to, to blue.

	private bool _damaged;                                               // True when the player gets damaged.
	private bool _lowEnergy;                                               // True when the player is on low energy.
	private bool _extemeLow;

	void Start()
	{
		_playerAttributes = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>();
		_playerAttributes.DamageDealt += DamageDealt;
		_maxHp = _playerAttributes.MaxHp;
		_maxEnergy = _playerAttributes.MaxEnergy;
		_recoveryWait = _playerAttributes.RecoveryWait;
		HpSlider.maxValue = _maxHp;
		EnergySlider.maxValue = _maxEnergy - 50;
		HpRegenSlider.maxValue = _recoveryWait;
	}

	private void DamageDealt(object sender, EventArgs eventArgs)
	{
		_damaged = true;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		HpSlider.value = _playerAttributes.HP; ;
		EnergySlider.value = _playerAttributes.Energy;
		HpRegenSlider.value = _playerAttributes.RecoveryTimer;
		if (_playerAttributes.Energy <= 50 && _playerAttributes.Energy > 25)
		{
			_lowEnergy = true;
			_extemeLow = false;
		}
		else if (_playerAttributes.Energy <= 25)
		{
			_lowEnergy = true;
			_extemeLow = true;
		}
		else _lowEnergy = false;
		DamageImage.color = _damaged ? _hpColour : Color.Lerp(DamageImage.color, Color.clear, _flashSpeed * Time.deltaTime);
		if (_energyTimer == 0)
		{
			DamageImage.color = _lowEnergy ? _energyColour : Color.Lerp(DamageImage.color, Color.clear, _flashSpeed * Time.deltaTime);
			if (_extemeLow == true) _energyTimer = 30;
			else _energyTimer = 60;
		}
		else _energyTimer -= 1;


		// Reset the damaged flag.
		_lowEnergy = false;
		_damaged = false;
	}
}
