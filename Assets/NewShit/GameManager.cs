using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Koyun Hareketlerini hesapla
    //oyuncu hareketlerii hesapla
    //UI elelmantlerini organize et
    //Suru hareketeini hesapla


    private void Start()
    {
        #region koyun spawn
        /*
         * Koyunlari uret ve bir listede tut.
         */
        #endregion
    }

    private void Update()
    {
        #region Koyun hareket
        /*
         * Uretilen koyunlari itere ederek
         * -hareket
         * -etkilesim
         * bilgilerini guncelle
        */
        #endregion

        #region Suru Hareket
        /*
         * Surunun hareketini hesapla elemanlarini kontrol et
         */
        #endregion

        #region Oyuncu Hareket
        /*
         * Girdilere gore oyuncu objesini ve kamerayi hareket ettir
         */
        #endregion

        #region UI guncelleme
        /*
         * menu butonu
         * Suru hacmi 
         * puan 
         * gibi ihtiyaac duyulan verileri ekrana yazdir
         */
        #endregion
    }
}
