using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///	 Base Damager function
/// </summary>

public class ParentDealDamage : MonoBehaviour
{
	// Variables
	[Header("Parent")]
	[Tooltip("Applies to all children")]
	public GameObject player;   /// should be loaded with PlayerWithGun prefab)
	public GameObject enemy;
	internal GameObject target;
	private float damageDelt;


	///***  Parent functions
	/// Damage function
	public virtual void OnHit(ControllerColliderHit hitting, float damageDelt)
	{
		if (hitting.gameObject == target)
		{
			if (player.GetComponent<Damagable>() != null)
			{
				player.GetComponent<Damagable>().GetDamaged(damageDelt);
			}
		}
	}

}