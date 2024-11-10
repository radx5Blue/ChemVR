using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;
using UnityEngine.XR.Interaction.Toolkit;

public class BurnerFire : MonoBehaviour
{

    public ParticleSystemRenderer fire;
    public Light fireLight;

    public float gasAmount = 0;

    public bool lightUp = false;

    public GameObject gasTap;

    public AudioSource gasSoundSource;
    public AudioClip gasSound;

    public AudioSource audioSource2;

    public AudioSource audioSource3;

    public AudioSource boiling;

    public LiquidVolume solution;
    public float temp = 20;

    public GameObject steam;
    public GameObject crystals;

    public bool crystalGrow = false;

    public float xz = 0.001f;
    public float y = 0.003f;

    public bool growFinished = false;

    public GameObject copperLeftover;

    public GameObject glass;
    public GameObject fillArea;
    




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gasAmount <= 0)
        {
            lightUp = false;
            fire.gameObject.SetActive(false);


            if (temp > 20)
            {

                temp -= 1 * Time.deltaTime;

            }

        } 
        else if (gasAmount > 0 && lightUp == true)
        {
            fire.gameObject.SetActive(true);
            fire.minParticleSize = gasAmount;
            fire.maxParticleSize = gasAmount;
            fireLight.intensity = gasAmount;

        }

        if (gasTap.transform.eulerAngles.x <= 23f && gasTap.transform.eulerAngles.x >= 0f)
        {

            gasAmount = 0.0f;

            Debug.Log("gas amount: " + gasAmount);

            // audioSource.volume = 0;
            lightUp = false;
            gasSoundSource.Stop();
            audioSource3.Stop();

            if (temp > 20)
            {

                temp -= 1 * Time.deltaTime;

            }


        }


        if (gasTap.transform.eulerAngles.x <= 45f && gasTap.transform.eulerAngles.x >= 23f)
        {

            gasAmount = 0.02f;

            Debug.Log("gas amount: " + gasAmount);

            if (!audioSource3.isPlaying)
            {

                if (!gasSoundSource.isPlaying)
                {
                    gasSoundSource.Play(0);
                }
            }

            if (temp <= 102 && lightUp == true)
            {

                temp += 1f * Time.deltaTime;

            }
            else
            {

                temp -= 1 * Time.deltaTime;

            }


        }

        if (gasTap.transform.eulerAngles.x <= 68f && gasTap.transform.eulerAngles.x >= 45f)
        {

            gasAmount = 0.08f;

            Debug.Log("gas amount: " + gasAmount);

            if (temp <= 102 && lightUp == true)
            {

                temp += 1.5f * Time.deltaTime;

            }
            else
            {

                temp -= 1 * Time.deltaTime;

            }



        }

        if (gasTap.transform.eulerAngles.x <= 90f && gasTap.transform.eulerAngles.x >= 68f)
        {

            gasAmount = 0.1f;

            Debug.Log("gas amount: " + gasAmount);

            if (temp <= 102 && lightUp == true)
            {

                temp += 2f * Time.deltaTime;

            } else
            {

                temp -= 1 * Time.deltaTime;

            }



        }

        if (temp < 40)
        {

            solution.turbulence1 = 0;
            solution.turbulence2 = 0;

            solution.foamColor = new Color(1, 1, 1, 0);

            crystalGrow = false;

            steam.SetActive(false);

        }

            if (temp > 40 && temp < 60)
        {

            solution.turbulence1 = .5f;
            solution.turbulence2 = .2f;

            solution.foamColor = new Color(1, 1, 1, 0.10f);

            crystalGrow = false;

            steam.SetActive(false);

        }

        if (temp > 60 && temp < 70)
        {

            solution.turbulence1 = .8f;
            solution.turbulence2 = .3f;

            solution.foamColor = new Color(1, 1, 1, 0.20f);

            crystalGrow = false;

            steam.SetActive(false);

            if (!boiling.isPlaying && growFinished == false)
            {
                boiling.volume = 0.08f;
                boiling.Play(0);
            }

        }


        if (temp > 70 && temp < 80)
        {

            solution.turbulence1 = 1f;
            solution.turbulence2 = .4f;

            //solution.foamColor = new Color(1, 1, 1, 0.30f);

            crystalGrow = false;

            steam.SetActive(true);

            if (!boiling.isPlaying && growFinished == false)
            {
                boiling.volume = 0.09f;
                //boiling.Play(0);
            }

        }



        if (temp >= 80 && temp < 90)
        {

            solution.turbulence1 = 1f;
            solution.turbulence2 = .5f;

            if (!boiling.isPlaying && growFinished == false)
            {
                boiling.volume = 0.1f;
               // boiling.Play(0);
            }

            //solution.foamColor = new Color(1, 1, 1, 0.45f);

            copperLeftover.SetActive(true);

            crystalGrow = false;

            steam.SetActive(true);

        }


        if (temp >= 90)
        {

            solution.turbulence1 = 1f;
            solution.turbulence2 = .6f;

           // solution.foamColor = new Color(1, 1, 1, 0.65f);

            steam.SetActive(true);

            solution.level -= .01f * Time.deltaTime;
            solution.alpha -= .07f * Time.deltaTime;
            // crystals.transform.localScale = new Vector3(0.01f, 0.03f, 0.01f);

            crystalGrow = true;


        }


        if (temp >= 90 && solution.level < 0.04)
        {


            solution.gameObject.SetActive(false);
            growFinished = true;
            boiling.Stop();
            fillArea.SetActive(false);
            glass.AddComponent<Rigidbody>();
            glass.AddComponent<XRGrabInteractable>();



        }

        if (crystalGrow && growFinished == false)
        {
            crystals.SetActive(true);

            xz += 0.001f * Time.deltaTime;
            y += 0.003f * Time.deltaTime;

            crystals.transform.localScale = new Vector3(xz, y, xz);
        }

        Debug.Log("temp amount: " + temp);



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FireArea" && gasAmount > 0 && lightUp == false)
        {

            lightUp = true;
            gasSoundSource.Stop();
            audioSource2.Play(0);
            audioSource3.Play(0);

        }
    }

}
