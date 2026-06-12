using UnityEngine;
using UnityEngine.Timeline;


public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float baseSpeed = 5f;
    private float speed;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 0.5f;
    public AudioClip gameOverSound;
    public AudioClip shootSound;

    private AudioSource ad;
    private AudioSource sd;
    private float nextFireTime = 0f;
    Vector2 dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ad = GetComponent<AudioSource>();
        sd = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Skora göre hızı güncelle
        SCOREMAN scoreManager = FindFirstObjectByType<SCOREMAN>();
        if (scoreManager != null)
        {
            speed = baseSpeed + scoreManager.score / 20f * 0.5f;
        }
        else
        {
            speed = baseSpeed;
        }

        dir = Vector2.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            dir = speed * Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = speed * Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
            sd.PlayOneShot(shootSound);
        }

        rb.linearVelocity = dir;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("astro"))
        {
            ad.PlayOneShot(gameOverSound);
            SCOREMAN sc = FindFirstObjectByType<SCOREMAN>();
            sc.GameOver();
            Destroy(gameObject, 1f);
        }
    }
    void Shoot()
    {
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y + 0.5f);
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.linearVelocity = Vector2.up * bulletSpeed;
        }
    }
}
