using HotelManagement.Entity.Shared;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Entity.Models.Users
{
    /// <summary>
    /// Kullanıcı Rollerinin tutulduğu tablodur.
    /// </summary>
    public class Role : BaseEntity
    {
        /// <summary>
        /// Kullanıcı rolü tekil bilgisidir.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Rolü niteleyen isim bilgisidir.
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; }
    }
}
