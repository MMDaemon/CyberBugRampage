using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{

	public Collider RightHandCollider;
	public Collider LeftHandCollider;

	private Animator _animator;
	private float _hitTimer = 0;

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
			StartAttack();
		}
		else if (!_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.Hit"))
		{
			FinishAttack();
		}
		if(_hitTimer <= 0)
		{
			_animator.SetBool("Hit", false);
		}
		else
		{
			_hitTimer -= Time.deltaTime;
		}
	}

	private void StartAttack()
	{
		GetComponent<PlayerAttributes>().ResetRecoveryTimer();
		_hitTimer = 0.3f;
		_animator.SetBool("Hit", true);
		RightHandCollider.enabled = true;
		LeftHandCollider.enabled = true;
	}

	private void FinishAttack()
	{
		RightHandCollider.enabled = false;
		LeftHandCollider.enabled = false;
	}
}
