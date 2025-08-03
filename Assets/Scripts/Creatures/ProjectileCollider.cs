using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{
    private LineManager lineManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lineManager = GameObject.FindGameObjectWithTag("LineManager").GetComponent<LineManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        lineManager.TakeDamage();
    }
}
