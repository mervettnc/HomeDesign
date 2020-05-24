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
            //admin rol�nde bir kullan�c� yoksa olu�tur
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
                               Content="<p> Bohem tarzdan ho�lan�yorsan�z veya evinize daha fazla konfor ve rahatl�k getirecek bir dekorasyon ar�yorsan�z bu tarza yo�unla�man�n" +
                               " zaman� gelmi� demektir. Bohem dekorasyon ayn� zamanda eklektik stil oldu�undan keskin �izgileri oldu�u s�ylenemez. Yani herkes kendi " +
                               "zevkine g�re bohem tarz esteti�ine sahip olabilir. Dilerseniz bohem stilin yaln�zca bir b�l�m�n� kullanabilir dilerseniz de" +
                               " bu tarz� b�t�n�yle uygulayabilirsiniz. Rahatl���yla �n plana ��kan bohem dekorasyon konforlu anlay���ndan �t�r� yatak odalar�na �ok uygundur." +
                               " Zira evde oturma odas� ile birlikte konfor kriteri �n plana ��kan di�er alan yatak odas�d�r. Ba�ta yata��n�z olmak �zere kendi zevkinize g�re" +
                               " dekore edebilece�iniz bu tarz size keyifli ve huzurlu bir atmosfer sa�layacak ayn� zamanda yatak odan�z�n kendine has bir �izgisi olmas�n� sa�layacakt�r." +
                               "</p>",
                               Slug="bohem-decoration-1",
                               CreationTime=DateTime.Now,
                               ModificationTime=DateTime.Now

                            },

                            new Project
                            {

                               Title="Bohem Decoration 2",
                               UserId=user.Id,
                               Content="<p> Bohem dekorasyon g�z al�c� canl� renkler, de�i�ik desenler ve sanatsal atmosferin harmanlad��� bir stildir. " +
                               "Mor, mavi, sar�, turuncu, kahverengi ve pembenin parlak tonlar�n� bu tarzda bolca kullan�l�r. Yatak odas� �zelinde bakt���m�zda ise " +
                               "ilk akla gelen kuma�larda canl� renkler tercih etmek olacakt�r. Bu demek oluyor ki nevresim tak�m�ndan yast�klara dek renk kullanmaktan �ekinmiyoruz." +
                               " Yatak �rt�s� d���nda perde ve hal� da renk kullan�labilir. Renk d���nda etnik desenler de bohem tarz�n vazge�ilmezlerindendir. " +
                               "Ancak renk ve desenden ka��n�yorsan�z sade ve a��k renkler kullanabilir, bohem etkiyi aksesuarlarda tercih edebilirsiniz. " +
                               "Bohem dekorasyon eklektik stille ayn� i�levi g�rd���nden �ok farkl� tarzlar� bir araya getirerek yarat�c� ve ��k bir yatak odas� ger�ekle�tirebilirsiniz." +
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
