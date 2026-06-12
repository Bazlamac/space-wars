using Unity.VisualScripting;
using UnityEngine;

public class ASTRO : MonoBehaviour
{
    public GameObject explosionprefab;
    public float lifeTime = 7f;

    public int point = 1;
    public AudioClip gameOverSound;

    public AudioClip explosionSound;

    private AudioSource ad;
    private float speed;
    private float baseSpeed = 2f;


    void Start()
    {
        Destroy(gameObject, lifeTime);
        ad = GetComponent<AudioSource>();

        // Aha burda skora gore hız artıo
        SCOREMAN sc = FindFirstObjectByType<SCOREMAN>();
        speed = baseSpeed + sc.score / 10f * 0.5f;


    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -5f)
        {
            FindFirstObjectByType<SCOREMAN>().GameOver();
            if (gameOverSound != null)
            {
                AudioSource.PlayClipAtPoint(gameOverSound, Camera.main.transform.position);
            }
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (explosionprefab != null)
            {
                GameObject explosion = Instantiate(explosionprefab, transform.position, Quaternion.identity);
                Destroy(explosion, 1f);
            }
            ad.PlayOneShot(gameOverSound);
            Destroy(gameObject, 1f);
        }
        if (collision.CompareTag("Mermi"))
        {
            SCOREMAN sc = FindFirstObjectByType<SCOREMAN>();
            sc.AddScore(point);
            GameObject explosion = Instantiate(explosionprefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Destroy(explosion, 1f);
            Destroy(gameObject);
        }
    }
}