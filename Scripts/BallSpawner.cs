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
    // [SerializeField] private FlashingButton newGameBtn;

    private void Awake(){
        #if UNITY_ANDROID || UNITY_IOS
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //no sleep for this device
        #endif
    }

    private void Start(){
        SpawnNewObject();
    }

    private void SpawnNewObject(){
        // if (scoreController.GetBalls() <= 0){
        //     if (!newGameBtn.flashing){
        //         newGameBtn.flashing = true;
        //     }

        //     return;
        // }

        if (!scoreController.TimeRemains() && scoreController.TimedMode()){
            return;
        }

        // GameObject nBall = Instantiate(spawnObj, transform.position, Quaternion.identity);
        GameObject nBall = Instantiate(spawnObj, transform.position, Random.rotation);
        nBall.GetComponent<DragAndShoot>().SetBallSpawner(this);
        nBall.GetComponent<DragAndShoot>().SetCamera(cam);
        // scoreController.TakeBalls(1);
        objectsAlive.Add(nBall);

        // newGameBtn.SetButtonInteractable(true);
    }

    public void RequestNewSpawn(){
        Invoke("SpawnNewObject", newSpawnTime);
    }

    public void StartNewGame(){
        for (int i = 0; i < objectsAlive.Count; i++){
            Destroy(objectsAlive[i].gameObject);
        }
        objectsAlive.Clear();

        // newGameBtn.flashing = false;
        scoreController.ResetGame();
        // RequestNewSpawn();
        SpawnNewObject();
    }

    public void RequestNewGame(){
        // newGameBtn.SetButtonInteractable(false);
        Invoke("StartNewGame", newSpawnTime);
    }

    public void OnTimerBtnClicked(){
        scoreController.FlipTimedMode();
        StartNewGame();
        // RequestNewGame();
    }

    // public void GoMainMenu(){
    //     SceneManager.LoadScene("MainMenuScene");
    // }

}
