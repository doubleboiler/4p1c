using UnityEngine;

public class GrabAndThrow : MonoBehaviour
{
    float distance;
    Vector3 previousPos;
    GameObject grabbedObject;

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null)
            {
                TryGrabObject(GetMouseHoverObject());
            }
            else
                DropObject();
        }

        if (grabbedObject != null)
        {
            previousPos = grabbedObject.transform.position;
            Vector3 newPos = Camera.main.transform.position + Camera.main.ScreenPointToRay(Input.mousePosition).direction * distance;
            grabbedObject.transform.position = newPos;
        }
    }

    GameObject GetMouseHoverObject()
    {
        //Vector3 pos = gameObject.transform.position;

        RaycastHit raycastHit;

        //Vector3 target = pos + Camera.main.ScreenPointToRay(Input.mousePosition).direction * range;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider.gameObject.tag == "Dice")
                return raycastHit.collider.gameObject;
        }

        //if (Physics.Linecast(pos, target, out raycastHit))
        //    return raycastHit.collider.gameObject;

        return null;
    }

    void TryGrabObject(GameObject grabObject)
    {
        if (grabObject == null || !CanGrab(grabObject))
            return;

        grabbedObject = grabObject;
        distance = Vector3.Distance(grabbedObject.transform.position, Camera.main.transform.position);
        grabbedObject.GetComponent<Rigidbody>().useGravity = false;
    }

    void DropObject()
    {
        if (grabbedObject == null)
            return;

        Rigidbody rb = grabbedObject.GetComponent<Rigidbody>();

        if(rb != null)
        {
            Vector3 throwVector = grabbedObject.transform.position - previousPos;
            float speed = throwVector.magnitude / Time.deltaTime;
            Vector3 throwVelosity = speed * throwVector.normalized;
            rb.velocity = throwVelosity;
            grabbedObject.GetComponent<Rigidbody>().useGravity = true;
        }

        grabbedObject = null;
    }
    bool CanGrab(GameObject candidate)
    {
        return candidate.GetComponent<Rigidbody>() != null;
    }

}
