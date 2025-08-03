using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    public void SpawnProjectile()
    {
        projectile.SetActive(true);
    }

    public void DestroyProjectile()
    {
        print(gameObject.name);
        gameObject.SetActive(false);
    }
}
