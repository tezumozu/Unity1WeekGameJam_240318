using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class BattleActor : I_DamageApplicable , IDisposable{

    protected S_BattleActorStatus maxStatus;
    protected S_BattleActorStatus currentStatus;
    protected BeforeStatusEffect currentBeforeStatusEffect;
    protected AfterStatusEffect currentAfterStatusEffect;
    protected List<E_ActionType> skillList;
    protected Dictionary<E_Buff,BattleBuff> buffDic;
    protected BattleActorAction currentAction;


    protected I_ActionCreatable actionFactory;
    protected I_StatusEffectCreatable statusEffectFactory;
    protected I_BuffCreatable buffFactory;


    //UI更新用
    protected ActorUIManager statusUIManager;
    protected BattleTextManager textUIManager;
    protected BattleUIManager uiManager;
    protected BattleInputManager inputManager;
    protected ActorAnimManager actorAnimManager;

    protected bool isFinishAnim;

    protected IDisposable finishAnimDispose;


    //Subjects
    private Subject<Unit> isDeadSubject;
    public IObservable<Unit> isDeadAsync => isDeadSubject;


    public S_BattleActorStatus GetMaxStatus{
        get{ return maxStatus; }
    }

    public S_BattleActorStatus GetCurrentStatus{
        get{ return currentStatus; }
    }

    public E_BeforeStatusEffect GetCurrentBeforeStatusEffect{
        get{ return currentBeforeStatusEffect.EffectData.EffectType; }
    }

    public E_AfterStatusEffect GetCurrentAftoreStatusEffect{
        get{ return currentAfterStatusEffect.EffectData.EffectType; }
    }

    public List<E_ActionType> GetSkillList{
        get{ return new List<E_ActionType>(skillList); }
    }

    public Dictionary<E_Buff,BattleBuff> GetBuffDic{
        get{ return new Dictionary<E_Buff,BattleBuff>(buffDic); }
    }


    public BattleActor(I_ActionCreatable actionFactory,I_BuffCreatable buffFactory,I_StatusEffectCreatable statusEffectFactory){
        isDeadSubject = new Subject<Unit>();
        skillList = new List<E_ActionType>();
        buffDic = new Dictionary<E_Buff,BattleBuff>();

        this.actionFactory = actionFactory;
        this.buffFactory = buffFactory;
        this.statusEffectFactory = statusEffectFactory;

        //null対策
        currentAction = actionFactory.CreateAction(E_ActionType.Attack);

        //状態異常をリセット
        currentBeforeStatusEffect = this.statusEffectFactory.CreateEffect(E_BeforeStatusEffect.Non);
        currentAfterStatusEffect = this.statusEffectFactory.CreateEffect(E_AfterStatusEffect.Non);

        //マネージャの取得
        uiManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleUIManager>();
        textUIManager = GameObject.Find("Canvas/BattleUI").GetComponent<BattleTextManager>();
        inputManager = GameObject.Find("BattleInputManager").GetComponent<BattleInputManager>();
    }


    public abstract IEnumerator SetNextAction();


    public virtual IEnumerator ActionBattleActor(BattleActor defender){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        if(currentAction.ActionData.IsStatusEffectApplicable){
            //状態異常を回復する
            ClearEffect();
        }else{
            //状態異常の影響をチェック;
            currentAction = currentBeforeStatusEffect.AppliyEffect(currentAction);
        }

        //アクションのコスト分、ＭＰを消費する
        currentStatus.MP = currentStatus.MP - currentAction.ActionData.Cost;

        //ステータスをバフごとに補正
        S_BattleActorStatus effectedStatus = currentStatus;

        foreach (var item in buffDic){
           effectedStatus = item.Value.EffectedBuff(effectedStatus,currentAction);
        }

        //アクションを使用する
        //テキスト変更
        textUIManager.SetText(currentStatus.Name + " " + currentAction.ActionData.ActionSkillText);


        //クリック待ちとアニメーション終了待ちをする
        isFinishAnim = false;

        actorAnimManager.StartAttackAnim();

        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());
        

        while(!isFinishAnim){
            yield return null;
        }

        //UIの更新
        statusUIManager.SetStatus(currentStatus,maxStatus);
        

        //アクションの成功判定
        if(!currentAction.checkSuccess(this,defender)){
            textUIManager.SetText("しかし、うまく決まらなかった！");

            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());
        }else{

            //クリティカル判定
            if(currentAction.CheckCritical(effectedStatus)){
                textUIManager.SetText("クリティカル！");

                yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());
            }

            //ボーナスチェック
            effectedStatus = currentAction.CheckBonus(effectedStatus,this,defender);

            //アクションの実行 アクションの終了待ちをする
            yield return currentAction.UseAction(effectedStatus,this,defender);
        }

        //反動ダメージなどを考慮してUI更新
        statusUIManager.SetStatus(currentStatus,maxStatus);

    }



    //状態異常Aの処理
    public virtual IEnumerator CheckBeforeStatusEffect(){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        if(currentBeforeStatusEffect.EffectData.EffectType != E_BeforeStatusEffect.Non){

            //テキスト変更
            textUIManager.SetText(currentStatus.Name + " " + currentBeforeStatusEffect.EffectData.EffectAplliyText);

            //クリック待ちをする
            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());
        }
        
        yield return null;
    }


    //状態異常Bの処理
    public virtual IEnumerator CheckAfterStatusEffect(){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        if(currentAfterStatusEffect.EffectData.EffectType == E_AfterStatusEffect.Non){
            yield break;
        }

        //テキスト変更
        textUIManager.SetText(currentStatus.Name + " " + currentAfterStatusEffect.EffectData.EffectText);

        //クリック待ちをする
        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        //状態異常の処理
        yield return currentAfterStatusEffect.AppliyEffect(this);
    }



    //バフや状態異常の継続に関する処理
    public virtual IEnumerator RefreshBattleActor(){

        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //バフの更新
        var keys = buffDic.Keys;
        foreach (var key in keys){
            if(!buffDic[key].CheckContinueBuff()){
                buffDic.Remove(key);
            }
        }

        statusUIManager.SetBuffList(buffDic.Values);


        //状態異常の更新
        if(!currentBeforeStatusEffect.CheckContinueEffect()){
            //テキスト変更
            textUIManager.SetText(currentStatus.Name + " " + currentBeforeStatusEffect.EffectData.EffectRecoveryText);

            //クリック待ちをする
            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

            currentBeforeStatusEffect = statusEffectFactory.CreateEffect(E_BeforeStatusEffect.Non);
        }

        statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);



        if(!currentAfterStatusEffect.CheckContinueEffect()){
            //テキスト変更
            textUIManager.SetText(currentStatus.Name + " " + currentAfterStatusEffect.EffectData.EffectRecoveryText);

            //クリック待ちをする
            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

            currentAfterStatusEffect = statusEffectFactory.CreateEffect(E_AfterStatusEffect.Non);
        }

        //UI更新
        statusUIManager.SetAfterStatusEffect(currentAfterStatusEffect.EffectData);

        yield return null;
    }



    //I_DamageApplicable
    //ダメージを受ける
    public IEnumerator AppliyDamage(int attackPoint,E_Element elementType){

        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //防御力を計算
        //ステータスをバフごとに補正
        S_BattleActorStatus effectedStatus = currentStatus;

        foreach (var item in buffDic){
           effectedStatus = item.Value.EffectedBuff(effectedStatus);
        }

        int defensePoint = (int)((float)effectedStatus.Defense * (float)effectedStatus.ElementResistanceRateDic[elementType] * 0.5);

        //ダメージ計算
        int damage = (int)((float)attackPoint / (float)defensePoint * getDamageRamd()) + 1;

        //HP減少
        currentStatus.HP = currentStatus.HP - damage;

        if(currentStatus.HP <= 0){
            currentStatus.HP = 0;
        }

        //クリック待ちとアニメーション終了待ちをする
        isFinishAnim = false;

        actorAnimManager.StartDamagedAnim();

        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        while(!isFinishAnim){
            yield return null;
        }

        //UIの更新
        statusUIManager.SetStatus(currentStatus,maxStatus);
        
        //Text変更
        textUIManager.SetText(currentStatus.Name + " は " + damage + " ポイントのダメージを受けた！");

       //クリック待ち
        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        //もし倒されたら
        if(currentStatus.HP <= 0){
            currentStatus.HP = 0;

            //クリック待ちとアニメーション終了待ちをする
            isFinishAnim = false;

            actorAnimManager.StartDeadAnim();

            while(!isFinishAnim){
                yield return null;
            }

            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

            //Text変更
            textUIManager.SetText(currentStatus.Name + " は たおれた！");

            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

            isDeadSubject.OnNext(Unit.Default);
        }

        yield return damage;
    }



//ダメージを回復
    public IEnumerator AppliyHeel(int HeelPoint){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //HP回復
        currentStatus.HP = currentStatus.HP + HeelPoint;

        //UIの更新
        statusUIManager.SetStatus(currentStatus,maxStatus);
        
        //Text変更
        textUIManager.SetText(currentStatus.Name + " はHPが " + HeelPoint + " ポイント回復した！");

        //クリック待ちをする
        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());
    }



    //バフ・デバフを受ける
    public IEnumerator AppliyBuff(E_Buff buffType,int turn){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        //Buffを取得
        var buff = buffFactory.CreateBuff(buffType,turn);
        buffDic.Add(buffType,buff);

        //Text変更
        textUIManager.SetText(currentStatus.Name + " " + buff.BuffData.BuffText);

        //クリック待ちをする
        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        statusUIManager.SetBuffList(buffDic.Values);

        yield return null;
    }



    //状態異常Aを受ける
    public IEnumerator AppliyEffect(E_BeforeStatusEffect effectType){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);
        var effect = statusEffectFactory.CreateEffect(effectType);

        //状態異常を防ぐか確認
        if(currentBeforeStatusEffect.EffectData.EffectType == E_BeforeStatusEffect.EffectProtect){
            //Text変更
            textUIManager.SetText(currentStatus.Name + " は " + effect.EffectData.EffectName + " を防いだ");

            //クリック待ちをする
            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        }else{
            currentBeforeStatusEffect = effect;

            //Text変更
            textUIManager.SetText(currentStatus.Name + " は " + currentBeforeStatusEffect.EffectData.EffectName + " を受けた！");

            //クリック待ちをする
            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

            statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);
        }
    }



    //状態異常Bを受ける
    public IEnumerator AppliyEffect(E_AfterStatusEffect effectType){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        var effect = statusEffectFactory.CreateEffect(effectType);

        //状態異常を防ぐか確認
        if(currentAfterStatusEffect.EffectData.EffectType == E_AfterStatusEffect.EffectProtect){
            //Text変更
            textUIManager.SetText(currentStatus.Name + " は " + effect.EffectData.EffectName + " を防いだ");

            //クリック待ちをする
            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

        }else{
            currentAfterStatusEffect = effect;

            //Text変更
            textUIManager.SetText(currentStatus.Name + " は " + effect.EffectData.EffectName + " を受けた！");

            //クリック待ちをする
            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());

            statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);
        }
    }


    //バフを消す
    public IEnumerator ClearBuff(){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);

        buffDic.Clear();
        
        //UI変更
        statusUIManager.SetBuffList(buffDic.Values);
        //Text変更
        textUIManager.SetText(currentStatus.Name + " の能力値変化がもとに戻った！");

        //クリック待ちをする
        yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());
        
    }



    //状態異常を消す
    public IEnumerator ClearEffect(){
        //UI切り替え
        uiManager.ChangeUI(E_BattleUIType.Text);


        if(!(currentBeforeStatusEffect.EffectData.EffectType == E_BeforeStatusEffect.Non) && !(currentBeforeStatusEffect.EffectData.EffectType == E_BeforeStatusEffect.EffectProtect)){
            //Text変更
            textUIManager.SetText(currentStatus.Name + " " + currentBeforeStatusEffect.EffectData.EffectRecoveryText);
            currentBeforeStatusEffect = statusEffectFactory.CreateEffect(E_BeforeStatusEffect.Non);

            //UI更新
            statusUIManager.SetBeforeStatusEffect(currentBeforeStatusEffect.EffectData);

            //クリック待ちをする
            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());
        }


        if(!(currentAfterStatusEffect.EffectData.EffectType == E_AfterStatusEffect.Non) && !(currentAfterStatusEffect.EffectData.EffectType == E_AfterStatusEffect.EffectProtect)){
            //Text変更
            textUIManager.SetText(currentStatus.Name + " " + currentAfterStatusEffect.EffectData.EffectRecoveryText);
            currentAfterStatusEffect = statusEffectFactory.CreateEffect(E_AfterStatusEffect.Non);

            //UI更新
            statusUIManager.SetAfterStatusEffect(currentAfterStatusEffect.EffectData);

            //クリック待ちをする
            yield return CoroutineHander.OrderStartCoroutine(inputManager.WaitClickInput());
        }
        
    }


    protected float getDamageRamd (){
        return UnityEngine.Random.Range( 0.8f , 1.2f );
    }



    public virtual void Dispose(){
        if( !(finishAnimDispose is null) )finishAnimDispose.Dispose();
    }
}
