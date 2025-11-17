using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
	//随从 战士 费用：3 攻击力：4 生命值：3
	//Barricade Basher
	//怒袭甲龙
	//[x]Whenever you gain Armor, gain +2/+2 and attack arandom enemy minion.
	//每当你获得护甲值，获得+2/+2并随机攻击一个敌方随从。
	class Sim_DINO_400 : SimTemplate
	{
		public override void onHeroGotarmor(Playfield p, Minion own)
        {
            p.minionGetBuffed(own, 2, 2);
            
            //List<Minion> enemyMinions = own.own ? p.enemyMinions : p.ownMinions;
            //if (enemyMinions.Count == 0) return;
            //int index = p.Minion.Next(0, enemyMinions.Count);
            //p.minionAttacksMinion(own, enemyMinions[index]);
        }
	}
}
