using System;
using System.Collections.Generic;
using UnityEngine;

public class DataStruct
{
    public class Equipment:Article
    {
        public Equipment()
        {

        }
        public override object GetValue(string propertyName)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return null;
            }
            return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }
        public override bool SetValue(string propertyName, object num)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return false;
            }
            this.GetType().GetProperty(propertyName).SetValue(this, num, null);
            return true;
        }
    }
    public class Material:Article
    {
        public Material()
        {
            baimazhi = 0;
            tengzhi = 0;
            ciqingzhi = 0;
            sajinzhi = 0;
            chengxintangzhi = 0;
            yanghaobi = 0;
            yusunbi = 0;
            xiangyalanghao = 0;
            yuzanzihao = 0;
            miaojinyunlong = 0;
        }
        /// <summary>
        /// 白麻纸数量
        /// </summary>
        public int baimazhi { get; set; }
        /// <summary>
        /// 藤纸数量
        /// </summary>
        public int tengzhi { get; set; }
        /// <summary>
        /// 瓷青纸数量
        /// </summary>
        public int ciqingzhi { get; set; }
        /// <summary>
        /// 洒金纸数量
        /// </summary>
        public int sajinzhi { get; set; }
        /// <summary>
        /// 澄心堂纸数量
        /// </summary>
        public int chengxintangzhi { get; set; }
        /// <summary>
        /// 羊毫笔数量
        /// </summary>
        public int yanghaobi { get; set; }
        /// <summary>
        /// 玉笋笔数量
        /// </summary>
        public int yusunbi { get; set; }
        /// <summary>
        /// 象牙狼毫
        /// </summary>
        public int xiangyalanghao { get; set; }
        /// <summary>
        /// 玉瓒紫毫
        /// </summary>
        public int yuzanzihao { get; set; }
        /// <summary>
        /// 描金云龙
        /// </summary>
        public int miaojinyunlong { get; set; }

        public override object GetValue(string propertyName)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return null;
            }
            return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }
        public override bool SetValue(string propertyName, object num)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return false;
            }
            this.GetType().GetProperty(propertyName).SetValue(this, num, null);
            return true;
        }
    }
    public class Book :Article
    {
        public Book()
        {
            jingshitongyan = 0;
            qingchengxinfa = 0;
            beimingshengong = 0;
            xixingdafa = 0;
            jiuyinzhenjing = 0;
            qingshanjianfa = 0;
            yingzhaogong = 0;
            shanghanlun = 0;
            hamagong = 0;
        }
        /// <summary>
        /// 警世通言数量
        /// </summary>
        public int jingshitongyan { get; set; }
        /// <summary>
        /// 青城心法数量
        /// </summary>
        public int qingchengxinfa { get; set; }
        /// <summary>
        /// 北冥神功数量
        /// </summary>
        public int beimingshengong { get; set; }
        /// <summary>
        /// 吸星大法数量
        /// </summary>
        public int xixingdafa { get; set; }
        /// <summary>
        /// 九阴真经数量
        /// </summary>
        public int jiuyinzhenjing { get; set; }
        /// <summary>
        /// 青山剑法数量
        /// </summary>
        public int qingshanjianfa { get; set; }
        /// <summary>
        /// 鹰爪功数量
        /// </summary>
        public int yingzhaogong { get; set; }
        /// <summary>
        /// 伤寒论数量
        /// </summary>
        public int shanghanlun { get; set; }
        /// <summary>
        /// 蛤蟆功数量
        /// </summary>
        public int hamagong { get; set; }

        public override object GetValue(string propertyName)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return null;
            }
            return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }
        public override bool SetValue(string propertyName, object num)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return false;
            }
            this.GetType().GetProperty(propertyName).SetValue(this, num, null);
            return true;
        }
    }
    public class Medicine:Article
    {
        public Medicine()
        {
            lingzhi = 0;
            renshen = 0;
        }
        /// <summary>
        /// 灵芝数量
        /// </summary>
        public int lingzhi { get; set; }
        /// <summary>
        /// 人参数量
        /// </summary>
        public int renshen { get; set; }

        public override object GetValue(string propertyName)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return null;
            }
            return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }
        public override bool SetValue(string propertyName, object num)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return false;
            }
            this.GetType().GetProperty(propertyName).SetValue(this, num, null);
            return true;
        }
    }
    public class Special: Article
    {
        public Special()
        {
            qiguaidebaoguo = 0;
        }
        /// <summary>
        /// 奇怪的包裹数量
        /// </summary>
        public int qiguaidebaoguo { get; set; }

        public override object GetValue(string propertyName)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return null;
            }
            return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }
        public override bool SetValue(string propertyName, object num)
        {
            var pro = this.GetType().GetProperty(propertyName);
            if (pro == null)
            {
                return false;
            }
            this.GetType().GetProperty(propertyName).SetValue(this, num, null);
            return true;
        }
    }
    public abstract class Article
    {
        public abstract object GetValue(string propertyName);
        public abstract bool SetValue(string propertyName, object num);
    }
}
