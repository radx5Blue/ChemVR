﻿using UnityEngine;
using UnityEditor;

public class ResetGameObjectPosition
{
    [MenuItem("GameObject/Reset Transform #r")]
    static public void MoveSceneViewCamera()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach (GameObject selected_object in selectedObjects)
        {
            Undo.RegisterCompleteObjectUndo(selected_object.transform, "Reset game object to origin");

            Vector3 p_pos = Vector3.zero;
            Quaternion p_rot = Quaternion.identity;
            Vector3 p_scale = Vector3.one;

            if (selected_object.transform.parent != null)
            {
                p_pos = selected_object.transform.parent.position;
                p_rot = selected_object.transform.parent.rotation;
                p_scale = selected_object.transform.parent.localScale;
            }

            selected_object.transform.position = Vector3.zero + p_pos;
            selected_object.transform.rotation = Quaternion.identity * p_rot;
            selected_object.transform.localScale = Vector3.one;
        }
    }
}