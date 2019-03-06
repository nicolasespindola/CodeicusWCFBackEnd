using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSTareas.Model
{
    public class ApplicationLog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public string Method { get; set; }

        [Required]
        public string RequestBody { get; set; }

        [Required]
        public DateTime CreateDateTime { get; set; }

        public ApplicationLog()
        {
            CreateDateTime = DateTime.Now;
        }

        public void Update(string url, string statusCode, string requestBody)
        {
            this.URL = url;
            this.Method = statusCode;
            this.RequestBody = requestBody;
        }
    }
}