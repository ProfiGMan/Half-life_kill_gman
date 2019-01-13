using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Camera cam;
    public GameObject[] WallsOnLeft;
    public GameObject[] WallsOnRight;
    public GameObject[] Ceiling;
    public bool[] CeilingLine;
    public GameObject[] Ground;
    public bool[] GroundLine;

    public GameObject player;       //Public variable to store a reference to the player game object
    public float offsetBeforeMovingH = 5f;
    public float offsetBeforeMovingV = 3.5f;

    void Update () 
    {
        bool leftWallSeen = false;
        bool rightWallSeen = false;

        foreach(GameObject wall in WallsOnLeft)
        {
            leftWallSeen = isVisible(wall);
            if(leftWallSeen) break;
        }

        foreach(GameObject wall in WallsOnRight)
        {
            rightWallSeen = isVisible(wall);
            if(rightWallSeen) break;
        }

        bool ceilingSeen = false;
        bool groundSeen = false;

        if(Ceiling.Length > 0)
        foreach(GameObject wall in Ceiling)
        {
            ceilingSeen = isVisible(wall);
            if(ceilingSeen) break;
        }

        foreach(GameObject wall in Ground)
        {
            groundSeen = isGroundVisible(wall);
            if(groundSeen) break;
        }

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 pos = transform.position;

        Vector3 offset = transform.position - player.transform.position;

        if(offset.x < -offsetBeforeMovingH && !rightWallSeen) 
            pos.x = player.transform.position.x - offsetBeforeMovingH;
        else if(offset.x > offsetBeforeMovingH && !leftWallSeen) 
            pos.x = player.transform.position.x + offsetBeforeMovingH;
        else pos.x = transform.position.x;
        
        if(offset.y < -offsetBeforeMovingV && !ceilingSeen) 
            pos.y = player.transform.position.y - offsetBeforeMovingV;
        else if(offset.y > offsetBeforeMovingV && !groundSeen) 
            pos.y = player.transform.position.y + offsetBeforeMovingV;
        else pos.y = transform.position.y;

        transform.position = pos;
    }

    bool isVisible(GameObject obj)
    {
        return obj.GetComponent<Renderer>().isVisible;
    }

    bool isGroundVisible(GameObject obj)
    {
        if(isVisible(obj))
        {
            float rightGroundBorderPos = 
                obj.transform.position.x + obj.GetComponent<SpriteRenderer>().
                bounds.size.x / 2;
            float leftGroundBorderPos = 
                obj.transform.position.x - obj.GetComponent<SpriteRenderer>().
                bounds.size.x / 2;
            if(player.transform.position.x >= leftGroundBorderPos &&
            player.transform.position.x <= rightGroundBorderPos) 
            {
                return true;
            }
        }
        return false;
    }
}