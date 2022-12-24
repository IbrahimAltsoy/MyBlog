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
