using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //https://medium.com/cuvr/creating-your-first-vr-app-c73de6ec5be2

    private Camera headCamera;
    public float speed;
    
    // Speed at which the player will rotate around the y axis
    public float rotationSpeed;

    private float zRotation;
    private float normZ;

    // Start is called before the first frame update
    void Start()
    {
        headCamera = this.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        normZ = getAngleZ();
        //print(normZ);
        /*if (normZ == 0)
        {
            headCamera.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        }
        else if (normZ > 30)
        {
            headCamera.transform.Rotate(0.0f, 0.0f, -30.0f, Space.Self);
        }
        else if (normZ > -30)
        {
            headCamera.transform.Rotate(0.0f, 0.0f, 30.0f, Space.Self);
        }*/

    }

    public float getAngleZ()
    {
        zRotation = headCamera.transform.rotation.eulerAngles.z;
        normZ = zRotation;
        // Normalize the zRotation so that -180 < normZ < 180
        if (zRotation >= 180)
        {
            normZ = zRotation - 360;
        }
        return normZ;
    }
}
