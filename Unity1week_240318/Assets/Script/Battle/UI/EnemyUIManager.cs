using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManager : ActorUIManager{

    Slider HPSlider;
    Text HPSliderNum;

    // Start is called before the first frame update
    void Start(){
        //HPbarを取得
        HPSlider = StatusBer.transform.Find("Slider").gameObject.GetComponent<Slider>();
    }

    public override void SetStatus(S_BattleActorStatus currentStatus , S_BattleActorStatus maxStatus){
        HPSlider.value = (float)currentStatus.HP / (float)maxStatus.HP;
    }

    public override void SetActiveBeforeStatusEffect(E_BeforeStatusEffect type,bool flag){

    }

    public override void SetActiveAfterStatusEffect(E_AfterStatusEffect type,bool flag){

    }

    public override void UpdateBuff(List<E_Buff> buffList){

    }

    public override IEnumerator StartActorAnim(E_ActorAnim anim){
        yield return null;
    }
}
