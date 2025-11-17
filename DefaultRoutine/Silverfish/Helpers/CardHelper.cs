using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HREngine.Bots;

namespace HREngine.Bots
{
    public class CardHelper
    {
        private static readonly Dictionary<string, Type> SimTypesDict;

        static CardHelper()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var baseType = typeof(SimTemplate);
            SimTypesDict = assembly.GetTypes().AsParallel().Where(
                t => t.Namespace == "HREngine.Bots" && t.BaseType == baseType).ToDictionary(t => t.Name, t => t);
        }

        // 根据id获取对应sim
        public static SimTemplate GetCardSimulation(CardDB.cardIDEnum tempCardIdEnum)
        {
            SimTemplate result = new SimTemplate();

            switch (tempCardIdEnum)
            {
                // 战士皮肤
                case CardDB.cardIDEnum.HERO_01wbp:
                case CardDB.cardIDEnum.HERO_01vbp:
                case CardDB.cardIDEnum.HERO_01obp:
                case CardDB.cardIDEnum.HERO_01fbp:
                case CardDB.cardIDEnum.HERO_01dbp:
                case CardDB.cardIDEnum.HERO_01bbhp:
                case CardDB.cardIDEnum.HERO_01bahp:
                case CardDB.cardIDEnum.HERO_01azhp:
                case CardDB.cardIDEnum.HERO_01ayhp:
                case CardDB.cardIDEnum.HERO_01axhp:
                case CardDB.cardIDEnum.HERO_01awhp:
                case CardDB.cardIDEnum.HERO_01auhp:
                case CardDB.cardIDEnum.HERO_01aphp:
                case CardDB.cardIDEnum.HERO_01acbp:
                case CardDB.cardIDEnum.HERO_01aabp:
                case CardDB.cardIDEnum.VAN_HERO_01bp:
                case CardDB.cardIDEnum.CS2_102_H1:
                case CardDB.cardIDEnum.CS2_102_H2:
                case CardDB.cardIDEnum.CS2_102_H3:
                case CardDB.cardIDEnum.CS2_102_H4:
                case CardDB.cardIDEnum.VAN_CS2_102_H3:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_01bp;
                    break;
                // 萨满皮肤
                case CardDB.cardIDEnum.HERO_02bfhp:
                case CardDB.cardIDEnum.HERO_02mbp:
                case CardDB.cardIDEnum.HERO_02fbp:
                case CardDB.cardIDEnum.HERO_02bhhp:
                case CardDB.cardIDEnum.HERO_02bh:
                case CardDB.cardIDEnum.HERO_02bghp:
                case CardDB.cardIDEnum.HERO_02bchp:
                case CardDB.cardIDEnum.HERO_02bbhp:
                case CardDB.cardIDEnum.HERO_02azhp:
                case CardDB.cardIDEnum.HERO_02axhp:
                case CardDB.cardIDEnum.HERO_02athp:
                case CardDB.cardIDEnum.HERO_02arhp:
                case CardDB.cardIDEnum.HERO_02an:
                case CardDB.cardIDEnum.HERO_02ambp:
                case CardDB.cardIDEnum.HERO_02ajbp_Copy:
                case CardDB.cardIDEnum.HERO_02agbp:
                case CardDB.cardIDEnum.VAN_HERO_02bp:
                case CardDB.cardIDEnum.CS2_049_H1:
                case CardDB.cardIDEnum.CS2_049_H2:
                case CardDB.cardIDEnum.CS2_049_H3:
                case CardDB.cardIDEnum.CS2_049_H4:
                case CardDB.cardIDEnum.CS2_049_H5:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_02bp;
                    break;
                // 潜行者皮肤
                case CardDB.cardIDEnum.CS2_083b_H1:
                case CardDB.cardIDEnum.CS2_083b_H2:
                case CardDB.cardIDEnum.HERO_03dbp:
                case CardDB.cardIDEnum.VAN_HERO_03bp:
                case CardDB.cardIDEnum.HERO_03acbp2://从这开始可能有强化技能污染
                case CardDB.cardIDEnum.HERO_03aqhp2:
                case CardDB.cardIDEnum.HERO_03bchp:
                case CardDB.cardIDEnum.HERO_03sbp:
                case CardDB.cardIDEnum.HERO_03akhp2:
                case CardDB.cardIDEnum.AT_132_ROGUE_H1:
                case CardDB.cardIDEnum.HERO_03acbp:
                case CardDB.cardIDEnum.HERO_03bghp:
                case CardDB.cardIDEnum.HERO_03ayhp:
                case CardDB.cardIDEnum.HERO_03mbp:
                case CardDB.cardIDEnum.HERO_03afbp:
                case CardDB.cardIDEnum.HERO_03sbp2:
                case CardDB.cardIDEnum.HERO_03ebp2:
                case CardDB.cardIDEnum.HERO_03afbp2:
                case CardDB.cardIDEnum.HERO_03bchp2:
                case CardDB.cardIDEnum.HERO_03dbp2:
                case CardDB.cardIDEnum.HERO_03rbp:
                case CardDB.cardIDEnum.HERO_03axhp2:
                case CardDB.cardIDEnum.HERO_03axhp:
                case CardDB.cardIDEnum.HERO_03ebp:
                case CardDB.cardIDEnum.HERO_03akhp:
                case CardDB.cardIDEnum.HERO_03aqhp:
                case CardDB.cardIDEnum.HERO_03arhp2:
                case CardDB.cardIDEnum.HERO_03bghp2:
                case CardDB.cardIDEnum.HERO_03mbp2:
                case CardDB.cardIDEnum.HERO_03arhp:
                case CardDB.cardIDEnum.HERO_03dbp2_Copy:
                case CardDB.cardIDEnum.HERO_03rbp2:
                case CardDB.cardIDEnum.HERO_03ayhp2:
                case CardDB.cardIDEnum.HERO_03dbp_Copy:
                case CardDB.cardIDEnum.HERO_03bdhp:
                case CardDB.cardIDEnum.HERO_03bdhp2:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_03bp;
                    break;
                // 圣骑士皮肤
                case CardDB.cardIDEnum.HERO_04aibp:
                case CardDB.cardIDEnum.HERO_04aphp:
                case CardDB.cardIDEnum.HERO_04auhp:
                case CardDB.cardIDEnum.HERO_04ayhp:
                case CardDB.cardIDEnum.HERO_04bchp:
                case CardDB.cardIDEnum.HERO_04bdhp:
                case CardDB.cardIDEnum.HERO_04fbp3:
                case CardDB.cardIDEnum.HERO_04lbp:
                case CardDB.cardIDEnum.HERO_04ubp:
                case CardDB.cardIDEnum.HERO_04wbp:
                case CardDB.cardIDEnum.CS2_101_H1:
                case CardDB.cardIDEnum.CS2_101_H2:
                case CardDB.cardIDEnum.CS2_101_H3:
                case CardDB.cardIDEnum.CS2_101_H4:
                case CardDB.cardIDEnum.HERO_04fbp:
                case CardDB.cardIDEnum.HERO_04ebp:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_04bp;
                    break;
                // 猎人皮肤
                case CardDB.cardIDEnum.VAN_HERO_05bp:
                case CardDB.cardIDEnum.DS1h_292_H1:
                case CardDB.cardIDEnum.DS1h_292_H2:
                case CardDB.cardIDEnum.DS1h_292_H3:
                case CardDB.cardIDEnum.HERO_05dbp:
                case CardDB.cardIDEnum.HERO_05bfhp2://从这开始可能有强化技能污染
                case CardDB.cardIDEnum.HERO_05ahhp2:
                case CardDB.cardIDEnum.HERO_05athp:
                case CardDB.cardIDEnum.HERO_05ambp:
                case CardDB.cardIDEnum.HERO_05aohp2:
                case CardDB.cardIDEnum.HERO_05ybp:
                case CardDB.cardIDEnum.AT_132_HUNTER_H1:
                case CardDB.cardIDEnum.DS1h_292_H3_AT_132:
                case CardDB.cardIDEnum.HERO_05ashp:
                case CardDB.cardIDEnum.HERO_05bahp:
                case CardDB.cardIDEnum.HERO_05ashp2:
                case CardDB.cardIDEnum.HERO_05zbp:
                case CardDB.cardIDEnum.HERO_05athp2:
                case CardDB.cardIDEnum.HERO_05azhp:
                case CardDB.cardIDEnum.HERO_05azhp2:
                case CardDB.cardIDEnum.HERO_05avhp:
                case CardDB.cardIDEnum.HERO_05dbp2:
                case CardDB.cardIDEnum.HERO_05avhp2:
                case CardDB.cardIDEnum.HERO_05aohp:
                case CardDB.cardIDEnum.HERO_05ybp2:
                case CardDB.cardIDEnum.DS1h_292_H1_AT_132:
                case CardDB.cardIDEnum.HERO_05ambp2:
                case CardDB.cardIDEnum.HERO_05zbp2:
                case CardDB.cardIDEnum.HERO_05bahp2:
                case CardDB.cardIDEnum.HERO_05bfhp:
                case CardDB.cardIDEnum.HERO_05ahhp:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_05bp;
                    break;
                // 德鲁伊皮肤
                case CardDB.cardIDEnum.VAN_HERO_06bp:
                case CardDB.cardIDEnum.CS2_017_HS1:
                case CardDB.cardIDEnum.CS2_017_HS2:
                case CardDB.cardIDEnum.CS2_017_HS3:
                case CardDB.cardIDEnum.CS2_017_HS4:
                case CardDB.cardIDEnum.HERO_06ebp://
                case CardDB.cardIDEnum.HERO_06fbp:
                case CardDB.cardIDEnum.HERO_06zbp:
                case CardDB.cardIDEnum.HERO_06aibp:
                case CardDB.cardIDEnum.HERO_06ayhp:
                case CardDB.cardIDEnum.HERO_06bjhp:
                case CardDB.cardIDEnum.HERO_06pbp:
                case CardDB.cardIDEnum.AT_132_DRUIDa:
                case CardDB.cardIDEnum.HERO_06ubp:
                case CardDB.cardIDEnum.HERO_06awhp:
                case CardDB.cardIDEnum.HERO_06ashp:
                case CardDB.cardIDEnum.HERO_06behp:
                case CardDB.cardIDEnum.HERO_06rbp:
                case CardDB.cardIDEnum.HERO_06bahp:
                case CardDB.cardIDEnum.HERO_06ahbp:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_06bp;
                    break;
                // 术士皮肤
                case CardDB.cardIDEnum.HERO_07bbhp:
                case CardDB.cardIDEnum.VAN_HERO_07bp:
                case CardDB.cardIDEnum.CS2_056_H1:
                case CardDB.cardIDEnum.CS2_056_H2:
                case CardDB.cardIDEnum.CS2_056_H3:
                case CardDB.cardIDEnum.HERO_07dbp:
                case CardDB.cardIDEnum.HERO_07ebp:
                case CardDB.cardIDEnum.HERO_07bghp://从这开始可能有强化技能污染
                case CardDB.cardIDEnum.HERO_07amhp2:
                case CardDB.cardIDEnum.HERO_07aqhp2:
                case CardDB.cardIDEnum.HERO_07anhp2:
                case CardDB.cardIDEnum.HERO_07axhp:
                case CardDB.cardIDEnum.HERO_07azhp2:
                case CardDB.cardIDEnum.HERO_07bdhp2:
                case CardDB.cardIDEnum.HERO_07blhp:
                case CardDB.cardIDEnum.HERO_07zbp:
                case CardDB.cardIDEnum.HERO_07azhp:
                case CardDB.cardIDEnum.HERO_07arhp:
                case CardDB.cardIDEnum.HERO_07ebp2_Copy:
                case CardDB.cardIDEnum.HERO_07axhp2:
                case CardDB.cardIDEnum.AT_132_WARLOCKb:
                case CardDB.cardIDEnum.HERO_07ybp:
                case CardDB.cardIDEnum.HERO_07ebp2:
                case CardDB.cardIDEnum.HERO_07anhp:
                case CardDB.cardIDEnum.HERO_07aqhp:
                case CardDB.cardIDEnum.AT_132_WARLOCKa:
                case CardDB.cardIDEnum.HERO_07bbhp2:
                case CardDB.cardIDEnum.HERO_07ybp2:
                case CardDB.cardIDEnum.HERO_07blhp2:
                case CardDB.cardIDEnum.HERO_07bdhp:
                case CardDB.cardIDEnum.HERO_07zbp2:
                case CardDB.cardIDEnum.HERO_07agbp:
                case CardDB.cardIDEnum.HERO_07bchp2:
                case CardDB.cardIDEnum.HERO_07arhp2:
                case CardDB.cardIDEnum.HERO_07bchp:
                case CardDB.cardIDEnum.HERO_07dbp2:
                case CardDB.cardIDEnum.HERO_07bghp2:
                case CardDB.cardIDEnum.HERO_07amhp:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_07bp;
                    break;
                // 法师皮肤
                case CardDB.cardIDEnum.HERO_08bchp:
                case CardDB.cardIDEnum.CS2_034_H1:
                case CardDB.cardIDEnum.CS2_034_H2:
                case CardDB.cardIDEnum.CS2_034_H3:
                case CardDB.cardIDEnum.CS2_034_H4:
                case CardDB.cardIDEnum.HERO_08ebp:
                case CardDB.cardIDEnum.HERO_08fbp:
                case CardDB.cardIDEnum.TRLA_Mage_01:
                case CardDB.cardIDEnum.VAN_HERO_08bp:
                case CardDB.cardIDEnum.HERO_08lbp:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_08bp;
                    break;
                // 牧师皮肤
                case CardDB.cardIDEnum.CS1h_001_H1:
                case CardDB.cardIDEnum.CS1h_001_H2:
                case CardDB.cardIDEnum.CS1h_001_H3:
                case CardDB.cardIDEnum.HERO_09dbp:
                case CardDB.cardIDEnum.VAN_HERO_09bp:
                case CardDB.cardIDEnum.HERO_09ajhp2://从这开始可能有强化技能污染
                case CardDB.cardIDEnum.HERO_09athp:
                case CardDB.cardIDEnum.HERO_09agbp:
                case CardDB.cardIDEnum.HERO_09athp2:
                case CardDB.cardIDEnum.HERO_09ajhp:
                case CardDB.cardIDEnum.HERO_09dbp2:
                case CardDB.cardIDEnum.HERO_09arhp2:
                case CardDB.cardIDEnum.HERO_09bahp:
                case CardDB.cardIDEnum.HERO_09behp2:
                case CardDB.cardIDEnum.HERO_09bahp2:
                case CardDB.cardIDEnum.HERO_09bdhp2:
                case CardDB.cardIDEnum.HERO_09abbp:
                case CardDB.cardIDEnum.CS1h_001_H1_AT_132:
                case CardDB.cardIDEnum.HERO_09dbp_Copy:
                case CardDB.cardIDEnum.HERO_09bdhp:
                case CardDB.cardIDEnum.HERO_09aqhp:
                case CardDB.cardIDEnum.HERO_09arhp:
                case CardDB.cardIDEnum.HERO_09abbp2:
                case CardDB.cardIDEnum.HERO_09dbp2_Copy:
                case CardDB.cardIDEnum.HERO_09aqhp2:
                case CardDB.cardIDEnum.HERO_09behp:
                case CardDB.cardIDEnum.CS1h_001_H2_AT_132:
                case CardDB.cardIDEnum.HERO_09agbp2:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_09bp;
                    break;
                // 恶魔猎人皮肤
                case CardDB.cardIDEnum.HERO_10akhp:
                case CardDB.cardIDEnum.HERO_10amhp:
                case CardDB.cardIDEnum.HERO_10ashp:
                case CardDB.cardIDEnum.HERO_10auhp:
                case CardDB.cardIDEnum.HERO_10awhp:
                case CardDB.cardIDEnum.HERO_10azhp:
                case CardDB.cardIDEnum.HERO_10bbp:
                case CardDB.cardIDEnum.HERO_10bd:
                case CardDB.cardIDEnum.HERO_10bdhp:
                case CardDB.cardIDEnum.HERO_10lbp:
                case CardDB.cardIDEnum.HERO_10zbp:
                case CardDB.cardIDEnum.HERO_10xbp:
                case CardDB.cardIDEnum.HERO_10bpe:
                case CardDB.cardIDEnum.HERO_10cbp:
                case CardDB.cardIDEnum.TB_HunterPrince_04:
                case CardDB.cardIDEnum.VAN_HERO_10bp:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_10bp;
                    break;
                //巫妖王皮肤
                case CardDB.cardIDEnum.HERO_11gbp:
                case CardDB.cardIDEnum.HERO_11fbp:
                case CardDB.cardIDEnum.HERO_11hbp:
                case CardDB.cardIDEnum.HERO_11ibp:
                case CardDB.cardIDEnum.HERO_11lbp:
                case CardDB.cardIDEnum.HERO_11ohp:
                case CardDB.cardIDEnum.HERO_11uhp:
                case CardDB.cardIDEnum.HERO_11vhp:
                case CardDB.cardIDEnum.HERO_11zhp:
                case CardDB.cardIDEnum.HERO_11aehp:
                case CardDB.cardIDEnum.HERO_11cbp:
                case CardDB.cardIDEnum.HERO_11ajhp:
                case CardDB.cardIDEnum.HERO_11aqhp://新
                case CardDB.cardIDEnum.HERO_11aghp:
                case CardDB.cardIDEnum.HERO_11aihp:
                    tempCardIdEnum = CardDB.cardIDEnum.HERO_11bp;
                    break;
                // 异画幸运币
                case CardDB.cardIDEnum.FP1_COIN:
                case CardDB.cardIDEnum.GVG_COIN:
                case CardDB.cardIDEnum.AT_COIN:
                case CardDB.cardIDEnum.TB_011:
                case CardDB.cardIDEnum.LOE_COIN:
                case CardDB.cardIDEnum.CFM_630:
                case CardDB.cardIDEnum.DAL_COIN:
                case CardDB.cardIDEnum.ULD_COIN:
                case CardDB.cardIDEnum.DRG_COIN:
                case CardDB.cardIDEnum.BT_COIN:
                case CardDB.cardIDEnum.BAR_COIN3:
                case CardDB.cardIDEnum.DMF_COIN1:
                case CardDB.cardIDEnum.DMF_COIN2:
                case CardDB.cardIDEnum.BAR_COIN1:
                case CardDB.cardIDEnum.BAR_COIN2:
                case CardDB.cardIDEnum.SW_COIN1:
                case CardDB.cardIDEnum.SW_COIN2:
                case CardDB.cardIDEnum.AV_COIN1:
                case CardDB.cardIDEnum.AV_COIN2:
                case CardDB.cardIDEnum.EX1_169:
                case CardDB.cardIDEnum.CORE_EX1_169:
                case CardDB.cardIDEnum.GAME_005:
                case CardDB.cardIDEnum.VAN_EX1_169:
                case CardDB.cardIDEnum.TSC_COIN1:
                case CardDB.cardIDEnum.TSC_COIN2:
                case CardDB.cardIDEnum.REV_COIN1:
                case CardDB.cardIDEnum.REV_COIN2:
                case CardDB.cardIDEnum.RLK_COIN1:
                case CardDB.cardIDEnum.RLK_COIN2:
                case CardDB.cardIDEnum.ETC_COIN1:
                case CardDB.cardIDEnum.TTN_COIN1:
                case CardDB.cardIDEnum.TTN_COIN2:
                case CardDB.cardIDEnum.WW_COIN1:
                case CardDB.cardIDEnum.WW_COIN2:
                case CardDB.cardIDEnum.TOY_COIN1:
                case CardDB.cardIDEnum.TOY_COIN2:
                case CardDB.cardIDEnum.TOY_COIN3:
                case CardDB.cardIDEnum.VAC_COIN1:
                case CardDB.cardIDEnum.VAC_COIN2:
                case CardDB.cardIDEnum.GDB_COIN1:
                case CardDB.cardIDEnum.GDB_COIN2:
                case CardDB.cardIDEnum.MUDAN_COIN1:
                case CardDB.cardIDEnum.EDR_COIN1:
                case CardDB.cardIDEnum.EDR_COIN2:
                case CardDB.cardIDEnum.LOOTA_BOSS_45p:
                case CardDB.cardIDEnum.TLC_COIN1://龟
                case CardDB.cardIDEnum.TLC_COIN2:
                case CardDB.cardIDEnum.DINO_COIN1://龟迷你
                case CardDB.cardIDEnum.DINO_COIN2:
                case CardDB.cardIDEnum.TIME_COIN1://时间流
                case CardDB.cardIDEnum.TIME_COIN2://时间流
                    tempCardIdEnum = CardDB.cardIDEnum.GAME_005;
                    break;
            }

            var className = string.Format("Sim_{0}", tempCardIdEnum);
            var simType = GetTypeByName(className);
            if (simType != null)
            {
                result = Activator.CreateInstance(simType) as SimTemplate;
            }
            //else
            //{
            //    Helpfunctions.Instance.ErrorLog("missing sim class: " + className);
            //}
            return result;
        }

        /// <summary>
        /// Gets a all Type instances matching the specified class name with just non-namespace qualified class name.
        /// </summary>
        /// <param name="className">Name of the class sought.</param>
        /// <returns>Types that have the class name specified. They may not be in the same namespace.</returns>
        public static Type GetTypeByName(string className)
        {
            Type t;
            if (SimTypesDict.TryGetValue(className, out t))
                return t;
            return null;
        }

        public static bool IsCardSimulationImplemented(SimTemplate cardSimulation)
        {
            var type = cardSimulation.GetType();
            var baseType = typeof(SimTemplate);
            bool implemented = type.IsSubclassOf(baseType);
            return implemented;
        }
    }
}
