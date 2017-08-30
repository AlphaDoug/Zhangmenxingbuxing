using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public enum EnemyFightState { 
    Idle,
    Atkgo,
    Atkback,
    Die
}
public class EnemyFight : MonoBehaviour {

    public EnemyFightState state = EnemyFightState.Idle;

    private Transform target;
    private Vector3 targetPos;
    private Vector3 startPos;
    private Vector3 startRot;

    public float speed=1;
    private bool isAtk=false;
    private bool isDie = false;

    public float HP = 100;
    public int attack = 10;

    public GameObject actionBarPre;
    public GameObject actionBar;

    private Animation anima;
    public string animName_idle;
    public string animName_atk;
    public string animName_run;
    public string animName_die;
    public string animName_damege;
    private bool abc;

    private Vector3 poss;
    private Vector3 rott;

    public Image Hpimg;

    void OnEnable () {
        Hpimg.fillAmount = 1;
        abc = false;
        state = EnemyFightState.Idle;
        isAtk = false;
         isDie = false;
         HP = 100;
             //attack = 10;
             //speed = 1;
        startPos = transform.position;
        startRot = transform.localEulerAngles;
        poss = startPos;
        rott = startRot;
        anima=transform.GetChild(0).GetComponent<Animation>();
        actionBar = Instantiate(actionBarPre.gameObject);
        actionBar.transform.SetParent(GameObject.Find("FightCanvas/ActionBar").transform);
        actionBar.transform.localPosition = Vector3.zero;
        actionBar.GetComponent<ActionBar>().speed = speed;
        target = null;
}
	
	void Update () {
        
        if (isDie)//如果死了切换状态为死亡
        {
            state = EnemyFightState.Die;
        }
        else {
           // Debug.Log(state);
            if (actionBar.GetComponent<Scrollbar>().value == 1 && (FightManager.main.state == FightState.Computer || abc == true))
            {
                abc = true;
                FightManager.main.state = FightState.Enemy;//把整个游戏的战斗状态为敌人控制
                state = EnemyFightState.Atkgo;//敌人状态切换为攻击状态
            }
        }

        switch (state)
        {
            case EnemyFightState.Idle:
                break;
            case EnemyFightState.Atkgo:
                OnAtk();
                break;
            case EnemyFightState.Atkback:
                OnAtk();
                break;
            case EnemyFightState.Die:
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
    void OnAtk()
    {
        if (target == null || target.gameObject.activeSelf==false)//如果还没有攻击过,即没有目标
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(Tags.Player);//寻找主角
            //Debug.Log("玩家个数" + targets.Length);
            if (targets.Length > 0)
            {
                target = targets[Random.Range(0, targets.Length)].transform;
                targetPos = target.transform.position;//这里为多个主角的时候，敌人会随机选取主角
            }

        }
        else {
           // Debug.Log(target.gameObject.activeSelf);
            float dis = Vector3.Distance(transform.position, targetPos);
            if (dis > 1.5f)
            {
                transform.LookAt(targetPos);
                transform.Translate(Vector3.forward * 25 * Time.deltaTime);
                anima.CrossFade(animName_run);
            }
            else
            {
                if (targetPos == startPos)
                {
                    anima.CrossFade(animName_idle);
                    transform.localEulerAngles = startRot;

                    transform.localPosition = startPos;
                    FightManager.main.FinishRound();//结束一个回合
                    actionBar.GetComponent<Scrollbar>().value = 0;
                        state = EnemyFightState.Idle;
                    isAtk = false;
                    targetPos = target.transform.position;
                    abc = false;
                }
                else
                {
                    StartCoroutine(waitAtkEnd());
                }
            }
        }
    }

    IEnumerator waitAtkEnd()
    {
        anima.CrossFade(animName_atk);
        Facade.Instance.PlayNormalSound(AudioManager.Sound_Tiger);
        yield return new WaitForSeconds(0.6f);//anima.GetClip(animName_atk).length
        if (isAtk == false)
        {
            if(target!=null)
            target.gameObject.SendMessage("OnDamage",attack);
            isAtk = true;
        }
        state = EnemyFightState.Idle;
        targetPos = startPos;
    }

   public void OnDamage(int value)
    {
        StartCoroutine(waitDamageEnd());
        HP -= value;
        Hpimg.fillAmount -= (float)value / 100;
        if (HP <= 0)
        {
            isDie = true;
            FightManager.main.CostEnemyCount();
        }
    }
    IEnumerator waitDamageEnd()
    {
        anima.CrossFade(animName_damege);
        yield return new WaitForSeconds(anima.GetClip(animName_damege).length);
        anima.CrossFade(animName_idle);
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
