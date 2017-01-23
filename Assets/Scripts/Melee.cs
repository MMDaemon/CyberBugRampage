using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Melee : MonoBehaviour
{

	public Collider RightHandCollider;
	public Collider LeftHandCollider;
	public Animation PulseSphereAnimation;
	public Animation DamageSphereAnimation;
	public float LightAttackDamage = 10;

	private Animator _animator;
	private Dictionary<string,float> _hitTimer;
	private bool _hitting = false;
	private float _currentAttackDamage = 0;
	private string _beforeAttack = string.Empty;

	// Use this for initialization
	void Start ()
	{
		_hitTimer = new Dictionary<string, float>();
		_hitTimer.Add("Fire1",0);
		_hitTimer.Add("Fire2",0);
		_animator = GetComponent<Animator>();
		RightHandCollider.enabled = false;
		LeftHandCollider.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetButton("Fire1"))
		{
			StartAttack("Fire1");
		}
		if (Input.GetButton("Fire2"))
		{
			StartAttack("Fire2");
		}
		if (Input.GetButton("Block"))
		{
			_animator.SetBool("Block", true);
		}
		else
		{
			_animator.SetBool("Block", false);
		}
		EvaluateHitTimer();
		EvaluateAnimations();
	}

	private void StartAttack(string buttonName)
	{
		GetComponent<PlayerAttributes>().ResetRecoveryTimer();
		_hitTimer[buttonName] = 0.3f;
		_animator.SetBool(buttonName, true);
	}

	private void EvaluateHitTimer()
	{
		if (_hitTimer["Fire1"] <= 0)
		{
			_animator.SetBool("Fire1", false);
		}
		else
		{
			_hitTimer["Fire1"] -= Time.deltaTime;
		}

		if (_hitTimer["Fire2"] <= 0)
		{
			_animator.SetBool("Fire2", false);
		}
		else
		{
			_hitTimer["Fire2"] -= Time.deltaTime;
		}
	}

	private void EvaluateAnimations()
	{
		LeftHandCollider.enabled = false;
		RightHandCollider.enabled = false;
		_hitting = false;
		_currentAttackDamage = 0;

		if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.LightHit"))
		{
			_currentAttackDamage = LightAttackDamage;
			RightHandCollider.enabled = true;
			if (_beforeAttack.Equals("Torso Layer.LightHit"))
			{
				_hitting = true;
			}
			_beforeAttack = "Torso Layer.LightHit";


		}
		else if(_beforeAttack.Equals("Torso Layer.LightHit"))
		{
			_beforeAttack = string.Empty;
		}

		if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.LightHit2"))
		{
			_currentAttackDamage = LightAttackDamage;
			LeftHandCollider.enabled = true;
			_hitting = true;
			if (_beforeAttack.Equals("Torso Layer.LightHit2"))
			{
				_hitting = true;
			}
			_beforeAttack = "Torso Layer.LightHit2";
		}
		else if (_beforeAttack.Equals("Torso Layer.LightHit2"))
		{
			_beforeAttack = string.Empty;
		}

		if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.JumpAttack"))
		{
			_beforeAttack = "Torso Layer.JumpAttack";
		}
		else if (_beforeAttack.Equals("Torso Layer.JumpAttack"))
		{
			_beforeAttack = string.Empty;
			DamageSphereAnimation.Play("Ground Slam");
		}

		if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.BlockingLightHit"))
		{
			PulseSphereAnimation.Play("Puls Sphere Forward");
		}
		if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.BlockingHeavyHit"))
		{
			PulseSphereAnimation.Play("Puls Sphere Expand");
		}
	}

	public bool Hitting
	{
		get { return _hitting; }
	}

	public float AttackDamage
	{
		get { return _currentAttackDamage; }
	}
}
