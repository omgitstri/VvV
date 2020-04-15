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
	internal GameObject target;


	///***  Parent functions
	/// Damage function
	public virtual void OnHit(ControllerColliderHit hitting, float damageDelt)
	{
		/// 
		if (hitting.gameObject == target)
		{
            /// Get component
            if(target.TryGetComponent(out Damagable component))
            {
                component.GetDamaged(damageDelt);
            }
		}
	}

}