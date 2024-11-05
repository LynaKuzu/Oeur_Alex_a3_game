using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game10003;

public class TimedAttack(int atkDmg, int atkTime, int atkTimeMax)
{
    public int GetDmg()
    {
        return atkDmg;
    }
    public void Tick(int reduceTime)
    {
        atkTime = atkTime - reduceTime;
    }
    public void LoadAtk()
    {
        
        atkTime = 30 + Random.Integer(100);
    }
    public float getTime()
    {
        //return (atkTime / atkTimeMax) * 100;
        return atkTime;
    }
}