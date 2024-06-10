using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField] Slider Loading_bar;
    [SerializeField] float time; 
    [SerializeField] string scenenames;
    [SerializeField] GameObject Loading_bar_text;

    // Start is called before the first frame update
    void Start()
    {
        scenenames = GameManager.Instance.scenename;
        Loading_bar.maxValue = 1.0f;
        StartCoroutine(LoadScene(scenenames));
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Loading_bar.value = time;
        Loading_bar_text.transform.GetComponent<TextMeshProUGUI>().text = "Loading... " + (Mathf.Floor(time * 100f) / 100f) * 100f + "%";

    }

    IEnumerator LoadScene(string name)
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(name); // 비동기 Scene 로딩 ( 로딩할 Scene 이름 )
        op.allowSceneActivation = false;  // Scene 이 로딩 되었을때 바로 실행할지 .
        //yield return new WaitForSecondsRealtime(0.9f); // 1초 대기
        yield return new WaitForSecondsRealtime(op.progress + 0.9f); // 실제 로딩 대기 + 1초 대기
        op.allowSceneActivation = true; // 로딩된 Scene 실행.
    }

}
