namespace Assets.Scripts.Classes
{
    public class Key
    {
        public int RoomNumber { get; set; }
        public string Label { get; set; } = null;

        public Key(int roomNumber, string label)
        {
            RoomNumber = roomNumber;
            if (string.IsNullOrEmpty(label))
            {
                Label = roomNumber.ToString();
            }
            else
            {
                Label = label;
            }
        }
    }
}