using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger instance;

    [SerializeField] string menuSceneName;
    [SerializeField] string levelSceneName;
    [SerializeField] string endSceneName;
    [SerializeField] string levelSelectorSceneName;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene(levelSceneName);
    }

    public void LoadEndScene()
    {
        SceneManager.LoadScene(endSceneName);
    }

    public void LoadLevelSelector()
    {
        SceneManager.LoadScene(levelSelectorSceneName);
    }
}
