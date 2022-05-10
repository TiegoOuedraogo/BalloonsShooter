using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] AudioClip shootSound;
    private AudioSource src;
    // Start is called before the first frame update
    void Start()
    {
        src = GetComponent<AudioSource>();

    }

    public void PlaySound()
    {
        src.PlayOneShot(shootSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
