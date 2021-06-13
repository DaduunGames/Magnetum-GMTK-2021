using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullTag : MonoBehaviour
{
    public float dragSpeed = 1f;
    Vector3 lastMousePos;
    public Axis axis = Axis.y;

    private GameObject Cam;

    private Vector3 originalPos;
    public float MinDist;
    public float MaxDist;

    public AudioSource pullAudio;

    public enum Axis
    {
        x,
        y,
        z
    }

    private void Start()
    {
        originalPos = transform.position;
        Cam = Camera.main.gameObject;

    }


    void OnMouseDown()
    {
        lastMousePos = Input.mousePosition;
        pullAudio.Play();
    }

    void OnMouseDrag()
    {
        Vector3 delta = Input.mousePosition - lastMousePos;
        Vector3 pos = transform.position;
        switch (axis)
        {
            case Axis.x:
                #region move
                if (Cam.transform.position.z < transform.position.z )
                {
                    pos.x += delta.x * dragSpeed;
                }
                else
                {
                    pos.x += delta.x  * -dragSpeed;
                }
                #endregion
                pos.x = Mathf.Clamp(pos.x, originalPos.x + MinDist, originalPos.x + MaxDist);
                break;

            case Axis.y:
                #region move
                pos.y += delta.y * dragSpeed;
                #endregion
                pos.y = Mathf.Clamp(pos.y, originalPos.y + MinDist, originalPos.y + MaxDist);
                break;

            case Axis.z:
                #region move
                if (Cam.transform.position.x < transform.position.x)
                {
                    pos.z += (delta.y + delta.x) / 2 * -dragSpeed;
                }
                else
                {
                    pos.z += (delta.y + delta.x) / 2 * dragSpeed;
                }
                #endregion
                pos.z = Mathf.Clamp(pos.z, originalPos.z + MinDist, originalPos.z + MaxDist);
                break;
        }
        




        transform.position = pos;
        lastMousePos = Input.mousePosition;
       
    }

    private void OnDrawGizmos()
    {
        Vector3 minPos = new Vector3(0, 0, 0);
        Vector3 maxPos = new Vector3(0, 0, 0);

        switch (axis)
        {
            case Axis.x:
                minPos.x += MinDist;
                maxPos.x += MaxDist;
                break;

            case Axis.y:
                minPos.y += MinDist;
                maxPos.y += MaxDist;
                break;

            case Axis.z:
                minPos.z += MinDist;
                maxPos.z += MaxDist;
                break;
        }

        Gizmos.DrawLine(transform.position + minPos, transform.position + maxPos);
    }
}
