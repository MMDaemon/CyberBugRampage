using UnityEngine;
using System.Collections;

public class EnemyHandCollider : MonoBehaviour {

	public float Damage = 10;
	public Animator ParentAnimator;

	bool _hitLeft = true;

	public float GetDamage()
	{
		if (_hitLeft)
		{
			_hitLeft = false;
			return Damage;
		}
		else
		{
			return 0;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!ParentAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
		{
			_hitLeft = true;
		}
	}
}
