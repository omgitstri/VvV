using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;

    private float applySpeed;

    [SerializeField]
    private float jumpForce;

    private bool isRun = false;
    private bool isGround = true;

    private CapsuleCollider capsuleCollider;

    [SerializeField]
    private float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX = 0;

    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;
    private GunController gunController;

    GameObject gunPrefab;
    GameObject handPrefab;

    public Image aimer;

    bool isNearEnemy = false;

    private AudioSource audioSource;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        capsuleCollider = GetComponent<CapsuleCollider>();
        myRigid = GetComponent<Rigidbody>();
        applySpeed = walkSpeed;
        gunController = FindObjectOfType<GunController>();
        gunPrefab = GameObject.Find("GunHolder");
        handPrefab = GameObject.Find("HandHolder");
        audioSource = GetComponent<AudioSource>();
        handPrefab.SetActive(false);
    }

    void Update()
    {
        IsGround();
        TryJump();
        TryRun();
        Move();
        CameraRotation();
        CharacterRotation();
    }

    private void IsGround()
    {
        isGround = Physics.Raycast(transform.position, Vector3.down, capsuleCollider.bounds.extents.y + 0.1f);
    }


    private void TryJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        myRigid.velocity = transform.up * jumpForce;
    }

    private void TryRun()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !gunController.isFineSightMode)
        {
            Running();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            RunningCancel();
        }
    }

    private void Running()
    {
//        gunController.CancelFineSight();

        isRun = true;
        applySpeed = runSpeed;
    }

    public void RunningCancel()
    {
        isRun = false;
        applySpeed = walkSpeed;
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * applySpeed;

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);

        if(gunController.isFineSightMode || isNearEnemy)
        {
            aimer.enabled = false;
        }
        else
        {
            aimer.enabled = true;
        }

        if((Input.GetButton("Horizontal") || Input.GetButton("Vertical"))&& !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if(Input.GetButtonUp("Horizontal")|| Input.GetButtonUp("Vertical"))
        {
            audioSource.Stop();
        }
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }

    private void CameraRotation()
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy"&& !isNearEnemy)
    //    {
    //        isNearEnemy = true;
    //        gunPrefab.SetActive(false);
    //        handPrefab.SetActive(true);
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Enemy"&& isNearEnemy)
    //    {
    //        isNearEnemy = false;
    //        handPrefab.SetActive(false);
    //        gunPrefab.SetActive(true);
    //    }
    //}
}