using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{

	public Collider RightHandCollider;
	public Collider LeftHandCollider;

	private Animator _animator;
	private float _hitTimer = 0;
	private bool blocking = false;

	// Use this for initialization
	void Start ()
	{
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
		_hitTimer = 0.3f;
		_animator.SetBool(buttonName, true);
	}

	private void EvaluateHitTimer()
	{
		if (_hitTimer <= 0)
		{
			_animator.SetBool("Fire1", false);
			_animator.SetBool("Fire2", false);
		}
		else
		{
			_hitTimer -= Time.deltaTime;
		}
	}

	private void EvaluateAnimations()
	{
		LeftHandCollider.enabled = false;
		RightHandCollider.enabled = false;
		if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.LightHit"))
		{
			RightHandCollider.enabled = true;
		}
		if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.LightHit2"))
		{
			LeftHandCollider.enabled = true;
		}
	}
}
