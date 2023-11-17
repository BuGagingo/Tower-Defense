using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{
    public float shootInterval = 0.75f;
    public float shootTimer = 0;
    public GameObject arrowPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        //Определяем координату клика
        Vector2 mouseScreenPos = Input.mousePosition;
        Vector2 mouseScenePos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        // создаем переменную с позицией объекта
        Vector2 bowPos = transform.position;
        //Находим вектор направления
        Vector2 wantedDirection = mouseScenePos - bowPos;
        //Изначальный вектор
        Vector2 defaultDirection = Vector2.up;
        //Угол поворота
        float angle = Vector2.SignedAngle(defaultDirection, wantedDirection);
        Vector3 newEuler = new Vector3(0, 0, angle);
        transform.localEulerAngles = newEuler;
        
        
        if (Input.GetMouseButton(0))
        {
            if (shootTimer <= 0)
            {
                GameObject newProjectile = Instantiate(arrowPrefab, transform.position, transform.rotation);
                shootTimer = shootInterval;
            }
        }
    }
}
