using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterLeavingArea : MonoBehaviour
{
    
    private void OnTriggerExit(Collider other){
        if (other.CompareTag("ReaperArea")){
            Destroy(gameObject);
        }
    }
    
}
