using UnityEngine;
using UnityEngine.AI;

/// <summary>
///      Enemy movement: switch statement, functions & variables
/// </summary>

public class EnemyMovementState : MonoBehaviour
{
	// Variables
	///  Enemy switch variables
	public enum MoveState
	{
		Walk,
		Crawl,
		Run,
		Idle
	};
	public MoveState currentMoveState;

	///  Enemy movement variables
	public float speed = 1f;
	private NavMeshAgent navMesh;


	// On frame
	void Start()
	{
		#region		<-- TOP

		currentMoveState = MoveState.Walk;

		///  NavMesh component
		navMesh = GetComponent<NavMeshAgent>();

		#endregion		<-- BOTTOM
	}


	void Update()
	{
		#region		<-- TOP

		navMesh.speed = speed;

		#endregion		<-- BOTTOM

		MoveStateSwitch();
	}

	// Switch statement
	#region		<-- TOP

	///  Switch statement
	#region		<-- TOP

	public void MoveStateSwitch()
	{
		switch (currentMoveState)
		{
			case MoveState.Walk:
				EnemyWalk();
				break;
			case MoveState.Crawl:
				EnemyCrawl();
				break;
			case MoveState.Run:
				EnemyRun();
				break;
			case MoveState.Idle:
				EnemyIdle();
				break;
			default:
				break;
		}
	}
	#endregion		<-- BOTTOM


	///  Switch statement functions
	#region		<-- TOP

	public void EnemyWalk()
	{
		speed = 3.0f;
	}

	public  void EnemyCrawl()
	{
		speed = 5f;
	}

	public  void EnemyRun()
	{
		speed = 10f;
	}

	public  void EnemyIdle()
	{
		speed = 0.0f;
	}

	#endregion		<-- BOTTOM

	#endregion		<-- BOTTOM

}