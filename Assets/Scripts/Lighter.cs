using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{

    //public float speed = 40;
    public GameObject fireParticle;
    //public Transform firePoint;
    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FireLight()
    {

        audioSource.PlayOneShot(audioClip);
        fireParticle.SetActive(true);

    }

    public void FireOut()
    {
        fireParticle.SetActive(false);
    }

}
