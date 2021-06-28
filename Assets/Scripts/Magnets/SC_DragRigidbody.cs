using UnityEngine;

public class SC_DragRigidbody : MonoBehaviour
{
    public float forceAmount = 500;

    Rigidbody selectedRigidbody;
    Camera targetCamera;
    Vector3 originalScreenTargetPosition;
    Vector3 originalRigidbodyPos;
    float selectionDistance;

    Ray Ray;
    RaycastHit Hit;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        targetCamera = GetComponent<Camera>();
    }

    void Update()
    {
        

        if (!targetCamera)
        {
            print("No camera");
            return;
        }

        //Debug.DrawRay(targetCamera.transform.position, Ray.direction*100, Color.blue);

        if (Input.GetMouseButtonDown(0))
        {
            //Check if we are hovering over Rigidbody, if so, select it
            selectedRigidbody = GetRigidbodyFromMouseClick();
        }
        if (Input.GetMouseButtonUp(0) && selectedRigidbody)
        {
            //Release selected Rigidbody if there any
            selectedRigidbody = null;
        }
    }

    void FixedUpdate()
    {
        if (selectedRigidbody)
        {
            print(selectedRigidbody.name);
            Vector3 mousePositionOffset = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance)) - originalScreenTargetPosition;
            selectedRigidbody.velocity = (originalRigidbodyPos + mousePositionOffset - selectedRigidbody.transform.position) * forceAmount * Time.deltaTime;
        }
    }

    Rigidbody GetRigidbodyFromMouseClick()
    {
        RaycastHit hitInfo = new RaycastHit();

        Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray = new Ray(targetCamera.transform.position, Ray.direction);
        
        if (Physics.Raycast(Ray, out Hit))
        {
            hitInfo = Hit;
        }
        
        print(hitInfo.collider.name);

        if (hitInfo.collider.gameObject.GetComponent<Rigidbody>())
        {
            selectionDistance = Vector3.Distance(Ray.origin, hitInfo.point);
            originalScreenTargetPosition = targetCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, selectionDistance));
            originalRigidbodyPos = hitInfo.collider.transform.position;
            return hitInfo.collider.gameObject.GetComponent<Rigidbody>();
        }


        return null;
    }
}
