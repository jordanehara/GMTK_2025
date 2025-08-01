using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneChanger.instance.LoadMenuScene();
    }

    public void LoadEndScene()
    {
        SceneChanger.instance.LoadEndScene();
    }

    public void LoadLevelScene()
    {
        SceneChanger.instance.LoadLevelScene();
    }

    public void LoadLevelSelector()
    {
        SceneChanger.instance.LoadLevelSelector();
    }
}
