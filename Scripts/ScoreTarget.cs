using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTarget : MonoBehaviour
{
    
    [SerializeField] private int points = 1;
    [SerializeField] private ScoreController scoreController;

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){ //if the colliding object has tag "Player," then score
            scoreController.AddScore(points);
        }
    }

}
