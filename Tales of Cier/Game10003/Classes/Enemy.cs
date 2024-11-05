using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game10003;

public class Enemy(float hpM, int enmyX, int enmyY)
{
    float hpC = hpM;
    public void HpSub(int dmg)
    {
        hpC = hpC - dmg;
    }
    public void Blit()
    {
        Draw.FillColor = new(255, 0, 0);
        Draw.Rectangle(enmyX, enmyY, 50, 50);
        Draw.FillColor = new(0, 255, 0);
        Draw.Rectangle(enmyX - 25, enmyY - 10, (hpC / hpM) * 100, 5);
    }
}
