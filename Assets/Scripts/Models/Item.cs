namespace Assets.Scripts.Models
{
    [System.Serializable]
    public class Item
    {
        public string Name;
        public float Weight;

        public string PrefabName;

        public Item(string name, float weight)
        {
            Name = name;
            Weight = weight;
            PrefabName = "Assets/Prefabs/Sword";
        }

        public Item()
        {
            Name = "";
            Weight = 0f;
            PrefabName = "Assets/Prefabs/Sword";
        }
    }
}