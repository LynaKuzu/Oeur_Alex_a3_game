using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game10003;

public class Player(int plrX, int plrY, float hpM, int numCos)
{
    float hpC = hpM;
    public int CosNumis()
    {
        //placeholder code
        return numCos;
    }
    //draw player
    public void Blit()
    {
        Draw.FillColor = new(200, 200, 200);
        Draw.Rectangle(plrX, plrY, 50, 50);
        Draw.FillColor = new(0, 255, 0);
        Draw.Rectangle(plrX - 25, plrY - 10, (hpC / hpM) * 100, 5);
    }
    public void HpSub(int dmg)
    {
        hpC = hpC - dmg;
    }
    //set player position
    public void SetPlrPos(int numX, int numY)
    {
        plrX = numX;
        plrY = numY;
    }
    public void MovePlrPos(int numX, int numY)
    {
        plrX += numX;
        plrY += numY;
    }
    public int getX()
    {
        return plrX;
    }
    public int getY()
    {
        return plrY;
    }

}
