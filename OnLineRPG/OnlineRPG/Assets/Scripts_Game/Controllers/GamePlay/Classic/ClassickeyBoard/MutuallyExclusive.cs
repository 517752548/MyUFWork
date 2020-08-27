using UnityEngine;

public class MutuallyExclusive : MonoBehaviour {
	public GameObject[] exclusives;
	private void OnEnable()
	{
		foreach (var go in exclusives) {
			go.SetActive(false);
		}
	}

	private void OnDisable()
	{
		foreach (var go in exclusives) {
			go.SetActive(true);
		}
	}
	private void OnDestroy()
	{
		foreach (var go in exclusives) {
			go.SetActive(true);
		}
	}
}