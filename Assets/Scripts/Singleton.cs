using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = GetComponent<T>();
            Debug.Log("Creating instance of " + instance.name);
        }
        else
        {
            Debug.Log("Deleting instance of " + instance.name);
            Destroy(gameObject);
        }
    }
}