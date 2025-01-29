using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook: MonoBehaviour
{
    [SerializeField] private float grappleLength;
    [SerializeField] private LayerMask grappleLayer;
    [SerializeField] private LineRenderer rope;
    [SerializeField] private int extraGrapple;

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;

    private bool isGrappling = false;
    private Vector2 grapplePoint2d = new Vector2();

    private PlayerMovement playerMovementScript;

    private int grappleCount = 0;
    

    // Start is called before first frame update
    void Start(){
        joint = gameObject.GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        rope.enabled = false; // don't draw rope right away

        playerMovementScript = GetComponent<PlayerMovement>(); // used to get whether or not player is jumping
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetMouseButton(0) && grappleCount <= extraGrapple){
            if(!isGrappling){
                 grapplePoint2d = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                 isGrappling = true;
                 grappleCount++;
            }
            RaycastHit2D hit = Physics2D.Raycast(
                origin: grapplePoint2d,
                direction: Vector2.zero,
                distance: Mathf.Infinity,
                layerMask: grappleLayer
            );

            if(hit.collider != null){
                grapplePoint = hit.point;
                grapplePoint.z = 0;
                joint.connectedAnchor = grapplePoint;
                joint .enabled = true;
                joint.distance = grappleLength;
                rope.SetPosition(0, grapplePoint);
                rope.SetPosition(1, transform.position);
                rope.enabled = true;
            }
        }
        if(Input.GetMouseButtonUp(0)){
            joint.enabled = false;
            rope.enabled = false;
            isGrappling = false;
            if(playerMovementScript.GetIsGrounded()){
                grappleCount = 0;
            }
        }

        if(rope.enabled){
            rope.SetPosition(1, transform.position);
        }
    }

    void checkJumpValues(){
        if(!playerMovementScript.GetIsGrounded()){
            grappleCount++;
        }
    }
}
