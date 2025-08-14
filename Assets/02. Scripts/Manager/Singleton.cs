using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    protected abstract bool isDestroy { get;}

    private static T _instance;
    public static  T Instance
    {
        get
        {
            // === 싱글톤 인스턴스를 보장하기 위해서===
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    singletonObject.name = typeof(T).ToString();
                    _instance = singletonObject.AddComponent<T>();
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        // === 중복 생성 방지 ===
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this as T;
        if(!isDestroy)
            DontDestroyOnLoad(gameObject);
    }
}
