using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 随从 猎人 费用：3 攻击力：4 生命值：2
    // Hydralisk
    // 刺蛇
    // [x]<b>Battlecry:</b> Deal 2 damage to a random enemy. 
    // Repeat for each other Zerg minion you control.
    // <b>战吼：</b>随机对一个敌人造成 2 点伤害。你每控制一个其他异虫随从，重复一次。

    class Sim_SC_008 : SimTemplate
    {
        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            List<Minion> temp = (own.own) ? p.ownMinions : p.enemyMinions; // 获取己方随从列表
            int zergCount = 0;

            // 计算其他 Zerg 随从数量
            foreach (Minion m in temp)
            {
                //foreach (Minion m in p.ownMinions)
                
                    if(m.handcard.card.nameCN == CardDB.cardNameCN.跳虫 || m.handcard.card.nameCN == CardDB.cardNameCN.刺蛇 || m.handcard.card.nameCN == CardDB.cardNameCN.刺蛇|| m.handcard.card.nameCN == CardDB.cardNameCN.巢群虫后)
                    {
                       zergCount++;
                   }
                
            }

            // 进行 (1 + zergCount) 次随机伤害
            for (int i = 0; i <= zergCount; i++)
            {
                if (target != null)
                {
                    p.minionGetDamageOrHeal(target, 2);
                }
                else
                {
                    p.minionGetDamageOrHeal(own.own ? p.enemyHero : p.ownHero, 2);
                }
            }
        }
    }
}