using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDrag : MonoBehaviour
{
	//private Vector3 screenPoint;
	//private Vector3 offset;

    public GameObject Anchor;

	private bool IsHoldingMouse = false;

    Ray Ray;
    RaycastHit Hit;

    public LayerMask layerMask;
    private void Update()
    {
        //if (Input.GetMouseButton(0) && IsHoldingMouse)
        //{
        //	Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        //	Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint); //+ offset;
        //	Anchor.transform.position = cursorPosition;
        //}
        if (IsHoldingMouse)
        {
            print(Input.mousePosition);
            
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Ray, out Hit, 100f, layerMask))
            {
                print("yes");
                Anchor.transform.position = Hit.point;
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
			IsHoldingMouse = false;
        }
	}

    private void OnMouseDown()
    {
		IsHoldingMouse = true;
		//screenPoint = Camera.main.WorldToScreenPoint(Anchor.transform.position);
		//offset = Anchor.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
}
