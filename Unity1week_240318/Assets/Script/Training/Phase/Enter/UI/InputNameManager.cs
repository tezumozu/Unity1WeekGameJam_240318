using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UniRx;


public class InputNameManager : MonoBehaviour{
    [SerializeField]
    GameObject DesitionUI;

    [SerializeField]
    TMP_InputField inputField;

    [SerializeField]
    CheckDesitionNameUI CheckDesitionNameUI;

    private Subject<string> inputNameSubject = new Subject<string>();
    public IObservable<string> InputNameAsync => inputNameSubject;

    public void SetActive(bool flag){
        gameObject.SetActive(flag);
        DesitionUI.SetActive(false);
    }


    public void OnPushDesitionNameButton(){
        if(String.IsNullOrWhiteSpace(inputField.text)) return;
        CheckDesitionNameUI.SetName(inputField.text);
        DesitionUI.SetActive(true);
        gameObject.SetActive(false);
    }


    public void DesitionName(){
        inputNameSubject.OnNext(inputField.text);
        SetActive(false);
    }

    public void CancelDesitionName(){
        gameObject.SetActive(true);
        DesitionUI.SetActive(false);
    }
}
