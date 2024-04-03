using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class InputNameManager : MonoBehaviour{
    private Subject<string> inputNameSubject = new Subject<string>();
    public IObservable<string> InputNameAsync => inputNameSubject;
}
