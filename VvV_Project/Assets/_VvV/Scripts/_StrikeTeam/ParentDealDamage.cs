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
	public GameObject player;   /// Loaded with PlayerWithGun prefab but not used in script)
	public GameObject enemy;


	///***  Parent functions
	/// Damage function
	public virtual void OnHit(ControllerColliderHit hitting, float damageDelt)
	{
		if (hitting.gameObject.tag == player.gameObject.tag)
		{
			if (hitting.gameObject.GetComponent<Damagable>() != null)
			{
				hitting.gameObject.GetComponent<Damagable>().GetDamaged(damageDelt);
			}
		}
	}

}