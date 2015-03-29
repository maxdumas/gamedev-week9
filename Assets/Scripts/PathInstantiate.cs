using UnityEngine;
using System.Collections;

public class PathInstantiate : MonoBehaviour {

	public GameObject FloorTilePrefab;
	public GameObject GridGeneratorPrefab;

	private EncapsulateView _watcher;
	private int _counter = 0;
	private float _t;
	private float _l, _r;

	void Start() {
		_watcher = GameObject.Find("Root").GetComponent<EncapsulateView>();

		_l = Random.Range(0.1f, 0.2f);
		_r = Random.Range (0.1f, 0.3f);
		_t = Random.Range (0.9f, 1f);
	}

	void Update () {
		if(_counter++ < 50) {
			float r0 = Random.value;
			if(r0 < _l) {
				transform.Rotate(transform.up, 90f);
			} else if (r0 < _l + _r) {
				transform.Rotate(transform.up, -90f);
			}
			float r1 = Random.value;
			if(r1 < _t) {
				Instantiate(FloorTilePrefab, transform.position, transform.rotation);
				transform.position += transform.forward * 5f;
				_watcher.UpdateFrustum();
			} else {
				Instantiate(GridGeneratorPrefab, transform.position, transform.rotation);
				_watcher.UpdateFrustum();
				Destroy (this.gameObject);
			}
		} else {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		Destroy (other.gameObject);
    }
}
