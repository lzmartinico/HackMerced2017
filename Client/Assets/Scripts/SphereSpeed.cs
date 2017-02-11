using System.Collections;
using UnityEngine;

public class SphereSpeed : MonoBehaviour {
    static float speed;

    
    public static float Get(){
        return speed;    
    }
    
    public static void Set(float s) {
        speed = s;
    }
    
}
