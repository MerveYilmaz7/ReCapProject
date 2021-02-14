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
    }
}
