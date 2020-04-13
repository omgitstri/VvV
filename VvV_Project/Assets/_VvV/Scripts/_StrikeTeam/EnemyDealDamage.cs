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
	public float damageDelt = 1;

	///***  Child functions
	///  Damage function
	public override void OnHit(ControllerColliderHit hitting, float damageDelt)
	{
		base.OnHit(hitting, damageDelt);
	}

}