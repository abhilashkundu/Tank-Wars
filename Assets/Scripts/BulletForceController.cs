using UnityEngine;

public class BulletForceController : MonoBehaviour
{
    [SerializeField]TankMovement tank1;
    private void Start()
    {
        tank1 = GameObject.FindGameObjectWithTag("Tank1").GetComponent<TankMovement>();
        Destroy(this.gameObject, 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tank1") || collision.gameObject.CompareTag("Tank2"))
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "shield" && tank1.shieldOn == false)
        {
            Destroy(this.gameObject);
        }
    }
}