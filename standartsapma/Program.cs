using System;

class Program
{
    // Bu fonksiyonda iterasyon yöntemiyle standart sapmayı hesaplayacağız
    static double StandartSapmaIterasyon(double[] degerler)
    {
        int n = degerler.Length; // dizi uzunluğunu n olarak alıyoruz
        double toplam = 0; // Burada toplam değeri saklamak için bir değişken oluşturuyoruz

        // Şimdi, dizi içindeki tüm elemanları topluyoruz
        foreach (var x in degerler)
        {
            toplam += x; // her bir elemanı toplama ekliyoruz
        }
        double ortalama = toplam / n; // toplamı eleman sayısına bölerek ortalamayı buluyoruz

        // Varyansı hesaplamak için ikinci bir döngü kullanacağız
        double varyansToplam = 0;
        foreach (var x in degerler)
        {
            // Her bir elemanın ortalamadan farkının karesini alıp varyans toplamına ekliyoruz
            varyansToplam += Math.Pow(x - ortalama, 2);
        }
        double varyans = varyansToplam / (n - 1); // Varyansı (n-1) ile bölerek buluyoruz

        // Standart sapma, varyansın karekökü alınarak bulunur
        return Math.Sqrt(varyans); // standart sapmayı döndürüyoruz
    }

    // Recursive ile standart sapmayı hesaplamak için yeni fonksiyonumuzu oluşturuyoruz
    static double VaryansRecursive(double[] degerler, int index, double ortalama)
    {
        // Dizi içerisindeki tüm elemanları işlediysek toplamaya etkisi olmaması için 0 döndürüyoruz
        if (index >= degerler.Length)
            return 0;

        // Mevcut eleman sayısının ortalamadan farkının karesini alıyoruz
        double varyansToplam = Math.Pow(degerler[index] - ortalama, 2);

        // Bir sonraki eleman için aynı işlemi yapmak üzere kendini çağırıyoruz
        return varyansToplam + VaryansRecursive(degerler, index + 1, ortalama);
    }

    static void Main()
    {
        // Kullanıcıdan kaç adet sayı gireceğini alıyoruz
        Console.Write("Kaç adet sayı gireceksiniz? ");
        int n = int.Parse(Console.ReadLine()); 

        // Girilen sayı kadar bir dizi oluşturuyoruz
        double[] degerler = new double[n];
        Console.WriteLine("Sayıları giriniz:");

        // Kullanıcıdan her bir sayıyı girmesini istiyoruz
        for (int i = 0; i < n; i++)
        {
            Console.Write($"Sayı {i + 1}: "); 
            degerler[i] = double.Parse(Console.ReadLine()); // kullanıcıdan aldığımız sayıyı diziye dahil ediyoruz
        }

        // İlk olarak ortalamayı hesaplıyoruz
        double ortalama = 0;
        foreach (var x in degerler)
        {
            ortalama += x; // tüm elemanları topluyoruz
        }
        ortalama /= n; // toplamı eleman sayısına bölerek ortalamayı elde ediyoruz

        // İterasyon yöntemini kullanarak standart sapmayı hesaplıyoruz
        double standartSapmaIterasyon = StandartSapmaIterasyon(degerler);
        Console.WriteLine($"İterasyon yöntemi ile Standart Sapma: {standartSapmaIterasyon}");

        // Recursive yöntemi kullanarak varyans ve ardından standart sapmayı hesaplıyoruz
        double varyansRecursive = VaryansRecursive(degerler, 0, ortalama) / (n - 1);
        double standartSapmaRecursive = Math.Sqrt(varyansRecursive); // Varyansın karekökünü alıyoruz
        Console.WriteLine($"Recursive yöntem ile Standart Sapma: {standartSapmaRecursive}");
        Console.ReadLine();
    }
}
