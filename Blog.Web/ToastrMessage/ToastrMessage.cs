namespace Blog.Web.ToastrMessaje
{
    public static class ToastrMessage
    {
        public static class Article
        {
            public static string ArticleAddSuccesfull(string articleTitle)
            {
                return $"{articleTitle} başlıklı içerik başarıyla eklendi.";
            }
            public static string ArticleUpdateSuccesfull(string articleTitle)
            {
                return $"{articleTitle} başlıklı içerik başarıyla güncellendi.";
            }
            public static string ArticleAddUnSuccessful(string articleTitle)
            {
                return $"{articleTitle} başlıklı içerik eklenemedi!!!.";
            }
            public static string ArticleUpdateUnSuccessful(string articleTitle)
            {
                return $"{articleTitle} başlıklı içerik başarıyla güncellenemedi!!!";
            }
            public static string ArticleDeleteSuccessful(string articleTitle)
            {
                return $"{articleTitle} başlıklı içerik başarıyla silindi!!!";
            }
        }
    }
}
//Toastr kütüphanesini kullanmak için önce Blog.web katmanına kütphaneyi packatenaget üzerinden kütüphaneyi kuruyoruz. akabinde ise program.cs ye servis olarak tanıyoruz orada yazıolması gereken kodlar var hem üstte hem altta devamında ise işimiz bitmiyor, uzuantısı var kullnılacak Viewlrt için ortak alan olan Layoutlara ekliyoruz. Devamında ise kullanılacak alanda ilgili Controllere(mesela articlecontoller ekledik.) gidiyoruz. Gerekli işlemleri burada yapıyoruz. kullandık. Blog.Web e bir klasör açtık bu klasörde static sınıflar oluşturduk, ve burada nerene ne yapması gerekiyor nerede çıkacak error mü warning mi success mi error mu ne olduğunu ve ilgili mesaj kısmını ekliyoruz. Tekrar Controllere gelip "field" ını oluşturmak için gerekli kodları yazıyoruz. kullanıma hazır hale gelmiş olur. Artık tek yapılması gereken şey controllerin metodlarında nerede ne iş yapacağını beklentisi üzerine BlogWeb teki ToastrMessage klasöründen static classları istemek kalıyor. 