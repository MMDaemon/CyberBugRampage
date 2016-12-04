using UnityEngine;
using System.Collections;

public class MeleeEnemy : MonoBehaviour
{

	public Collider RightHandCollider;
	public float MinAttackDistance;

	private Animator _animator;
	private bool _attacking;
	private Transform player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		_animator = GetComponent<Animator>();
		RightHandCollider.enabled = false;
		_attacking = false;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!_attacking && Vector2.Distance(transform.position, player.position)<MinAttackDistance)
		{
			StartAttack();
		}
		else if (!_animator.GetCurrentAnimatorStateInfo(1).IsName("Torso Layer.Hit"))
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
		_attacking = true;
		_animator.SetBool("Hit", true);
		RightHandCollider.enabled = true;
	}

	private void FinishAttack()
	{
		_attacking = false;
		RightHandCollider.enabled = false;
	}
}
