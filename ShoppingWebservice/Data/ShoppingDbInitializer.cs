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
            User kurt = new User("Kurt", "Hansen", "kurt@gmail.com", "Imaginative Street 123, 4000 Fantasy World");

            users.Add(kurt);
            foreach (User user in users) {
                context.Users.Add(user);
            }

            // Items
            IList<Item> items = new List<Item>();
            Item datterinoTomater = new Item("datterino tomater", "økologiske datterino tomater", 21.00f, "mad, frugtOgGrønt, grøntsager");
            Item vildmoseKartofler = new Item("vildmose kartofler", "miniature kartofler dyrket i nord jylland", 20.00f, "mad, frugtOgGrønt, grøntsager");
            Item roastbeef = new Item("roastbeef", "af tyksteg", 210.00f, "mad, kød, oksekød");
            Item oksetyndsteg = new Item("oksetyndsteg", "lækker, lækker oksetyndsteg til en sulten mavse", 299.00f, "mad, kød, oksekød");
            Item kulmulefilet = new Item("kulmulefilet", "kulmulefilet med skind (merluccius merluccius)", 160.00f, "mad, fisk, fileterOgFars");
            Item jerseyLetmælk = new Item("jerseyLetmælk", "irmas ækologiske mælk fra ko", 12.00f, "mad, mejeri, mælkOgFløde");
            Item jomfruhummer = new Item("jomfruhummer", "de har lange organer med muskuløse haler, og bor i sprækker eller huler på havbunden", 450.00f, "mad, fisk, fileterOgFars");
            Item kærnemælk = new Item("kærnemælk", "kærnemælk henviser til en række af mælkedrikke. Oprindeligt kærnemælk var væsken efterladt efter kærning smør ud af fløde", 6.95f, "mad, mejeri, mælkOgFløde");
            Item chokoRugbrødsboller = new Item("choko rugbrødsboller", "super lækre chokoladefyldte rugbrødsboller", 40.00f, "mad, brødOgKager, rugbrød");
            Item carbernetSauvignon = new Item("Carbernet Sauvignon", "denne vin stammer fra Los Morros ejendom i Maipo-dalen, der er den første vindyrknings dal i Chile til at blive internationalt anerkendt for sin fremragende Cabernet Sauvignon", 129.95f, "mad, vin, rødvin");
            Item hyldebærSaft = new Item("hyldebær saft", "juice er en væske (drik), der naturligt findes i frugt og grøntsager", 21.95f, "mad, drikkevarer, juiceSaftOgMost");
            Item colafantasi = new Item("colafantasi", "dejlig sukkerfyldt væske", 14.95f, "mad, drikkevarer, juiceSaftOgMost");
            Item hvedemel = new Item("hvedemel", "mel er et pulver fremstillet ved formaling af ubehandlede korn eller andre frø eller rødder", 16.00f, "mad, kolonial, bagning");
            Item nøddemix = new Item("nøddemix", "En nød er en frugt, der består af en hård skal og en frø, som er generelt spiselige", 23.00f, "mad, kolonial, bagning");
            Item chokoladetærte = new Item("chokoladetærte", "dejlig chokoladetærte", 32.95f, "mad, kolonial, bagning");
            Item millionbøf = new Item("millionbøf", "med kartoffelmos", 18.75f, "mad, frost, middagsretter");
            Item finskSødLakrids = new Item("finsk sød lakrids", "lakrids er roden af Glycyrrhiza glabra, hvorfra en sød smag kan udvindes", 26.00f, "mad, kiosk, slik");
            Item brystkarameller = new Item("brystkarameller", "bolcher som i gamle dage", 29.95f, "mad, kiosk, slik");
            Item vitaminC = new Item("vitaminC", "vitamin C eller L-ascorbinsyre, eller blot ascorbat (anionen af ascorbinsyre), er et vigtigt næringsstof for mennesker og visse andre dyrearter", 65.00f, "mad, pleje, vitaminerOgKosttilskud");
            Item proteinbar = new Item("proteinbar", "bliv bomstærk", 20.00f, "mad, pleje, vitaminerOgKosttilskud");
            Item toiletpapir = new Item("toiletpapir", "3-lags papir fremstillet af ny papirmasse bleget med brintoverilte.", 35.00f, "husholdning, køkkenrulleOgToiletpapir");

            Item granaPadano = new Item("Grana Padano", "Den dufter af parmesan. Den knaser, har smag af salt og ægte umamismag, der bliver hængende i munden længe efter.", 54.00f, "mad,mejeri,ost");
            Item landana = new Item("Landana", "Smagfuld, blød og cremet. Naturligt lagret på træ. Produceret efter gamle hollandske ostetraditioner. 100% mælk fra fritgående køer.", 44.95f, "mad,mejeri,ost");
            Item flødeost = new Item("Flødeost", "m. hvidløg.", 9.95f, "mad,mejeri,ost");
            Item brieMarcillat = new Item("Brie Marcillat", "Plasir de Roi Brie.", 11.95f, "mad,mejeri,ost");
            Item thybo = new Item("Thybo", "Dejlig åååst.", 50.00f, "mad,mejeri,ost");
            Item flødehavarti = new Item("Flødehavarti", "38% fedt.", 17.95f, "mad,mejeri,ost");
            Item gammelOlesFar = new Item("Gammel Oles far", "Føj for satan den er ulækker den her.", 62.95f, "mad,mejeri,ost");


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
            items.Add(granaPadano);
            items.Add(landana);
            items.Add(flødeost);
            items.Add(brieMarcillat);
            items.Add(thybo);
            items.Add(flødehavarti);
            items.Add(gammelOlesFar);

            foreach (Item item in items) {
                context.Items.Add(item);
            }

            // Carts
            IList<Cart> carts = new List<Cart>();

            //kurt cart 1 - open
            Cart cart1 = new Cart(kurt);
            cart1.AddCartItem(new CartItem(hvedemel, hvedemel.Price, 4));
            cart1.AddCartItem(new CartItem(jerseyLetmælk, jerseyLetmælk.Price, 6));
            cart1.AddCartItem(new CartItem(nøddemix, nøddemix.Price, 2));
            cart1.AddCartItem(new CartItem(millionbøf, millionbøf.Price, 1));
            cart1.AddCartItem(new CartItem(vitaminC, vitaminC.Price, 1));
            carts.Add(cart1);

            //kurt cart 2 - open
            Cart cart2 = new Cart(kurt);
            cart2.AddCartItem(new CartItem(toiletpapir, toiletpapir.Price, 35));
            cart2.AddCartItem(new CartItem(proteinbar, proteinbar.Price, 6));
            carts.Add(cart2);

            //kurt cart 3 - closed
            Cart cart3 = new Cart(kurt);
            cart3.AddCartItem(new CartItem(flødeost, flødeost.Price, 1));
            cart3.AddCartItem(new CartItem(millionbøf, millionbøf.Price, 1));
            cart3.AddCartItem(new CartItem(oksetyndsteg, oksetyndsteg.Price, 1));
            cart3.AddCartItem(new CartItem(thybo, thybo.Price, 2));
            cart3.AddCartItem(new CartItem(chokoladetærte, chokoladetærte.Price, 2));
            cart3.CheckedOutAt = DateTime.UtcNow.AddHours(2);
            carts.Add(cart3);

            foreach (Cart cart in carts) {
                context.Carts.Add(cart);
            }

            base.Seed(context);
        }


    }
}