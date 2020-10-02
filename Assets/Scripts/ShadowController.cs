using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowController : MonoBehaviour
{
    public GameObject follower;
    public GameObject Player;
    public GameObject endPointShadow;
    private Vector3 startPoint;
    private float distanceBetweenStartAndEnd;
    private float StartDistance;
    GameObject rawImage;


    // Start is called before the first frame 
    void Start()
    {
        rawImage = GameObject.Find("RawImage");
        rawImage.SetActive(false);
        startPoint = transform.position;
        distanceBetweenStartAndEnd = Vector3.Distance(startPoint, endPointShadow.transform.position);
        StartDistance = Vector3.Distance(Player.transform.position, follower.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        var curDist = Vector3.Distance(Player.transform.position, follower.transform.position);
        if(curDist < StartDistance){
            var percent = curDist / (StartDistance / 100);
            Debug.Log(percent);
            if (percent <= 20)
            {
                //load image
                rawImage.SetActive(true);
                //rawImage.GetComponent<RawImage>().IsActive();
            }
            else
            {
                var upDist = (distanceBetweenStartAndEnd / 100) * (100 - percent);

                transform.position = new Vector3(Player.transform.position.x, startPoint.y + upDist, Player.transform.position.z);
            }
        }
    }
}
