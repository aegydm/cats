using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] string start;
    // Start is called before the first frame update
    void Start()
    {
        //GameManager.Instance.Ingame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Starter()
    {
        GameManager.Instance.One("testScenes");
    }

}
