using System;
using System.Collections.Generic;
using System.Text;

namespace ERP.Atlas.Utility
{
    public static class ResultConst
    {
        #region Global  
        public const string RequiredProperty = "Bu məlumat daxil edilməlidir";
        public const string PercentRequiredProperty = "Faiz yoxdursa 0 daxil edin";

        public const string NoChanges = "Heç bir dəyişiklik olunmadı";

        public const string Maxlength20 = "Ən çox 20 simvol daxil edilə bilər";
        public const string Maxlength50 = "Ən çox 50 simvol daxil edilə bilər";
        public const string Maxlength100 = "Ən çox 100 simvol daxil edilə bilər";

        public const string Minlength3 = "Ən az 3 simvol daxil edilməlidir";
        public const string Minlength10 = "Ən az 10 simvol daxil edilməlidir";

        public const string OperationSuccessed = "Əməliyyat uğurla başa çatdı.!";
        public const string Error = "Xəta baş verdi.!";

        public const string ModelNotValid = "Zəhmət olmasa bütün xanaları doldurun!";

        public const string AddSuccess = "Uğurla əlavə edildi.!";
        public const string EditSuccess = "Uğurla redaktə edildi.!";
        public const string DeleteSuccess = "Uğurla silindi.!";
        #endregion

        #region Login
        //user null
        public const string MinlengthLogin = "Ən az 6 simvol daxil edilməlidir";
        public const string UserNull = " Hörmətli istifadəçi Daxil edilən məlumatlar düz deyil!";
        public const string LockedOut = "Hörmətli istifadəçi daxil etdiyiniz məlumatlar düz deyil, hesabınız 5 dəqiqəlik bloklanıb!";
        public const string Blocked = "Hörmətli istifadəçi  hesabınız  bloklanıb!";
        public const string UsernameorPassWrong = "İstifadəçi Adı və ya Şifrə düz deyil!";

        #endregion
    }
}
