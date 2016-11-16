using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour
{

	public Collider RightHandCollider;

	private Animator _animator;

	// Use this for initialization
	void Start ()
	{
		_animator = GetComponent<Animator>();
		RightHandCollider.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (Input.GetButton("Fire1"))
		{
			StartAttack();
		}
		else if (!_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.Slap"))
		{
			FinishAttack();
		}
		else
		{
			_animator.SetBool("Hit", false);
		}
	}

	private void StartAttack()
	{
		GetComponent<PlayerAttributes>().ResetRecoveryTimer();
		_animator.SetBool("Hit", true);
		RightHandCollider.enabled = true;
	}

	private void FinishAttack()
	{
		RightHandCollider.enabled = false;
	}
}
