using System.Collections.Generic;
using System;

namespace HREngine.Bots
{
    public partial class Behavior丨标准丨蛋猎 : Behavior
    {
        private int bonus_enemy = 4;
        private int bonus_mine = 4;

        public override string BehaviorName() { return "丨标准丨蛋猎"; }
        PenalityManager penman = PenalityManager.Instance;





        /// <summary>
        /// 标准蛋猎的留牌策略
        /// </summary>
        /// <param name="cards">起手卡牌列表</param>
        public override void specialMulligan(List<Mulligan.CardIDEntity> cards)
        {
            int 击伤猎物 = 0;
            int 孵化池 = 0;
            int 跳虫 = 0;
            int 两栖之灵 = 0;
            int 异星虫卵 = 0;
            int 恐鳞追猎者  = 0;
            int 拼布好朋友 = 0;
            int 蛛魔之卵 = 0;
            int 进化腔 = 0;
            int 刺蛇 = 0;
            int 劳作老马 = 0;
            int 可怕的主厨 = 0;
            int 坑道虫 = 0;
            int 玩具兵盒 = 0;
            int 奇利亚斯豪华版3000型 = 0;
            

            foreach (Mulligan.CardIDEntity card in cards)
            {
                CardDB.Card cardCN = CardDB.Instance.getCardDataFromID(card.id);
                if (cardCN.nameCN == CardDB.cardNameCN.击伤猎物)
                {
                    击伤猎物 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.孵化池)
                {
                    孵化池 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.跳虫)
                {
                    跳虫 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.两栖之灵)
                {
                    两栖之灵 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.异星虫卵)
                {
                    异星虫卵 += 1;
                }
                 if (cardCN.nameCN == CardDB.cardNameCN.恐鳞追猎者)
                {
                    恐鳞追猎者 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.拼布好朋友)
                {
                    拼布好朋友 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.蛛魔之卵)
                {
                    蛛魔之卵 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.进化腔)
                {
                    进化腔 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.刺蛇)
                {
                    刺蛇 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.劳作老马)
                {
                    劳作老马 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.可怕的主厨)
                {
                    可怕的主厨 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.坑道虫)
                {
                    坑道虫 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.玩具兵盒)
                {
                    玩具兵盒 += 1;
                }
                if (cardCN.nameCN == CardDB.cardNameCN.奇利亚斯豪华版3000型)
                {
                    奇利亚斯豪华版3000型 += 1;
                }
            }

            foreach (Mulligan.CardIDEntity card in cards)
            {
                CardDB.Card cardCN = CardDB.Instance.getCardDataFromID(card.id);

                if (cardCN.nameCN == CardDB.cardNameCN.击伤猎物)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = -2;
                        card.holdReason = "不留击伤猎物";
                        
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.孵化池)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "留一张孵化池";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张孵化池，留一张就好";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.跳虫)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "留一张跳虫，2分钟8只冲家";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张跳虫，留一张就好";
                            }
                        }
                    }                  
                }

                if (cardCN.nameCN == CardDB.cardNameCN.两栖之灵)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "留一张两栖之灵跳起来!";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = 2;
                                tmp.holdReason = "按规则丢弃第二张两栖之灵，留一张就好，怕没随从";
                            }
                        }
                    }
                }

                if (cardCN.nameCN == CardDB.cardNameCN.异星虫卵)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "留一张异星虫卵,琥珀宝藏（确信）！";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张异星虫卵，去找配合";
                            }
                        }
                    }             
                }

                if (cardCN.nameCN == CardDB.cardNameCN.恐鳞追猎者)
                {
                    if (cards.Count >= 3 )
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按规则丢弃恐鳞追猎者！";
                    }
                    if (cards.Count >= 3 && 异星虫卵 + 蛛魔之卵 >= 1)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "按特殊规则留恐鳞追猎者，因为有配合";
                    }             
                }

                if (cardCN.nameCN == CardDB.cardNameCN.拼布好朋友)
                {
                    if (cards.Count >= 3 )
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按规则丢弃拼布好朋友！";                      
                    }                 
                }

                if (cardCN.nameCN == CardDB.cardNameCN.蛛魔之卵)
                {
                    if (cards.Count >= 3)
                    {
                        card.holdByRule = 2;
                        card.holdReason = "留一张蛛魔之卵";
                        foreach (Mulligan.CardIDEntity tmp in cards)
                        {
                            if (tmp.entitiy == card.entitiy) continue;
                            if (tmp.id == card.id)
                            {
                                tmp.holdByRule = -2;
                                tmp.holdReason = "按规则丢弃第二张蛛魔之卵，去找配合";
                            }
                        }
                    }             
                }

                if (cardCN.nameCN == CardDB.cardNameCN.进化腔)
                {
                    if (cards.Count >= 3 )
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按规则丢弃进化腔，没随从呢！";                      
                    }                 
                }
                
                if (cardCN.nameCN == CardDB.cardNameCN.刺蛇)
                {
                    if (cards.Count >= 3 )
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按规则丢弃刺蛇，没开铺呢！";                      
                    }                  
                }

                if (cardCN.nameCN == CardDB.cardNameCN.劳作老马)
                {
                    if (cards.Count >= 3 )
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按规则丢弃劳作老马，干不动了！";                      
                    }                
                }

                if (cardCN.nameCN == CardDB.cardNameCN.可怕的主厨)
                {
                    if (cards.Count >= 3 )
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按规则丢弃可怕的主厨，因为太可怕了！不敢吃。";                      
                    }                  
                }

                if (cardCN.nameCN == CardDB.cardNameCN.坑道虫)
                {
                    if (cards.Count >= 3 )
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按规则丢弃坑道虫，抽嘛？来一根~";                      
                    }                  
                }

                if (cardCN.nameCN == CardDB.cardNameCN.玩具兵盒)
                {
                    if (cards.Count >= 3 )
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按规则丢弃玩具兵盒，乐高！";                      
                    }                  
                }

                if (cardCN.nameCN == CardDB.cardNameCN.奇利亚斯豪华版3000型)
                {
                    if (cards.Count >= 3 )
                    {
                        card.holdByRule = -2;
                        card.holdReason = "按规则丢弃奇利亚斯豪华版3000型，超模依旧！";                      
                    }                  
                }

                //剩下大于等于4费的卡hb是默认不留的
            }       
        }

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public override int getComboPenality(CardDB.Card card, Minion target, Playfield p, Handmanager.Handcard nowHandcard)
        {
            // 无法选中(值越大越不会打出)
            if (target != null && target.untouchable)
            {
                return 100000;
            }
            // 初始惩罚值（负为优先打出该牌，正为低优先打出该牌）
            int pen = 0;
            
            //此处为单卡描述
            switch (card.nameCN)		
            {   

                case CardDB.cardNameCN.击伤猎物:
                if (target.Hp == 1) pen -= 10;  
                break;

                case CardDB.cardNameCN.孵化池:
                if (p.ownMinions.Count >= 7 )  pen = +1000;
                pen -= 100;
                break;

                case CardDB.cardNameCN.跳虫:
                pen -= 20;
                break;

                case CardDB.cardNameCN.两栖之灵:
                if (p.ownMinions.Count >= 3 && p.ownMaxMana >= 3) pen = -50;
                if (p.enemyMinions.Count <= 0 && p.ownMinions.Count >= 2) pen = -80;
                //ToString() 会把 cardNameEN 和 cardNameCN 都转换成字符串
                if (target != null && target.name.ToString() == CardDB.cardNameCN.异星虫卵.ToString()) pen -= 85; 
                if (target != null && target.name.ToString() == CardDB.cardNameCN.蛛魔之卵.ToString()) pen -= 84;
                pen += 5; 
                break;

                case CardDB.cardNameCN.异星虫卵:
                pen -= 15;
                break;
                
                case CardDB.cardNameCN.恐鳞追猎者:
                foreach (Minion m in p.ownMinions)
				{
					if(m.handcard.card.nameCN == CardDB.cardNameCN.异星虫卵 || m.handcard.card.nameCN == CardDB.cardNameCN.蛛魔之卵 || m.handcard.card.nameCN == CardDB.cardNameCN.劳作老马)
					{
						pen -= 70;
					}
				}
                if (p.ownMinions.Count <= 0 ) pen += 100;
				break;
                
                case CardDB.cardNameCN.拼布好朋友:
                if (p.owncards.Count <= 3) pen -= 40;
                if (p.anzEnemyTaunt == 0 && p.calTotalAngr() + p.ownMinions.Count >= p.enemyHero.Hp + p.enemyHero.armor && p.ownMaxMana >= 4) pen -= 1000 ;
                break;

                case CardDB.cardNameCN.蛛魔之卵:
                pen -= 13;
                break;

                case CardDB.cardNameCN.进化腔:
                if (p.ownMinions.Count >= 3 )  pen = -90;
                foreach (Minion m in p.ownMinions)
				{
					if(m.handcard.card.nameCN == CardDB.cardNameCN.跳虫 && p.ownMinions.Count >= 2)
					{
						pen -= 90;
					}
				}
                foreach(Handmanager.Handcard hc in p.owncards)
                {
                    if (p.ownMaxMana <= 3 && (hc.card.nameCN == CardDB.cardNameCN.异星虫卵 || hc.card.nameCN == CardDB.cardNameCN.蛛魔之卵 || hc.card.nameCN == CardDB.cardNameCN.可怕的主厨) && p.ownMinions.Count <= 2) pen += 200;
                }
                pen += 5;
                break;

                case CardDB.cardNameCN.刺蛇:
                foreach (Minion m in p.ownMinions)
				{
					if(m.handcard.card.nameCN == CardDB.cardNameCN.跳虫 || m.handcard.card.nameCN == CardDB.cardNameCN.感染者 || m.handcard.card.nameCN == CardDB.cardNameCN.刺蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.巢群虫后 || m.handcard.card.nameCN == CardDB.cardNameCN.飞蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.异龙 || m.handcard.card.nameCN == CardDB.cardNameCN.蟑螂 || m.handcard.card.nameCN == CardDB.cardNameCN.脊针爬虫 || m.handcard.card.nameCN == CardDB.cardNameCN.潜伏者)
					{
						pen -= 80;
					}
				}
                pen += 50;
                break;

                case CardDB.cardNameCN.飞蛇:
                foreach (Minion m in p.ownMinions)
				{
					if(m.handcard.card.nameCN == CardDB.cardNameCN.跳虫 || m.handcard.card.nameCN == CardDB.cardNameCN.感染者 || m.handcard.card.nameCN == CardDB.cardNameCN.刺蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.巢群虫后 || m.handcard.card.nameCN == CardDB.cardNameCN.飞蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.异龙 || m.handcard.card.nameCN == CardDB.cardNameCN.蟑螂 || m.handcard.card.nameCN == CardDB.cardNameCN.脊针爬虫 || m.handcard.card.nameCN == CardDB.cardNameCN.潜伏者)
					{
						pen -= 80;
					}
				}
                pen += 50;
                break;

                case CardDB.cardNameCN.劳作老马:
                pen -= 25;               
                break;
                
                case CardDB.cardNameCN.可怕的主厨:               
                break;

                case CardDB.cardNameCN.坑道虫:
                if (p.owncards.Count <= 3) pen -= 20;
                break;

                case CardDB.cardNameCN.雷欧克:
                if (p.ownMinions.Count >= 3) pen -= 80;
                break;

                case CardDB.cardNameCN.遥控狂潮:
                if (p.ownMinions.Count >= 3 )  pen = -70;
                if (p.ownMinions.Count >= 6 )  pen = +100;
                if (p.ownMinions.Count <= 3 )  pen += 5;
                break;

                case CardDB.cardNameCN.奇利亚斯豪华版3000型:
                if (p.ownMinions.Count >= 3) pen -= 80;
                if (nowHandcard.getManaCost(p) <= 1) pen -= 80;
                if (nowHandcard.getManaCost(p) <= 3) pen -= 30;
                if (nowHandcard.getManaCost(p) > 3) pen += 10;
                break;

                case CardDB.cardNameCN.刀锋女王凯瑞甘:
                if (p.enemyMinions.Count >= 3) pen -= 1000;
                pen -= 300;
                break;

                case CardDB.cardNameCN.稳固射击:
                pen += 1;
                break;

                case CardDB.cardNameCN.毁灭跳击:
                foreach (Minion m in p.ownMinions)
				{
                    if((m.handcard.card.nameCN == CardDB.cardNameCN.跳虫 || m.handcard.card.nameCN == CardDB.cardNameCN.感染者 || m.handcard.card.nameCN == CardDB.cardNameCN.刺蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.巢群虫后 || m.handcard.card.nameCN == CardDB.cardNameCN.飞蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.异龙 || m.handcard.card.nameCN == CardDB.cardNameCN.蟑螂 || m.handcard.card.nameCN == CardDB.cardNameCN.脊针爬虫 || m.handcard.card.nameCN == CardDB.cardNameCN.潜伏者) && p.ownMinions.Count >= 3 )
					{
						pen -= 60;
					}
					if((m.handcard.card.nameCN == CardDB.cardNameCN.跳虫 || m.handcard.card.nameCN == CardDB.cardNameCN.感染者 || m.handcard.card.nameCN == CardDB.cardNameCN.刺蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.巢群虫后 || m.handcard.card.nameCN == CardDB.cardNameCN.飞蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.异龙 || m.handcard.card.nameCN == CardDB.cardNameCN.蟑螂 || m.handcard.card.nameCN == CardDB.cardNameCN.脊针爬虫 || m.handcard.card.nameCN == CardDB.cardNameCN.潜伏者) && p.ownMinions.Count >= 3 && p.enemyHero.Hp + p.enemyHero.armor<= 7)
					{
						pen -= 1000;
					}
				}
                pen -= 3;
                break;
        
                }
            return pen;
        }

        // 核心，场面值
        public override float getPlayfieldValue(Playfield p)
        {
            if (p.value > -200000) return p.value;
            float retval = 0;
            retval += getGeneralVal(p);
            retval += p.owncarddraw * 5;
            // 危险血线
            int hpboarder = 3;
            // 不考虑法强了
            if (p.enemyHeroName == HeroEnum.mage) retval += 2 * p.enemyspellpower;
            // 抢脸血线
            int aggroboarder = 20;
            retval += getHpValue(p, hpboarder, aggroboarder);
            // 出牌序列数量
            int count = p.playactions.Count;
            int ownActCount = 0;
            bool useAb = false;

            bool canBe_flameward = false;

            if (p.anzOldWoman > 0)
            {
                foreach (SecretItem si in p.enemySecretList)  //Todo: 是否要判断己方回合还是敌方回合？？？
                {
                    if (si.canBe_flameward) { canBe_flameward = true; break; }
                }
            }
            bool attacted = false;
            // 排序问题！！！！
            // 遍历所有的动作
            for (int i = 0; i < count; i++)
            {
                Action a = p.playactions[i]; // 当前动作
                ownActCount++; // 计数自己的动作数量

                // 根据不同动作类型调整评分
                switch (a.actionType)
                {
                    case actionEnum.useLocation:
                        retval -= 100;
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
                        useAb = true; // 使用了英雄技能
                        break;


                    //在这里加出牌顺序
                    case actionEnum.playcard:

                    // 判断具体的卡牌，并根据出牌顺序调整评分  减分早下  加分晚下 分数别太极端 会出毛病
                    switch (a.card.card.nameCN)
                    {

                    case CardDB.cardNameCN.幸运币:
                    case CardDB.cardNameCN.潜伏者:
                    case CardDB.cardNameCN.坑道虫:
                    case CardDB.cardNameCN.拼布好朋友:
                        retval -= i * 10;
                    break;
                    case CardDB.cardNameCN.恐鳞追猎者:
                        retval -= i * 5;
                    break;
                    }
                        break;

                    default:
                        continue;
                }

                // 如果出牌是海盗或“虚触侍从”
                if (a.card.card.race == CardDB.Race.PIRATE || a.card.card.nameCN == CardDB.cardNameCN.虚触侍从)
                {
                    // 检查己方随从是否有“船载火炮”
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.handcard.card.nameCN == CardDB.cardNameCN.船载火炮)
                        {
                            retval += 10 - i * 3; // 根据出牌顺序加分
                            break;
                        }
                    }
                }
            }
            // 对手基本随从交换模拟
            retval -= p.lostDamage;
            //retval += getSecretPenality(p); // 奥秘的影响
            retval -= p.enemyWeapon.Angr * 3 + p.enemyWeapon.Durability * 3;

            // 留着技能下回合出的情况
            if (p.ownMaxMana < 2 && p.ownHeroPowerCostLessOnce <= -99)
            {
                if (!useAb && p.enemyMinions.Count == 0)
                    retval += 20;
            }
            
             // 如果不攻击就能击杀还有额外奖励哦
            if (!attacted && p.enemyHero.Hp <= 0) retval += 10000;
            //p.value = retval;
            return retval;
        }


        // 发现卡的价值
        public override int getDiscoverVal(CardDB.Card card, Playfield p)
        {
			// Helpfunctions.Instance.logg("发现卡：" + card.nameCN);
			// Helpfunctions.Instance.logg("发现卡类型：" + card.race);
			// Helpfunctions.Instance.logg("发现卡费用：" + card.cost);
            switch (card.nameCN)
            {
    
            //随从
            //case CardDB.cardNameCN.随从名:
            //return 5;

            }
            return 0;
        }
        // 敌方随从价值 主要等于（HP + Angr） * 4
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
                case CardDB.cardNameCN.烈焰亡魂:
                case CardDB.cardNameCN.饥饿食客哈姆:
                case CardDB.cardNameCN.箭矢工匠:
                case CardDB.cardNameCN.傀儡大师多里安:
                case CardDB.cardNameCN.脆骨海盗:
                case CardDB.cardNameCN.暗影升腾者:
                case CardDB.cardNameCN.赤红教士:
                case CardDB.cardNameCN.受伤的搬运工:
                case CardDB.cardNameCN.阿米图斯的信徒:
                case CardDB.cardNameCN.隐藏宝石:
                case CardDB.cardNameCN.落难的大法师:
                case CardDB.cardNameCN.虚空协奏者:
                case CardDB.cardNameCN.神话观测者:
                case CardDB.cardNameCN.奥术工匠:
                case CardDB.cardNameCN.食肉魔块:
                case CardDB.cardNameCN.小动物看护者:
                case CardDB.cardNameCN.扭曲的织网蛛:
                case CardDB.cardNameCN.怪异魔蚊:
                case CardDB.cardNameCN.丑恶的残躯:
                case CardDB.cardNameCN.饱胀水蛭:
                case CardDB.cardNameCN.痴梦树精:
                case CardDB.cardNameCN.死亡寒冰:
                case CardDB.cardNameCN.梦缚迅猛龙:
                case CardDB.cardNameCN.雷欧克:
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
                case CardDB.cardNameCN.随船外科医师:
                case CardDB.cardNameCN.玩具船:
                case CardDB.cardNameCN.淘金客:
                case CardDB.cardNameCN.雏龙牧人:
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

                case CardDB.cardNameCN.白银之手新兵:
                case CardDB.cardNameCN.脆弱的食尸鬼:
                case CardDB.cardNameCN.伊丽扎刺刃:
                case CardDB.cardNameCN.石心之王:
                case CardDB.cardNameCN.神秘的蛋:
                case CardDB.cardNameCN.异星虫卵:
                case CardDB.cardNameCN.蛛魔之卵:
                case CardDB.cardNameCN.可怕的主厨:
                case CardDB.cardNameCN.劳作老马:
                    retval -= 150;
                    break;
                
                case CardDB.cardNameCN.侏儒飞行员诺莉亚:
                if (p.anzEnemyTaunt == 0 && p.calTotalAngr()  >= p.enemyHero.Hp + p.enemyHero.armor)
                    retval -= 150;
                    break;
               
                   
                

                
                
            }
            return retval;
        }

        // 我方随从价值，大致等于主要等于 （HP + Angr） * 4 
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
                case CardDB.cardNameCN.可怕的主厨:
                    retval -= 2 * bonus_mine;
                    break;
                case CardDB.cardNameCN.奇利亚斯豪华版3000型:
                    retval += 2 * bonus_mine;
                    break;
                case CardDB.cardNameCN.巢群虫后:
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