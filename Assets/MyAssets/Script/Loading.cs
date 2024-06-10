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
        AsyncOperation op = SceneManager.LoadSceneAsync(name); // �񵿱� Scene �ε� ( �ε��� Scene �̸� )
        op.allowSceneActivation = false;  // Scene �� �ε� �Ǿ����� �ٷ� �������� .
        //yield return new WaitForSecondsRealtime(0.9f); // 1�� ���
        yield return new WaitForSecondsRealtime(op.progress + 0.9f); // ���� �ε� ��� + 1�� ���
        op.allowSceneActivation = true; // �ε��� Scene ����.
    }

}
