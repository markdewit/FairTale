using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D myBody;
    private Animator anim;

    public Transform GroundCheckPosition;
    public LayerMask GroundLayer;

    private bool isGrounded;
    private bool jump;

    private float jumpPower = 5f;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGrounded();
        PlayerJump();
        //if (Physics2D.Raycast(GroundCheckPosition.position, Vector2.down, 0.5F, GrounsLayer))
        //{
        //    print("hit the bottom");
        //}

    }

    void FixedUpdate()
    {
        PlayerWalk();

    }
    void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h > 0)
        {
            myBody.velocity = new Vector2(speed, myBody.velocity.y);
            ChangeDirection(1);
        }
        else if (h < 0)
        {
            myBody.velocity = new Vector2(-speed, myBody.velocity.y);
            ChangeDirection(-1);
        }
        else
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }


        anim.SetInteger("Speed", Mathf.Abs((int)myBody.velocity.x));


    }

    void ChangeDirection(float direction)
    {
        if (direction == 1)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y);
        }
        else
        {
            this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y);
        }
        
    }

    void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(GroundCheckPosition.position, Vector2.down, 0.1f, GroundLayer);

        //if (isGrounded && jump)
        //{
        //    jump = false;

        //    anim.SetBool("Jump", false);
        //}
    }

    void PlayerJump()
    {
        //if (isGrounded)
        //{
        //    if (Input.GetKey(KeyCode.Space))
        //    {
        //        jump = true;
        //        myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
        //        anim.SetBool("Jump", true);
        //    }
        //}
    }
}
