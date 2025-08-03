using TMPro;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private string taskName;
    [Range(1, 5)] public int level;

    void Awake()
    {
    }

    public void LoadLevel()
    {
        levelManager.canvas.SetActive(false);
        levelManager.UnloadLevel();
        if (levelManager.level == 1)
        {
            SceneChanger.instance.LoadEndScene();
        }
        else
        {
            levelManager.level += 1;
            print(level);
            levelManager.LoadLevel();
        }
    }
}
