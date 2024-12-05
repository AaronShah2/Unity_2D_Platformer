using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 0.125f;
   
   // Late Update
    void LateUpdate()
    {
        if(target != null){
            Vector3 cameraPos = target.position + offset;
            Vector3 smoothedPos = Vector3.Lerp(transform.position, cameraPos, smoothSpeed);
            transform.position = smoothedPos;
            transform.LookAt(target);
        }
    }
}
