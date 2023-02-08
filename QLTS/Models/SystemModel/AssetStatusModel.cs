namespace QLTS.Models.SystemModel
{
    public class AssetStatusModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AssetStatusModel(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
    }
}