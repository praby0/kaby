using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.UIElements;

[CustomEditor(typeof(CameraClass))]

public class CameraEditor : Editor
{

    void OnSceneGUI()
    {
        CameraClass cam = (CameraClass)target;
        Handles.color = Color.green;
        Handles.DrawWireDisc(cam.cameralight.transform.position, cam.player.transform.position, cam.radius);
    }


}
