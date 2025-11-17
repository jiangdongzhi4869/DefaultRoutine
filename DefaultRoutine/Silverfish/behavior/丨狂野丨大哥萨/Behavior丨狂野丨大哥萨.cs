using System.Collections.Generic;
using System;
using Logger = Triton.Common.LogUtilities.Logger;
using log4net;
using System.Linq;

namespace HREngine.Bots
{
    public partial class Behavior丨狂野丨大哥萨 : Behavior
    {
        private int bonus_enemy = 4;
        private int bonus_mine = 4;
        // 存储敌方职业名称的全局变量
        private HeroEnum enemyHeroName;


        public override string BehaviorName() { return "丨狂野丨大哥萨"; }
        PenalityManager penman = PenalityManager.Instance;

        // 存储大哥卡牌的集合
        HashSet<CardDB.Card> bigbroCards = new HashSet<CardDB.Card>()
        {
            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.TSC_639), //暴食巨鳗格拉格
            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.WW_440), //奔雷骏马
            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.WW_382), //步移山丘
            CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.TID_712), //猎潮者耐普图隆
        };

        //文本输出
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        //全局变量
        int flag1 = 0;//童话林地
        int flag2 = 0;//拍卖行木槌
        int flag3 = 0;//泥沼变形怪
        int flag4 = 0;//间歇热泉
        int flag5 = 0;//先祖召唤
        int flag6 = 0;//奔雷骏马
        int flag7 = 0;//步移山丘
        int flag8 = 0;//猎潮者耐普图隆
        int flag9 = 0;//暴食巨鳗格拉格

        /// <summary>
        /// 大哥萨的留牌策略
        /// </summary>
        /// <param name="cards">起手卡牌列表</param>
        public override void specialMulligan(List<Mulligan.CardIDEntity> cards)
        {
            foreach (Mulligan.CardIDEntity card in cards)
            {
                CardDB.Card cardCN = CardDB.Instance.getCardDataFromID(card.id);
                if (cardCN.nameCN == CardDB.cardNameCN.童话林地)
                {
                    flag1 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.拍卖行木槌)
                {
                    flag2 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.泥沼变形怪)
                {
                    flag3 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.间歇热泉)
                {
                    flag4 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.先祖召唤)
                {
                    flag5 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.奔雷骏马)
                {
                    flag6 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.步移山丘)
                {
                    flag7 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.猎潮者耐普图隆)
                {
                    flag8 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.暴食巨鳗格拉格)
                {
                    flag9 += 1;
                }
            }

            foreach (Mulligan.CardIDEntity card in cards)
            {
                CardDB.Card cardCN = CardDB.Instance.getCardDataFromID(card.id);

                if (cardCN.nameCN == CardDB.cardNameCN.童话林地)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手留童话林地";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张童话林地";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.拍卖行木槌)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手留拍卖行木槌";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张拍卖行木槌";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.泥沼变形怪)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手留泥沼变形怪";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张泥沼变形怪";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.转生)
                {

                    if (cards.Count > 3 && flag1 + flag2 + flag3 >= 2)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "后手组件齐全，留转生打出变形怪回合膨胀场面";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张转生";
                            }
                        }
                    }

                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不符合特殊规则不留";
                    }

                }

                if (cardCN.nameCN == CardDB.cardNameCN.间歇热泉)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手留间歇热泉";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张间歇热泉";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.先祖之魂)
                {
                    if (cards.Count >= 3 && flag2 + flag3 == 2)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手有地标和武器留先祖之魂";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张先祖之魂";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.先祖召唤)
                {
                    if (cards.Count >= 3 && flag1 + flag2 + flag3 < 2)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "先后手留一张先祖召唤";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张先祖召唤";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.先祖知识)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留先祖知识";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.即兴演奏)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留即兴演奏";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.衰变)
                {
                    if (enemyHeroName == HeroEnum.priest || enemyHeroName == HeroEnum.demonhunter)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "对阵牧瞎留一张衰变";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张衰变";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.提神冰冷)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留提神冰冷";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.闪电风暴)
                {
                    if (enemyHeroName == HeroEnum.priest || enemyHeroName == HeroEnum.demonhunter)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "对阵牧瞎留一张闪电风暴";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张闪电风暴";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.我找到了)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留我找到了";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.暴食巨鳗格拉格)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留暴食巨鳗格拉格";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.奔雷骏马)
                {
                    if (cards.Count >= 3 && flag5 == 1)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "有先祖召唤留一张奔雷骏马";
                    }
                    else
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不符合特殊规则不留";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.步移山丘)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留步移山丘";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.猎潮者耐普图隆)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留猎潮者耐普图隆";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.嗜血)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留嗜血";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.石化武器)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留石化武器";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.雷霆绽放)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留雷霆绽放";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.萨尔的礼物)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留萨尔的礼物";
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.鱼群聚集)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留鱼群聚集";
                    }
                }
            }
        }

        public override int getComboPenality(CardDB.Card card, Minion target, Playfield p, Handmanager.Handcard nowHandcard)
        {
            // 无法选中(值越大越不会打出)
            if (target != null && target.untouchable)
            {
                return 100000;
            }
            // 初始惩罚值（负为优先打出该牌，正为低优先打出该牌）
            int pen = 0;
            //一费检查手牌有没有船载火炮、幸运币、海盗，此处为没有海盗，返回值1000不打出此combo。
            if (Hrtprozis.Instance.gTurn <= 2 && card.race == CardDB.Race.PIRATE && p.enemyMinions.Count == 0)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.nameCN == CardDB.cardNameCN.烈焰亡魂)
                    {
                        foreach (Handmanager.Handcard hhc in p.owncards)
                        {
                            if (hhc.card.nameCN == CardDB.cardNameCN.幸运币 || hhc.getManaCost(p) == 1 && hhc.card.race != CardDB.Race.PIRATE && hhc.card.type == CardDB.cardtype.MOB)
                            {
                                return 1000;
                            }
                        }
                    }
                }
            }
            //如果是海盗并且随从有船载火炮 增加基础推荐出牌。
            if(card.race == CardDB.Race.PIRATE)	
			{
				foreach (Minion m in p.ownMinions)
				{
					if(m.handcard.card.nameCN == CardDB.cardNameCN.烈焰亡魂)
					{
						pen -= 100;
					}
				}
			}

            int 启动法术牌 = 0;//先祖召唤和我找到了数量           
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.nameCN == CardDB.cardNameCN.先祖召唤
                    || hc.card.nameCN == CardDB.cardNameCN.我找到了)
                    启动法术牌++;
            }

            int 变形怪数量 = 0;//泥沼变形怪数量           
            foreach (Handmanager.Handcard hc in p.owncards)
            {
                if (hc.card.nameCN == CardDB.cardNameCN.泥沼变形怪)
                    变形怪数量++;
            }

            bool 幸运币 = false;   // 是否有幸运币
            bool 童话林地 = false; // 是否有地标童话林地
            bool 拍卖行木槌 = false;   // 是否有武器拍卖行木槌
            bool 泥沼变形怪 = false;   // 是否有泥沼变形怪
            bool 间歇热泉 = false;   // 是否有间歇热泉
            bool 转生 = false;   // 是否有转生
            bool 先祖之魂 = false;   // 是否有先祖之魂
            bool 先祖召唤 = false;   // 是否有先祖召唤
            bool 先祖知识 = false;   // 是否有先祖知识
            bool 提神冰冷 = false;   // 是否有提神冰冷
            bool 我找到了 = false;   // 是否有我找到了  
            bool 即兴演奏 = false;   // 是否有即兴演奏
            bool 衰变 = false;   // 是否有衰变
            bool 闪电风暴 = false;   // 是否有闪电风暴
            bool 嗜血 = false;   // 是否有嗜血
            bool 暴食巨鳗格拉格 = false;   // 是否有暴食巨鳗格拉格
            bool 奔雷骏马 = false;   // 是否有奔雷骏马
            bool 步移山丘 = false;   // 是否有步移山丘
            bool 猎潮者耐普图隆 = false;   // 是否有猎潮者耐普图隆
            bool 耐普图隆之手 = false; //战场上是否有耐普图隆之手
            bool 大哥随从 = false; //手牌里是否有大哥随从
            int 泥沼变形怪费用 = 0;//泥沼变形怪费用
            int 先祖召唤费用 = 0;//先祖召唤费用
            int 我找到了费用 = 0;//我找到了费用
            foreach (Minion m in p.ownMinions)
                {
                    if (m.handcard.card.nameCN == CardDB.cardNameCN.耐普图隆之手)
                    {
                        耐普图隆之手 = true;
                    }
                }

            foreach (Handmanager.Handcard hc in p.owncards)
            {
                // 检查是否有幸运币
                if (hc.card.nameCN == CardDB.cardNameCN.幸运币)
                {
                    幸运币 = true;
                }

                // 检查是否有童话林地
                if (hc.card.nameCN == CardDB.cardNameCN.童话林地)
                {
                    童话林地 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.拍卖行木槌)
                {
                    拍卖行木槌 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.泥沼变形怪)
                {
                    泥沼变形怪 = true;
                    泥沼变形怪费用 = hc.manacost;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.间歇热泉)
                {
                    间歇热泉 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.转生)
                {
                    转生 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.先祖之魂)
                {
                    先祖之魂 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.先祖召唤)
                {
                    先祖召唤 = true;
                    先祖召唤费用 = hc.manacost;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.先祖知识)
                {
                    先祖知识 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.提神冰冷)
                {
                    提神冰冷 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.我找到了)
                {
                    我找到了 = true;
                    我找到了费用 = hc.manacost;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.即兴演奏)
                {
                    即兴演奏 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.衰变)
                {
                    衰变 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.闪电风暴)
                {
                    闪电风暴 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.嗜血)
                {
                    嗜血 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.暴食巨鳗格拉格)
                {
                    暴食巨鳗格拉格 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.奔雷骏马)
                {
                    奔雷骏马 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.步移山丘)
                {
                    步移山丘 = true;
                }

                if (hc.card.nameCN == CardDB.cardNameCN.猎潮者耐普图隆)
                {
                    猎潮者耐普图隆 = true;
                }
                if (暴食巨鳗格拉格 == true || 奔雷骏马 == true || 步移山丘 == true || 猎潮者耐普图隆 == true)
                {
                    大哥随从 = true;
                }
            }

            //此处为单卡描述
            switch (card.nameCN)		
            {
                case CardDB.cardNameCN.间歇热泉:
                    if (target != null )
                    {
                        if (target.own)
                        {
                        return 1000; // 规定不以己方为目标
                        }
                    else
                        {
                        pen -= 3;   
                        }
                    }
                    break;
                
                case CardDB.cardNameCN.雷霆绽放:
                    if (p.ownMaxMana <= 2 )
                        {
                            pen += 100;   
                        }
                    break;
                
                case CardDB.cardNameCN.石化武器:
                    if(target != null && target.handcard.card.nameCN == CardDB.cardNameCN.步移山丘)
                        {
                            pen -= 10;
                        }
                    else if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.猎潮者耐普图隆 && 耐普图隆之手 == false)
                        {
                            pen -= 8;
                        }
                    else if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.耐普图隆之手)
                        {
                            pen -= 6;
                        }
                    else
                    {
                        pen += 10;
                    }
                    break;


                case CardDB.cardNameCN.先祖召唤:
                    if (大哥随从 == false || 泥沼变形怪 == true)
                        {
                            return 1000; // 如果手牌中没有大哥或者有变形怪，禁止使用先祖召唤
                        }
                    if ((p.ownMaxMana < 6) && (奔雷骏马 == true || 暴食巨鳗格拉格 == true || 步移山丘 == true || 猎潮者耐普图隆 == true))
                        {
                            pen -= 5; //6费之前手牌里有大哥，优先打出
                        }
                    if ((我找到了费用 <= 先祖召唤费用) && (我找到了 == true))
                        {
                            pen += 5; //手牌里有我找到了先用我找到了
                        }
                    break;

                case CardDB.cardNameCN.我找到了:
                    if (大哥随从 == false || 泥沼变形怪 == true)
                        {
                            return 1000; // 如果手牌中没有大哥或者有变形怪，禁止使用我找到了
                        }
                    if (奔雷骏马 == true || 暴食巨鳗格拉格 == true || 步移山丘 == true || 猎潮者耐普图隆 == true)
                        {
                            pen -= 7; //手牌里有大哥，优先打出
                        }
                    if ((我找到了费用 <= 先祖召唤费用) && (我找到了 == true))
                        {
                            pen -= 10; //手牌里有我找到了先用我找到了
                        }
                    break;

                case CardDB.cardNameCN.童话林地:
                    if (p.ownMaxMana >= 3)
                        {
                            pen -= 50; //3费优先打地标
                        }
                    
                    if (变形怪数量 == 2)
                        {
                            return 1000; // 地标失去作用，禁止打出
                        }
                    break;

                case CardDB.cardNameCN.拍卖行木槌:
                    if (p.ownMaxMana == 2)
                        {
                            pen -= 100; //2费优先提刀
                        }
                    break;

                case CardDB.cardNameCN.泥沼变形怪:
                    if (p.ownMaxMana == 3)
                        {
                            pen -= 100; //3费优先出
                        }
                    if (p.ownMaxMana == 4)
                        {
                            pen -= 80; //4费优先出
                        }
                    if (p.ownMaxMana == 5)
                        {
                            pen -= 60; //5费优先出
                        }
                    pen -=40;//其他时间也优先出，不管牌库了
                    break;

                case CardDB.cardNameCN.即兴演奏:
                    if (target != null )
                    {
                        if (target != null && !target.own)
                        {
                        return 1000; // 如果目标敌方控制不打出
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.步移山丘)
                        {
                            pen -= 10;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.猎潮者耐普图隆 && 耐普图隆之手 == false)
                        {
                            pen -= 8;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.耐普图隆之手)
                        {
                            pen -= 6;
                        }
                   
                    }
                    break;

                case CardDB.cardNameCN.转生:
                    if (target != null )
                    {
                        if (target != null && !target.own)
                        {
                        return 1000; // 如果目标敌方控制不打出
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.奔雷骏马)
                        {
                            pen -= 10;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.猎潮者耐普图隆)
                        {
                            pen -= 8;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.步移山丘)
                        {
                            pen -= 6;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.暴食巨鳗格拉格)
                        {
                            pen -= 4;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.耐普图隆之手)
                        {
                            pen += 6;
                        }
                    }
                    break;

                case CardDB.cardNameCN.先祖之魂:
                    if (target != null )
                    {
                        if (target != null && !target.own)
                        {
                            return 1000; // 如果目标敌方控制不打出
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.奔雷骏马)
                        {
                            pen -= 10;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.猎潮者耐普图隆)
                        {
                            pen -= 8;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.步移山丘)
                        {
                            pen -= 6;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.暴食巨鳗格拉格)
                        {
                            pen -= 4;
                        }
                        if (target != null && target.handcard.card.nameCN == CardDB.cardNameCN.耐普图隆之手)
                        {
                            pen += 6;
                        }
                    }
                    break;

                case CardDB.cardNameCN.提神冰冷:
					break;

                case CardDB.cardNameCN.先祖知识:
					if (p.owncards.Count < 2) 
                    {
                        pen -= 5; //手牌低于3时尽快打出
                    }
                    if (p.owncards.Count > 7) 
                    {
                        pen += 100; //手牌大于7不要打出
                    }
                    if (童话林地 == false && 拍卖行木槌 == false && 泥沼变形怪 == false && 先祖召唤 == false) 
                    {
                        pen -= 5; //没有核心组件时尽快打出
                    }
                    break;

            }

            //combo
            //Action action = null;
            if (Hrtprozis.Instance.gTurn == 1
                 && 幸运币
                 && (童话林地 || 泥沼变形怪 || 先祖召唤))
            {
                switch (card.nameCN) 
                {
                    case CardDB.cardNameCN.间歇热泉:
                        pen -= 100;
                        break;
                    case CardDB.cardNameCN.幸运币:
                        pen += 200;
                        break;
                }
            }

            if (Hrtprozis.Instance.gTurn <= 2
                && 拍卖行木槌
                && !泥沼变形怪)
            {
                switch (card.nameCN)
                {
                    case CardDB.cardNameCN.拍卖行木槌:
                        pen -= 5;
                        break;
                }
                //switch (action.actionType)
                //{
                //    case actionEnum.attackWithHero:
                //        pen += 10;
                //        break;
                //}
            }

            if (Hrtprozis.Instance.gTurn == 3
                && 幸运币
                && 先祖召唤
                && 大哥随从
                && !泥沼变形怪)
            {
                switch (card.nameCN)
                {
                    case CardDB.cardNameCN.幸运币:
                        pen -= 10;
                        break;
                    case CardDB.cardNameCN.先祖召唤:
                        pen -= 10;
                        break;
                }
            }

            if (Hrtprozis.Instance.gTurn == 3 && 童话林地)
            {
                switch (card.nameCN)
                {
                    case CardDB.cardNameCN.童话林地:
                        pen -= 10;
                        break;
                }
            //    switch (action.actionType)
            //    {
            //        case actionEnum.useLocation:
            //            pen -= 10;
            //            break;
            //    }
            //    switch (action.actionType)
            //    {
            //        case actionEnum.attackWithHero:
            //            pen -= 10;
            //            break;
            //    }                
            }

            if (Hrtprozis.Instance.gTurn == 3
                && 幸运币
                && 泥沼变形怪
                && 泥沼变形怪费用 == 3
                && 转生)
            {
                switch (card.nameCN)
                {
                    case CardDB.cardNameCN.泥沼变形怪:
                        pen -= 10;
                        break;
                    case CardDB.cardNameCN.幸运币:
                        pen -= 10;
                        break;
                    case CardDB.cardNameCN.转生:
                        pen -= 10;
                        break;
                }
            }

            if (Hrtprozis.Instance.gTurn == 4
                && 幸运币
                && 泥沼变形怪
                && 泥沼变形怪费用 <= 4
                && (转生 || 先祖之魂))
            {
                switch (card.nameCN)
                {
                    case CardDB.cardNameCN.泥沼变形怪:
                        pen -= 10;
                        break;
                    case CardDB.cardNameCN.幸运币:
                        pen -= 10;
                        break;
                    case CardDB.cardNameCN.转生:
                        pen -= 10;
                        break;
                    case CardDB.cardNameCN.先祖之魂:
                        pen -= 10;
                        break;
                }
            }

            return pen;
        }

        /// <summary>
        /// 探底卡的价值
        /// </summary>
        /// <param name="card"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public override int getDredgeVal(CardDB.Card card, Playfield p)
        {
            switch (card.nameCN)
            {
                // 高优先级 - 启动组件
                case CardDB.cardNameCN.童话林地:
                    return 20;
                case CardDB.cardNameCN.泥沼变形怪:
                    return 20;
                case CardDB.cardNameCN.拍卖行木槌:
                    if (flag1 + flag3 > 0)
                        {
                            return 15;
                        }
                    else
                        {
                            return 0;
                        }
                case CardDB.cardNameCN.先祖召唤:
                    if (flag6 + flag7 + flag8 + flag9 >0)
                        {
                            return 20;
                        }
                    else
                        {
                            return 15;
                        }
                case CardDB.cardNameCN.奔雷骏马:
                    if (flag5 >0)
                        {
                            return 20;
                        }
                    else
                        {
                            return 0;
                        }
                // 中优先级 - 大哥随从
                case CardDB.cardNameCN.暴食巨鳗格拉格:
                    if (flag5 >0)
                        {
                            return 14;
                        }
                    else
                        {
                            return 0;
                        }
                case CardDB.cardNameCN.步移山丘:
                    if (flag5 >0)
                        {
                            return 16;
                        }
                    else
                        {
                            return 0;
                        }
                case CardDB.cardNameCN.猎潮者耐普图隆:
                    if (flag5 >0)
                        {
                            return 18;
                        }
                    else
                        {
                            return 0;
                        }

                // 低优先级 - 膨胀场面、斩杀组件
                case CardDB.cardNameCN.转生:
                    return 10;
                case CardDB.cardNameCN.先祖之魂:
                    return 8;
                case CardDB.cardNameCN.即兴演奏:
                    return 6;
                case CardDB.cardNameCN.石化武器:
                    return 6;
                case CardDB.cardNameCN.嗜血:
                    return 6;

                // 未特别指定的卡牌，根据WinrateWhenDrawn计算优先级
                default:
                    // 获取当前卡的职业
                    string className = card.Class.ToString().ToUpper();

                    //初始化Hsreplay数据
                    Hsreplay hs = Hsreplay.Instance;

                    // 从对应职业的数据列表中找到匹配的卡牌数据
                    var cardStats = Hsreplay.AllCardStats.FirstOrDefault(c => c.DbfId == card.dbfId);

                    if (cardStats != null)
                    {
                        Helpfunctions.Instance.logg("getDredgeVal - 使用Hsreplay数据比对" + card.nameCN.ToString() + " => " + cardStats.WinrateWhenDrawn);
                        Log.Info("getDredgeVal - 使用Hsreplay数据比对" + card.nameCN.ToString() + " => " + cardStats.WinrateWhenDrawn);
                        // 返回计算优先级
                        return (int)(20 * cardStats.WinrateWhenDrawn / 100);
                    }

                    // 如果找不到对应的卡牌数据，或者职业数据不存在，则返回最低优先级
                    return 0;

            }
        }


        /// <summary>
        /// 核心，场面值
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public override float getPlayfieldValue(Playfield p)
        {
            // 如果场上的评分值大于-200000，则返回该值
            if (p.value > -200000) return p.value;

            float retval = 0; // 初始化返回值

            // 加上一般的场面价值
            retval += getGeneralVal(p);

            // 自己的抽牌数量，每张牌价值5分
            retval += p.owncarddraw * 5;

            // 危险血量线
            int hpboarder = 3;

            // 不考虑法术伤害加成
            if (p.enemyHeroName == HeroEnum.mage) retval += 2 * p.enemyspellpower;

            // 攻击血量线
            int aggroboarder = 20;

            // 加上血量值
            retval += getHpValue(p, hpboarder, aggroboarder);

            // 出牌的动作数量
            int count = p.playactions.Count;
            int ownActCount = 0; // 自己的动作计数
            bool useAb = false; // 是否使用了英雄技能
            bool attacted = false; // 是否已进行攻击

            // 遍历所有的动作
            for (int i = 0; i < count; i++)
            {
                Action a = p.playactions[i]; // 当前动作
                ownActCount++; // 计数自己的动作数量

                // 根据不同动作类型调整评分
                switch (a.actionType)
                {
                    case actionEnum.useLocation:
                        retval -= i * 10;
                        continue;

                    case actionEnum.trade:
                        retval -= 20; // 交换行动减分
                        continue;

                    // 英雄或随从攻击
                    case actionEnum.attackWithMinion:
                    case actionEnum.attackWithHero:
                        if (a.target != null && a.target.isHero)
                        {
                            attacted = true; // 如果攻击了英雄，标记为已攻击
                        }
                        if (a.actionType == actionEnum.attackWithMinion)
                        {
                            int atk = a.own.Angr > 0 ? a.own.Angr + p.anzOldWoman : a.own.Angr;
                            retval += atk * 10;
                        }
                        continue;

                    // 使用英雄技能
                    case actionEnum.useHeroPower:
                        useAb = false; // 不要使用英雄技能
                        break;


                    //在这里加出牌顺序
                    case actionEnum.playcard:

                        // 判断具体的卡牌，并根据出牌顺序调整评分  减分早下  加分晚下 分数别太极端 会出毛病
                        switch (a.card.card.nameCN)
                        {
                            case CardDB.cardNameCN.幸运币:
                                if (Hrtprozis.Instance.gTurn < 3)
                                    {
                                        retval += i * 10;
                                    }
                                else
                                    {
                                        retval -= i * 10;
                                    }
                                break;
                            case CardDB.cardNameCN.童话林地:
                                retval -= i * 15;
                                break;
                            case CardDB.cardNameCN.泥沼变形怪:
                                retval -= (i * 11 + 5);
                                break;
                        }
                        break;

                    default:
                        continue;
                }
                
                // 如果出牌是海盗或“虚触侍从”
                if (a.card.card.race == CardDB.Race.PIRATE || a.card.card.nameCN == CardDB.cardNameCN.虚触侍从)
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.handcard.card.nameCN == CardDB.cardNameCN.船载火炮)
                        {
                            retval += 10 - i * 3;
                            break;
                        }
                    }
                //// 出牌排序优先，判断具体的卡牌，并根据出牌顺序调整评分  减分早下  加分晚下 分数别太极端 会出毛病
                switch (a.card.card.nameCN)
                {
                    case CardDB.cardNameCN.礼盒雏龙:
                        retval -= 3 * i;
                        break;
                    case CardDB.cardNameCN.随船外科医师:
                        retval -= 2 * i;
                        break;
                    case CardDB.cardNameCN.虚触侍从:
                        retval -= (i * 4 > 10 ? 10 : i * 4);
                        break;
                    case CardDB.cardNameCN.亡者复生:
                        retval -= 30;
                        break;
                }
            }

            // 对手基本随从交换模拟
            retval -= p.lostDamage;
            retval += getSecretPenality(p); // 奥秘的影响
            retval -= p.enemyWeapon.Angr * 3 + p.enemyWeapon.Durability * 3; // 对方武器影响

            // 留着技能下回合使用的情况
            if (p.ownMaxMana < 2 && p.ownHeroPowerCostLessOnce <= -99)
            {
                if (!useAb && p.enemyMinions.Count == 0)
                {
                    retval += 20;
                }
            }

            // 针对术士职业的特殊防“亵渎”
            if (retval > 50 && p.enemyHeroStartClass == TAG_CLASS.WARLOCK && p.enemyMinions.Count == 0 && p.ownMinions.Count > 2)
            {
                bool found = false;

                // 防止“亵渎”，从2血开始计算
                for (int i = 1; i <= 10; i++)
                {
                    found = false;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.Hp == i)
                        {
                            retval -= 2 * (i - 1);
                            found = true;
                        }
                    }
                    if (!found)
                    {
                        if (i == 1) retval += 10;
                        if (i == 2) retval += 10;
                        break;
                    }
                }
            }

            // “心灵震爆”闲置时优先出
            if (p.owncards.Count <= 4)
            {
                foreach (Handmanager.Handcard hc in p.owncards)
                {
                    if (hc.card.nameCN == CardDB.cardNameCN.心灵震爆 && hc.getManaCost(p) <= p.mana)
                    {
                        retval -= 50;
                    }
                }
            }

            // 如果不攻击就能击杀敌方英雄，额外加分
            if (!attacted && p.enemyHero.Hp <= 0) retval += 10000;

            // 返回计算后的场面价值
            return retval;
        }


        /// <summary>
        /// 发现卡的价值
        /// </summary>
        /// <param name="card"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public override int getDiscoverVal(CardDB.Card card, Playfield p)
        {
			// Helpfunctions.Instance.logg("发现卡：" + card.nameCN);
			// Helpfunctions.Instance.logg("发现卡类型：" + card.race);
			// Helpfunctions.Instance.logg("发现卡费用：" + card.cost);
            switch (card.nameCN)
            {
            //法术（if条件成功了！）
            case CardDB.cardNameCN.心灵震爆:
            if (p.enemyHero.Hp <= 5 + p.calTotalAngr()) return 100;
            return 15;                
            case CardDB.cardNameCN.精神灼烧:
            if (p.enemyHero.Hp >= 3 + p.calTotalAngr() && p.ownMinions.Count <= p.enemyMinions.Count) return 20;
            return 10;  
            case CardDB.cardNameCN.亡者复生:
            return 5;
            
            //随从（龙）
            case CardDB.cardNameCN.时空扭曲者扎里米:
            return 50; 
            case CardDB.cardNameCN.礼盒雏龙:
            return 30; 
            case CardDB.cardNameCN.暮光雏龙:
            case CardDB.cardNameCN.随船外科医师:
            case CardDB.cardNameCN.错误产物:
            case CardDB.cardNameCN.精灵龙:
            return 20; 
            case CardDB.cardNameCN.光明之翼:
            case CardDB.cardNameCN.星光雏龙:
            case CardDB.cardNameCN.深蓝系咒师:
            case CardDB.cardNameCN.碧蓝幼龙:
            return 15;
            case CardDB.cardNameCN.黏土巢母:
            case CardDB.cardNameCN.骸骨巨龙:
            return 10; 

            }
            if (card.race == CardDB.Race.DRAGON)    
            {
            return 3;
            }
            return 0;

        }

        /// <summary>
        /// 敌方随从价值 主要等于（HP + Angr） * 4
        /// </summary>
        /// <param name="m"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public override int getEnemyMinionValue(Minion m, Playfield p)
        {
            bool dieNextTurn = false;
            foreach (Minion mm in p.enemyMinions)
            {
                if (mm.handcard.card.nameCN == CardDB.cardNameCN.末日预言者)
                {
                    dieNextTurn = true;
                    break;
                }
            }
            if (m.destroyOnEnemyTurnEnd || m.destroyOnEnemyTurnStart || m.destroyOnOwnTurnEnd || m.destroyOnOwnTurnStart) dieNextTurn = true;
            if (dieNextTurn)
            {
                return -1;
            }
            if (m.Hp <= 0) return 0;
            int retval = 0;
            if (m.Angr > 0 || m.taunt || m.handcard.card.race == CardDB.Race.TOTEM || p.enemyHeroStartClass == TAG_CLASS.PALADIN || p.enemyHeroStartClass == TAG_CLASS.PRIEST)
                retval += m.Hp * 4;
            retval += m.spellpower * 2;
            retval += m.Hp * m.Angr / 2;
            if (!m.frozen && (!m.cantAttack || m.handcard.card.nameCN == CardDB.cardNameCN.邪刃豹))
            {
                retval += m.Angr * 4;
                if (m.Angr > 5) retval += 10;
                if (m.windfury) retval += m.Angr * 2;
            }
            if (m.silenced) return retval;

            if (m.taunt) retval += 2;
            if (m.divineshild) retval += m.Angr * 2;
            if (m.divineshild && m.taunt) retval += 5;
            if (m.stealth) retval += 2;

            // 鱼人
            if (m.handcard.card.race == CardDB.Race.MURLOC) retval += bonus_enemy * 4;

            // 剧毒价值两点属性
            if (m.poisonous)
            {
                retval += 8;
            }
            if (m.lifesteal) retval += m.Angr * bonus_enemy * 4;

            int bonus = 4;
            switch (m.handcard.card.nameCN)
            {
                case CardDB.cardNameCN.巫师学徒:
                case CardDB.cardNameCN.肢体商贩:
                case CardDB.cardNameCN.巨型图腾埃索尔:
                case CardDB.cardNameCN.驻锚图腾:
                case CardDB.cardNameCN.刺豚拳手:
                case CardDB.cardNameCN.空中飞爪:
                case CardDB.cardNameCN.金翼巨龙:
                case CardDB.cardNameCN.安保自动机:
                case CardDB.cardNameCN.机械跃迁者:
                case CardDB.cardNameCN.火焰术士弗洛格尔:
                case CardDB.cardNameCN.对空奥术法师:
                case CardDB.cardNameCN.前沿哨所:
                case CardDB.cardNameCN.战场军官:
                case CardDB.cardNameCN.伯尔纳锤喙:
                case CardDB.cardNameCN.甜水鱼人斥候:
                case CardDB.cardNameCN.塔姆辛罗姆:
                case CardDB.cardNameCN.暗影珠宝师汉纳尔:
                case CardDB.cardNameCN.伦萨克大王:
                case CardDB.cardNameCN.布莱恩铜须:
                case CardDB.cardNameCN.观星者露娜:
                case CardDB.cardNameCN.大法师瓦格斯:
                case CardDB.cardNameCN.火妖:
                case CardDB.cardNameCN.下水道渔人:
                case CardDB.cardNameCN.空中炮艇:
                case CardDB.cardNameCN.船载火炮:
                case CardDB.cardNameCN.火舌图腾:
                case CardDB.cardNameCN.末日预言者:
                case CardDB.cardNameCN.莫尔杉哨所:
                case CardDB.cardNameCN.鱼人领军:
                case CardDB.cardNameCN.南海船长:
                case CardDB.cardNameCN.灭龙弩炮:
                case CardDB.cardNameCN.战马训练师:
                case CardDB.cardNameCN.加基森拍卖师:
                case CardDB.cardNameCN.健谈的调酒师:
                case CardDB.cardNameCN.豪宅管家俄里翁:
                case CardDB.cardNameCN.小鬼骑士:
                case CardDB.cardNameCN.针岩图腾:
                case CardDB.cardNameCN.伴唱机:
                case CardDB.cardNameCN.空气之怒图腾:
                case CardDB.cardNameCN.战场通灵师:
                case CardDB.cardNameCN.纸艺天使:
                case CardDB.cardNameCN.纳亚克海克森:
                case CardDB.cardNameCN.粗暴的猢狲:
                    retval += 150;
                    break;
              
                // 不解巨大劣势
                case CardDB.cardNameCN.安娜科德拉:
                case CardDB.cardNameCN.农夫:
                case CardDB.cardNameCN.旗标骷髅:
                case CardDB.cardNameCN.尼鲁巴蛛网领主:
                case CardDB.cardNameCN.凯瑞尔罗姆:
                case CardDB.cardNameCN.暗鳞先知:
                case CardDB.cardNameCN.鲨鳍后援:
                case CardDB.cardNameCN.相位追猎者:
                case CardDB.cardNameCN.鱼人宝宝车队:
                case CardDB.cardNameCN.饥饿的秃鹫:
                case CardDB.cardNameCN.锈水海盗:
                case CardDB.cardNameCN.盛装歌手:
                case CardDB.cardNameCN.玛克扎尔的小鬼:
                case CardDB.cardNameCN.发明机器人:
                case CardDB.cardNameCN.宝藏经销商:
                case CardDB.cardNameCN.虚触侍从:
                case CardDB.cardNameCN.随船外科医师:
                case CardDB.cardNameCN.玩具船:
                    retval += 50;
                    break;
                // 算有点用
                case CardDB.cardNameCN.贪婪的书虫:
                case CardDB.cardNameCN.治疗图腾:
                case CardDB.cardNameCN.力量图腾:
                case CardDB.cardNameCN.神秘女猎手:
                case CardDB.cardNameCN.矮人神射手:
                case CardDB.cardNameCN.低阶侍从:
                case CardDB.cardNameCN.战斗邪犬:
                case CardDB.cardNameCN.法力浮龙:
                case CardDB.cardNameCN.飞刀杂耍者:
                    retval += 15;
                    break;
            }
            return retval;
        }

        /// <summary>
        /// 我方随从价值，大致等于主要等于 （HP + Angr） * 4 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="p"></param>
        /// <returns></returns> 
        public override int getMyMinionValue(Minion m, Playfield p)
        {
            bool dieNextTurn = false;
            foreach (Minion mm in p.enemyMinions)
            {
                if (mm.handcard.card.nameCN == CardDB.cardNameCN.末日预言者)
                {
                    dieNextTurn = true;
                    break;
                }
            }
            if (m.destroyOnEnemyTurnEnd || m.destroyOnEnemyTurnStart || m.destroyOnOwnTurnEnd || m.destroyOnOwnTurnStart) dieNextTurn = true;
            if (dieNextTurn)
            {
                return -1;
            }
            if (m.Hp <= 0) return 0;
            int retval = 5;
            if (m.Hp <= 0) return 0;
            retval += m.Hp * 4;
            retval += m.Angr * 4;
            retval += m.Hp * m.Angr / 2;
            // 高攻低血是垃圾
            if (m.Angr > m.Hp + 4) retval -= (m.Angr - m.Hp) * 3;

            // 风怒价值
            if ((!m.playedThisTurn || m.rush == 1 || m.charge == 1) && m.windfury) retval += m.Angr;
            // 圣盾价值
            if (m.divineshild) retval += m.Angr * 3;
            // 潜行价值
            if (m.stealth) retval += m.Angr / 2 + 1;
            // 吸血
            if (m.lifesteal) retval += m.Angr / 2 + 1;
            // 圣盾嘲讽
            if (m.divineshild && m.taunt) retval += 4;

            int bonus = 4;
            switch (m.handcard.card.nameCN)
            {
                case CardDB.cardNameCN.虚触侍从:
                    retval += 2 * bonus_mine;
                    break;
                case CardDB.cardNameCN.随船外科医师:
                    retval += 2 * bonus_mine;
                    break;
            }
            return retval;
        }

        public override int getSirFinleyPriority(List<Handmanager.Handcard> discoverCards)
        {

            return -1; //comment out or remove this to set manual priority
            int sirFinleyChoice = -1;
            int tmp = int.MinValue;
            for (int i = 0; i < discoverCards.Count; i++)
            {
                CardDB.cardNameEN name = discoverCards[i].card.nameEN;
                if (SirFinleyPriorityList.ContainsKey(name) && SirFinleyPriorityList[name] > tmp)
                {
                    tmp = SirFinleyPriorityList[name];
                    sirFinleyChoice = i;
                }
            }
            return sirFinleyChoice;
        }
        public override int getSirFinleyPriority(CardDB.Card card)
        {
            return SirFinleyPriorityList[card.nameEN];
        }

        private Dictionary<CardDB.cardNameEN, int> SirFinleyPriorityList = new Dictionary<CardDB.cardNameEN, int>
        {
            //{HeroPowerName, Priority}, where 0-9 = manual priority
            { CardDB.cardNameEN.lesserheal, 0 },
            { CardDB.cardNameEN.shapeshift, 6 },
            { CardDB.cardNameEN.fireblast, 7 },
            { CardDB.cardNameEN.totemiccall, 1 },
            { CardDB.cardNameEN.lifetap, 9 },
            { CardDB.cardNameEN.daggermastery, 5 },
            { CardDB.cardNameEN.reinforce, 4 },
            { CardDB.cardNameEN.armorup, 2 },
            { CardDB.cardNameEN.steadyshot, 8 }
        };


        public override int getHpValue(Playfield p, int hpboarder, int aggroboarder)
        {
            int offset_enemy = 0;
            int offset_mine = p.calEnemyTotalAngr() + Hrtprozis.Instance.enemyDirectDmg;

            int retval = 0;
            // 血线安全
            if (p.ownHero.Hp + p.ownHero.armor - offset_mine > hpboarder)
            {
                retval += (5 + p.ownHero.Hp + p.ownHero.armor - offset_mine - hpboarder) * 3 / 2;
            }
            // 快死了
            else if (p.ownHero.Hp + p.ownHero.armor - offset_mine > 0)
            {
                //if (p.nextTurnWin()) retval -= (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor);
                retval -= 4 * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor + offset_mine) * (hpboarder + 1 - p.ownHero.Hp - p.ownHero.armor + offset_mine);
            }
            else
            {
                retval -= 3 * (hpboarder + 1) * (hpboarder + 1) + 100;
            }
            if (p.ownHero.Hp + p.ownHero.armor - offset_mine < 6 && p.ownHero.Hp + p.ownHero.armor - offset_mine > 0)
            {
                retval -= 80 / (p.ownHero.Hp + p.ownHero.armor - offset_mine);
            }
            // 对手血线安全
            if (p.enemyHero.Hp + p.enemyHero.armor + offset_enemy >= aggroboarder)
            {
                retval += 3 * (aggroboarder - p.enemyHero.Hp - p.enemyHero.armor - offset_enemy);
            }
            // 开始打脸
            else
            {
                retval += 4 * (aggroboarder + 1 - p.enemyHero.Hp - p.enemyHero.armor - offset_enemy);
            }
            // 进入斩杀线
            // if (p.enemyHero.Hp + p.enemyHero.armor + offset_enemy <= 5 && p.enemyHero.Hp + p.enemyHero.armor + offset_enemy > 0)
            // {
            //     retval += 300 / (p.enemyHero.Hp + p.enemyHero.armor - offset_enemy);
            // }
            // 场攻+直伤大于对方生命，预计完成斩杀
            if (p.anzEnemyTaunt == 0 && p.calTotalAngr() + p.calDirectDmg(p.mana, false) >= p.enemyHero.Hp + p.enemyHero.armor)
            {
                retval += 2000;
            }
            // 下回合斩杀本回合打脸
            if (p.calDirectDmg(p.ownMaxMana + 1, false, true) >= p.enemyHero.Hp + p.enemyHero.armor)
            {
                retval += 100;
            }
            return retval;
        }


        /// <summary>
        /// 攻击触发的奥秘惩罚
        /// </summary>
        /// <param name="si"></param>
        /// <param name="attacker"></param>
        /// <param name="defender"></param>
        /// <returns></returns>
        public override int getSecretPen_CharIsAttacked(Playfield p, SecretItem si, Minion attacker, Minion defender)
        {
            if (attacker.isHero) return 0;
            int pen = 0;
            // 攻击的基本惩罚
            if (si.canBe_explosive && !defender.isHero)
            {
                pen -= 20;
                //pen += (attacker.Hp + attacker.Angr);
                foreach (SecretItem sii in p.enemySecretList)
                {
                    sii.canBe_explosive = false;
                }
            }
            return pen;
        }
    }
}