using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Talktest : MonoBehaviour
{
    [SerializeField] private TalkSystem talkSystem01;
    [SerializeField] private TextMeshProUGUI textCountdown;
    [SerializeField] private TalkSystem talkSystem02;

    private IEnumerator Start()
    {
        textCountdown.gameObject.SetActive(false);

        yield return new WaitUntil(()=>talkSystem01.UpdateDialog());

        textCountdown.gameObject.SetActive(true);
        int count = 5;
        while (count > 0)
        {
            textCountdown.text = count.ToString();
            count --;

            yield return new WaitForSeconds(1);
        }
        textCountdown.gameObject.SetActive(false);

    }
}
