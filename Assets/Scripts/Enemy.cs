using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject gameManager;
    private GameManager gm;

    public GameObject bullet;
    private GameObject player;

    private void Start()
    {
        gameManager = GameObject.Find("Game Manager");
        gm = gameManager.GetComponent<GameManager>();
        player = GameObject.Find("Player");
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            if (Vector3.Distance(transform.position, player.transform.position) < 30)
            {
                Vector3 dir = player.transform.position - transform.position;
                //Instantiate(bullet, transform.position, Quaternion.LookRotation(dir));
                GameObject newBullet = Instantiate(bullet, transform.position, bullet.transform.rotation);
                newBullet.transform.forward = dir;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("utkozes");
            gm.GameOver();
        }
    }
}
