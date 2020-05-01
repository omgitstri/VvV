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
	private Animator animator = null;

	/// Enemy switch variables
	public enum MoveState
	{
		Walk,
		Crawl,
		Run,
		Idle,
        Hurt,
        Dead
	};
	public MoveState currentMoveState;

	///  Enemy movement variables
	[SerializeField]
	private float speed = 1f;
	private NavMeshAgent navMesh;
    [SerializeField]private AudioSource audioSource = null;
    private SoundFX sfx = null;
	 // On frame
	void Awake()
	{
		/// Enemy level
		eStats = transform.root.GetComponent<EnemyStatsContainer>().eStats;
		
		///  NavMesh component
		navMesh = GetComponent<NavMeshAgent>();

		animator = GetComponent<Animator>();
        sfx = GetComponent<SoundFX>();
	}

	void Start()
	{
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
            case MoveState.Hurt:
                EnemyHurt();
                break;
            case MoveState.Dead:
                EnemyDead();
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

        if (audioSource != null) {
            //sfx.PlaySound(audioSource, Toolbox.GetInstance.GetSound().eStep, true);
            sfx.LoopSound(audioSource, Toolbox.GetInstance.GetSound().eStep);
        }
    }

	public  void EnemyCrawl()
	{
		speed = eStats.crawlSpd;
		animator.SetBool("isCrawling", true);
        sfx.LoopSound(audioSource, Toolbox.GetInstance.GetSound().eCrawl);

    }

	public  void EnemyRun()
	{
		speed = eStats.moveSpd * 2;
	}

	public  void EnemyIdle()
	{
		speed = 0; /* eStats.moveSpd; */
        sfx.StopSound(audioSource);
	}

    public void EnemyHurt() {
        speed = 0;
    }

    public void EnemyDead() {
        speed = 0;
        sfx.StopSound(audioSource);
    }

	#endregion		<-- BOTTOM

	#endregion		<-- BOTTOM

	public void ActivateCrawl()
	{
		currentMoveState = MoveState.Crawl;
        eStats.isCrawling = true;
	}

	public void DeactivateCrawl()
	{
		currentMoveState = MoveState.Walk;
        eStats.isCrawling = false;
	}

    public void EnemyDied()
    {
        currentMoveState = MoveState.Dead;
    }
}