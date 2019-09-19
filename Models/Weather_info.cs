namespace WeatherForecast.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Weather_info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int dt { get; set; }

        [Display(Name = "Temp")]
        [Column(TypeName = "numeric")]
        public decimal main_temp { get; set; }

        [Display(Name = "Min")]
        [Column(TypeName = "numeric")]
        public decimal main_temp_min { get; set; }

        [Display(Name = "Max")]
        [Column(TypeName = "numeric")]
        public decimal main_temp_max { get; set; }

        [Display(Name = "Pressure")]
        [Column(TypeName = "numeric")]
        public decimal main_pressure { get; set; }

        [Display(Name = "Sea Lvl")]
        [Column(TypeName = "numeric")]
        public decimal main_sea_level { get; set; }

        [Display(Name = "Grnd Lvl")]
        [Column(TypeName = "numeric")]
        public decimal main_grnd_level { get; set; }

        [Display(Name = "Humidity")]
        public int main_humidity { get; set; }

        [Display(Name = "Temp kf")]
        [Column(TypeName = "numeric")]
        public decimal main_temp_kf { get; set; }

        public int weather_id { get; set; }

        [Display(Name = "Weather")]
        [Required]
        [StringLength(6)]
        public string weather_main { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(16)]
        public string weather_description { get; set; }

        [Required]
        [StringLength(3)]
        public string weather_icon { get; set; }

        [Display(Name = "Clouds")]
        public int clouds_all { get; set; }

        [Display(Name = "Wind Speed")]
        [Column(TypeName = "numeric")]
        public decimal wind_speed { get; set; }

        [Display(Name = "Wind Degree")]
        [Column(TypeName = "numeric")]
        public decimal wind_deg { get; set; }

        [Required]
        [StringLength(1)]
        public string syspod { get; set; }

        [Display(Name = "Date")]
        [Required]
        [StringLength(19)]
        public string dt_txt { get; set; }

        [Display(Name = "Snow")]
        [Column(TypeName = "numeric")]
        public decimal? snow_3h { get; set; }

        [Display(Name = "Rain")]
        [Column(TypeName = "numeric")]
        public decimal? rain_3h { get; set; }
    }
}
