//Bu projede hangi tablolar ve hangi sütunlar olacak?
//O tablolara göre classlar oluşturalım.
//O sütunlara göre propertyleri ekleyelim bu classlara.

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelFinder.Entities
{
    public class Hotel
    {
        //Primary ve Identity sağlar.
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required] //Bu alan benim için gerekli.
        [StringLength(50)] //Nvarchar(50)
        public string Name { get; set; }

        [Required] //Bu alan benim için gerekli.
        [StringLength(50)] //Nvarchar(50)
        public string City { get; set; }
    }
}
