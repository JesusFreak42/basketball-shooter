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
        if (born && Time.time > (bornTime + liveTime)){
            Destroy(gameObject);
        }
    }

    public void Birthday(){
        born = true;
        bornTime = Time.time;
    }
}
