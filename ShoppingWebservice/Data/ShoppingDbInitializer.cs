using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using ShoppingWebservice.Models;

namespace ShoppingWebservice.Data {
    // source: http://www.entityframeworktutorial.net/code-first/seed-database-in-code-first.aspx
    // https://edspencer.me.uk/2012/10/30/seed-data-from-sql-scripts-using-entity-framework-migrations-ef-4-3/

    public class ShoppingDbInitializer : DropCreateDatabaseAlways<ShoppingContext> {

        protected override void Seed(ShoppingContext context) {
            // Users
            IList<User> users = new List<User>();
            User tobias = new User("Tobias", "Jacobsen", "tobias.cbs@gmail.com", "Imaginative Street 123, 4000 Fantasy World");
            User lennart = new User("Lennart", "Mogensen", "lennart64@yahoo.dk", "Wolly Street 45, 1100 Fitilihu");
            User meffert = new User("Meffert", "Silleben", "lovesild@gmail.com", "Imaginative Street 60, 4000 Fantasy World");
            User kurt = new User("Kurt", "Hansen", "kurt69@hotmail.com", "Imaginative Street 12, 4000 Fantasy World");
            User sonja = new User("Sonja", "Hansen", "sonja54@hotmail.com", "Imaginative Street 12, 4000 Fantasy World");
            User kaj = new User("Kaj", "Jensen", "kajersej@aol.com", "Wolly Street 3, 1100 Fitilihu");
            User lise = new User("Lise", "Fnise", "fnis13@gmail.com", "Wolly Street 5, 1100 Fitilihu");

            users.Add(tobias);
            users.Add(lennart);
            users.Add(meffert);
            users.Add(kurt);
            users.Add(sonja);
            users.Add(kaj);
            users.Add(lise);
            foreach (User user in users) {
                context.Users.Add(user);
            }

            // Categories
            IList<Category> categories = new List<Category>();
            Category mad = new Category("mad", "fødevarer er ethvert stof forbruges til at yde ernæringsmæssig støtte til kroppen");
            Category frugtOgGrønt = new Category("frugtOgGrønt", "dejlige sprøde grøntsager og saftigt frugt");
            Category grøntsager = new Category("grøntsager", "dejlige sprøde grøntsager");
            Category kød = new Category("kød", "kød er dyrekød, der spises som mad");
            Category oksekød = new Category("oksekød", "oksekød er det kulinariske navn for kød fra kvæg");
            Category fisk = new Category("fisk", "fisk er ethvert medlem af en paraphyletic gruppe af organismer, der består af alle gill-bærende vandlevende craniate dyr, der mangler lemmer med cifre");
            Category fileterOgFars = new Category("fileter og fars", "dejlige fileter, fars og andet godt fra gulvet");
            Category rejerOgSkaldyr = new Category("rejer og skaldyr", "dejlige rejer og skaldyr fra havet");
            Category mejeri = new Category("mejeri", "et mejeri er en virksomhed etableret for høstning og forarbejdning (eller begge) af animalsk mælk");
            Category mælkOgFløde = new Category("mælk og fløde", "mælk og fløde til den runde mavse");
            Category brødOgKager = new Category("brød og kager", "brød og kager til bordet");
            Category rugbrød = new Category("rugbrød", "groft og fint rugbrød");
            Category vin = new Category("vin", "vin (fra latin Vinum) er en alkoholisk drik fremstillet af gærede druer eller andre frugter");
            Category rødvin = new Category("rødvin", "rødvin er en type vin lavet af mørke-farvede (sorte) druesorter");
            Category drikkevarer = new Category("drikkevarer", "en drink eller drikke er en væske til konsum");
            Category juiceSaftOgMost = new Category("juice, saft og most", "rødvin er en type vin lavet af mørke-farvede (sorte) druesorter");
            Category kolonial = new Category("kolonial", "ting og sager");
            Category bagning = new Category("bagning", "bagning er en metode til madlavning, der bruger langvarig tør varme, normalt i en ovn, men også i varm aske, eller på varme sten");
            Category frost = new Category("frost", "frost er belægningen eller deponering af is, som kan dannes i fugtig luft i kolde forhold, normalt natten over");
            Category middagsretter = new Category("middagsretter", "En tv-middag (også kaldet færdigpakkede måltid, færdigsyet måltid, færdigret, frosne middag, frosne måltid, mikrobølgeovn måltid) er en pre pakket frossen eller kølet måltid, der normalt kommer som en individuel portion");
            Category kiosk = new Category("kiosk", "En kiosk (fra tyrkisk Köşk, fra persisk kūshk) er en lille, adskilt havepavillon åben på nogle eller alle sider");
            Category slik = new Category("slik", "candy, også kaldet slik eller sodavandsis, er en godbid, der indeholder sukker som en hovedbestanddel");
            Category pleje = new Category("pleje", "fordi du fortjener det");
            Category vitaminerOgKosttilskud = new Category("vitaminer og kosttilskud", "Bigger, Stronger, Faster!");
            Category husholdning = new Category("husholdning", "en husstand består af en eller flere personer, der bor i samme bolig, og også deler på måltider eller bolig, og kan bestå af en enkelt familie eller en anden gruppering af mennesker");
            Category køkkenrulleOgToiletpapir = new Category("køkkenrulle og toiletpapir", "til bummelum og andet snavs");

            categories.Add(mad);
            categories.Add(frugtOgGrønt);
            categories.Add(grøntsager);
            categories.Add(kød);
            categories.Add(oksekød);
            categories.Add(fisk);
            categories.Add(fileterOgFars);
            categories.Add(rejerOgSkaldyr);
            categories.Add(mejeri);
            categories.Add(mælkOgFløde);
            categories.Add(brødOgKager);
            categories.Add(rugbrød);
            categories.Add(vin);
            categories.Add(rødvin);
            categories.Add(drikkevarer);
            categories.Add(juiceSaftOgMost);
            categories.Add(kolonial);
            categories.Add(bagning);
            categories.Add(frost);
            categories.Add(middagsretter);
            categories.Add(kiosk);
            categories.Add(slik);
            categories.Add(pleje);
            categories.Add(vitaminerOgKosttilskud);
            categories.Add(husholdning);
            categories.Add(køkkenrulleOgToiletpapir);
            foreach (Category category in categories) {
                context.Categories.Add(category);
            }

            // Items
            IList<Item> items = new List<Item>();
            Item datterinoTomater = new Item("datterino tomater", "økologiske datterino tomater", 21.00f);
            Item vildmoseKartofler = new Item("vildmose kartofler", "miniature kartofler dyrket i nord jylland", 20.00f);
            Item roastbeef = new Item("roastbeef", "af tyksteg", 210.00f);
            Item oksetyndsteg = new Item("oksetyndsteg", "lækker, lækker oksetyndsteg til en sulten mavse", 299.00f);
            Item kulmulefilet = new Item("kulmulefilet", "kulmulefilet med skind (merluccius merluccius)", 160.00f);
            Item jerseyLetmælk = new Item("jerseyLetmælk", "irmas ækologiske mælk fra ko", 12.00f);
            Item jomfruhummer = new Item("jomfruhummer", "de har lange organer med muskuløse haler, og bor i sprækker eller huler på havbunden", 450.00f);
            Item kærnemælk = new Item("kærnemælk", "kærnemælk henviser til en række af mælkedrikke. Oprindeligt kærnemælk var væsken efterladt efter kærning smør ud af fløde", 6.95f);
            Item chokoRugbrødsboller = new Item("choko rugbrødsboller", "super lækre chokoladefyldte rugbrødsboller", 40.00f);
            Item carbernetSauvignon = new Item("Carbernet Sauvignon", "denne vin stammer fra Los Morros ejendom i Maipo-dalen, der er den første vindyrknings dal i Chile til at blive internationalt anerkendt for sin fremragende Cabernet Sauvignon", 129.95f);
            Item hyldebærSaft = new Item("hyldebær saft", "juice er en væske (drik), der naturligt findes i frugt og grøntsager", 21.95f);
            Item colafantasi = new Item("colafantasi", "dejlig sukkerfyldt væske", 14.95f);
            Item hvedemel = new Item("hvedemel", "mel er et pulver fremstillet ved formaling af ubehandlede korn eller andre frø eller rødder", 16.00f);
            Item nøddemix = new Item("nøddemix", "En nød er en frugt, der består af en hård skal og en frø, som er generelt spiselige", 23.00f);
            Item chokoladetærte = new Item("chokoladetærte", "dejlig chokoladetærte", 32.95f);
            Item millionbøf = new Item("millionbøf", "med kartoffelmos", 18.75f);
            Item finskSødLakrids = new Item("finsk sød lakrids", "lakrids, eller lakrids, er roden af Glycyrrhiza glabra, hvorfra en sød smag kan udvindes", 26.00f);
            Item brystkarameller = new Item("brystkarameller", "bolcher som i gamle dage", 29.95f);
            Item vitaminC = new Item("vitaminC", "vitamin C eller L-ascorbinsyre, eller blot ascorbat (anionen af ascorbinsyre), er et vigtigt næringsstof for mennesker og visse andre dyrearter", 65.00f);
            Item proteinbar = new Item("proteinbar", "bliv bomstærk", 20.00f);
            Item toiletpapir = new Item("toiletpapir", "3-lags papir fremstillet af ny papirmasse bleget med brintoverilte.", 35.00f);

            // Item categories
            datterinoTomater.Categories.Add(mad);
            datterinoTomater.Categories.Add(frugtOgGrønt);
            datterinoTomater.Categories.Add(grøntsager);

            vildmoseKartofler.Categories.Add(mad);
            vildmoseKartofler.Categories.Add(frugtOgGrønt);
            vildmoseKartofler.Categories.Add(grøntsager);

            roastbeef.Categories.Add(mad);
            roastbeef.Categories.Add(kød);
            roastbeef.Categories.Add(oksekød);

            oksetyndsteg.Categories.Add(mad);
            oksetyndsteg.Categories.Add(kød);
            oksetyndsteg.Categories.Add(oksekød);

            kulmulefilet.Categories.Add(mad);
            kulmulefilet.Categories.Add(fisk);
            kulmulefilet.Categories.Add(fileterOgFars);

            jerseyLetmælk.Categories.Add(mad);
            jerseyLetmælk.Categories.Add(mejeri);
            jerseyLetmælk.Categories.Add(mælkOgFløde);

            kærnemælk.Categories.Add(mad);
            kærnemælk.Categories.Add(mejeri);
            kærnemælk.Categories.Add(mælkOgFløde);

            jomfruhummer.Categories.Add(mad);
            jomfruhummer.Categories.Add(fisk);
            jomfruhummer.Categories.Add(fileterOgFars);

            chokoRugbrødsboller.Categories.Add(mad);
            chokoRugbrødsboller.Categories.Add(brødOgKager);
            chokoRugbrødsboller.Categories.Add(rugbrød);

            carbernetSauvignon.Categories.Add(mad);
            carbernetSauvignon.Categories.Add(vin);
            carbernetSauvignon.Categories.Add(rødvin);

            hyldebærSaft.Categories.Add(mad);
            hyldebærSaft.Categories.Add(drikkevarer);
            hyldebærSaft.Categories.Add(juiceSaftOgMost);

            colafantasi.Categories.Add(mad);
            colafantasi.Categories.Add(drikkevarer);
            colafantasi.Categories.Add(juiceSaftOgMost);

            hvedemel.Categories.Add(mad);
            hvedemel.Categories.Add(kolonial);
            hvedemel.Categories.Add(bagning);

            nøddemix.Categories.Add(mad);
            nøddemix.Categories.Add(kolonial);
            nøddemix.Categories.Add(bagning);

            chokoladetærte.Categories.Add(mad);
            chokoladetærte.Categories.Add(kolonial);
            chokoladetærte.Categories.Add(bagning);

            millionbøf.Categories.Add(mad);
            millionbøf.Categories.Add(frost);
            millionbøf.Categories.Add(middagsretter);

            finskSødLakrids.Categories.Add(mad);
            finskSødLakrids.Categories.Add(kiosk);
            finskSødLakrids.Categories.Add(slik);

            brystkarameller.Categories.Add(mad);
            brystkarameller.Categories.Add(kiosk);
            brystkarameller.Categories.Add(slik);

            vitaminC.Categories.Add(mad);
            vitaminC.Categories.Add(pleje);
            vitaminC.Categories.Add(vitaminerOgKosttilskud);

            proteinbar.Categories.Add(mad);
            proteinbar.Categories.Add(pleje);
            proteinbar.Categories.Add(vitaminerOgKosttilskud);

            toiletpapir.Categories.Add(husholdning);
            toiletpapir.Categories.Add(køkkenrulleOgToiletpapir);

            items.Add(datterinoTomater);
            items.Add(vildmoseKartofler);
            items.Add(roastbeef);
            items.Add(oksetyndsteg);
            items.Add(kulmulefilet);
            items.Add(jerseyLetmælk);
            items.Add(kærnemælk);
            items.Add(jomfruhummer);
            items.Add(chokoRugbrødsboller);
            items.Add(carbernetSauvignon);
            items.Add(hyldebærSaft);
            items.Add(colafantasi);
            items.Add(hvedemel);
            items.Add(nøddemix);
            items.Add(chokoladetærte);
            items.Add(millionbøf);
            items.Add(finskSødLakrids);
            items.Add(brystkarameller);
            items.Add(vitaminC);
            items.Add(proteinbar);
            items.Add(toiletpapir);

            foreach (Item item in items) {
                context.Items.Add(item);
            }

            // Carts

            IList<Cart> carts = new List<Cart>();

            //tobias cart 1
            Cart tobiasCart1 = new Cart(DateTime.Now, tobias);
            tobiasCart1.CartItems.Add(new CartItem(hvedemel, hvedemel.Price, 4));
            tobiasCart1.CartItems.Add(new CartItem(jerseyLetmælk, jerseyLetmælk.Price, 6));
            tobiasCart1.CartItems.Add(new CartItem(nøddemix, nøddemix.Price, 2));
            tobiasCart1.CartItems.Add(new CartItem(millionbøf, millionbøf.Price, 1));
            tobiasCart1.CartItems.Add(new CartItem(vitaminC, vitaminC.Price, 1));
            carts.Add(tobiasCart1);

            // tobias cart 2
            Cart tobiasCart2 = new Cart(DateTime.Now, tobias);
            tobiasCart2.CartItems.Add(new CartItem(oksetyndsteg, oksetyndsteg.Price, 1));
            tobiasCart2.CartItems.Add(new CartItem(vitaminC, vitaminC.Price, 1));
            tobiasCart2.CartItems.Add(new CartItem(kulmulefilet, kulmulefilet.Price, 2));
            tobiasCart2.CartItems.Add(new CartItem(proteinbar, proteinbar.Price, 13));
            tobiasCart2.CartItems.Add(new CartItem(chokoladetærte, chokoladetærte.Price, 50));
            carts.Add(tobiasCart2);

            // kurt cart 1
            Cart kurtCart1 = new Cart(DateTime.Now, kurt);
            kurtCart1.CartItems.Add(new CartItem(kærnemælk, kærnemælk.Price, 1));
            kurtCart1.CartItems.Add(new CartItem(jomfruhummer, jomfruhummer.Price, 1));
            kurtCart1.CartItems.Add(new CartItem(vildmoseKartofler, vildmoseKartofler.Price, 2));
            kurtCart1.CartItems.Add(new CartItem(datterinoTomater, datterinoTomater.Price, 10));
            kurtCart1.CartItems.Add(new CartItem(toiletpapir, toiletpapir.Price, 50));
            carts.Add(kurtCart1);

            foreach (Cart cart in carts) {
                context.Carts.Add(cart);
            }

            base.Seed(context);
        }


    }
}