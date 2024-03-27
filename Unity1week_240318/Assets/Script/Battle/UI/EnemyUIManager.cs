using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : ActorUIManager{

    // Start is called before the first frame update
    void Start(){
        //HPbarを取得
        HPSlider = StatusBer.transform.Find("Slider").gameObject.GetComponent<Slider>();
    }

    public override void SetStatus(S_BattleActorStatus currentStatus , S_BattleActorStatus maxStatus){
        HPSlider.value = (float)currentStatus.HP / (float)maxStatus.HP;
    }

    public override void SetBuffList(IEnumerable<BattleBuff> buffList){
        buffListUIManager.SetList(buffList,false);
    }
}
