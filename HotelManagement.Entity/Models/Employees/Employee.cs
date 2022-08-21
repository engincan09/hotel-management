using HotelManagement.Entity.Models.Users;
using HotelManagement.Entity.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement_Entity.Models.Employees
{
    public class Employee : BaseEntity
    {
        /// <summary>
        /// Tablo tekil bilgisdir.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Personelin sistem üzerinde hesabu
        /// </summary>
        public int? UserId { get; set; }

        /// <summary>
        /// Personel Tipi
        /// </summary>
        public EmployeeType EmployeeType { get; set; }

        /// <summary>
        /// Personel Sicil numarası/kodu
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Personel adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Personel soyadı
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Personel Telefon numarası
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Personel email bilgisi
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Personelin işe giriş tarihi
        /// </summary>
        public DateTime JobStartDate { get; set; }

        public int MyProperty { get; set; }
        public User User { get; set; }
    }

    public enum EmployeeType
    {
        GenelMudur,
        GenelMudurYardimci,
        OnBuro,
        Muhasebe,
        MuhasebeMudur,
        Temizlik,
        Mutfak,
        Teknik,
        Guvenlik,
        Aktivite,
        InsanKaynaklari,
        InsanKaynaklariMudur,
        SatinAlma,
        SatinAlmaMudur
    }
}
