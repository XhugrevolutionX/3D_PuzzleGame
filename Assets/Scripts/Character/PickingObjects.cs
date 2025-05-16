using UnityEngine;

public class PickingObjects : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private float objectPickupDistance;

    private Transform _attachedObject = null;
    private float _attachedObjectDistance = 0f;
    
    public void PickObject()
    {
        RaycastHit hit;
        bool cast = Physics.Raycast(head.position, head.forward, out hit, objectPickupDistance);
        
        if (_attachedObject != null)
        {
            _attachedObject.SetParent(null);

            if (_attachedObject.GetComponent<Rigidbody>() != null)
                _attachedObject.GetComponent<Rigidbody>().isKinematic = false;
            

            if (_attachedObject.GetComponent<Collider>() != null) 
                _attachedObject.GetComponent<Collider>().enabled = true;
            
            _attachedObject = null;
        }
        else
        {
            if (cast)
            {
                if (hit.transform.CompareTag("Pickable"))
                {
                    _attachedObject = hit.transform;
                    _attachedObject.SetParent(transform);
                    _attachedObjectDistance = Vector3.Distance(head.position, _attachedObject.transform.position);
                    
                    if (_attachedObject.GetComponent<Rigidbody>() != null)
                        _attachedObject.GetComponent<Rigidbody>().isKinematic = true;
            

                    if (_attachedObject.GetComponent<Collider>() != null) 
                        _attachedObject.GetComponent<Collider>().enabled = false;
                }
            }
        }
    }

    void Update()
    {
        if (_attachedObject != null)
        {
            _attachedObject.position = head.position + head.forward * _attachedObjectDistance;
        }
    }
}
