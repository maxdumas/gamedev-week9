using UnityEngine;
using System.Collections;

public class EncapsulateView : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void UpdateFrustum () {
		GameObject[] generators = GameObject.FindGameObjectsWithTag("Generated");
		if(generators.Length > 0) {
			Vector3 p = generators[0].transform.position;
			float minx = p.x, miny = p.y, minz = p.z,
				maxx = p.x, maxy = p.y, maxz = p.z;
			Vector3 centroid = Vector3.zero;
			foreach(var g in generators) {
				Vector3 q = g.transform.position;
				minx = Mathf.Min (minx, q.x);
				miny = Mathf.Min (miny, q.y);
				minz = Mathf.Min (minz, q.z);

				maxx = Mathf.Max (maxx, q.x);
				maxy = Mathf.Max (maxy, q.y);
				maxz = Mathf.Max (maxz, q.z);

				centroid += q;
			}
			centroid /= generators.Length;
			Vector3 a = new Vector3(maxx, maxy, maxz);
			Vector3 b = new Vector3(minx, miny, minz);
			Camera.main.orthographicSize = (a - b).magnitude / 2f;
			if(Camera.main.orthographicSize < 0.05f) {
				Camera.main.orthographicSize = 1f;
			}
			this.transform.position = centroid;
		}
	}
}
