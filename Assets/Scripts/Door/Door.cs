using UnityEngine;

public class Door : MonoBehaviour
{
    
    [SerializeField] private Transform leftPanel;
    [SerializeField] private Transform rightPanel;
    
    [SerializeField] private Transform leftStoppingPoint;
    [SerializeField] private Transform rightStoppingPoint;
    [SerializeField] private Transform middleStoppingPoint;

    [SerializeField] private bool _state = false;
    void FixedUpdate()
    {
        if (_state)
        {
            if (Mathf.Abs(leftStoppingPoint.localPosition.x) - Mathf.Abs(leftPanel.localPosition.x) > Mathf.Epsilon)
            {
                leftPanel.localPosition = Vector3.Lerp(leftPanel.localPosition, leftStoppingPoint.localPosition, 0.125f);
            }
            if (Mathf.Abs(rightStoppingPoint.localPosition.x) - Mathf.Abs(rightPanel.localPosition.x) > Mathf.Epsilon)
            {
                rightPanel.localPosition = Vector3.Lerp(rightPanel.localPosition, rightStoppingPoint.localPosition, 0.125f);
            }
        }
        else
        {
            if (Mathf.Abs(middleStoppingPoint.localPosition.x) + Mathf.Abs(leftPanel.localPosition.x) > Mathf.Epsilon)
            {
                leftPanel.localPosition = Vector3.Lerp(leftPanel.localPosition, middleStoppingPoint.localPosition, 0.125f);
            }
            if (Mathf.Abs(middleStoppingPoint.localPosition.x) + Mathf.Abs(rightPanel.localPosition.x) > Mathf.Epsilon)
            {
                rightPanel.localPosition = Vector3.Lerp(rightPanel.localPosition, middleStoppingPoint.localPosition, 0.125f);
            }
        }
    }
    
    
    public void Open()
    {
        Debug.Log("Open");
        _state = true;
    }

    public void Close()
    {
        Debug.Log("Close");
       _state = false;
    }
}
