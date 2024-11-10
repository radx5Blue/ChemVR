using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.SceneManagement;

public class HandPresence : MonoBehaviour
{
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDevice;
    public GameObject spawnedController; 

    public GameObject handModelPrefab;

    private GameObject spawnHandModel;


    private Animator handAnimator;

    // Start is called before the first frame update
    void Start()
    {

        TryInitialize();




    }

    void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }

    }

    void TryInitialize()
    {

        List<InputDevice> devices = new List<InputDevice>();
        // InputDeviceCharacteristics rightControllerCharacteristic = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + " " + item.characteristics);

        }


        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name);
            if (prefab)
            {
                spawnedController = Instantiate(prefab, transform);
            }
            else
            {
                Debug.LogError("Controller not found!");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            spawnHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnHandModel.GetComponent<Animator>();

        }

    }

    // Update is called once per frame
    void Update()
    {

         if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
         {
            SceneManager.LoadScene("lab_1");
        }




        // if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)  && triggerValue > 0.1)
        // {
        //    Debug.Log("Trigger Pressed " + triggerValue);
        //}



        //if(targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue) &&  primary2DAxisValue != Vector2.zero)
        // {
        //    Debug.Log("Primary Touch Pad " + primary2DAxisValue);
        // }

        if (!targetDevice.isValid)
        {
            TryInitialize();

        } 
        else
        {

            if (showController)
            {
                spawnHandModel.SetActive(false);
                spawnedController.SetActive(true);
            }
            else
            {
                spawnHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnimation();
            }


        }



    }
}
