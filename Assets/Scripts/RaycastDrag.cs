using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDrag : MonoBehaviour
{
    public GameObject Anchor;

	private bool IsHoldingMouse = false;

    Ray Ray;
    RaycastHit Hit;

    public LayerMask layerMask;
    private void Update()
    {
        if (IsHoldingMouse)
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Ray, out Hit, 100f, layerMask))
            {
                
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
	}
}
