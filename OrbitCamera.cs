using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour
{

    private Transform XCamera;
    private Transform FocusObject;
    private Vector3 LocalRotation;

    public float CameraDistance = 3f;
    public float MouseSensitivity = 4f;
    public bool CameraDisabled = false;


    // Use this for initialization
    void Start()
    {
        this.XCamera = this.transform;
        this.FocusObject = this.transform.parent;
    }


    void LateUpdate()
    {
        //Zet de camera uit
        if (Input.GetKeyDown(KeyCode.P))
            CameraDisabled = !CameraDisabled;

        if (!CameraDisabled)
        {
            //Laat de camera roteren
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity * -1;

                //Zorgt dat de camera niet onder de grond gaat
                if (LocalRotation.y < 0f)
                    LocalRotation.y = 0f;
                else if (LocalRotation.y > 90f)
                    LocalRotation.y = 90f;
            }
            
        }

        //Zorgt dat de camera orbit
        Quaternion QT = Quaternion.Euler(LocalRotation.y, LocalRotation.x, 0);
        this.FocusObject.rotation = Quaternion.Lerp(this.FocusObject.rotation, QT, Time.deltaTime * 10);

        if (this.XCamera.localPosition.z != this.CameraDistance * -1f)
        {
            //Zet de camera op de juiste positie
            this.XCamera.localPosition = new Vector3(0, 0, Mathf.Lerp(this.XCamera.localPosition.z, this.CameraDistance * -1f, Time.deltaTime));
        }
    }
}