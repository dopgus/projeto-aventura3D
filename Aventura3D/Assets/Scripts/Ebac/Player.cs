using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject projectile;
    public Vector3 dir;

    public PoolManager poolManager;

    public bool canMove = false;

    public MeshRenderer meshRenderer;

    public int deathNumber = 0;

    public void ChangeColor(Color c)
    {
        meshRenderer.material.SetColor("_Color", c);
    }

    public void OnDestroy()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(dir * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-dir * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        var obj = poolManager.GetPooledObject();
        obj.SetActive(true);
        obj.GetComponent<Projectile>().StartProjectile();
        obj.GetComponent<Projectile>().OnHitTarget = CountDeaths;
        //obj.transform.SetParent(null);
        obj.transform.position = shootPoint.transform.position;
    }
    private void CountDeaths()
    {
        deathNumber++;
        Debug.Log("Count "+deathNumber);
    }
}
