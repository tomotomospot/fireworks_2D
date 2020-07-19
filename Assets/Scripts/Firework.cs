using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Firework : MonoBehaviour
{

    [FormerlySerializedAs("Train")] public GameObject[] train;

    // クリックした位置座標
    private Vector3 _clickPosition;
    private int _number;
    private int _count;
   // public float lifetime;

    void Start()
    {
        _count = 0;
        SoundManager.Instance.PlayBGM(0);
    }

    void Awake()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickPosition = Input.mousePosition;
            _clickPosition.y = 0f;
            _clickPosition.z = 10f;

            //number = Random.Range(0, Train.Length); ランダム処理
            var transform1 = transform;
            Instantiate(train[_count], transform1.position, transform1.rotation);
            StartCoroutine("Firework_SE");
            if (_count >= train.Length - 1)
            {
                _count = 0;
            }
            else
            {
                _count++;
            }

            //Instantiate(Train[number], Camera.main.ScreenToWorldPoint(clickPosition), Train[number].transform.rotation);
            //Destroy(gameObject, lifetime);
        }

    }

    // コルーチン  
    private IEnumerator Firework_SE()
    {
        yield return new WaitForSeconds(3.0f);
        // コルーチンの処理  
        //SoundManager.Instance.PlayBGM(0);
        Debug.Log("2");
        SoundManager.Instance.PlaySE(0);
    }

}


