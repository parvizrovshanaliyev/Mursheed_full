namespace ERP.Mursheed.Utility
{
    public enum ResultCode
    {
        Success = 1,
        Error = 2,
        Unauthorize = 3,
        Blocked = 4,
        NotFound = 5
    }

    #region HRM
    public enum EPhoneType
    {
        Home = 1,
        Mobile = 2,
        Work = 3,
    }
    public enum EContractType
    {
        Muqavile = 1,
        Daimi = 2
    }
    public enum EPersonApplicationType
    {
        IsdenCixarilma = 1,
        IseQebul = 2,
        Xitam = 3
    }
    public enum EPersonelFileType
    {
        DiplomunKopyasi = 1,
        HerbiBilet = 2,
        NigahHaqqindaSehadetname = 3,
        Ovladlarinin_D_H_Sehadetnamesi = 4,
        IseQebulErizesi = 5,
        DSMF = 6,
        MaddiMesulliyyet = 7,
        EmekKitabcasi = 8
    }
    #endregion
}
