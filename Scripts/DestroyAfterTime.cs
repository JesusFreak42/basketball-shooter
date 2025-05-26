using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{

    [SerializeField] private float liveTime = 5f;
    private bool born = false;
    private float bornTime;

    // private void Start(){
    //     bornTime = Time.time;
    // }

    private void Update(){
        if (born && Time.time > (bornTime + liveTime)){ //destroy this object after time
            Destroy(gameObject);
        }
    }

    public void Birthday(){ //set this object alive
        born = true;
        bornTime = Time.time;
    }
}
