using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamerOrbit : MonoBehaviour
{
    /// <summary>
    ///  CREDIT: https://answers.unity.com/questions/1257281/how-to-rotate-camera-orbit-around-a-game-object-on.html
    /// </summary>

    public Transform target;
    public float distance = 2.0f;
    public float xSpeed = 20.0f;
    public float ySpeed = 20.0f;
    
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float distanceMin = 10f;
    public float distanceMax = 10f;
    public float smoothTime = 2f;


    public GameObject SettingsCanvas;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;



    // Use this for initialization
    void Start()
    {
        //PlayerPrefs.DeleteKey("OrbitX");
        //PlayerPrefs.DeleteKey("OrbitY");

        xSpeed = StaticVariables.x;
        ySpeed = StaticVariables.y;
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }
    }

    
    void LateUpdate()
    {

       


        StaticVariables.x = PlayerPrefs.GetFloat("OrbitX");
        StaticVariables.y = PlayerPrefs.GetFloat("OrbitY");

        xSpeed = 20 + StaticVariables.x * 15;
        ySpeed = 20 + StaticVariables.y * 15;

        if (target)
        {
            if (Input.GetMouseButton(1) || Input.GetMouseButton(2))
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * Time.deltaTime;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * Time.deltaTime;
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }

    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    

    

}
