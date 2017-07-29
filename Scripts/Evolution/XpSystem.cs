using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Server.Mobiles;

namespace Server.Evolution
{
    public class XpSystem
    {
        [CommandProperty(AccessLevel.GameMaster)]
        public int pointXP { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int niveaux { get; set; }

        public void Serialize(GenericWriter writer)
        {
            writer.Write(36);  //version
            writer.Write(pointXP);
            writer.Write(niveaux);
        }

        public XpSystem()
        {
            pointXP = 0;
            niveaux = 0;
        }

        public XpSystem(GenericReader reader)
        {
            int version = reader.ReadInt();
            pointXP = reader.ReadInt();
            niveaux = reader.ReadInt();
        }

        public bool levelUp()
        {
            bool lvlUp = false;
            switch (niveaux)
            {
                case 0:
                    if (pointXP >= 1)
                        lvlUp = true;
                    break;
                case 1:
                    if (pointXP >= 3)
                        lvlUp = true;
                    break;
                case 2:
                    if (pointXP >= 7)
                        lvlUp = true;
                    break;
                case 3:
                    if (pointXP >= 13)
                        lvlUp = true;
                    break;
                case 4:
                    if (pointXP >= 19)
                        lvlUp = true;
                    break;
                case 5:
                    if (pointXP >= 26)
                        lvlUp = true;
                    break;
                case 6:
                    if (pointXP >= 34)
                        lvlUp = true;
                    break;
                case 7:
                    if (pointXP >= 43)
                        lvlUp = true;
                    break;
                case 8:
                    if (pointXP >= 53)
                        lvlUp = true;
                    break;
                case 9:
                    if (pointXP >= 64)
                        lvlUp = true;
                    break;
                case 10:
                    if (pointXP >= 76)
                        lvlUp = true;
                    break;
                case 11:
                    if (pointXP >= 83)
                        lvlUp = true;
                    break;
                case 12:
                    if (pointXP >= 97)
                        lvlUp = true;
                    break;
                case 13:
                    if (pointXP >= 112)
                        lvlUp = true;
                    break;
                case 14:
                    if (pointXP >= 128)
                        lvlUp = true;
                    break;
                case 15:
                    if (pointXP >= 145)
                        lvlUp = true;
                    break;
                case 16:
                    if (pointXP >= 163)
                        lvlUp = true;
                    break;
                case 17:
                    if (pointXP >= 182)
                        lvlUp = true;
                    break;
                case 18:
                    if (pointXP >= 202)
                        lvlUp = true;
                    break;
                case 19:
                    if (pointXP >= 223)
                        lvlUp = true;
                    break;
                case 20:
                    if (pointXP >= 245)
                        lvlUp = true;
                    break;
                case 21:
                    if (pointXP >= 268)
                        lvlUp = true;
                    break;
                case 22:
                    if (pointXP >= 292)
                        lvlUp = true;
                    break;
                case 23:
                    if (pointXP >= 317)
                        lvlUp = true;
                    break;
                case 24:
                    if (pointXP >= 343)
                        lvlUp = true;
                    break;
                case 25:
                    if (pointXP >= 100000)
                        lvlUp = true;
                    break;
                default:
                    break;
            }
            if (lvlUp == true)
                niveaux++;
            return lvlUp;
        } 
        
        public void SkillUpdate(PlayerMobile from)
        {
            for (int i = 0; i < Enum.GetNames(typeof(SkillName)).Length; ++i)
            {
                if (from.m_exp.niveaux == 0)
                    from.Skills[i].Cap = 40;
                else
                    from.Skills[i].Cap = 40 + from.m_exp.niveaux * 2;
            }
            if (from.m_exp.niveaux == 0)
                from.Skills.Cap = 200;
            else
                from.Skills.Cap = 200 + from.m_exp.niveaux * 20;
        }  
    }
}
