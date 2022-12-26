using Blog.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.FluentValidation
{
    public class ArticleValidator: AbstractValidator<Article>//Servislerde  yani Bura yapıldıktan sonra servislere eklenmesi gerekiyor ki faailiyete geçsin bunu da şuraya ekliyoruz. Servic katmanında Extencions içindeki ServiceLayerExtensşon classının içine dahil edilecektir. Takibi buradan yap. akabinde ise Extensitions klasörüne gidip bir class oluşturuyoruz. Bu Clasın ismi ise FluentValidationExtensions gibi bir isim veriyoruz. Akabinde bu clasın içinde static classlar oluşturuyoruz. Tam bitmedi mimarisi kurmuş olduk şimdi kullanmaya gelince bu durumu ilgili entity nin controllerine gidip işleme alacaz biz burada ilk olarak ArticleControlelr e gidip inşasını oluşturacaz hazır hale gelmiş olur. dedik olmadı akabinde ilgili View syfasına kayıt formunun altına bunu  => <div asp-validation-summary="ModelOnly"></div>  ekledik devamında ise => <span asp-validation-for="CategoryId" class="text-danger"></span> bunu da veri girişlerinin olacağı heryere entegre ettik ve bitiyor. 
    {
        public ArticleValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .NotNull()
                .MaximumLength(151)
                .MinimumLength(3)
                .WithName("Başlık");
            RuleFor(x => x.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(501)
                .MinimumLength(15)
                .WithName("Başlık");

        }

    }
}
