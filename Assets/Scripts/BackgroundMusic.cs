using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
