using TMPro;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private string taskName;
    [Range(1, 5)] public int level;

    void Awake()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = $"{level}. " + taskName;
    }

    public void LoadLevel()
    {
        levelManager.level = level;
        SceneChanger.instance.LoadLevelScene();
    }
}
