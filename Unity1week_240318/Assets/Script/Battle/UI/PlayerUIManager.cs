using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : ActorUIManager{
    // Start is called before the first frame update
    Slider HPSlider;
    Text HPSliderNum;
    Slider MPSlider;
    Text MPSliderNum;

    void Start(){
        //HPbarを取得
        HPSlider = StatusBer.transform.Find("HPBer/Slider").gameObject.GetComponent<Slider>();
        HPSliderNum = StatusBer.transform.Find("HPBer/Num").gameObject.GetComponent<Text>();
        //MPbarを取得
        MPSlider = StatusBer.transform.Find("MPBer/Slider").gameObject.GetComponent<Slider>();
        MPSliderNum = StatusBer.transform.Find("MPBer/Num").gameObject.GetComponent<Text>();
        
    }

    public override void SetStatus(S_BattleActorStatus currentStatus,S_BattleActorStatus maxStatus){
        Debug.Log("test");
        HPSlider.value = (float)currentStatus.HP / (float)maxStatus.HP;
        HPSliderNum.text = currentStatus.HP.ToString();

        MPSlider.value = (float)currentStatus.MP / (float)maxStatus.MP;
        MPSliderNum.text = currentStatus.MP.ToString();
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
