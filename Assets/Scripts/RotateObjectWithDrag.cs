using UnityEngine;

public class RotateObjectWithDrag : MonoBehaviour
{
   private Vector3 _mPrevPos = Vector3.zero;
   private Vector3 _mPosDelta = Vector3.zero;
   [SerializeField] private float speed;

   void Update()
   {
      if (Input.GetMouseButton(0))
      {
         _mPosDelta = Input.mousePosition - _mPrevPos;
         if (Vector3.Dot(transform.up, Vector3.up) >= 0)
         {
            transform.Rotate(transform.up, -Vector3.Dot(_mPosDelta, Camera.main.transform.right) * Time.deltaTime * speed, Space.World);
         }
         else
         {
            transform.Rotate(transform.up, Vector3.Dot(_mPosDelta, Camera.main.transform.right) * Time.deltaTime * speed, Space.World);
         }
         
         transform.Rotate(Camera.main.transform.right, Vector3.Dot(_mPosDelta, Camera.main.transform.up) * Time.deltaTime * speed, Space.World);
      }
      
      _mPrevPos = Input.mousePosition;
   }
}
