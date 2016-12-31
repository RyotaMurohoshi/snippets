using UnityEngine;
using FsUnity;

public class Main : MonoBehaviour {
	void Start () {
        Point point = new Point(0, 0);
        Debug.Log(point.X + ", " + point.Y);
	}
}
