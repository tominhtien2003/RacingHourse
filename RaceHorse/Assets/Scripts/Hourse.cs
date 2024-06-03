using UnityEngine;

public class Hourse : MonoBehaviour
{
    private const string RUN = "Run";

    [SerializeField] private float speedHourse;

    private Rigidbody rb;
    private Animator animator;
    private float randomSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        HandleRandomSpeed();
        randomSpeed++;
    }
    private void Update()
    {
        HandleRandomSpeed();
    }
    private void FixedUpdate()
    {
        if (GameManager.Instance.starting)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        animator.SetBool(RUN, true);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speedHourse);
    }
    private void HandleRandomSpeed()
    {
        if (transform.position.z / 50f >= randomSpeed)
        {
            int random = Random.Range(0, 2);
            if (random >= 1)
            {
                speedHourse = Mathf.Clamp(Random.Range(speedHourse + .5f, speedHourse +1f), 18f, 19f);
            }
            else
            {
                speedHourse = Mathf.Clamp(Random.Range(speedHourse - .5f, speedHourse - 1f), 18f, 19f);
            }
            randomSpeed++;
        }
    }
    
}
