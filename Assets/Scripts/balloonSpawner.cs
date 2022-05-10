using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        Instantiate(balloonPrefab, transform.position, transform.rotation);
    }
}
