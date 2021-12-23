using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Blog
    {
        [Key]
        [Required(ErrorMessage = "Lütfen Blog Başlığı Giriniz")]
        public int BlogID { get; set; }
        [Required(ErrorMessage = "Lütfen Blog Başlığı Giriniz")]
        [MaxLength(100, ErrorMessage = "Blog Başlığı 100 karakterden uzun olamaz")]
        [MinLength(1, ErrorMessage = "Blog Başlığı 1 karakterden uzun olmalı")]

        public string BlogTitle { get; set; }
        [Required(ErrorMessage = "Lütfen Blog İçeriği Giriniz")]
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }//bloğun thumbnaili sunucuda çok yer kaplamasın maksatlı,string olarak dosya yolu tutcaz
        [Required(ErrorMessage = "Lütfen Blog Görselini Giriniz")]
        public string BlogImage { get; set; }//bloğun büyük resme

        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        [Required(ErrorMessage = "Lütfen Blog Başlığı Giriniz")]

        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int WriterID { get; set; }
        [Required(ErrorMessage = "Lütfen Blog Başlığı Giriniz")]

        public Writer Writer { get; set; }
        public List<Comment> Comments { get; set; }




    }
}
