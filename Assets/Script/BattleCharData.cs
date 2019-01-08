using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class BattleCharData : MonoBehaviour {
    public string NameText;

    public float CharSpeed;

    public int Attack;
    public int Deffence;
    public int CounterPercent;

    public int EvadePercent;

    public int AttackRange;
    public int Skill;

    public string AttackText;

    public int EquipItem1;
    public int EquipItem2;
    public int EquipItem3;

    [SerializeField]
    private SpriteAtlas spriteAtlas;

    public Image imageRenderer;

    private List<Sprite> spriteList;

    // Use this for initialization
    // 이름,속도,공격,방어,반격률,회피률,공격종류,스킬종류,대사,아이템1,아이템2,아이템3

    public void Init(string[] values, int charName)
    {
        NameText = values[0];
        CharSpeed = float.Parse(values[1]);
        Attack = int.Parse(values[2]);
        Deffence = int.Parse(values[3]);
        CounterPercent = int.Parse(values[4]);
        EvadePercent = int.Parse(values[5]);
        AttackRange = int.Parse(values[6]);
        Skill = int.Parse(values[7]);
        AttackText = values[8];
        EquipItem1 = int.Parse(values[9]);
        EquipItem2 = int.Parse(values[10]);
        EquipItem3 = int.Parse(values[11]);

        setCharDataList (charName);
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void setCharDataList(int spriteNumber)
    {
        var sprites = new Sprite[spriteAtlas.spriteCount];
        spriteAtlas.GetSprites (sprites);
        spriteList = sprites.ToList ();

        imageRenderer.sprite = spriteList[spriteNumber];
    }


    void OnMouseOver()
    {
        this.gameObject.SetActive(true);
    }

    void OnMouseExit()
    {
        this.gameObject.SetActive(false);
    }
}
