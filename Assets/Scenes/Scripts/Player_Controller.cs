using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Controller : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody _rigidbody;

    [SerializeField] private float _speed = 3.5f;
    [SerializeField] private float JumpForce = 5f;
    [SerializeField] private Transform OnGroundCheker;
    [SerializeField] private float OnGroundCheckDistance = 0.1f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float fallMultiplier = 2.5f;

    [SerializeField] private AudioClip[] footsteps;
    AudioSource playerAudio;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        Run();
        Jump();
        MoveInput();
        ModifyGravity();
    }
    // Не помню зачем но надо
    Vector3 directionVector;
    public void FixedUpdate()
    {
        // Отдельная переменная с векторами где координата Y не зануляется
        Vector3 MoveDir = Vector3.ClampMagnitude(directionVector, 1) * _speed;

        // Ходьба
        _rigidbody.velocity = new Vector3(MoveDir.x,_rigidbody.velocity.y, MoveDir.z);
    }


    private void MoveInput()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = 6f;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = 3.5f;
        }

        // Получаем направление движения относительно камеры
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0f;
        cameraRight.y = 0f;
        cameraForward.Normalize();
        cameraRight.Normalize();

        directionVector = cameraForward * V + cameraRight * H;

        if (directionVector != Vector3.zero)
        {
            _animator.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 1).magnitude);
            Quaternion targetRotation = Quaternion.LookRotation(directionVector, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }
        else
        {
            _animator.SetFloat("Speed", Vector3.ClampMagnitude(directionVector, 0).magnitude);
        }

    }

   

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseGravity();
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        }
    }
    private void UseGravity()
    {
        // Проверка длины луча
        if (Physics.Raycast(OnGroundCheker.position, Vector3.down, out RaycastHit hitInfo, OnGroundCheckDistance))
        {
            JumpForce = 5f;
        }
        else
        {
            JumpForce = 0f;
        }
    }


    private void ModifyGravity()
    {
        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    private void Run() 
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _speed = 6f;
            _animator.SetBool("Run",true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            _speed = 3.5f;
            _animator.SetBool("Run", false);
        }
    }

    // Метод для синхронизации звуков шагов. Вызывается только в самой анимации - на ней нужно ключи ставить.
    void FootStep() 
    {
        int randInd = Random.Range(0, footsteps.Length);
        playerAudio.PlayOneShot(footsteps[randInd]);
    }


}
