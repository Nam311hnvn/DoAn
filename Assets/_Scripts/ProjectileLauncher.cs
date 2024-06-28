using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;
    public bool isBow1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isBow1 = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            isBow1 = false;
        }

    }

    public void FireProjectile()
    {


        //clone obj va tra ve obj
        GameObject projectile = Instantiate(isBow1?projectilePrefab:projectilePrefab2, launchPoint.position, projectilePrefab.transform.rotation);//(nhan ban obj,spawn,copy def rotation to obj)


        Vector3 orgScale = projectile.transform.localScale;

        projectile.transform.localScale = new Vector3(orgScale.x * transform.localScale.x > 0 ? 1 : -1, orgScale.y, orgScale.z);
    }


}
