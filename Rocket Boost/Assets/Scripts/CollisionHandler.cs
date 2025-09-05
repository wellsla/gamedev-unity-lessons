using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Collided with Friendly");
                break;
            case "Finish":
                NextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;     
        int nextScene = currentScene + 1; 

        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }

    void ReloadLevel()
    {        
        int currentScene = SceneManager.GetActiveScene().buildIndex;        
        SceneManager.LoadScene(currentScene);
    }
}
