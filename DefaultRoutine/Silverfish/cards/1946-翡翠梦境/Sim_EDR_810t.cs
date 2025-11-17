using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 巫妖王 费用：1 攻击力：0 生命值：2
	//Bloated Leech
	//饱胀水蛭
	//[x]At the end of your turn, yourhero steals @ Health fromthe lowest Health enemy.
	//在你的回合结束时，你的英雄会从生命值最低的敌人处偷取@点生命值。
	class Sim_EDR_810t : SimTemplate
	{
		public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                Minion target = null;

                if (turnEndOfOwner)
                {
                    target = p.getEnemyCharTargetForRandomSingleDamage(1);
                }
                else
                {
                    target = p.searchRandomMinion(p.ownMinions, searchmode.searchHighestAttack); 
                    if (target == null) target = p.ownHero;
                }
                p.minionGetDamageOrHeal(target, 1, true);
                triggerEffectMinion.stealth = false;
                // === 丑恶的残躯在场判断 ===
                if (turnEndOfOwner && p.enemyHero.Hp <= 4)
                {
                    bool hasHusk = false;
                    foreach (Minion m in p.ownMinions)
                    {
                        if (m.nameCN == CardDB.cardNameCN.丑恶的残躯 && !m.silenced)
                        {
                            hasHusk = true;
                            break;
                        }
                    }

                    if (hasHusk)
                    {
                        // 重新检测最低血量目标（包含英雄）
                        Minion lowestTarget = p.enemyHero;
                        foreach (Minion m in p.enemyMinions)
                        {
                            if (m.Hp > 0 && m.Hp < lowestTarget.Hp) 
                                lowestTarget = m;
                        }

                        // 追加额外2点伤害（总伤害=基础1+额外1=2）
                        p.minionGetDamageOrHeal(lowestTarget, 1, true);
                        p.minionGetDamageOrHeal(triggerEffectMinion.own ? p.ownHero : p.enemyHero, -1);
                    }
                }
            }
        }
    }
}