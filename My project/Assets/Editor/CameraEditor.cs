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
        Handles.DrawWireArc(cam.cameralight.transform.position, Vector3.up, Vector3.forward, 360, cam.radius);
    }


}
