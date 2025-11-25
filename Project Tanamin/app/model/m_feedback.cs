namespace Project_Tanamin.app.model
{
    public class Feedback
    {
        public int id_feedback { get; set; }
        public int? id_user { get; set; }
        public DateTime tanggal_feedback { get; set; }
        public string pertanyaan { get; set; }
        public string? respon { get; set; }
    }
}
