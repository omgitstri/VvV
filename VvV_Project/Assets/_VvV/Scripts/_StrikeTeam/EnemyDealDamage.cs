using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///	 Base Damager function
/// </summary>

public class EnemyDealDamage : ParentDealDamage
{
	// Variables
	[Header("Child")]
	[Tooltip("Variables not found in the parent class")]
	[SerializeField]
	private float damageVar;


	///***  Child functions
	///  Damage function
	public override void OnHit(ControllerColliderHit hitting, float damageDelt)
	{
		damageDelt = damageVar;
		target = player;
		base.OnHit(hitting, damageDelt);
	}

}