using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Ceasar_kontrol()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            String test_sonuc = _proje.Ceasar("...", 1);
            String test_beklenen = "///";
            Assert.AreEqual(test_beklenen, test_sonuc);
        }
        [TestMethod]
        public void Ceasar_SayiGiris_Kontrol()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            String test_sonuc = _proje.Ceasar("123", 1);
            String test_beklenen = "234";
            Assert.AreNotEqual(test_beklenen, test_sonuc);
        }
        [TestMethod]
        public void Ceasar_Decode_Kontrol()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            String test_sonuc = _proje.Ceasar_Decode("///", 1);
            String test_beklenen = "...";
            Assert.AreEqual(test_beklenen, test_sonuc);
        }
        [TestMethod]
        public void Cit_Kontrol()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            String test_sonuc = _proje.Cit("1.2#3~");
            String test_beklenen = "123.#~";
            Assert.AreEqual(test_beklenen, test_sonuc);
        }
        [TestMethod]
        public void Cit_Decode_Kontrol()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            String test_sonuc = _proje.Cit_Decode("123.#~");
            String test_beklenen = "1.2#3~";
            Assert.AreEqual(test_beklenen, test_sonuc);
        }
        [TestMethod]
        public void Sutun_Kontrol()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            String test_sonuc = _proje.Sutun("E123R123K123A123N123", 4);
            String test_beklenen = "ERKAN111112222233333";
            Assert.AreEqual(test_beklenen, test_sonuc);
        }
        [TestMethod]
        public void Sutun_SifirGiris_Kontrol()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            String test_sonuc = _proje.Sutun("E123R123K123A123N123", 0);
            String test_beklenen = "Sütun Sayısı 0'dan büyük olmalıdır.";
            Assert.AreEqual(test_beklenen, test_sonuc);
        }
        [TestMethod]
        public void Sutun_NegatifGiris_Kontrol()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            String test_sonuc = _proje.Sutun("E123R123K123A123N123", -1);
            String test_beklenen = "Sütun Sayısı 0'dan büyük olmalıdır.";
            Assert.AreEqual(test_beklenen, test_sonuc);
        }
        [TestMethod]
        public void Polybius_Kontrol_BuyukHarf()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            //BÜYÜK HARF KONTROLÜ
            String test2_sonuc = _proje.Polybius("ERKAN");
            String test2_beklenen = "04 31 20 00 23";
            Assert.AreEqual(test2_beklenen, test2_sonuc);
        }
        [TestMethod]
        public void Polybius_Kontrol_KucukHarf()
        {
            bilgiguvenligi.Form1 _proje = new bilgiguvenligi.Form1();
            //KÜÇÜK HARF KONTROLÜ
            String test_sonuc = _proje.Polybius("erkan");
            String test_beklenen = "04 31 20 00 23";
            Assert.AreEqual(test_beklenen, test_sonuc);
        }
    }
}
