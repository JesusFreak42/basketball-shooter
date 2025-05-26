using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAnimTrigger : MonoBehaviour
{
    
    [SerializeField] private Animator netAnim;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            // Debug.Log("score anim triggered");
            netAnim.Play("NetScoreAnim", 0, 0f);
        }
    }
}
