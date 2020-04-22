using UnityEngine;
using UnityEngine.AI;

/// <summary>
///      Enemy movement: switch statement, functions & variables
/// </summary>

public class EnemyMovementState : MonoBehaviour
{
	// Variables
	/// Handler reference
    private EnemyStats eStats;
	[SerializeField] private float currentLevel = 0;
	[SerializeField] private float nextLevel = 0;
	private Animator animator = null;

	/// Enemy switch variables
	public enum MoveState
	{
		Walk,
		Crawl,
		Run,
		Idle
	};
	public MoveState currentMoveState;

	///  Enemy movement variables
	[SerializeField]
	private float speed = 1f;
	private NavMeshAgent navMesh;

	 // On frame
	void Awake()
	{
		/// Enemy level
		eStats = transform.root.GetComponent<EnemyStatsContainer>().eStats;
		
		///  NavMesh component
		navMesh = GetComponent<NavMeshAgent>();

		animator = GetComponent<Animator>();
	}

	void Start()
	{
		nextLevel = eStats.moveSpd;

		currentMoveState = MoveState.Walk;

	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Comma))
		{
			DeactivateCrawl();
		}
		MoveStateSwitch();
		navMesh.speed = speed;
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
		speed = eStats.moveSpd;
		animator.SetBool("isCrawling", false);

	}

	public  void EnemyCrawl()
	{
		speed = eStats.crawlSpd;
		animator.SetBool("isCrawling", true);

	}

	public  void EnemyRun()
	{
		speed = eStats.moveSpd * 2;
	}

	public  void EnemyIdle()
	{
		speed = 0; /* eStats.moveSpd; */

	}

	#endregion		<-- BOTTOM

	#endregion		<-- BOTTOM

	public void ActivateCrawl()
	{
		currentMoveState = MoveState.Crawl;
	}

	public void DeactivateCrawl()
	{
		currentMoveState = MoveState.Walk;
	}
}