using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    // ==================== VARIABLES ===================
	private static T instance;
	private static readonly object instanceLock = new object();
	private static bool quitting = false;

	public static T Instance {
		get {
			lock (instanceLock) {
				if (instance==null && !quitting) {

					instance = GameObject.FindObjectOfType<T>();
					if (instance == null) {
						GameObject _go = new GameObject(typeof(T).ToString());
						instance = _go.AddComponent<T>();

						DontDestroyOnLoad(instance.gameObject);
					}
				}

				return instance;
			}
		}
	}

    // ==================== INICIO ====================
	protected virtual void Awake() {
		if (instance==null) instance = gameObject.GetComponent<T>();
		else if (instance.GetInstanceID() != GetInstanceID()) {
			Destroy(gameObject);
			throw new System.Exception(string.Format("Instance of {0} already exists, removing {1}",GetType().FullName,ToString()));
		}
	}

	protected virtual void OnApplicationQuit() {
		quitting = true;
	}
}