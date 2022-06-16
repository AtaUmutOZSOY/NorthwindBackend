using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static class ColorMassages
        {
            public static string ColorExistMassage = "Bu İsimde Bir Renk Mevcut";

        }

        public static class AuthMessages
        {
            public static string UnSucceedLogIn = "Kullanıcı Adı veya Parola Yanlış";
            public static string SucceedUserRegistiration = "Kullanıcı Başarıyla Oluşturuldu";
            public static string AuthorizationDenied = "Yetkiniz Yok";
            public static string RegistirationDenied = "Kullanıcı Adı veya Parola Yanlış";
            public static string SuccessLogin = "Giriş Başarılı";
            public static string AccessTokenCreated = "Token Başarılı Şekilde Oluşturuldu";
            public static string UserNotExist = "Bu E-mail Adresine Kayıtlı Bir Kullanıcı Yok";

        }
        

        public static class BrandMessages
        {
            
        }
        public static class CarImagesMassages
        {
            public static string CarImageCountsError = "Araç Resmi Sayısı En Fazla 5 Adet Olabilir";
        }
        public static class UserMassages
        {
            public static string UserDeleted = "Kullanıcı Başarılı Bir Şekilde Silindi";
            public static string UserNotFound = "Kullanıcı Bulunamadı";
            public static string UserAlreadyExist = "Bu E-Posta Adresi ile Kayıtlı Kullanıcı Zaten Var";
        }
        public static class ActionMessages
        {
            public static string SuccedAdd = "Ekleme Başarılı";
            public static string SuccedRemove = "Silme Başarılı";
            public static string SuccedUpdate = "Güncelleme Başarılı";
            public static string UnsuccedUpdate = "Güncelleme Başarısız";
            public static string UnsucceddAdd = "Ekleme Başarısız.";
            public static string UnsucceddRemove = "Silme Başarısız";
            public static string NotExist = "Bu İsimde Bir Değer Bulunamadı";
            public static string AlreadyExist= "Zaten Mevcut" ;
        }
    }
}
