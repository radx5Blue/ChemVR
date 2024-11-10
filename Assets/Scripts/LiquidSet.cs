using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;

public class LiquidSet : MonoBehaviour
{

    public LiquidVolume solution;
    public float level = -1;
    public float startlevel = 0.001f;
    public float endlevel = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        solution.level = level;
    }

    // Update is called once per frame
    void Update()
    {

        if (solution.level <= startlevel)
        {
           solution.gameObject.SetActive(false);


        } else if (solution.level > endlevel)
        {
            solution.gameObject.SetActive(true);

        }


        

     
        
    }
}
