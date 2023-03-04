using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public float range = 100f;
    public Camera fpsCam;

    //Efectos
    public GameObject impactEffect;
    public ParticleSystem flashEffect; //crea las particulas
    public AudioSource _audSource; //crea el sonido del disparo
    
    public AudioClip _clip_Disparo;//salida del disparo
    public AudioClip _Clip_Impacto;//impacto del disparo
        void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
        if(Input.GetMouseButtonDown(1))
        {
            Disparar2();
        }
    }
    void Disparar()
    {
        RaycastHit hit;
        AudioPlay(_clip_Disparo);
        flashEffect.Play();

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
     {
        //Debug.Log (hit.transform.name);// Para testear contra que coliciono
          if(hit.transform.tag == "Enemigo")
        {
            hit.transform.gameObject.GetComponent<Enemigo>().vidaEnemigo -= 5;
            GameObject impactGO = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,4f);//tiempo de destruccion del GameObj.
        }
        if(hit.transform.tag == "Blanco")
        {
            AudioPlay(_Clip_Impacto);
            hit.transform.gameObject.GetComponent<Blanco>().vidaBlanco -= 10;
            GameObject impactGO = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,4f);
        }
        
     }
     void AudioPlay(AudioClip _clip_Test)
     {
        _audSource.clip = _clip_Test;
        _audSource.Play();
     }

     }
    void Disparar2()
    {
        RaycastHit hit;
        AudioPlay(_clip_Disparo);
        flashEffect.Play();

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
     {
       
        if(hit.transform.tag == "Blanco")
        {
            AudioPlay(_Clip_Impacto);
            hit.transform.gameObject.GetComponent<Blanco>().vidaBlanco -= 10;
            GameObject impactGO = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
            Destroy(impactGO,4f);
        }
        
     }
     void AudioPlay(AudioClip _clip_Test)
     {
        _audSource.clip = _clip_Test;
        _audSource.Play();
     }

     }
}
