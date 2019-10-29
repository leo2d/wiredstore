using System.Linq;
using System.Text;
using Wired.Data.Contexts;
using Wired.Models.Entities;

namespace Wired.Data
{
    public static class DbStarter<T>
    {
        public static void Initialize(WiredContext context)
        {
            context.Database.EnsureCreated();

            if (context.Customers.Any())
                return;
            var defaultPassword = PasswordManager.CalculateSha1("123", Encoding.Default);
            var customers = new Customer[]
            {
                new Customer(){Name="Jack Hannaford" , Email="jack@company.com", Password= defaultPassword, Cpf="6666666666"},
                new Customer(){Name="Jubileu" , Email="jubileu@mail.com", Password=defaultPassword, Cpf="999999999"},
                new Customer(){Name="James" , Email="mail@mail.com", Password=defaultPassword, Cpf="99234234999"},
            };

            foreach (var customer in customers)
                context.Customers.Add(customer);
            context.SaveChanges();

            var adms = new Administrator[]
            {
                    new Administrator(){Name="Leon S. Kennedy", Email="leon@rpd.com" },
                    new Administrator(){Name="Claire Redfield",  Email="claire@mail.com"},
                    new Administrator(){Name="Caroline Lacerdinha",  Email="caroline@wired.com"},
            };

            foreach (var adm in adms)
                context.Administrators.Add(adm);

            var genres = new Genre[]
            {
                new Genre(){Name="RPG" },
                new Genre(){Name="Ação" },
                new Genre(){Name="FPS" },
                new Genre(){Name="Aventura" },
                new Genre(){Name="Esportes" },
                new Genre(){Name="Survival Horror" }

            };

            foreach (var genre in genres)
                context.Genres.Add(genre);
            context.SaveChanges();

            var games = new Game[]
            {
                new Game(){Name="Resident Evil 2", ReleaseYear="2019", Price=129.99, Producer="Capcom", Description="Na noite de 29 de setembro de 1998, o policial novato Leon S. Kennedy e Claire Redfield, a irmã de Chris, chegam a Raccoon City. Leon percebe que a cidade está calma demais e muito deserta. Ele pára seu jipe no meio da estrada ao avistar um corpo e desce para verificar. Enquanto isso, Claire chega a um restaurante para pedir informações. Ela está na cidade à procura de seu irmão, que não dá notícias há um bom tempo. Em uma lanchonete, Claire se encontra em meio ao terror quando um zumbi a ataca. Ao fugir pela porta dos fundos, dá de cara com Leon, que foi cercado por um grupo de mortos-vivos."},
                new Game(){Name="Devil May Cry 5", ReleaseYear="2019", Price=99.99, Producer="Capcom", Description="Aguardada continuação de Devil May Cry 4"},
                new Game(){Name="Cyberpunk 2077", ReleaseYear="2019", Price=124.99, Producer="Game baseado no RPG de mesa Cyberpunk 2020, criado por Mike Pondsmith em 1988, que foi um dos primeiros a explorar a ambientação cyberpunk nesse estilo de jogo. Desde o início de seu desenvolvimento, o título prometeu integrar personagens, mecânicas e ambientes do original em sua história e jogabilidade de forma fiel "},
            };

        }

    }
}
