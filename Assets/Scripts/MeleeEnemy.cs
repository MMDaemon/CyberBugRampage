using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class MeleeEnemy : MonoBehaviour
{

	public Collider RightHandCollider;
	public float MinAttackDistance;

	private Animator _animator;
	private bool _attacking;
	private Transform player;
	private ThirdPersonCharacter _controller;
	private float _stationaryTurnSpeed;
	private float _movingTurnSpeed;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		_controller = gameObject.GetComponent<ThirdPersonCharacter>();
		_stationaryTurnSpeed = _controller.m_StationaryTurnSpeed;
		_movingTurnSpeed = _controller.m_MovingTurnSpeed;
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
		_controller.m_MovingTurnSpeed = 0;
		_controller.m_StationaryTurnSpeed = 0;
	}

	private void FinishAttack()
	{
		_controller.m_MovingTurnSpeed = _movingTurnSpeed;
		_controller.m_StationaryTurnSpeed = _stationaryTurnSpeed;
		_attacking = false;
		RightHandCollider.enabled = false;
	}
}
