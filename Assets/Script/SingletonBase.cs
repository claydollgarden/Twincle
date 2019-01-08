using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase<T>  : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                var temp = FindObjectOfType<T>();

                if(temp == null)
                {
                    temp = FindObjectOfType<GameManager>().gameObject.AddComponent<T>();

                }
                _instance = temp;
            }

            return _instance;
        }
    }
    private static T _instance;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

}
