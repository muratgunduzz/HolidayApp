/*Bu pratikte bir yardımcı seyehat uygulaması ile kullanıcılarımızın planlayacakları 3 günlük bir tatilde harcayacakları yaklaşık tutarı hesaplamalarına yardımcı oluyoruz.

3 adet lokasyonumuz var:

1 - Bodrum (Paket başlangıç fiyatı 4000 TL)

2 - Marmaris (Paket başlangıç fiyatı 3000 TL)

3 - Çeşme (Paket başlangıç fiyatı 5000 TL)

Kullanıcımıza gitmek istediği lokasyonu sormalıyız. Bu noktada Büyük-Küçük harf duyarlılığını ortadan kaldırmalı eğer yukarıdaki 3 seçenek dışında bir lokasyon girilirse bir hata olduğunu söylemeli, girebileceği lokasyon isimlerini hatırlatmalı ve yeniden bir veri girmesini istemeliyiz.

Kullanıcının girdiği veriyi bir değişkende tutalım.

Kullanıcıya kaç kişi için tatil planlamak istediğini soralım.

Kişi sayısını bir değişkende tutalım.

Ardından gitmek istenilen lokasyon ve o lokasyonda tatili sırasında yapabilecekleri ile ilgili bir özet bilgiyi ekrana yazdırmalıyız.

Kullanıcıya tatiline ne şekilde gitmek istediğini sorarak aşağıdaki seçenekleri gösterelim..

2 seçeneğimiz var:

1 - Kara yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 1500 TL )

2 - Hava yolu ( Kişi başı ulaşım tutarı gidiş-dönüş 4000 TL)

" Lütfen yukarıdaki seçeneklerden bir tanesini seçiniz diyerek cevabı kullanıcıdan "1" ya da "2" olarak alalım, farklı bir değer girilmesi durumunda bir hata olduğunu söyleyerek soruyu yeniden yöneltelim.

Ardından gidilecek lokasyon, kişi sayısı ve ulaşım aracı seçenekleriyle bir toplam fiyat hesaplayıp bunu kullanıcıya sunalım.

Kullanıcıya başka bir tatil planlamak isteyip istemediğini soralım, istiyorsa uygulama ilk aşamadan çalışmaya başlayabilir, kullanıcı istemiyorsa iyi günler dileyerek uygulamayı sonlandırabiliriz. */

using System;

class Program
{
    static string Choice()
    {
        Console.WriteLine("1) Bodrum\n2) Marmaris\n3) Dalaman\n4) Çeşme\n5) Kuş Adası");
        string input = Console.ReadLine();
        return input.ToLower();
    }

    static int ShowSummary(string location)
    {
        int locationCost = 0;

        switch (location)
        {
            case "bodrum":
                Console.WriteLine("\nBodrum'da yapabileceğiniz aktiviteler:");
                Console.WriteLine("- Tarihi Bodrum Kalesi'ni ziyaret edin.");
                Console.WriteLine("- Gümbet'te denize girin ve su sporları yapın.");
                Console.WriteLine("- Bodrum gece hayatını keşfedin.");
                locationCost = 4000;
                break;

            case "marmaris":
                Console.WriteLine("\nMarmaris'te yapabileceğiniz aktiviteler:");
                Console.WriteLine("- Marmaris Marina'da yürüyüş yapın.");
                Console.WriteLine("- Günlük tekne turlarına katılın.");
                Console.WriteLine("- İçmeler Plajı'nda güneşlenin.");
                locationCost = 3000;
                break;

            case "çeşme":
                Console.WriteLine("\nÇeşme'de yapabileceğiniz aktiviteler:");
                Console.WriteLine("- Alaçatı'nın tarihi sokaklarını gezin.");
                Console.WriteLine("- Çeşme Ilıca Plajı'nda yüzün.");
                Console.WriteLine("- Yelken veya rüzgar sörfü yapın.");
                locationCost = 5000;
                break;

            case "dalaman":
            case "kuş adası":
                Console.WriteLine("\nBu bölgemiz için maalesef hizmet verememekteyiz. Lütfen başka bir bölge seçiniz.");
                break;

            default:
                Console.WriteLine("\nGeçersiz bir bölge seçtiniz. Lütfen listeden bir bölge seçiniz.");
                break;
        }

        return locationCost;
    }

    static void Main()
    {
        bool anotherPlan = true;

        while (anotherPlan)
        {
            Console.WriteLine("Merhabalar,\nTatilim uygulamasına hoşgeldiniz!\nAşağıdaki listeden size uygun olan tatil bölgelerini seçebilirsiniz.");

            string location = Choice();
            while (location == "dalaman" || location == "kuş adası")
            {
                Console.WriteLine("Bu bölgemiz için maalesef hizmet verememekteyiz. Lütfen başka bir bölge seçiniz.");
                location = Choice(); 
            }

            while (location != "bodrum" && location != "marmaris" && location != "çeşme")
            {
                Console.WriteLine("Lütfen gitmek istediğiniz yeri tam olarak yazınız.");
                location = Choice();
            }

            Console.WriteLine(location + " bölgesini tercih ettiniz.\nEmin misiniz?\n1)Evet\n2)Hayır");
            string decision = Console.ReadLine();

            if (decision == "1")
            {
                Console.WriteLine("Lütfen kaç kişilik rezervasyon yapmak istediğinizi giriniz: ");
                int peopleCount = Convert.ToInt32(Console.ReadLine());

                int locationCost = ShowSummary(location);

                Console.WriteLine("Seçtiğiniz bölge için hem hava, hem de kara yolu ile ulaşım imkanı mevcut.\nLütfen ulaşım tercihinizi yapınız:\n1) Uçak\n2) Otobüs");
                int tripChoice = 0;

                while (tripChoice != 1 && tripChoice != 2)
                {
                    if (tripChoice != 0)
                    {
                        Console.WriteLine("Geçersiz bir seçim yaptınız, lütfen tekrar seçim yapınız.");
                    }
                    tripChoice = Convert.ToInt32(Console.ReadLine());
                }

                int tripCost = 0;
                if (tripChoice == 1)
                {
                    tripCost = peopleCount * 4000;
                }
                else if (tripChoice == 2)
                {
                    tripCost = peopleCount * 1500;
                }

                int totalCost = locationCost + tripCost;
                Console.WriteLine("Lokasyon: " + location + "\nKişi sayısı: " + peopleCount + "\nToplam Tutar: " + totalCost);
            }
            else if (decision == "2")
            {
                Console.WriteLine("Tekrardan bir seçim yapınız.");
                location = Choice();
            }

            // Başka bir tatil planlaması isteyip istemediğini sor
            Console.WriteLine("\nBaşka bir tatil planlaması ister misiniz? (Evet/Hayır)");
            string userResponse = Console.ReadLine().ToLower();

            if (userResponse != "evet")
            {
                anotherPlan = false;
                Console.WriteLine("Tatil planlaması sonlandırılıyor. İyi günler dileriz!");
            }
        }
    }
}
