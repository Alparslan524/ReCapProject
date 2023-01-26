using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarListed = "Arabalar Listelendi";
        public static string ListedByPrice = "Fiyat Aralığına Göre Listelendi";
        public static string CarDetailListed = "Araç Detayları Listelendi";
        public static string FalseDailyPrice = "Günlük Fiyat Sıfırdan Büyük Olmalıdır";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorListed = "Renkler Listelendi";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandListed = "Markalar Listelendi";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserListed = "Kullanıcılar Listelendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerListed = "Müşteriler Listelendi";

        public static string RentalAdded = "Kiralama İşlemi Eklendi";
        public static string RentalDeleted = "Kiralama İşlemi Silindi";
        public static string RentalUpdated = "Kiralama İşlemi Güncellendi";
        public static string RentalListed = "Kiralamalar Listelendi";
        public static string BrandQuantityError = "Bir markanın maksimum 10 aracı olabilir";
        public static string SameDescription = "Aynı açıklamaya sahip başka bir araç var";
        public static string MaxBrandQuantity = "Marka sayısı 15i geçti. Ürün eklenemez";

        public static string CarImageAdded = "Araç resmi eklendi";
        public static string CarImageDeleted = "Araç resmi silindi";
        public static string CarImageListed = "Araç resmleri listelendi";
        public static string CarImageUpdated = "Araç resmi güncellendi";

        public static string MaxImageError = "Bir aracın maksimum 5 resmi olabilir";

        public static string GetImagesByCarIdListed = "Araç ID sine göre resimleri listelendi";

        public static string DefaultCarImageAdded = "Default Araç resmi yüklendi";
    }
}
