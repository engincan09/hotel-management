using HotelManagement.Entity.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelManagement_Entity.Models.Systems
{
    public class Organizasyon : BaseEntity
    {
        /// <summary>
        /// Kayıt tekil bilgisidir.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Üst pozisyon tekil bilgisidir.
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Kadro sayısı.
        /// </summary>
        [DefaultValue(0)]
        public short NumberOfStaff { get; set; }

        /// <summary>
        /// Pozisyonu isim bilgisidir.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Organizasyon Kodu
        /// </summary>
        [MaxLength(64)]
        public string Code { get; set; }

        public bool? IsBirimMudur { get; set; }

        /// <summary>
        /// Üst pozisyon bilgilerini döndürür.
        /// </summary>
        public Organizasyon Parent { get; set; }

        /// <summary>
        /// Alt kırılımlar
        /// </summary>
        public ICollection<Organizasyon> Childs { get; set; }


    }

}
