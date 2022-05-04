using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.Collections;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded= false;
    public float restartDelay=1f;
    public GameObject completeLevelUI;
    public Text countText;
    public Text speed;
    public int scoreValue;
    public float animationDuration=0.001f;
    public PlaayerMovement force;

    public void Start(){
        
        countText.text = PlayerPrefs.GetInt("score", scoreValue).ToString();
        
    }
    
    public void setSpeed(int frc){
        force.force=frc;
        PlayerPrefs.SetInt("speed", frc);
        speed.text = frc.ToString();
        StartCoroutine(scoreIn(speed));
    }

    public void scorePlus(){
        
        scoreValue=PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("score",scoreValue+1);
        scoreValue=PlayerPrefs.GetInt("score");
        countText.text = scoreValue.ToString();

            StartCoroutine(scoreIn(countText));
    }

    IEnumerator scoreIn(Text a){
        for(int i=0; i<17;i++){
        a.fontSize=a.fontSize+3;
        yield return new WaitForSeconds(animationDuration);
        }
        
        for(int i=0; i<17;i++){
        a.fontSize=a.fontSize-3;
        yield return new WaitForSeconds(animationDuration);
        }
    }

    

    public void CompleteLevel(){
        Debug.Log("Level Completed!");
        completeLevelUI.SetActive(true);
    }
    public void EndGame(){
        if(gameHasEnded==false){
            gameHasEnded=true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }
    void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
