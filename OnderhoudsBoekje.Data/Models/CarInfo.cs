using System.ComponentModel.DataAnnotations;

namespace OnderhoudsBoekje.Data.Models
{
    public class CarInfo
    {
        /// <summary>
        /// The brand of the car.
        /// </summary>
        [MaxLength(50)]
        public string Brand { get; set; } = "";

        /// <summary>
        /// The model of the car.
        /// </summary>
        [MaxLength(50)]
        public string Model { get; set; } = "";

        /// <summary>
        /// The license plate of the car.
        /// </summary>
        [MaxLength(10)]
        public string LicensePlate { get; set; } = "";

        /// <summary>
        /// The date the car was built.
        /// </summary>
        public int? BuildYear{ get; set; }

        /// <summary>
        /// The cylinder capacity of the car.
        /// </summary>
        public int? CylinderCapacity { get; set; }

        /// <summary>
        /// The amount of cylinders the car has.
        /// </summary>
        public int? CylinderCount { get; set; }

        /// <summary>
        /// The type of fuel the car uses.
        /// </summary>
        public string FuelType { get; set; } = "";

        /// <summary>
        /// Engine code of the car.
        /// </summary>
        [MaxLength(20)]
        public string EngineCode { get; set; } = "";

        /// <summary>
        /// The color of the car.
        /// </summary>
        [MaxLength(20)]
        public string Color { get; set; } = "";

        /// <summary>
        /// The VIN of the car.
        /// </summary>
        [MaxLength(17)]
        public string Vin { get; set; } = "";

        /// <summary>
        /// The current mileage of the car.
        /// </summary>
        public uint Mileage { get; set; }
    }
}
