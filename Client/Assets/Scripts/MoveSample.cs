using UnityEngine;
using System.Collections;
using Leap.Unity;
using Leap;
using System;

public class MoveSample : MonoBehaviour
{
    public Material m;
    public float x;
    public float y;
    public float z;
    public float time;
    private bool fisted;
    public float movingTime;
    private bool started;

    /*private HandModel GetHand(Collider other)
    {
        if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<HandModel>())
        {
            return other.transform.parent.parent.GetComponent<HandModel>();
        }
        else
        {
            return null;
        }
    }*/



    /* void OnTriggerEnter(Collider other)
     {
         HandModel handModel = GetHand(other);
         fisted = ((handModel != null) && (handModel.GetLeapHand().GrabAngle <= (Math.PI * 0.75)));
     }*/

    /*void OnTriggerExit(Collider other)
     {
         // HandModel handModel = GetHand(other);
         //fisted = (handModel == null) ? fisted : false;

     }*/

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            fisted = true;
        }
    }

    void OnMouseExit()
    {
        fisted = false;
    }

    private void endWithSuccess()
    {
        Destroy(gameObject);
        // add full points
    }

    private void Update()
    {
        //rm when using leap momo
        LineRenderer lr = gameObject.GetComponent<LineRenderer>();
        lr.SetPosition(0, gameObject.transform.position);
        //rm when using leap momo
        if (!started && fisted && (movingTime - 0.5 <= Time.time) && (movingTime + 0.5 > Time.time))
        {
            started = true;
            iTween.MoveTo(gameObject, iTween.Hash("x", x, "y", y, "z", z, "time", time,
                                                  "easeType", "easeInOutExpo", "oncompleteobject", this.gameObject,
                                                  "delay", .1, "oncomplete", "endWithSuccess"));
        }
        else if (!started && !(movingTime + 0.5 > Time.time))
        {
            // didnt get to thing in time
            Destroy(gameObject);
        }
        else if (started && !fisted)
        {
            // left ball during movement
            Destroy(gameObject);
        }
    }



void Start(){
        //TODO instanciate it at the right time lad
        LineRenderer lr = gameObject.AddComponent<LineRenderer>();
        lr.material = new Material(m);
        if (lr.material == null)
            Debug.Log("WTF NO MATERIAL");
        Vector3[] pts = new Vector3[2];
        pts[0] = gameObject.transform.position;
        pts[1] = new Vector3(x, y, z);
        lr.numPositions = pts.Length;
        lr.SetPositions(pts);
        // A simple 2 color gradient with a fixed alpha of 1.0f.
        //float alpha = 1.0f;
       // Gradient gradient = new Gradient();
        /*gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
        lr.colorGradient = gradient;*/
        started = false;
	}
}

