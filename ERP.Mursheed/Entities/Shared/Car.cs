using System.Collections.Generic;

namespace Entities.Shared
{
    public class Car
    {
        public Car()
        {
            Drivers = new HashSet<Driver>();
            CarPhotos = new HashSet<CarPhoto>();
        }
        public int Id { get; set; }
        public int ModelId { get; set; }

        public Model Model { get; set; }
        public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<CarPhoto> CarPhotos { get; set; }
    }

    public class Brand
    {
        public Brand()
        {
            Models = new HashSet<Model>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }

    public class Model
    {
        public Model()
        {
            Cars = new HashSet<Car>();
        }
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }

        public Brand Brand { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }

    public class CarPhoto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }

        public virtual Car Car { get; set; }
    }

    
}
