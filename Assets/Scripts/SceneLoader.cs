using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private string NameFromIndex(int BuildIndex)
    {
        var path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        var slash = path.LastIndexOf('/');
        var name = path.Substring(slash + 1);
        var dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }

    private int sceneIndexFromName(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            var sceneNameFromIndex = NameFromIndex(i);
            if (sceneNameFromIndex == sceneName)
                return i;
        }
        return -1;
    }

    public void LoadStartScene() => SceneManager.LoadScene(0);
    public void LoadSuccessScene() => SceneManager.LoadScene(sceneIndexFromName("Success"));
    public void LoadGameOverScene() => SceneManager.LoadScene(sceneIndexFromName("Game Over"));
}
