namespace HomeDesign.Migrations
{
    using HomeDesign.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.UI.WebControls;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeDesign.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeDesign.Models.ApplicationDbContext context)
        {
            //admin rolünde bir kullanýcý yoksa oluþtur
            //https://stackoverflow.com/questions/19280527/mvc-5-seed-users-and-roles
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "mrvttnc96@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "mrvttnc96@gmail.com",
                    Email = "mrvttnc96@gmail.com",
                    DisplayName = "Merve T",
                    EmailConfirmed = true

                };

                manager.Create(user, "Password1.");
                manager.AddToRole(user.Id, "admin");

                #region Seed Categories and Projects

                if (!context.Categories.Any())
                {
                    context.Categories.Add(new Category
                    {
                        CategoryName = "Bedroom Decoration ",
                        Projects = new List<Project>
                        {
                            new Project
                            {

                               Title="Bohem Decoration 1",
                               UserId=user.Id,
                               Content="<p> Bohem tarzdan hoþlanýyorsanýz veya evinize daha fazla konfor ve rahatlýk getirecek bir dekorasyon arýyorsanýz bu tarza yoðunlaþmanýn" +
                               " zamaný gelmiþ demektir. Bohem dekorasyon ayný zamanda eklektik stil olduðundan keskin çizgileri olduðu söylenemez. Yani herkes kendi " +
                               "zevkine göre bohem tarz estetiðine sahip olabilir. Dilerseniz bohem stilin yalnýzca bir bölümünü kullanabilir dilerseniz de" +
                               " bu tarzý bütünüyle uygulayabilirsiniz. Rahatlýðýyla ön plana çýkan bohem dekorasyon konforlu anlayýþýndan ötürü yatak odalarýna çok uygundur." +
                               " Zira evde oturma odasý ile birlikte konfor kriteri ön plana çýkan diðer alan yatak odasýdýr. Baþta yataðýnýz olmak üzere kendi zevkinize göre" +
                               " dekore edebileceðiniz bu tarz size keyifli ve huzurlu bir atmosfer saðlayacak ayný zamanda yatak odanýzýn kendine has bir çizgisi olmasýný saðlayacaktýr." +
                               "</p>",
                               Slug="bohem-decoration-1",
                               CreationTime=DateTime.Now,
                               ModificationTime=DateTime.Now

                            },

                            new Project
                            {

                               Title="Bohem Decoration 2",
                               UserId=user.Id,
                               Content="<p> Bohem dekorasyon göz alýcý canlý renkler, deðiþik desenler ve sanatsal atmosferin harmanladýðý bir stildir. " +
                               "Mor, mavi, sarý, turuncu, kahverengi ve pembenin parlak tonlarýný bu tarzda bolca kullanýlýr. Yatak odasý özelinde baktýðýmýzda ise " +
                               "ilk akla gelen kumaþlarda canlý renkler tercih etmek olacaktýr. Bu demek oluyor ki nevresim takýmýndan yastýklara dek renk kullanmaktan çekinmiyoruz." +
                               " Yatak örtüsü dýþýnda perde ve halý da renk kullanýlabilir. Renk dýþýnda etnik desenler de bohem tarzýn vazgeçilmezlerindendir. " +
                               "Ancak renk ve desenden kaçýnýyorsanýz sade ve açýk renkler kullanabilir, bohem etkiyi aksesuarlarda tercih edebilirsiniz. " +
                               "Bohem dekorasyon eklektik stille ayný iþlevi gördüðünden çok farklý tarzlarý bir araya getirerek yaratýcý ve þýk bir yatak odasý gerçekleþtirebilirsiniz." +
                               " </p>",
                               Slug="bohem-decoration-2",
                               CreationTime=DateTime.Now,
                               ModificationTime=DateTime.Now

                            }

                        }

                    });

                }

                #endregion
            }
        }
    }
}
