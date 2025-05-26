using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject spawnObj;
    private float newSpawnTime = 1.0f;
    private List<GameObject> objectsAlive = new List<GameObject>();

    [SerializeField] private Camera cam;
    [SerializeField] private ScoreController scoreController;

    private void Awake(){
        #if UNITY_ANDROID || UNITY_IOS
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //no sleep for this mobile device
        #endif
    }

    private void Start(){
        SpawnNewObject(); //spawn new ball on start
    }

    private void SpawnNewObject(){
        if (!scoreController.TimeRemains() && scoreController.TimedMode()){
            return;
        }

        GameObject nBall = Instantiate(spawnObj, transform.position, Random.rotation); //instantiate the ball here at a random rotation
        nBall.GetComponent<DragAndShoot>().SetBallSpawner(this); //set props in the child object
        nBall.GetComponent<DragAndShoot>().SetCamera(cam);
        objectsAlive.Add(nBall);
    }

    public void RequestNewSpawn(){
        Invoke("SpawnNewObject", newSpawnTime);
    }

    public void StartNewGame(){
        for (int i = 0; i < objectsAlive.Count; i++){ //destroy objects for new game
            Destroy(objectsAlive[i].gameObject);
        }
        objectsAlive.Clear(); //clear the list

        scoreController.ResetGame();
        SpawnNewObject();
    }

    public void RequestNewGame(){
        Invoke("StartNewGame", newSpawnTime); //invoke function after time
    }

    public void OnTimerBtnClicked(){
        scoreController.FlipTimedMode();
        StartNewGame();
    }

}
