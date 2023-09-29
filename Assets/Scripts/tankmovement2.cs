using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class tankmovement2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Transform powerplacement;
    [SerializeField] private GameObject shieldPrefab;

    private float movementInput;
    private float rotationInput;
    public bool shieldOn = false;
    private float shieldActiveTime = 10f;
    private float shieldTimer;
    private GameObject currentShield;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyTankMovement();
        ApplyTankRotation();
    }

    private void ApplyTankMovement()
    {
        Vector2 movement = transform.up * movementInput * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void ApplyTankRotation()
    {
        float rotation = -rotationInput * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation + rotation);
    }

    private void OnMoveTank(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        movementInput = inputVector.y;
        rotationInput = inputVector.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shieldpowerup"))
        {
            shieldOn = true;
            currentShield = Instantiate(shieldPrefab, powerplacement.position, transform.rotation);
            shieldTimer = shieldActiveTime;
        }
    }

    private void Update()
    {
        if (shieldOn)
        {
            currentShield.transform.position = powerplacement.position;
            shieldTimer -= Time.deltaTime;
            if (shieldTimer <= 0f)
            {
                shieldOn = false;
                currentShield.SetActive(false);
            }
        }
    }
}










