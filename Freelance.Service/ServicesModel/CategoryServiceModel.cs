using System;


namespace Freelance.Service.ServicesModel
{
    public class CategoryServiceModel
    {
        public Guid Id { get; set; }
        public Guid? ImageId { get; set; }
        public string NameCategory { get; set; }
        public string DescriptionCategory { get; set; }
    }
}
