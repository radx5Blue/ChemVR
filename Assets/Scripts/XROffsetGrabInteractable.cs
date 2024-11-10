using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initalAttachLocalPos;
    private Quaternion initalAttachLocalRot;
    // Start is called before the first frame update
    void Start()
    {

        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initalAttachLocalPos = attachTransform.localPosition;
        initalAttachLocalRot = attachTransform.localRotation;
        
    }

    protected override void OnSelectEntering(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        } else
        {

            attachTransform.localPosition = initalAttachLocalPos;
            attachTransform.localRotation = initalAttachLocalRot;

        }

        base.OnSelectEntering(interactor);
    }


}
