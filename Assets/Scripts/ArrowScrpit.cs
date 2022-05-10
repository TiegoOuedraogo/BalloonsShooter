using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScrpit : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject arrowPrefab;
    [SerializeField] Vector3 arrowForce;
    
    Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootArrow();
        }


    }

    private void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();
        //z axes rotation
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        rigidBody.angularVelocity = -rotateAmount * speed * Time.deltaTime;
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        arrow.GetComponent<Rigidbody2D>().AddRelativeForce(arrowForce);

        Destroy(arrow, 3f);
    }

}
