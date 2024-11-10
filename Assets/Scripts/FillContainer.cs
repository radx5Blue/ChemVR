using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;

public class FillContainer : MonoBehaviour
{

    public LiquidVolume solution;
    public bool firstHit = false;
    public float newLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //solution.level = newLevel;
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "fillingSphere")
        {

            if (firstHit == false && solution.gameObject.activeSelf == false)
            {
                solution.gameObject.SetActive(true);

            } else
            {
                if (newLevel < 0.15)
                {
                    newLevel += 0.0004f;
                    solution.level = newLevel;
                }
            }

            Destroy(other.gameObject);
            
        }
    }
}
