using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay=1f;
    ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper=FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitandLoad("GameOver", sceneLoadDelay));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitandLoad(string sceneName,float sceneLoadDelay)
    {
        yield return new WaitForSeconds(sceneLoadDelay);
        SceneManager.LoadScene(sceneName);

    }
}
