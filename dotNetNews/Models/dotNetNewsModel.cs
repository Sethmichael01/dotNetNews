using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetNews.Models
{
    public class dotNetNewsModel
    {
        [Key]
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string Title { get; set; }
        [MinLength(20, ErrorMessage = "Too few words")]
        public string Description { get; set; }
        [Display(Name = "Short Descripion")]
        public string ShortDescription { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; } = DateTime.Now;
        [Display(Name = "Image")]

        public byte[] Picture { get; set; }

        [NotMapped]
        public string ImageContentType { get; set; } = "image/png";

        public string GetInLineImgSource()
        {
            if (Picture == null || ImageContentType == null)
            {
                return null;
            }
            var base64Image = Convert.ToBase64String(Picture);
            return $"data:{ImageContentType};base64,{base64Image}";
        }

        [Display(Name = "Upload Product Picture")]
        [NotMapped]
        public IFormFile File
        {
            get
            {
                return null;
            }
            set
            {
                try
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        value.CopyTo(memoryStream);
                        Picture = memoryStream.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
