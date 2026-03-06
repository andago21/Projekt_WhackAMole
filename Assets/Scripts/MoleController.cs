using UnityEngine;

public class MoleController : MonoBehaviour
{
    [Header("Bewegung")]
    public float upPosition = 0.5f;
    public float downPosition = -0.5f;
    public float speed = 2f;
    public float waitTimeMin = 0.5f;
    public float waitTimeMax = 3f;

    private Vector3 startPos;
    private bool movingUp = true;
    private float waitTimer = 0f;
    private bool waiting = false;
    private bool isActive = false;

    void Start()
    {
        startPos = transform.position;
        transform.position = new Vector3(startPos.x, startPos.y + downPosition, startPos.z);
        // Jeder Mole startet zu einer anderen Zeit
        waitTimer = Random.Range(0f, waitTimeMax);
        waiting = true;
    }

    void Update()
    {
        if (!isActive) return;

        if (waiting)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f) waiting = false;
            return;
        }

        float targetY = movingUp
            ? startPos.y + upPosition
            : startPos.y + downPosition;

        Vector3 target = new Vector3(startPos.x, targetY, startPos.z);
        transform.position = Vector3.MoveTowards(
            transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            movingUp = !movingUp;
            // Zufällige Wartezeit nur wenn unten
            waiting = true;
            waitTimer = movingUp ? 0.2f : Random.Range(waitTimeMin, waitTimeMax);
        }
    }

    public void SetActive(bool active)
    {
        isActive = active;
        if (!active)
        {
            transform.position = new Vector3(startPos.x, startPos.y + downPosition, startPos.z);
            movingUp = true;
        }
    }

    public void OnHit()
    {
        Debug.Log("MOLE HIT: " + gameObject.name);
        transform.position = new Vector3(startPos.x, startPos.y + downPosition, startPos.z);
        movingUp = true;
        waiting = true;
        waitTimer = Random.Range(waitTimeMin, waitTimeMax);
    }
}