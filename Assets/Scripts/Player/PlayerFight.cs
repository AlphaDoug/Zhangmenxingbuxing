using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// 枚举主角的战斗状态
/// </summary>
public enum PlayerFightState { 
    Idle,
    Atk,
    Skill,
    Damage,
    Die
}
/// <summary>
/// 控制主角战斗的类
/// </summary>
/// 

//思路
public class PlayerFight : MonoBehaviour {

    private PlayerFightState state = PlayerFightState.Idle;

    private Vector3 targetPos;//目标位置的坐标
    private Transform target;//目标
    
    private bool isDie = false;
    private bool isAtked = false;

    private Vector3 startPos;
    private Vector3 startRot;
    public Scrollbar actionBarPre;
    private GameObject actionBar;
    public GameObject skillEffect;

    public float speed;
    public float HP;
    public int attack;

    private CharacterController controller;
    private Animation anima;
    public string animName_Idle;
    public string animName_Run;
    public string animName_atk;
    public string animName_skill;
    public string animName_damage;
    public string animName_die;
    public float atkTimer;

    private Vector3 poss;
    private Vector3 rott;

    public Image Hpimg;
    void OnEnable () {
        Hpimg.fillAmount = 1;
        isDie = false;
       // Debug.Log("11111111111111111");
        isAtked = false;

        state = PlayerFightState.Idle;

        //speed = 1f;
        HP = 100;
        //attack = 20;

        startPos = transform.position;
        startRot = transform.localEulerAngles;
        poss = startPos;
        rott = startRot;

        targetPos = startPos;//一开始的目标位置是本身所在的位置
        controller=transform.GetComponent<CharacterController>();
        anima=transform.GetChild(0).GetComponent<Animation>();
        actionBar = Instantiate(actionBarPre.gameObject);
        actionBar.transform.SetParent(GameObject.Find("FightCanvas/ActionBar").transform);
        actionBar.transform.localPosition = Vector3.zero;
        actionBar.GetComponent<ActionBar>().speed = speed;
}
	
	void Update () {

        if (isDie)
        {
            state = PlayerFightState.Die;
        }
        else {
            if (actionBar.GetComponent<Scrollbar>().value == 1 && (FightManager.main.state == FightState.Computer || state == PlayerFightState.Atk))
            {
                FightManager.main.state = FightState.Player;//整个游戏的战斗状态为玩家控制
                state = PlayerFightState.Atk;
            }
            
        }
        
        switch (state)
        {
            case PlayerFightState.Idle:
                break;
            case PlayerFightState.Atk:
                PlayerAtk();
                break;
            case PlayerFightState.Skill:
                PlayerSkill();
                break;
            case PlayerFightState.Damage:
                break;
            case PlayerFightState.Die:
                StartCoroutine(waitDieEnd());
                break;
            default:
                break;
        }
	}

    public void InitialTrans()
    {
        transform.position = poss;
        transform.eulerAngles = rott;
    }

    void PlayerAtk()
    {
        if ((targetPos == startPos || target == null || target.gameObject.activeSelf == false) && isAtked==false)//如果还没有攻击过,即没有目标
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(Tags.Enemy);
          //  Debug.Log("玩家个数" + targets.Length);
            if (targets.Length > 0)
            {
                target = targets[Random.Range(0, targets.Length)].transform;
                targetPos = target.transform.position;
            }
        }
        else
        {
            float dis = Vector3.Distance(targetPos,transform.position);
            if (dis > 1.5f)
            {
                if (targetPos != null)
                {
                    transform.LookAt(targetPos);
                    controller.SimpleMove(transform.forward * 15f);
                    anima.CrossFade(animName_Run);
                }
            }
            else {
                if (targetPos == startPos)
                {
                    anima.CrossFade(animName_Idle);
                    transform.localEulerAngles = startRot;
                    transform.localPosition = startPos;
                    OnRsetState();
                    actionBar.GetComponent<Scrollbar>().value = 0;
                    state = PlayerFightState.Idle;
                    isAtked = false;
                    if(target!=null)
                    targetPos = target.transform.position;

                }
                else {
                    StartCoroutine(WaitAtkEnd());
                }
            }
           
        }
    }

    //技能
    void PlayerSkill()
    {
        if (target == null && isAtked == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.tag == Tags.Enemy)
                    {
                        target = hitInfo.collider.gameObject.transform;
                    }
                }
            }
        }
        else {
            StartCoroutine(WaitSkillEnd());
        }
    }

    /*//对外接口——普通攻击（战斗菜单的按钮事件，点击 攻击 ，会调用此方法）
    public void OnAttack()
    {
        state = PlayerFightState.Atk;
        isAtked = false;
    }
    //对外接口——技能攻击
    public void OnSkill()
    {
        state = PlayerFightState.Skill;
        isAtked = false;
    }*/

    IEnumerator WaitAtkEnd()
    {
        anima.CrossFade(animName_atk);
        Facade.Instance.PlayNormalSound(AudioManager.Sound_People);
        yield return new WaitForSeconds(atkTimer);
        if (isAtked == false)
        {
            if(target!=null)
            target.gameObject.SendMessage("OnDamage",attack);
            isAtked = true;
        }
        targetPos = startPos;
        target = null;
    }

    IEnumerator WaitSkillEnd()
    {
        anima.CrossFade(animName_skill);
        yield return new WaitForSeconds(anima.GetClip(animName_skill).length);
        if (isAtked == false)
        {
            Instantiate(skillEffect, target.position, Quaternion.identity);
            target.gameObject.SendMessage("OnDamage",attack*2);
            isAtked = true;
        }
        target = null;
        OnRsetState();
    }
    

    void OnRsetState()
    {
        anima.CrossFade(animName_Idle);
        FightManager.main.FinishRound();
        actionBar.GetComponent<Scrollbar>().value = 0;
        state = PlayerFightState.Idle;
    }
    

    public void OnDamage(int value = 10)
    {
        if (isDie) return;
        StartCoroutine(waitDamageEnd());
        HP -= value;
        Hpimg.fillAmount -= (float)value / 100;
        if (HP <= 0)
        {
            isDie = true;
            FightManager.main.CostPlayerCount();
        }
    }

    IEnumerator waitDamageEnd()
    {
        anima.CrossFade(animName_damage);
        yield return new WaitForSeconds(anima.GetClip( animName_damage).length);
        anima.CrossFade(animName_Idle);
    }

    IEnumerator waitDieEnd()
    {
        anima.CrossFade(animName_die);
        yield return new WaitForSeconds(anima.GetClip(animName_die).length);
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false);
        Destroy(actionBar);
    }
}
