using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public Animator animator;
    //Directionnal mputs
    private float horizontalInput; 
    private float forwardInput;
    private Vector2 mouseAxis;
    private float sensitivity = .5f;
    public float speedRotation = 5f;

    //Speed
    public float speed = 4f;
    public float runSpeed;

    //Jump inputs
    public float jumpForce = 10f;
    public float jumpCooldown = 1.0f;
    private float nextJumpTime;

    //Attacks
    public float attackCooldown = 5f;
    public bool _isAttacking = false;
    private float currentCooldown;
   

    [SerializeField]
    private bool _isAlive = true;
    [SerializeField]
    private bool _isGrounded = true;
    [SerializeField]
    private bool _isRunning = false;

    private bool _isJumping;

    private Rigidbody playerRigidbody;



    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        nextJumpTime = Time.time;
    }


    void Update()
    {
        //get movement input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        mouseAxis.x += Input.GetAxis("Mouse X") * sensitivity;
        mouseAxis.y += Input.GetAxis("Mouse Y") * sensitivity;
        animator.SetFloat("Vertical", forwardInput);
        animator.SetFloat("Horizontal", horizontalInput);

        if (_isAlive)
        {
            //Movements
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
             transform.localRotation = Quaternion.Euler(0, mouseAxis.x, 0);

            //Jumps
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded && Time.time >= nextJumpTime)
            {
                Jump();
            }

            if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextJumpTime && _isGrounded && animator.GetBool("Running") == true) {
                Jump();
            }

            //Running fast
            if (Input.GetKey(KeyCode.LeftShift) && forwardInput > 0) 
            {
                runSpeed = 10;
                speed = runSpeed;
                _isRunning = true;
                animator.SetBool("Running", this._isRunning);
            }
            else {
                runSpeed = 4;
                speed = runSpeed;
                _isRunning = false;
                animator.SetBool("Running", this._isRunning);
            }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Attack();
                    _isAttacking = true;
                    this.animator.SetBool("Attack", this._isAttacking);
                 }
                if (animator.GetBool("Attack") == true)
                {
                    currentCooldown -= Time.deltaTime;
                }
                if (currentCooldown <= 0)
                {
                    currentCooldown = attackCooldown;
                    _isAttacking = false;
                    this.animator.SetBool("Attack", this._isAttacking);
                }
            
        }
    }
    //Jump function
    private void Jump()
    {
        _isJumping = true;
        this.animator.SetBool("Jump", this._isJumping);
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _isGrounded = false;
        nextJumpTime = Time.time + jumpCooldown;
    }
    //Detect if the colision object is the terrain
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) {
            _isGrounded = true;
            _isJumping = false;
            this.animator.SetBool("Jump", this._isJumping);
        }
    }
    //Attack function
    public void Attack()
    {
       // _isAttacking = true;
       // this.animator.SetBool("Attack", this._isAttacking);
       
        animator.SetTrigger("SwordAttack");

    }
}
