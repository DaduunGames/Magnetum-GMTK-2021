using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerOrbit : MonoBehaviour
{
    public float yawSpeed;
    public float pitchSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 rotations = new Vector3();

            rotations.x = Input.GetAxis("Mouse Y") * -pitchSpeed;
            rotations.y = Input.GetAxis("Mouse X") * yawSpeed;
            
            transform.parent.Rotate(rotations, Space.Self);


            Quaternion setZ = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            transform.rotation = setZ;
                
        }
    }
}
