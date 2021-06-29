using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject PosXAnchor;
    public GameObject NegXAnchor;
    public GameObject PosZAnchor;
    public GameObject NegZAnchor;
    public GameObject PosYAnchor;
    public GameObject NegYAnchor;
    public GameObject CurrentAnchor;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    // Use this for initialization
    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
        // Make the rigid body not change rotation
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;
        }

        AnchorFinder();
    }
    void LateUpdate()
    {
        if (target)
        {
            if (Input.GetMouseButton(1))
            {
                velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.02f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.02f;
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            //RaycastHit hit;
            //if (Physics.Linecast(target.position, transform.position, out hit))
            //{
            //distance -= hit.distance;
            //}
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }

        /*if (Input.GetKeyDown(KeyCode.W))
        {
            if (CurrentAnchor != PosYAnchor)
            {
                if (CurrentAnchor == NegYAnchor)
                {

                }
                else
                {
                    CurrentAnchor = PosYAnchor;
                }
            }
        }*/
        if(Input.GetKeyDown(KeyCode.A))
        {
            AnchorFinder();
            if(CurrentAnchor = PosXAnchor)
            {
                CurrentAnchor = NegZAnchor;
            }
            if(CurrentAnchor = NegXAnchor)
            {
                CurrentAnchor = PosZAnchor;
            }
            if(CurrentAnchor = PosZAnchor)
            {
                CurrentAnchor = PosXAnchor;
            }
            if(CurrentAnchor = NegZAnchor)
            {
                CurrentAnchor = NegXAnchor;
            }
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            AnchorFinder();
            if(CurrentAnchor = PosXAnchor)
            {
                CurrentAnchor = PosZAnchor;
            }
            if(CurrentAnchor = NegXAnchor)
            {
                CurrentAnchor = NegZAnchor;
            }
            if(CurrentAnchor = PosZAnchor)
            {
                CurrentAnchor = NegXAnchor;
            }
            if(CurrentAnchor = NegZAnchor)
            {
                CurrentAnchor = PosXAnchor;
            }
        }

        /*if(Input.GetKeyDown(KeyCode.S))
        {
            if(CurrentAnchor != NegYAnchor)
            {
                if(CurrentAnchor == PosYAnchor)
                {

                }
                else
                {
                    CurrentAnchor = NegYAnchor;
                }
            }
        }*/
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    public void AnchorFinder()
    {
        float PosXDistance = Vector3.Distance(gameObject.transform.position, PosXAnchor.transform.position);
        float NegXDistance = Vector3.Distance(gameObject.transform.position, NegXAnchor.transform.position);
        float PosZDistance = Vector3.Distance(gameObject.transform.position, PosZAnchor.transform.position);
        float NegZDistance = Vector3.Distance(gameObject.transform.position, NegZAnchor.transform.position);

        if (PosXDistance < NegXDistance && PosXDistance < PosZDistance && PosXDistance < NegZDistance)
        {
            CurrentAnchor = PosXAnchor;
        }
        if(NegXDistance < PosXDistance && NegXDistance < PosZDistance && NegXDistance < NegZDistance)
        {
            CurrentAnchor = NegXAnchor;
        }
        if(PosZDistance < PosXDistance && PosZDistance < NegXDistance && PosZDistance < NegZDistance)
        {
            CurrentAnchor = PosZAnchor;
        }
        if(NegZDistance < PosXDistance && NegZDistance < PosXDistance && NegZDistance < PosZDistance)
        {
            CurrentAnchor = NegZAnchor;
        }
    }

}
