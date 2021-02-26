using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Başarıyla Eklenmiştir.";
        public static string AddedError = "Ürün ismi en az 2 karakter ve Günlük Fiyat 0'dan büyük olmalıdır.";
        public static string Deleted =" Başarıyla Silinmiştir.";
        public static string Updated = " Başarıyla Güncellendi.";
        public static string GetAll = "Tümü Listelendi..";
        public static string CarDetailDto = "Detay Getirildi.";
        public static string Maintenance="Sistem Bakımdadır.";
        public static string GetId = "Id'ye Ait Bilgi Getirildi.";
        public static string ReturnDateError = "Seçmiş olduğunuz araba bir başkası tarafından kiralanmıştır. ";
        public static string Error = "İşlem Başarısız";
        public static string CheckIfBrandCarCountOfBrandCorrectError = "Bu markada en fazla 15 ürün olabilir.";
        public static string CheckIfCarNameExistsError = "Aynı isimde bir araba mevcut";

        public static string CheckIfBrandLimitExcededError = "Bu markada araba sayısı 15'i geçmiş olduğundan araba eklenemiyor.";

        public static string CarImageCountError = "Araba görseli en az 5 olmalıdır.";
    }
}
