using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blanco : MonoBehaviour
{
    public float vidaBlanco= 100;

   public GameObject efectoExplosion;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaBlanco <=0)
        {
          GameObject explosionEnemigo =  Instantiate(efectoExplosion, transform.position, transform.rotation);
          Destroy(explosionEnemigo,7);
          Destroy(gameObject);
        }

    }
}
