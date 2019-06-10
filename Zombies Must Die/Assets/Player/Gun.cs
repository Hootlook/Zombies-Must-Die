using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    [Range(50, 200)]
    private float damage;

    Enemy enemy;
    Camera cam;


    private float timer;


    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            damage = UnityEngine.Random.Range(100, 300);
            FireGun();
        }
    }

    private void FireGun()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponentInParent<Enemy>() != null)
            {

                enemy = hit.collider.gameObject.GetComponentInParent<Enemy>();

                if (enemy.Life > 0 )
                {
                    switch (hit.collider.tag)
                    {
                        case "Head":
                            enemy.TakeDamage(damage * 3);
                            break;

                        case "Legs":
                            enemy.TakeDamage(damage / 1.5f);
                            enemy.Legs -= UnityEngine.Random.Range(20, 100);
                            break;

                        case "Body":
                            enemy.TakeDamage(damage);
                            break;
                    }
                }

            }
        }

    }



}
