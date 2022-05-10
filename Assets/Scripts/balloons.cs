using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class balloons : MonoBehaviour
{
    [SerializeField] UIManager UIMngr;
    //private Rigidbody2D balloonRB;
    SoundManager soundManager;

    public bool isMovingUp = true;
    public float speed = 500;
    public float growRate = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        //balloonRB = GetComponent<Rigidbody2D>();

        InvokeRepeating("Grow", 1f, growRate);
    }

    private void Update()
    {
        if (Time.timeScale == 0) return;
        transform.Translate(new Vector3(0, (isMovingUp ? 1 : -1) * speed, 0));

        if (transform.localScale.x > 3)
        {
            soundManager.PlaySound();
            UIMngr.LoadSceneCurrent();
            Destroy(this.gameObject);
        }
    }

    void Grow()
    {
        transform.localScale =
            new Vector3(transform.localScale.x + 0.1f,
            transform.localScale.y + 0.1f,
            transform.localScale.z);
    }

    public bool justTouched = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("arrow"))
        {
            UIMngr.AddScore(getScore());
            UIMngr.LoadScene();
            soundManager.PlaySound();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !justTouched)
        {
            moveAround();
            justTouched = true;
            Invoke("changeJustChanged", 0.3f);
        }
    }


    void moveAround()
    {
        isMovingUp = !isMovingUp;
    }

    int getScore()
    {
        return transform.localScale.x < 1.5 ? 3 : transform.localScale.x < 2 ? 2 : 1;
    }

    void changeJustChanged()
    {
        justTouched = !justTouched;
    }
}
