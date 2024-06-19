using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class TalkSystem : MonoBehaviour
{
    [SerializeField] private int branch;
    [SerializeField] private DialogDB dialogDB;

    [SerializeField] private Speaker[] speakers;
    [SerializeField] private DialogData[] dialogs;
    [SerializeField]
    private bool isAutoStart = true;
    private bool isFirst = true;
    private int currentDialogIndex = -1;
    private int currentSpeakerIndex = 0;
    private float typingSpeed = 0.1f;
    private bool isTypingEffect = false;

    private void Awake()
    {
        int index = 0;
        for (int i = 0; i < dialogDB.Entities.Count; ++i)
        {
            if (dialogDB.Entities[i].branch == branch)
            {
                dialogs[index].speakerIndex = dialogDB.Entities[i].id;
                dialogs[index].name = dialogDB.Entities[i].name;
                dialogs[index].dialogue = dialogDB.Entities[i].dialog;
                index++;
            }
        }
        Setup();
    }

    private void Setup()
    {
        for (int i = 0; i < speakers.Length; ++i)
        {
            SetActiveObjects(speakers[i], false);
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        if (isFirst == true)
        {
            Setup();
            if ( isAutoStart)
            {
                SetNextDialog();
            }
            isFirst = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if ( isTypingEffect == true)
            {
                isTypingEffect = false;

                StopCoroutine("OnTypingText");
                speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;
            }
            if (dialogs.Length > currentDialogIndex +1)
            {
                SetNextDialog();
            }
            else
            {
                for (int i = 0; i < speakers.Length; ++i)
                {
                    SetActiveObjects(speakers[i], false);
                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                }
                return true;
            }
        }
        return false;
    }

    private void SetNextDialog()
    {
        SetActiveObjects(speakers[currentSpeakerIndex], false);

        currentDialogIndex ++;

        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

        SetActiveObjects(speakers[currentSpeakerIndex], true);

        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;

        //speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
        StartCoroutine("OnTypingText");
    }
    private void SetActiveObjects(Speaker speaker, bool visible)
    {
        speaker.imageDialog.gameObject.SetActive(visible);
        speaker.textDialogue.gameObject.SetActive(visible);
        speaker.textName.gameObject.SetActive(visible);

        speaker.objectArrow.SetActive(false);

        Color color = speaker.spriteRenderer.color;
        color.a = visible == true ? 1 : 0.2f;
        speaker.spriteRenderer.color = color;
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;
        isTypingEffect = true;
        while ( index < dialogs[currentDialogIndex].dialogue.Length )
        {
            speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue.Substring(0, index);
            index++;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTypingEffect = false;
        speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }
}

[System.Serializable]
public struct Speaker
{
    public SpriteRenderer spriteRenderer;  //캐릭터 이미지
    public Image imageDialog;              //대화창 GUI 
    public TextMeshProUGUI textName;       //화자의 이름GUI
    public TextMeshProUGUI textDialogue;   //대사 출력GUI
    public GameObject objectArrow;         //출력 완료 후 보이는 오브젝트
}
[System.Serializable]
public struct DialogData
{
    public int speakerIndex;
    public string name;
    [TextArea(3, 5)]
    public string dialogue;
}
