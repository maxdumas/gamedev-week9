using UnityEngine;
using System.Collections;

public class GridInstantiate : MonoBehaviour {
	public GameObject FloorTilePrefab;
	public GameObject WallTilePrefab;
	public GameObject PathGeneratorPrefab;

	// Use this for initialization
	void Start () {
		EncapsulateView watcher = GameObject.Find ("Root").GetComponent<EncapsulateView>();

		float t0 = Random.Range (0.8f, 0.9f);
		float t1 = Random.Range (0.09f, 0.1f);
		for(int x = 0; x < 5; ++x) {
			for(int z = 0; z < 5; ++z) {
				var p = transform.position + new Vector3(x * 5f, 0f, z * 5f);
				float r = Random.value;
				if(r < t0) {
					Instantiate(FloorTilePrefab, p, Quaternion.identity);
				} else if(r < t0 + t1) {
					Instantiate(WallTilePrefab, p, Quaternion.identity);
				} else {
					Instantiate(PathGeneratorPrefab, p, Quaternion.identity);
				}
			}
		}
		watcher.UpdateFrustum();
		Destroy (this.gameObject);
	}
}
