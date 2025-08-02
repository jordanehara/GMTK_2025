using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Creature : MonoBehaviour
{
    #region Stats
    [SerializeField] public int maxHealth;
    private int health;
    [SerializeField] public float movementSpeed;
    public LayerMask lineLayer;
    #endregion

    #region UI
    private TextMeshPro healthText;
    #endregion

    #region Creature States
    protected Rigidbody2D rb;
    [SerializeField] protected Animator animator;
    public enum CreatureStates { Idle, Walk, Attack }
    [SerializeField] protected CreatureStates currentState;
    protected Vector2 direction;
    [SerializeField] protected float minIdleTime;
    [SerializeField] protected float maxIdleTime;
    [SerializeField] protected float walkTime;
    protected bool stateComplete;
    protected List<string> randomActionsList = new List<string>();
    private DamageFlash damageFlash;
    #endregion

    #region  Capture
    private List<int> captureLines = new List<int>();
    protected LineManager lineManager;

    private bool isCaptured = false;
    #endregion

    void Awake()
    {
        lineManager = GameObject.FindGameObjectWithTag("LineManager").GetComponent<LineManager>();
        rb = GetComponent<Rigidbody2D>();
        stateComplete = true;
        damageFlash = GetComponent<DamageFlash>();
        healthText = GetComponentInChildren<TextMeshPro>();
    }

    public virtual void Update()
    {
        if (!lineManager.isDrawing)
        {
            health = maxHealth;
            captureLines.Clear();
        }
    }

    protected void AddToActionsList(string action, int num)
    {
        for (int i = 0; i < num; i++)
        {
            randomActionsList.Add(action);
        }
    }

    protected string ChooseRandomActionFromList()
    {
        stateComplete = false;
        return randomActionsList[Random.Range(0, randomActionsList.Count - 1)];
    }

    protected void setState(CreatureStates state)
    {
        animator.SetInteger("state", (int)state);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pointer" || collision.gameObject.tag == "Line")
        {
            lineManager.DestroyLines();
            health = maxHealth;
        }
    }

    public void Capture(int lineId)
    {
        if (lineManager.isDrawing && health > 0)
        {
            health -= 1;
            HealthFlasher();
            damageFlash.CallDamageFlash();

            if (health == 0)
            {
                print($"{name} Captured");
                isCaptured = true;
                Destroy(gameObject);
            }
            else
            {
                captureLines.Add(lineId);
            }
        }
    }

    private void HealthFlasher()
    {
        print(health);
        healthText.text = health.ToString();
    }

    public bool IsCaptured()
    {
        return isCaptured;
    }

    protected virtual IEnumerator Walk()
    {
        print("walking");
        setState(CreatureStates.Walk);

        // Get random direction
        direction = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 1.0f);
        if (direction.x < 0)
        {
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
        else
        {
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        rb.linearVelocity = direction.normalized * movementSpeed;
        yield return new WaitForSeconds(walkTime);
        rb.linearVelocity = Vector3.zero;
        stateComplete = true;
        print("walking done");
    }

    protected IEnumerator Idle()
    {
        print("idle");
        setState(CreatureStates.Idle);
        yield return new WaitForSeconds(Random.Range(minIdleTime, maxIdleTime));
        stateComplete = true;
        print("idle done");
    }
}
