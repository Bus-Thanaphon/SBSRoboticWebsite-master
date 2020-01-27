using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robotic.Core.Models
{
    public class Product : BaseEntity
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [DisplayName("ลำดับที่")]
        public int No { get; set; }
        
        //public string UNo { get; set; }

        [Required(ErrorMessage = "โปรดกรอกรหัสไม้")]
        [StringLength(30, ErrorMessage = "ไม่สามารถกรอกได้เกิน 30 ตัวอักษร")]
        [DisplayName("รหัสไม้")]
        public string PurchaseID { get; set; }

        [Required(ErrorMessage = "โปรดกรอกชื่อไม้")]
        [DisplayName("ชื่อไม้")]
        public string Name { get; set; }

        [Required(ErrorMessage = "โปรดกรอกประเภทไม้")]
        [DisplayName("ประเภทไม้")]
        public string Category { get; set; }

        [Required(ErrorMessage = "โปรดกรอกสีไม้")]
        [DisplayName("สีไม้")]
        public string Color_Principle { get; set; }

        [Required(ErrorMessage = "โปรดกรอกลายไม้")]
        [DisplayName("ลายไม้")]
        public string Grain { get; set; }

        [DisplayName("ความหนา")]
        [Range(1, 9999999, ErrorMessage = "ตัวเลขไม่ถูกต้อง(1 ขึ้นไป)")]
        public int Thickness { get; set; }

        [DisplayName("จำนวน")]
        [Range(0, 9999999, ErrorMessage = "ไม่สามารถกรอกให้ค่าติดลบได้")]
        public int Quantity { get; set; }

        //[Required]
        [DisplayName("คำอธิบาย")]
        [StringLength(128, ErrorMessage = "ไม่สามารถกรอกได้เกิน 128 ตัวอักษร")]
        public string Description { get; set; }

        [DisplayName("ขนาดกว้าง")]
        [Range(0, 9999999, ErrorMessage = "ไม่สามารถกรอกให้ค่าติดลบได้")]
        public int Dimention_Weight { get; set; }

        [DisplayName("ขนาดยาว")]
        [Range(0, 9999999,ErrorMessage = "ไม่สามารถกรอกให้ค่าติดลบได้")]
        public int Dimention_Height { get; set; }

        [DisplayName("โน๊ต")]
        public string Note { get; set; }

        //public Product()
        //{
        //    this.No = Guid.NewGuid().ToString();
        //}
    }
}
