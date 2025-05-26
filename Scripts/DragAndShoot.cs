using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{

    private Vector3 mouseDownPos;
    private Vector3 mouseUpPos;
    private Rigidbody rb;
    private bool shooting = false;

    [SerializeField] private float forceMultiplier = 3f;
    [SerializeField] private BallSpawner ballSpawner;
    [SerializeField] private Camera cam;
    private DestroyAfterTime grimReaper;

    private void Start(){
        rb = GetComponent<Rigidbody>();
        grimReaper = GetComponent<DestroyAfterTime>();
    }

    private void OnMouseDown(){
        // mouseDownPos = new Vector3(Input.mousePosition.x/Screen.width, Input.mousePosition.y/Screen.height, Input.mousePosition.z); //mouse position relative to screen size
        Vector3 ballScreenPos = cam.WorldToScreenPoint(transform.position); //use the ball's center
        mouseDownPos = new Vector3(ballScreenPos.x/Screen.width, ballScreenPos.y/Screen.height, ballScreenPos.z); //ball position relative to screen size
    }

    private void OnMouseUp(){
        mouseUpPos = new Vector3(Input.mousePosition.x/Screen.width, Input.mousePosition.y/Screen.height, Input.mousePosition.z); //mouse position relative to screen size
        // Shoot(mouseDownPos - mouseUpPos); //swipe down
        Shoot(mouseUpPos - mouseDownPos); //swipe up
    }

    private void Shoot(Vector3 shotForce){
        if (shooting) return; //don't shoot if currently shooting

        Vector3 shotForceMultiplier = new Vector3(200,300,200); //shot multiplier
        #if UNITY_ANDROID || UNITY_IOS
        shotForceMultiplier = new Vector3(300,400,300); //different sensitivity for mobile
        #endif

        rb.AddForce(new Vector3(shotForce.x*shotForceMultiplier.x, shotForce.y*shotForceMultiplier.y, shotForce.y*shotForceMultiplier.z) * forceMultiplier); //for 3D movement (x,y,z)
        // rb.AddForce(new Vector3(shotForce.x*300, 0f, shotForce.y*1000) * forceMultiplier); //for flat movement (no vertical)
        shooting = true;
        grimReaper.Birthday(); //the ball is now alive
        ballSpawner.RequestNewSpawn(); //request the next ball
    }

    public void SetBallSpawner(BallSpawner s){
        ballSpawner = s;
    }

    public void SetCamera(Camera c){
        cam = c;
    }

}
