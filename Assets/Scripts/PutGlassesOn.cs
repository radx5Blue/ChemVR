using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PutGlassesOn : MonoBehaviour
{

    public GameObject glasses;
    public GameObject glassUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "glasses")
        {

            Destroy(glasses.GetComponent<XRGrabInteractable>());

            glasses.SetActive(false);

           

            glassUI.SetActive(true);


        }


    }


}
