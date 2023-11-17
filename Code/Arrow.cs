using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Range(1, 10)]
    public float speed;
    [Range(1, 10)]
    public float dmg;
    // Start is called before the first frame update
    void Start()
    {
        //Уничтожаем через 3 секунды после появления
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("Попадание");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(dmg);
        }
        Destroy(gameObject);
    }
}
