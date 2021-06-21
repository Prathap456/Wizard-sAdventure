using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private CapsuleCollider2D caps;
    
    private Animator anim;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpSpeed;
    private bool Dash;
    [SerializeField]
    private LayerMask FloorlayerMask;   
    [SerializeField]
    public SoundsAndVfx musicSource;
    private TrailRenderer tr;
    private bool isRight=true;

    public Transform firePosition;
    public GameObject projectile;

    public int score;

    


    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        caps = GetComponent<CapsuleCollider2D>();
        tr = GetComponent<TrailRenderer>();
        
        
    }

    // Update is called once per frame
    private void Update()
    { 

        float horizontal = Input.GetAxis("Horizontal");

        Movement(horizontal);
        Attack();
        Jump();
        
     
    }

    void FixedUpdate()
    {
        
        Dashing();
        
    }

    private void Movement(float horizontal)
    {
        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            rb.velocity = new Vector2(horizontal * playerSpeed, rb.velocity.y);

           
            if (horizontal < 0)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
               // sr.flipX = true;
                isRight = false;

                
            }
            else if (horizontal > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
               // sr.flipX = false;
                isRight = true;
                
            }
        }
        
        anim.SetFloat("speed", Mathf.Abs(horizontal));
    }


    private void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Dash"))
        {

            anim.SetTrigger("dash");
            if(!isRight)
            {
                rb.velocity = new Vector2(-300, 0);


            }
            else if (isRight)
            {
                rb.velocity = new Vector2(300, 0);

            }
            
            musicSource.Play("dash");
            
        }
        
    }



    public void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            
            Instantiate(projectile, firePosition.position, firePosition.rotation);
        }
    }

    private bool Isgrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(caps.bounds.center, caps.bounds.size, 0f, Vector2.down, .1f, FloorlayerMask);
        //BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, FloorlayerMask);
        //CapsuleCast(Vector2.down, Vector2., CapsuleDirection2D.Vertical, 0, Vector2.down);

        // if (raycastHit2D.collider != null)
        return raycastHit2D.collider != null;
        
        
    }

    private void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)) && Isgrounded())
        {

            //rb.velocity = Vector2.up * jumpSpeed;
            rb.AddForce(new Vector2(0, jumpSpeed),ForceMode2D.Impulse);
            anim.SetTrigger("jump");
           

            musicSource.Play("jump");       // //FindObjectOfType<SoundsAndVfx>().Play("jump");
        }
        if (!Isgrounded())
        {
            //anim.SetLayerWeight(1, 1);
            anim.SetBool("isGrounded", false);
        }
        else
        {
            anim.SetBool("isGrounded", true);
            //anim.SetLayerWeight(1, 0);
           // anim.ResetTrigger("jump");
            anim.SetBool("landing", false);
        }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("landing", true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.tag == "Coin")
        {
            score++;
            musicSource.Play("collected");
            
        }
    }

}
