using UnityEngine;

public class GrabAndThrow : MonoBehaviour
{
    float grabbedObjectSize;
    Vector3 previousPos;
    GameObject grabbedObject;

    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            if (grabbedObject == null)
            {
                TryGrabObject(GetMouseHoverObject(1000));
            }
            else
                DropObject();
        }

        if(grabbedObject != null)
        {
            previousPos = grabbedObject.transform.position;
            Vector3 newPos = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObject.transform.position = newPos;
        }
    }

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 pos = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = pos + Camera.main.transform.forward * range;

        if (Physics.Linecast(pos, target, out raycastHit))
            return raycastHit.collider.gameObject;

        return null;
    }

    void TryGrabObject(GameObject grabObject)
    {
        if (grabObject == null || !CanGrab(grabObject))
            return;

        grabbedObject = grabObject;
        grabbedObjectSize = grabbedObject.GetComponent<MeshRenderer>().bounds.size.magnitude;
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
