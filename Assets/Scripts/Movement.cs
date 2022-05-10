using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 350.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Vector3 arrowForce;

    public UIManager UIManager;
    public float shootRate = 0.3f;
    float nextShoot = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
       speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        nextShoot += Time.deltaTime;
        movement = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;

        if (Input.GetButtonDown("Fire1") && nextShoot > shootRate)
        {
            ShootArrow();
            nextShoot = 0;
        }

    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    {

        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        //rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
        jumpPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    GameObject arrow;
    void ShootArrow()
    {
        arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrow.GetComponent<Rigidbody2D>().AddRelativeForce(arrowForce);

        Invoke("DestroyDelayed", 3f);
    }

    void DestroyDelayed()
    {
        //UIManager.AddScore(-1);
    }

    }
