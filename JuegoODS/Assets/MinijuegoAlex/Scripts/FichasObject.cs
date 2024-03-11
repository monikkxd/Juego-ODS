using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FichasObject : MonoBehaviour
{
    public bool PuedePresionar;

    public KeyCode TeclaPulsar;

    public GameObject HitEffect;

    public GameObject GoodEffect;

    public GameObject PerfectEffect;

    public GameObject MissedEffect;

    public GameObject pruebasefecto;
    

    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetKeyDown(TeclaPulsar))
        {
            if (PuedePresionar)
            {
                gameObject.SetActive(false);

                
                if(transform.position.y >= 0.70 || transform.position.y <= 0.30)
                {
                    Debug.Log("hit");
                    GameManagerAlex.instance.NormalHit();
                    Instantiate(HitEffect, transform.position, HitEffect.transform.rotation);
                    Instantiate(pruebasefecto, pruebasefecto.transform.position, pruebasefecto.transform.rotation);
                }
                else if (transform.position.y < 0.70 && transform.position.y >= 0.6 || transform.position.y > 0.30 && transform.position.y <= 0.4)
                {
                    Debug.Log("good");
                    GameManagerAlex.instance.GoodHit();
                    Instantiate(GoodEffect, transform.position, GoodEffect.transform.rotation);
                    Instantiate(pruebasefecto, pruebasefecto.transform.position, pruebasefecto.transform.rotation);
                }
                else if (transform.position.y < 0.60 && transform.position.y >= 0.50 || transform.position.y > 0.40 && transform.position.y <= 0.50)
                {
                    Debug.Log("Perfe");
                    GameManagerAlex.instance.PerfeHit();
                    Instantiate(PerfectEffect, transform.position, PerfectEffect.transform.rotation);
                    Instantiate(pruebasefecto, pruebasefecto.transform.position, pruebasefecto.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Pulsable")
        {
            PuedePresionar = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.activeInHierarchy)
        {
            if (collision.tag == "Pulsable")
            {
                PuedePresionar = false;

                GameManagerAlex.instance.Missed();
                Instantiate(MissedEffect, new Vector2 (transform.position.x, transform.position.y + 0.5f), MissedEffect.transform.rotation);
            }
        }
        
    }
}
