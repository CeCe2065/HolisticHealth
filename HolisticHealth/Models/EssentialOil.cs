namespace HolisticHealth.Models
{
    public class EssentialOil
    {
        public int EssentialOilID { get; set; }
        public string Description { get; set; }

        public int EssentialOilCategoryID { get; set; }
        public virtual EssentialOilCategory Type { get; set; }



    }
}