using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//tham khao cua AdamCyounis
public class ParallaxEffect : MonoBehaviour
{   //ParallaxEffect: hieu ung cuon song song dung de di chuyen BG khi player move
    public Camera cam;
    public Transform followTarget;

    //diem bat dau cho parallax game object
    Vector2 startingPosition;

    //gia tri Z cho parallax game object 
    float startingZ;

    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    float zDistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    //Nếu obj đứng trc target dùng nearClip,đứng sau dùng farClip 
    float clippingPlane => (cam.transform.position.z+ (zDistanceFromTarget>0? cam.farClipPlane : cam.nearClipPlane));
    //obj cách càng xa người chơi, di chuyển càng nhanh
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlane;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //target di chuyển , parallax object di chuyển nhanh dần theo cấp số nhân 
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;

        // X,Y thay đổi dựa theo vận tốc target*parallaxfactor,z giữ nguyên
        transform.position = new Vector3(newPosition.x,newPosition.y,startingZ);
    }
}
