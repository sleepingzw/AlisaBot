namespace AlisaDependency.DataTypes.Infos;

public class SvRoomInfo
{
    public int whatServer; // 0 国际 1 国服
    public int roomNum;
    public DateTime createTime;

    public SvRoomInfo(int whatServer, int roomNum)
    {
        this.whatServer = whatServer;
        this.roomNum = roomNum;
        this.createTime=DateTime.Now;
    }
}